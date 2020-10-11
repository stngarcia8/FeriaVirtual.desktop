using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Infraestructure.Mailer {

    public class MailSender {
        private readonly MailTypeMessage typeMessage;
        private readonly Client client;

        // constructor
        private MailSender(Client client,MailTypeMessage typeMessage) {
            this.client=client;
            this.typeMessage= typeMessage;
        }

        // Named Constructor.
        public static MailSender CreateSender(Client client,MailTypeMessage typeMessage) {
            return new MailSender(client,typeMessage);
        }

        public void SendMail() {
            MailConfigurator configurator = MailConfigurator.CreateConfigurator();
            MailMessageConfigurator messageConfigurator = MailMessageConfigurator.CreateMessage(client,typeMessage);
            configurator.SMTP.SendMailAsync(messageConfigurator.Message);
        }
    }
}