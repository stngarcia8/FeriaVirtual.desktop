using System.Net.Mail;
using System.Text;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Infraestructure.Mailer {

    public class MailMessageConfigurator {

        private MailMessage mailMessage;
        private Client client;
        private readonly MailTypeMessage typeMessage;

        // Properties.
        public MailMessage Message => mailMessage;

        // constructor
        private MailMessageConfigurator(Client client,MailTypeMessage typeMessage) {
            this.client= client;
            this.typeMessage= typeMessage;
            this.ConfigureMailHeader();
        }

        // Named Constructor.
        public static MailMessageConfigurator CreateMessage(Client client,MailTypeMessage typeMessage) {
            return new MailMessageConfigurator( client,typeMessage );
        }


        private void ConfigureMailHeader() {
           MailAddress  addressTo = new MailAddress( client.Credentials.Email, client.ToString() );
            MailAddress addressFrom = new MailAddress( "maipogrande.fv@gmail.com","Lucas Claudio Avalos Asathor" );
            mailMessage = new MailMessage(addressFrom, addressTo);
            mailMessage.IsBodyHtml= true;
            mailMessage.Priority= MailPriority.High;
            if(typeMessage== MailTypeMessage.NewClient) {
                CreateBodyNewClient();
            }
        }

        private void CreateBodyNewClient() {
            mailMessage.Subject= "Solicitud de registro a Feria Virtual aceptada.";
            StringBuilder body = new StringBuilder();
            body.Append( string.Format( "<p>Estimado(a) Sr(a). <b>{0}</b></p>",client.ToString() ) );
            body.Append( "<p>Su solicitud de ingreso a nuestro sitio web www.feriavirtualmaipogrande.cl, ha sido aceptada.</p>" );
            body.Append( "<p>Para iniciar su sesión y comenzar a disfrutar las bondades que ofrecemos, favor dirigirse a nuestro sitio web e ingrese sus credenciales en la página de inicio de sesión correspondiente.</p>" );
            body.Append( "<p>Sus credenciales son:<br> " );
            body.Append( string.Format( "Nombre de usuario: <b>{0}</b><br>",client.Credentials.Username ) );
            body.Append( string.Format( "Contraseña: <b>{0}</b><br>",client.Credentials.Password ) );
            body.Append(string.Format("Rol aprobado: <b>{0}</b></p>", client.Profile.ProfileName));
            body.Append( "<p>Gracias por su preferencia, saludos cordiales.</p><br><br> " );
            mailMessage.Body= body.ToString();
        }













    }
}
