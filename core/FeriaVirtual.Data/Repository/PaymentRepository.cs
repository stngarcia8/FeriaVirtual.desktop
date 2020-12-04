using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Data.Notifiers;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Data.Repository{

    public class PaymentRepository : Repository{

        private readonly EmailPaymentNotifier emailNotifier;
        private readonly IQueueNotifier queueNotifier;


        private PaymentRepository(){
            emailNotifier = EmailPaymentNotifier.CreateNotifier();
            queueNotifier = QueueNotifier.CreateNotifier();
        }


        public static PaymentRepository OpenRepository(){
            return new PaymentRepository();
        }


        public void NewPayment(Payment payment){
            var query = DefineQueryAction("spRegistrarPago ");
            query.AddParameter("pIdPago", payment.PaymentId, DbType.String);
            query.AddParameter("pIdMetodoPago", payment.PaymentMethod.MethodId, DbType.Int32);
            query.AddParameter("pIdPedido", payment.OrderId, DbType.String);
            query.AddParameter("pMonto", payment.Amount, DbType.Double);
            query.AddParameter("pObsPago", payment.Observation, DbType.String);
            query.ExecuteQuery();
            emailNotifier.Notify(payment, GetCustomerContactsMethod(payment.PaymentId));
        }


        public void GetPaymentByStatus(int statusId, int rolId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerPagos where pago_notificado=:pIdEstado and id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdEstado", statusId, DbType.Int32);
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }


        public void GetPaymentById(string paymentId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerPagos where id_pago=:pIdPago ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdPago", paymentId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }


        public void GetProducerIntoPayment(string orderId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwInvolucradosPago where id_pedido=:pIdPedido ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdPedido", orderId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }


        public PaymentContactMethod GetCustomerContactsMethod(string paymentId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwBuscarMailCliente where id_pago=:pIdPago  ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdPago", paymentId, DbType.String);
            return ExtractContactMethodFromDataTable(querySelect.ExecuteQuery());
        }


        private PaymentContactMethod ExtractContactMethodFromDataTable(DataTable data){
            var pcm = PaymentContactMethod.Create();
            if (data.Rows.Count.Equals(0)) return pcm;

            var row = data.Rows[0];
            pcm.CustomerName = row["Cliente"].ToString();
            pcm.CustomerEmail = row["email"].ToString();
            return pcm;
        }


        public void NewNotificationPayment(PaymentResult result){
            var query = DefineQueryAction("spNotificarPago ");
            query.AddParameter("pIdNotificacion", result.PaymentResultId, DbType.String);
            query.AddParameter("pIdPago", result.PaymentId, DbType.String);
            query.AddParameter("pIdCliente", result.ClientId, DbType.String);
            query.AddParameter("pFecha", result.SalesDate, DbType.Date);
            query.AddParameter("pCantidad", result.Quantity, DbType.Double);
            query.AddParameter("pProducto", result.ProductName, DbType.String);
            query.AddParameter("pUnitario", result.UnitPrice, DbType.Double);
            query.AddParameter("pTotal", result.ProductPrice, DbType.Double);
            query.ExecuteQuery();
            queueNotifier.Notify("maipogrande", "Payment", "ProductsPayment", ConvertPaymentResultInDto(result));
            //this.emailNotifier.Notify(result);
        }


        private PaymentResultDto ConvertPaymentResultInDto(PaymentResult result){
            var dto = new PaymentResultDto{
                PaymentId = result.PaymentId,
                ClientId = result.ClientId,
                SalesDate = result.SalesDate.ToString("yyyy-MM-dd"),
                Quantity = result.Quantity,
                ProductName = result.ProductName,
                UnitPrice = result.UnitPrice,
                ProductPrice = result.ProductPrice
            };
            return dto;
        }


        public void NotifySalesByEmail(IList<PaymentResult> results){
            var clientId = string.Empty;
            var paymentId = string.Empty;
            foreach (var r in results)
                if (!clientId.Equals(r.ClientId)){
                    clientId = r.ClientId;
                    paymentId = r.PaymentId;
                    var salesDto = new SalesDto{
                        ProducerName = r.ProducerName,
                        ProducerEmail = r.ProducerEmail,
                        SalesDate = r.SalesDate,
                        Products = GetSalesProductoFromResultsList(clientId, results)
                    };
                    emailNotifier.Notify(salesDto);
                }
        }


        private IList<SalesProductDto> GetSalesProductoFromResultsList(string clientId,
            IEnumerable<PaymentResult> results){
            IList<SalesProductDto> productList = new List<SalesProductDto>();
            foreach (var r in results)
                if (clientId.Equals(r.ClientId)){
                    var p = new SalesProductDto{
                        ProductName = r.ProductName,
                        Quantity = r.Quantity,
                        UnitPrice = r.UnitPrice,
                        ProductPrice = r.ProductPrice
                    };
                    productList.Add(p);
                }
            return productList;
        }

    }

}