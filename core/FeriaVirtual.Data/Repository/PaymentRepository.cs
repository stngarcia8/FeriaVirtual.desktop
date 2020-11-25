using System;
using FeriaVirtual.Data.Notifiers;
using System.Data;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Data.Repository {

    
    public class PaymentRepository: Repository {

        private EmailPaymentNotifier notifier;


        private PaymentRepository(){
            this.notifier = EmailPaymentNotifier.CreateNotifier();
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
            this.notifier.Notify(payment,GetCustomerContactsMethod(payment.PaymentId) );
        }






        public void GetPaymentByStatus(int statusId, int rolId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerPagos where pago_notificado=:pIdEstado and id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdEstado", statusId, DbType.Int32);
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
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




    }
}
