using System.Net;
using System.Net.Mail;

namespace FeriaVirtual.Infraestructure.Mailer {

    public class MailConfigurator {
        private readonly SmtpClient smtpClient;

        // Properties.
        public SmtpClient SMTP => smtpClient;

        // Constructor
        private MailConfigurator() {
            smtpClient= new SmtpClient();
            ConfigureSMTPClient();
        }

        // Named constructor
        public static MailConfigurator CreateConfigurator() {
            return new MailConfigurator();
        }

        private void ConfigureSMTPClient() {
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("maipogrande.fv@gmail.com","avaras08");
        }
    }
}