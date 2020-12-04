using System.Text;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.Domain.Enums;


namespace FeriaVirtual.Data.Notifiers{

    public class EmailContractNotifier : EmailNotifier{

        private ContractDetail detail;
        private string pdfFilePath;


        private EmailContractNotifier(){ }


        public static EmailContractNotifier CreateNotifier(){
            return new EmailContractNotifier();
        }


        public void Notify(Contract contract, string pdfFilePath, MailTypeMessage typeMessage){
            detail = contract.Details[0];
            this.pdfFilePath = pdfFilePath;
            this.typeMessage = typeMessage;
            GenerateBody();
            SendAnEmail();
        }


        private void SendAnEmail(){
            email.EmailTo = detail.Customer.Credentials.Email;
            email.UserTo = detail.Customer.ToString();
            email.AddAttachment(pdfFilePath);
            SendTheEmailToQueue();
        }


        private void GenerateBody(){
            switch (typeMessage){
                case MailTypeMessage.ContractAccepted:
                    CreateBodyContractAccepted();
                    break;
                case MailTypeMessage.ContractRefused:
                    CreateBodyContractRefused();
                    break;
            }
        }


        private void CreateBodyContractAccepted(){
            email.Subject = "Copia de contrato aceptado.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{detail.Customer}</b></p>");
            body.Append(
                "<p>Adjuntamos el contrato aceptado por usted mediante nuestro portal web 'Feria virtual', </p>");
            body.Append(
                "<p>Cualquier duda o consulta puede realizarlas por nuestros metodos de contactos oficiales.</p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            email.Body = body.ToString();
        }


        private void CreateBodyContractRefused(){
            email.Subject = "Contrato rechazado.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{detail.Customer}</b></p>");
            body.Append(
                "<p>Lamentamos el rechazo del contrato, este contrato fue realizado por las conversaciones realizadas entre usted y su ejecutivo, favor comuniquese con su ejecutivo para poder generar un contrato en que ambas partes este conforme.</p>");
            body.Append(
                "<p>Cualquier duda o consulta puede realizarlas por nuestros metodos de contacto oficiales.</p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            email.Body = body.ToString();
        }

    }

}