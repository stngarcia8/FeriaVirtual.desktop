using System.Text;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Data.Notifiers{

    public class EmailPaymentNotifier : EmailNotifier{

        private EmailPaymentNotifier(){ }


        public static EmailPaymentNotifier CreateNotifier(){
            return new EmailPaymentNotifier();
        }


        public void Notify(Payment payment, PaymentContactMethod contactMethod){
            CreateBodyNewPayment(payment, contactMethod);
            SendAnEmail(contactMethod.CustomerEmail, contactMethod.CustomerName);
        }


        public void Notify(PaymentResult paymentResult){
            CreateBodyNotifyPayment(paymentResult);
            SendAnEmail(paymentResult.ProducerEmail, paymentResult.ProducerName);
        }


        private void SendAnEmail(string email, string username){
            sender.Email = email;
            sender.UserEmail = username;
            SendTheEmail();
            //DisposeNotifier();
        }


        private void CreateBodyNewPayment(Payment payment, PaymentContactMethod contactMethod){
            sender.Subject = "Su pago fue realizado correctamente.";
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
            sender.MessageBody = body.ToString();
        }


        private void CreateBodyNotifyPayment(PaymentResult result){
            sender.Subject = "Notificación de venta de productos.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) {result.ProducerName}:</p>");
            body.Append(
                "<p>Se ha realizado una venta, en la cual, hay productos de su pertenencia involucrados, el detalle lo puede encontrar en nuestro sitio web, el resumen es el siguiente:</p>");
            body.Append("<table>");
            body.Append(
                $"<tr><td>Fecha de venta</td><td>{result.SalesDate.ToShortDateString()}</td></tr>");
            body.Append($"<tr><td>Producto</td><td>{result.ProductName}</td></tr>");
            body.Append($"<tr><td>Cantidad vendida</td><td>{result.Quantity}</td></tr>");
            body.Append($"<tr><td>Precio unitario</td><td>${result.UnitPrice}</td></tr>");
            body.Append($"<tr><td>Total a pagar</td><td>${result.ProductPrice}</td></tr>");
            body.Append("</table>");
            
            body.Append(
                $"<p>El valor de la venta (${result.ProductPrice}), será agregado a su cuenta, en el momento que nuestro cliente haga efectivo el pago del servicio, su estado de cuenta será actualizado, puede revisar sus ventas  en la página web, en el apartado historial de ventas, en caso de dudas o consultas, no olvide indicarlas por nuestros medios oficiales o puede también comunicarse con su ejecutivo.</p>");
            body.Append("<p>Muchas gracias por su atención, hasta pronto.</p>");
            sender.MessageBody = body.ToString();
        }

    }

}