using System.Text;
using FeriaVirtual.Domain.Dto;
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


        public void Notify(SalesDto salesDto){
            CreateBodyNotifyPayment(salesDto);
            SendAnEmail(salesDto.ProducerEmail, salesDto.ProducerName);
        }


        private void SendAnEmail(string email, string username){
            this.email.EmailTo = email;
            this.email.UserTo = username;
            SendTheEmailToQueue();
        }


        private void CreateBodyNewPayment(Payment payment, PaymentContactMethod contactMethod){
            email.Subject = "Su pago fue realizado correctamente.";
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
            email.Body = body.ToString();
        }


        private void CreateBodyNotifyPayment(SalesDto result){
            float totalSales = 0;
            email.Subject = "Notificación de venta de productos.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) {result.ProducerName}:</p>");
            body.Append(
                "<p>Se ha realizado una venta, en la cual, hay productos de su pertenencia involucrados, el detalle lo puede encontrar en nuestro sitio web, el resumen es el siguiente:</p>");

            body.Append("<table>");
            body.Append(
                "<thead><th>Fecha</th><th>Producto</th><th>Cantidad</th><th>Precio unitario</th><th>Total</th></thead>");
            body.Append("<tbody>");
            foreach (var p in result.Products){
                body.Append("<tr>");
                body.Append($"<td>{result.SalesDate.ToShortDateString()}</td>");
                body.Append($"<td>{p.ProductName}</td>");
                body.Append($"<td>{p.Quantity}</td>");
                body.Append($"<td>${p.UnitPrice}</td>");
                body.Append($"<td>${p.ProductPrice}</td>");
                body.Append("</tr>");
                totalSales += p.ProductPrice;
            }
            body.Append("</tbody>");
            body.Append("</table>");
            body.Append(
                $"<p>El valor de la venta (${totalSales}), será agregado a su cuenta, en el momento que nuestro cliente haga efectivo el pago del servicio, su estado de cuenta será actualizado, puede revisar sus ventas  en la página web, en el apartado historial de ventas, en caso de dudas o consultas, no olvide indicarlas por nuestros medios oficiales o puede también comunicarse con su ejecutivo.</p>");
            body.Append("<p>Muchas gracias por su atención, hasta pronto.</p>");
            email.Body = body.ToString();
        }

    }

}