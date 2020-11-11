using System.Net.Mail;
using System.Text;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailOrderDispatchConfigurator{

        private readonly OrderDispatch orderDispatch;
        private readonly MailTypeMessage typeMessage;

        // Properties.
        public MailMessage Message{ get; private set; }


        // constructor
        private MailOrderDispatchConfigurator(OrderDispatch orderDispatch, MailTypeMessage typeMessage){
            this.orderDispatch = orderDispatch;
            this.typeMessage = typeMessage;
            ConfigureMailHeader();
        }


        // Named Constructor.
        public static MailOrderDispatchConfigurator CreateMessage(OrderDispatch orderDispatch,
            MailTypeMessage typeMessage){
            return new MailOrderDispatchConfigurator(orderDispatch, typeMessage);
        }


        private void ConfigureMailHeader(){
            var addressTo = new MailAddress(orderDispatch.CarrierEmail, orderDispatch.CarrierName);
            var addressFrom = new MailAddress("maipogrande.fv@gmail.com", "Lucas Claudio Avalos Asathor");
            Message = new MailMessage(addressFrom, addressTo){
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
            if (typeMessage == MailTypeMessage.NewOrderDispatch) CreateBodyNewOrderDispatch();
        }


        private void CreateBodyNewOrderDispatch(){
            Message.Subject = "Nueva orden de despacho asignada.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{orderDispatch.CarrierName}</b></p>");
            body.Append(
                "<p>Según nuestros registros, usted se adjudicó el transporte de los productos que detallamos a continuación en la siguiente orden de despacho:</p>");
            body.Append($"Orden de despacho número: {orderDispatch.OrderId}<br>");
            body.Append($"Fecha de orden: {orderDispatch.DispatchDate}<br>");
            body.Append($"Cliente: {orderDispatch.ClientName}<br>");
            body.Append($"Empresa: {orderDispatch.CompanyName}<br>");
            body.Append($"Dirección de entrega: {orderDispatch.Destination}<br>");
            body.Append($"Teléfono: {orderDispatch.PhoneNumber}<br>");
            body.Append("<table>");
            body.Append("<theader>");
            body.Append("<th>Producto</th>");
            body.Append("<th>Cantidad</th>");
            body.Append("</theader>");
            body.Append("<tbody>");
            foreach (var p in orderDispatch.Products){
                body.Append("<tr>");
                body.Append($"<td>{p.Product}</td>");
                body.Append($"<td>{p.Quantity}(KG)</td>");
                body.Append("</tr>");
            }
            body.Append("</tbody>");
            body.Append("</table>");
            body.Append("<p>Saludos cordiales.</p><br><br> ");
            Message.Body = body.ToString();
        }

    }

}