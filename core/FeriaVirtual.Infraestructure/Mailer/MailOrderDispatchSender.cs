using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailOrderDispatchSender{

        private readonly OrderDispatch orderDispatch;
        private readonly MailTypeMessage typeMessage;


        // constructor
        private MailOrderDispatchSender(OrderDispatch orderDispatch, MailTypeMessage typeMessage){
            this.orderDispatch = orderDispatch;
            this.typeMessage = typeMessage;
        }


        // Named Constructor.
        public static MailOrderDispatchSender CreateSender(OrderDispatch orderDispatch, MailTypeMessage typeMessage){
            return new MailOrderDispatchSender(orderDispatch, typeMessage);
        }


        public void SendMail(){
            var configurator = MailConfigurator.CreateConfigurator();
            var messageConfigurator = MailOrderDispatchConfigurator.CreateMessage(orderDispatch, typeMessage);
            configurator.Smtp.SendMailAsync(messageConfigurator.Message);
        }

    }

}