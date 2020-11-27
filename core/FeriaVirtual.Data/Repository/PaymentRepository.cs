using System;
using FeriaVirtual.Data.Notifiers;
using System.Data;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Data.Repository {

    
    public class PaymentRepository: Repository {

        private readonly EmailPaymentNotifier emailNotifier;
      private readonly IQueueNotifier queueNotifier;

        private PaymentRepository(){
            this.emailNotifier = EmailPaymentNotifier.CreateNotifier();
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
            // this.emailNotifier.Notify(payment,GetCustomerContactsMethod(payment.PaymentId));
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
            return ExtractContactMethodFromDataTable( querySelect.ExecuteQuery());
        }


        private PaymentContactMethod ExtractContactMethodFromDataTable(DataTable data){
            PaymentContactMethod pcm = PaymentContactMethod.Create();
            if(data.Rows.Count.Equals(0)) return pcm;
            DataRow row = data.Rows[0];
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
            queueNotifier.Notify("Payment", "ProductsPayment", ConvertPaymentResultInDto(result));
            this.emailNotifier.Notify(result);
        }


        private PaymentResultDto ConvertPaymentResultInDto(PaymentResult result){
            PaymentResultDto dto = new PaymentResultDto();
            dto.PaymentId = result.PaymentId;
            dto.ClientId = result.ClientId;
            dto.SalesDate = result.SalesDate.ToString("yyyy-MM-dd");
            dto.Quantity = result.Quantity;
            dto.ProductName = result.ProductName;
            dto.UnitPrice = result.UnitPrice;
            dto.ProductPrice = result.ProductPrice;
            return dto;
        }








    }
}
