using System.Net.Mail;
using System.Text;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailMessageConfigurator{

        private readonly Client client;
        private readonly MailTypeMessage typeMessage;

        // Properties.
        public MailMessage Message{ get; private set; }


        // constructor
        private MailMessageConfigurator(Client client, MailTypeMessage typeMessage){
            this.client = client;
            this.typeMessage = typeMessage;
            ConfigureMailHeader();
        }


        // Named Constructor.
        public static MailMessageConfigurator CreateMessage(Client client, MailTypeMessage typeMessage){
            return new MailMessageConfigurator(client, typeMessage);
        }


        private void ConfigureMailHeader(){
            var addressTo = new MailAddress(client.Credentials.Email, client.ToString());
            var addressFrom = new MailAddress("maipogrande.fv@gmail.com", "Lucas Claudio Avalos Asathor");
            Message = new MailMessage(addressFrom, addressTo){
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
            switch (typeMessage){
                case MailTypeMessage.NewClient:
                    CreateBodyNewClient();
                    break;
                case MailTypeMessage.EditClient:
                    CreateBodyEditClient();
                    break;
            }
        }


        private void CreateBodyNewClient(){
            Message.Subject = "Solicitud de registro a Feria Virtual aceptada.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{client}</b></p>");
            body.Append(
                "<p>Su solicitud de ingreso a nuestro sitio web www.feriavirtualmaipogrande.cl, ha sido aceptada.</p>");
            body.Append(
                "<p>Para iniciar su sesión y comenzar a disfrutar las bondades que ofrecemos, favor dirigirse a nuestro sitio web e ingrese sus credenciales en la página de inicio de sesión correspondiente.</p>");
            body.Append("<p>Sus credenciales son:<br> ");
            body.Append($"Nombre de usuario: <b>{client.Credentials.Username}</b><br>");
            body.Append($"Contraseña: <b>{client.Credentials.Password}</b><br>");
            body.Append($"Rol aprobado: <b>{client.Profile.ProfileName}</b></p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            Message.Body = body.ToString();
        }


        private void CreateBodyEditClient(){
            Message.Subject = "Cambios en información de cuenta de usuario en feria virtual realizados.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{client}</b></p>");
            body.Append(
                "<p>Su solicitud de cambios de información en su cuenta de usuario de Feria Virtual, han sido realizados correctamente.</p>");
            body.Append("<p>Sus credenciales son:<br> ");
            body.Append($"Nombre de usuario: <b>{client.Credentials.Username}</b><br>");
            body.Append($"Contraseña: <b>{client.Credentials.Password}</b><br>");
            body.Append($"Nombre: <b>{client.FirstName}</b><br>");
            body.Append($"Apellido: <b>{client.LastName}</b><br>");
            body.Append($"Email: <b>{client.Credentials.Email}</b><br>");
            body.Append($"DNI: <b>{client.Dni}</b><br>");
            body.Append($"Rol aprobado: <b>{client.Profile.ProfileName}</b></p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            Message.Body = body.ToString();
        }

    }

}