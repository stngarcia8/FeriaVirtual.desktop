using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FeriaVirtual.Data.Notifiers;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository{

    public class OrderRepository : Repository{

        private readonly IQueueNotifier notifier;

        public Order Order{ get; }


        private OrderRepository(){
            Order = Order.CreateOrder();
            notifier = QueueNotifier.CreateNotifier();
        }


        public static OrderRepository OpenRepository(){
            return new OrderRepository();
        }


        public void GetOrderByStatus(int statusId, int rolId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerPedidoToApi where id_estado=:pIdEstado and id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdEstado", statusId, DbType.Int32);
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }


        public DataTable GetOrderDetailById(string orderId){
            Sql.Clear();
            Sql.Append("select * from fv_user.detalle_pedido where id_pedido=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", orderId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            return DataSource;
        }


        public void GenerateProposeProduct(string orderId){
            var queryAction = DefineQueryAction("spGenerarPropuestaProductos  ");
            queryAction.AddParameter("idped", orderId, DbType.String);
            queryAction.ExecuteQuery();
        }


        public void GetProposeProduct(string orderId){
            Sql.Clear();
            Sql.Append("select * from vwObtenerResultadoPropuesta where id_pedido=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", orderId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }


        public OrderResult GetResultsFromPropose(string orderId){
            Sql.Clear();
            Sql.Append("select * from fv_user.pie_pedido where id_pedido=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", orderId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            return ExtractResultFromDataTable(DataTable);
        }


        private OrderResult ExtractResultFromDataTable(DataTable data){
            var results = OrderResult.CreateResults();
            if (data.Rows.Count.Equals(0)) return results;

            var row = data.Rows[0];
            results.OrderId = row["id_pedido"].ToString();
            results.NetValue = float.Parse(row["valor_neto"].ToString());
            results.Iva = float.Parse(row["valor_iva"].ToString());
            results.TotalValue = float.Parse(row["valor_total"].ToString());
            results.DiscountValue = float.Parse(row["valor_descuento"].ToString());
            results.Amount = float.Parse(row["valor_total_descuento"].ToString());
            return results;
        }


        public void NewOrder(Order order, string clientId){
            var query = DefineQueryAction("spAgregarPedido ");
            query.AddParameter("pIdCliente", clientId, DbType.String);
            query = DefineParameters(order, query);
            query.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
            OrderDetailSave(order);
        }


        public void EditOrder(Order order, string clientId){
            var query = DefineQueryAction("spActualizarPedido ");
            query = DefineParameters(order, query);
            query.ExecuteQuery();
            OrderDetailSave(order);
        }


        private IQueryAction DefineParameters(Order order, IQueryAction query){
            query.AddParameter("pIdPedido", order.OrderId, DbType.String);
            query.AddParameter("pIdCondicion", order.Condition.ConditionId, DbType.Int32);
            query.AddParameter("pDescuento", order.OrderDiscount, DbType.Double);
            query.AddParameter("pObservacion", order.Observation, DbType.String);
            return query;
        }


        private void OrderDetailSave(Order order){
            foreach (var d in order.OrderDetailList){
                var queryDetail = DefineQueryAction("spAgregarDetallePedido ");
                queryDetail.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
                queryDetail.AddParameter("pIdPedido", order.OrderId, DbType.String);
                queryDetail.AddParameter("pProducto", d.ProductName, DbType.String);
                queryDetail.AddParameter("pCantidad", d.Quantity, DbType.Double);
                queryDetail.ExecuteQuery();
            }
        }


        public void DeleteOrder(string orderId){
            var query = DefineQueryAction("spEliminarPedido ");
            query.AddParameter("pIdPedido", orderId, DbType.String);
            query.ExecuteQuery();
        }


        public void RefuseOrder(OrderRefuse orderRefused){
            var query = DefineQueryAction("spRechazarPedido");
            query.AddParameter("pIdCierre", orderRefused.RefuseId, DbType.String);
            query.AddParameter("pIdPedido", orderRefused.OrderId, DbType.String);
            query.AddParameter("pTipo", orderRefused.RefuseType, DbType.Int32);
            query.AddParameter("pObservacion", orderRefused.Observation, DbType.String);
            query.ExecuteQuery();
        }


        public IList<OrderDto> PublishOrdersToApi(int statusId, string customerId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerPedidoToApi where id_cliente=:pId and id_estado=:pIdEstado ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", customerId, DbType.String);
            querySelect.AddParameter("pIdEstado", statusId, DbType.Int32);
            return GetOrderDataToPublish(querySelect.ExecuteQuery());
        }


        private IList<OrderDto> GetOrderDataToPublish(DataTable data){
            return data.Rows.Count.Equals(0)
                ? null
                : (from DataRow row in data.Rows select GetOrderDataFromDataRow(row)).ToList();
        }


        private OrderDto GetOrderDataFromDataRow(DataRow row){
            var o = new OrderDto{
                OrderId = row["id_pedido"].ToString(),
                ClientId = row["id_cliente"].ToString(),
                Condition = {
                    ConditionId = int.Parse(row["id_condicion"].ToString()),
                    ConditionDescription = row["Condicion pago"].ToString()
                },
                OrderDate = DateTime.Parse(row["Fecha orden"].ToString()).ToString("YYYY/MM/dd"),
                OrderDiscount = float.Parse(row["Descuento"].ToString()),
                Observation = row["Observación"].ToString()
            };
            o.OrderDetailList = SearchDetailsFromOrder(o.OrderId);
            return o;
        }


        public IList<OrderDetail> SearchDetailsFromOrder(string orderId){
            Sql.Clear();
            Sql.Append("select * from fv_user.detalle_pedido where id_pedido=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", orderId, DbType.String);
            return GetOrderDetailDataToOrder(querySelect.ExecuteQuery());
        }


        public IList<OrderDetail> GetOrderDetailDataToOrder(DataTable dataDetail){
            IList<OrderDetail> detailList = new List<OrderDetail>();
            if (dataDetail.Rows.Count.Equals(0)) return detailList;

            foreach (DataRow r in dataDetail.Rows) detailList.Add(GetDetailDataFromRow(r));

            return detailList;
        }


        private OrderDetail GetDetailDataFromRow(DataRow r){
            var d = OrderDetail.CreateDetail();
            d.OrderDetailId = r["id"].ToString();
            d.OrderId = r["id_pedido"].ToString();
            d.ProductName = r["nombre_producto"].ToString();
            d.Quantity = float.Parse(r["cantidad"].ToString());
            return d;
        }


        public void AceptProposeProducts(string orderId){
            var query = DefineQueryAction("spAceptarPropuestaProductos ");
            query.AddParameter("pIdPedido", orderId, DbType.String);
            query.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
            notifier.Notify("Order", "ProductsProposed", GetResultsFromPropose(orderId));
        }

    }

}