using System;
using FeriaVirtual.Data.Notifiers;
using FeriaVirtual.Infraestructure.Queues;
using FeriaVirtual.Domain.Dto;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using FeriaVirtual.Data.Exceptions;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Mailer;


namespace FeriaVirtual.Data.Repository{

    public class OrderDispatchRepository : Repository{

        private IQueueNotifier queueNotifier;
        private EmailOrderDispatchNotifier emailNotifier;


        private OrderDispatchRepository(){
            this.queueNotifier = QueueNotifier.CreateNotifier();
            emailNotifier = EmailOrderDispatchNotifier.CreateNotifier();
        }


        public static OrderDispatchRepository OpenRepository(){
            return new OrderDispatchRepository();
        }


        public void NewOrderDispatch(OrderDispatch orderDispatch){
            var query = DefineQueryAction("spAgregarOrdenDespacho ");
            query.AddParameter("pIdOrden", orderDispatch.DispatchId, DbType.String);
            query.AddParameter("pIdPedido", orderDispatch.OrderId, DbType.String);
            query.AddParameter("pFechaRetiro", DateTime.Parse(orderDispatch.DispatchDate), DbType.Date);
            query.AddParameter("pObservacion", orderDispatch.Observation, DbType.String);
            query.AddParameter("pIdCliente", orderDispatch.ClientId, DbType.String);
            query.AddParameter("pIdSeguro", orderDispatch.Safe.SafeId, DbType.Int32);
            query.AddParameter("pCosto", orderDispatch.DispatchValue, DbType.Double);
            query.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
            OrderDispatchDetailSave(orderDispatch);
             SendNotificationMail(orderDispatch);
            this.queueNotifier.Notify("Order", "ChangeStatus", ChangeMessageStatus.Create(orderDispatch.OrderId, 5) );
        }


        private void OrderDispatchDetailSave(OrderDispatch orderDispatch){
            foreach (var p in orderDispatch.Products){
                var queryDetail = DefineQueryAction("spAgregarDetalleDespacho ");
                queryDetail.AddParameter("pId", p.DetailId, DbType.String);
                queryDetail.AddParameter("pIdOrden", orderDispatch.DispatchId, DbType.String);
                queryDetail.AddParameter("pProducto", p.Product, DbType.String);
                queryDetail.AddParameter("pValor", p.UnitValue, DbType.Double);
                queryDetail.AddParameter("pCantidad", p.Quantity, DbType.Double);
                queryDetail.AddParameter("pTotal", p.TotalValue, DbType.Double);
                queryDetail.ExecuteQuery();
            }
        }


        private void SendNotificationMail(OrderDispatch orderDispatch){
            if (string.IsNullOrEmpty(orderDispatch.CarrierEmail)){
                var message =
                    $"El transportista {orderDispatch.CarrierName} no tiene configurada su cuenta de correo electrónico, por lo tanto no fue posible notificar por este medio la orden de despacho, de igual manera esta quedo asignada en su perfil de usuario.";
                throw new InvalidEmailException(message);
            }
            this.emailNotifier.Notify(orderDispatch);
            }


        public void AcceptOrderDispatch(string orderId, string observation){
            var query = DefineQueryAction("spAceptarRechazarDespacho  ");
            query.AddParameter("pIdOrden", orderId, DbType.String);
            query.AddParameter("pEstado", 6, DbType.Int32);
            query.AddParameter("pObservacion", observation, DbType.String);
            query.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
        }


        public void RefuseOrderDispatch(string orderId, string observation){
            var query = DefineQueryAction("spAceptarRechazarDespacho  ");
            query.AddParameter("pIdOrden", orderId, DbType.String);
            query.AddParameter("pEstado", 9, DbType.Int32);
            query.AddParameter("pObservacion", observation, DbType.String);
            query.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
        }


        public OrderDispatch FindOrderDispatchById(string orderId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwOrdenDespacho where id_pedido=:pIdPedido ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdPedido", orderId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            return DataTable.Rows.Count.Equals(0) ? null : GetOrderDispatchDataFromDataRow(DataTable.Rows[0]);
        }


        public IList<OrderDispatch> FinAllOrderDispatch(string carrierId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwOrdenDespacho where id_transportista=:pIdTransportista ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdTransportista", carrierId, DbType.String);
            return GetAllAvailableOrderDispatch(querySelect.ExecuteQuery());
        }


        private IList<OrderDispatch> GetAllAvailableOrderDispatch(DataTable data){
            return data.Rows.Count.Equals(0)
                ? null
                : (from DataRow row in data.Rows select GetOrderDispatchDataFromDataRow(row)).ToList();
        }


        private OrderDispatch GetOrderDispatchDataFromDataRow(DataRow row){
            var od = OrderDispatch.CreateOrder();
            od.DispatchId = row["id_orden"].ToString();
            od.OrderId = row["id_pedido"].ToString();
            od.ClientId = row["id_cliente"].ToString();
            od.DispatchDate = DateTime.Parse(row["fecha_preparacion"].ToString()).ToString("yyyy-MM-dd");
            od.CarrierId = row["id_transportista"].ToString();
            od.DispatchValue = float.Parse(row["valor_propuesto"].ToString());
            od.DispatchWeight = float.Parse(row["peso_comprometido"].ToString());
            od.Observation = row["observacion_subasta"].ToString();
            od.CompanyName = row["rsocial_comercial"].ToString();
            od.Destination = row["dir"].ToString();
            od.PhoneNumber = row["fono"].ToString();
            od.Status = int.Parse(row["estado_pedido"].ToString());
            od.Safe.SafeId = int.Parse(row["id_seguro"].ToString());
            od.Safe.SafeName = row["Seguro"].ToString();
            od.Safe.SafeCompany = row["Aseguradora"].ToString();
            od.Safe.SafeValue = float.Parse(row["Prima"].ToString());
            od.Products = SearchDetailForOrderDispatch(od.DispatchId);
            return od;
        }


        public IList<OrderDispatchDetail> SearchDetailForOrderDispatch(string dispatchId){
            Sql.Clear();
            Sql.Append("select * from fv_user.orden_detalle where id_orden=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", dispatchId, DbType.String);
            return GetOrderDispatchDetailDataToOrder(querySelect.ExecuteQuery());
        }


        private IList<OrderDispatchDetail> GetOrderDispatchDetailDataToOrder(DataTable dataDetail){
            IList<OrderDispatchDetail> detailList = new List<OrderDispatchDetail>();
            if (dataDetail.Rows.Count.Equals(0)) return detailList;

            foreach (DataRow r in dataDetail.Rows) detailList.Add(GetDetailDispatchDataFromRow(r));

            return detailList;
        }


        private OrderDispatchDetail GetDetailDispatchDataFromRow(DataRow r){
            var odd = OrderDispatchDetail.CreateDetail();
            odd.Product = r["producto"].ToString();
            odd.UnitValue = float.Parse(r["valor"].ToString());
            odd.Quantity = float.Parse(r["cantidad"].ToString());
            odd.TotalValue = float.Parse(r["total"].ToString());
            return odd;
        }

    }

}