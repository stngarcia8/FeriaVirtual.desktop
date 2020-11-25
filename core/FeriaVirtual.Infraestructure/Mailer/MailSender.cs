using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailSender{

        private readonly Client client;
        private readonly MailTypeMessage typeMessage;


        private MailSender(Client client, MailTypeMessage typeMessage){
            this.client = client;
            this.typeMessage = typeMessage;
        }


        public static MailSender CreateSender(Client client, MailTypeMessage typeMessage){
            return new MailSender(client, typeMessage);
        }


        public void SendMail(){
            var configurator = MailConfigurator.CreateConfigurator();
            var messageConfigurator = MailMessageConfigurator.CreateMessage(client, typeMessage);
            configurator.Smtp.SendMailAsync(messageConfigurator.Message);
        }

    }

}