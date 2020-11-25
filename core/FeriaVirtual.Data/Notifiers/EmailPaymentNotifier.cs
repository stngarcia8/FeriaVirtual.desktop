using System.Text;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Mailer;


namespace FeriaVirtual.Data.Notifiers{

    public class EmailPaymentNotifier{

        private PaymentContactMethod contactMethod;
        private Payment payment;
        private readonly MailerClientSender sender;


        private EmailPaymentNotifier(){
            sender = MailerClientSender.CreateSender();
        }


        public static EmailPaymentNotifier CreateNotifier(){
            return new EmailPaymentNotifier();
        }


        public void Notify(Payment payment, PaymentContactMethod contactMethod){
            this.payment = payment;
            this.contactMethod = contactMethod;
            GenerateBody();
            SendAnEmail();
        }


        private void SendAnEmail(){
            sender.Email = contactMethod.CustomerEmail;
            sender.UserEmail = contactMethod.CustomerName;
            sender.SendMail();
        }


        private void GenerateBody(){
            sender.Subject= "Su pago fue realizado correctamente.";
            var body = new StringBuilder();
            body.Append($"Estimado(a) {contactMethod.CustomerName}:<br>");
            body.Append(
                "Usted ha registrado un pago en nuestro <a href='http://maipogrande-fv.duckdns.org:8081'>sitio web</a>, para visualizar la información completa de este pago, favor dirigirse a la sección historial de pagos, en este apartado se encuentra disponible toda la información sobre sus transacciones.<br><br>");
            body.Append("El resumen de su transacción es el siguiente:<br>");
            body.Append($"Pago: {payment.PaymentId}<br>");
            body.Append($"Fecha de pago: {payment.PaymentDate.ToShortDateString()}<br>");
            body.Append($"Monto  cancelado: ${payment.Amount}<br>");
            body.Append($"Observación: {payment.Observation}<br>");
            body.Append($"Metodo de pago: {payment.PaymentMethod.MethodDescription}<br><br><br>");
            body.Append("Gracias por su preferencia.");
            sender.MessageBody= body.ToString();
        }

    }

}