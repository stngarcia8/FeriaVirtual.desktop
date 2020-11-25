﻿using System.Text;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Mailer;


namespace FeriaVirtual.Data.Notifiers{

    public class EmailOrderDispatchNotifier{

        private readonly MailerClientSender sender;
        private OrderDispatch orderDispatch;


        private EmailOrderDispatchNotifier(){
            sender = MailerClientSender.CreateSender();
        }


        public static EmailOrderDispatchNotifier CreateNotifier(){
            return new EmailOrderDispatchNotifier();
        }


        public void Notify(OrderDispatch orderDispatch){
            this.orderDispatch = orderDispatch;
            GenerateBody();
            SendAnEmail();
        }


        private void SendAnEmail(){
            sender.Email = orderDispatch.CarrierEmail;
            sender.UserEmail = orderDispatch.CarrierName;
            sender.SendMail();
        }


        private void GenerateBody(){
            sender.Subject = "Nueva orden de despacho asignada.";
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
            sender.MessageBody = body.ToString();
        }

    }

}