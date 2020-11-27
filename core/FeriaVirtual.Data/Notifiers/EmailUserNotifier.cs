using System.Text;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Data.Notifiers{

    public class EmailUserNotifier : EmailNotifier{

        private Client client;


        private EmailUserNotifier(){ }


        public static EmailUserNotifier CreateNotifier(){
            return new EmailUserNotifier();
        }


        public void Notify(Client client, MailTypeMessage typeMessage){
            this.client = client;
            this.typeMessage = typeMessage;
            GenerateBody();
            sender.Email = this.client.Credentials.Email;
            sender.UserEmail = this.client.ToString();
            SendTheEmail();
            DisposeNotifier();
        }


        private void GenerateBody(){
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
            sender.Subject = "Solicitud de registro a Feria Virtual aceptada.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{client}</b></p>");
            body.Append(
                "<p>Su solicitud de ingreso a nuestro sitio web www.feriavirtualmaipogrande.cl, ha sido aceptada.</p>");
            body.Append(
                "<p>Para iniciar su sesión y comenzar a disfrutar las bondades que ofrecemos, favor dirigirse a nuestro <a href='http://maipogrande-fv.duckdns.org:8081'>sitio web</a>, ingrese sus credenciales en la página de inicio de sesión.</p>");
            body.Append("<p>Sus credenciales son:<br> ");
            body.Append($"Nombre de usuario: <b>{client.Credentials.Username}</b><br>");
            body.Append($"Contraseña: <b>{client.Credentials.Password}</b><br>");
            body.Append($"Rol aprobado: <b>{client.Profile.ProfileName}</b></p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            sender.MessageBody = body.ToString();
        }


        private void CreateBodyEditClient(){
            sender.Subject = "Cambios en información de cuenta de usuario en feria virtual realizados.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{client}</b></p>");
            body.Append(
                "<p>Su solicitud de cambio de información en la cuenta de usuario de Feria Virtual, fue realizado correctamente.</p>");
            body.Append("<p>Sus credenciales son:<br> ");
            body.Append($"Nombre de usuario: <b>{client.Credentials.Username}</b><br>");
            body.Append($"Contraseña: <b>{client.Credentials.Password}</b><br>");
            body.Append($"Nombre: <b>{client.FirstName}</b><br>");
            body.Append($"Apellido: <b>{client.LastName}</b><br>");
            body.Append($"Email: <b>{client.Credentials.Email}</b><br>");
            body.Append($"DNI: <b>{client.Dni}</b><br>");
            body.Append($"Rol aprobado: <b>{client.Profile.ProfileName}</b></p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            sender.MessageBody = body.ToString();
        }

    }

}