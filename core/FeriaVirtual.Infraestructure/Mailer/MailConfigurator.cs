using System.Net;
using System.Net.Mail;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailConfigurator{

        public SmtpClient Smtp{ get; }


        private MailConfigurator(){
            Smtp = new SmtpClient();
            ConfigureSmtpClient();
        }


        public static MailConfigurator CreateConfigurator(){
            return new MailConfigurator();
        }


        private void ConfigureSmtpClient(){
            Smtp.Host = "smtp.gmail.com";
            Smtp.Port = 587;
            Smtp.EnableSsl = true;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.UseDefaultCredentials = false;
            Smtp.Credentials = new NetworkCredential("maipogrande.fv@gmail.com", "avaras08");
        }

    }

}