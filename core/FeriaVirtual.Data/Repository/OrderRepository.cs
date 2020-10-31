using System;
using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class OrderRepository:Repository {
        private readonly Order order;

        // properties
        public Order Order => order;

        // Constructor
        private OrderRepository() : base() {
            order = Order.CreateOrder();
        }

        // Named constructor
        public static OrderRepository OpenRepository() {
            return new OrderRepository();
        }

        public void GetOrderByStatus(int statusID, int rolID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerPedidoToApi where id_estado=:pIdEstado and id_rol=:pIdRol ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdEstado",statusID,DbType.Int32);
            querySelect.AddParameter("pIdRol",rolID,DbType.Int32);
            dataTable= querySelect.ExecuteQuery();
        }

        public DataTable GetOrderDetailById(string orderID) {
            sql.Clear();
            sql.Append("select * from fv_user.detalle_pedido where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            return DataSource;
        }

        public void GenerateProposeProduct(string orderID) {
            try {
            IQueryAction queryAction = DefineQueryAction("spGenerarPropuestaProductos  ");
            queryAction.AddParameter("idped",orderID,DbType.String);
            queryAction.ExecuteQuery();
            } catch (Exception ex) {
                throw ex;
            }
            }

        public void GetProposeProduct(string orderID) {
            sql.Clear();
            sql.Append("select * from vwObtenerResultadoPropuesta where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            dataTable= querySelect.ExecuteQuery();
        }

        public void NewOrder(Order order,string clientID) {
            IQueryAction query = DefineQueryAction("spAgregarPedido ");
            query.AddParameter("pIdCliente",clientID,DbType.String);
            query = DefineParameters(order,query);
            query.AddParameter("pGuid",Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
            OrderDetailSave(order);
        }

        public void EditOrder(Order order,string clientID) {
            IQueryAction query = DefineQueryAction("spActualizarPedido ");
            query = DefineParameters(order,query);
            query.ExecuteQuery();
            OrderDetailSave(order);
        }

        private IQueryAction DefineParameters(Order order,IQueryAction query) {
            query.AddParameter("pIdPedido",order.OrderID,DbType.String);
            query.AddParameter("pIdCondicion",order.Condition.ConditionID,DbType.Int32);
            query.AddParameter("pDescuento",order.OrderDiscount,DbType.Double);
            query.AddParameter("pObservacion",order.Observation,DbType.String);
            return query;
        }

        private void OrderDetailSave(Order order) {
            foreach(OrderDetail d in order.OrderDetailList) {
                IQueryAction queryDetail = DefineQueryAction("spAgregarDetallePedido ");
                queryDetail.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
                queryDetail.AddParameter("pIdPedido",order.OrderID,DbType.String);
                queryDetail.AddParameter("pProducto",d.ProductName,DbType.String);
                queryDetail.AddParameter("pCantidad",d.Quantity,DbType.Double);
                queryDetail.ExecuteQuery();
            }
        }

        public void DeleteOrder(string orderID) {
            IQueryAction query = DefineQueryAction("spEliminarPedido ");
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query.ExecuteQuery();
        }

        public IList<OrderDto> PublishOrdersToApi(int statusID, string customerID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerPedidoToApi where id_cliente=:pId and id_estado=:pIdEstado ");
                IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
                querySelect.AddParameter("pId",customerID, DbType.String);
            querySelect.AddParameter("pIdEstado",statusID,DbType.Int32);
            return GetOrderDataToPublish(querySelect.ExecuteQuery());
        }

        private IList<OrderDto> GetOrderDataToPublish(DataTable data) {
            if(data.Rows.Count.Equals(0)) {
                return null;
            }
            IList<OrderDto> orderList = new List<OrderDto>();
            foreach(DataRow row in data.Rows) {
                orderList.Add(GetOrderDataFromDataRow(row));
            }
            return orderList;
        }

        private OrderDto GetOrderDataFromDataRow(DataRow row) {
            OrderDto o = new OrderDto();
            o.OrderID = row["id_pedido"].ToString();
            o.ClientID= row["id_cliente"].ToString();
            o.Condition.ConditionID = int.Parse(row["id_condicion"].ToString());
            o.Condition.ConditionDescription= row["Condicion pago"].ToString();
            o.OrderDate= DateTime.Parse(row["Fecha orden"].ToString()).ToString("YYYY/MM/dd");
            o.OrderDiscount = float.Parse(row["Descuento"].ToString());
            o.Observation = row["Observación"].ToString();
            o.OrderDetailList = SearchDetailsFromOrder(o.OrderID);
            return o;
        }

        public IList<OrderDetail> SearchDetailsFromOrder(string orderID) {
            sql.Clear();
            sql.Append("select * from fv_user.detalle_pedido where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            return GetOrderDetailDataToOrder(querySelect.ExecuteQuery());
        }

        public IList<OrderDetail> GetOrderDetailDataToOrder(DataTable dataDetail) {
            IList<OrderDetail> detailList = new List<OrderDetail>();
            if(dataDetail.Rows.Count.Equals(0)) {
                return detailList;
            }
            foreach(DataRow r in dataDetail.Rows) {
                detailList.Add(GetDetailDataFromRow(r));
            }
            return detailList;
        }

        private OrderDetail GetDetailDataFromRow(DataRow r) {
            OrderDetail d = OrderDetail.CreateDetail();
            d.OrderDetailID = r["id"].ToString();
            d.OrderID = r["id_pedido"].ToString();
            d.ProductName = r["nombre_producto"].ToString();
            d.Quantity = float.Parse(r["cantidad"].ToString());
            return d;
        }

        public void AceptProposeProducts(string orderID) {
            IQueryAction query = DefineQueryAction("spAceptarPropuestaProductos ");
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
            query.ExecuteQuery();
        }


    }
}