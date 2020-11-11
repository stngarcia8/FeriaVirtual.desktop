using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.Domain.Enums;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailContractMessageConfigurator{

        private readonly ContractDetail detail;
        private readonly string pdfFilePath;
        private readonly MailTypeMessage typeMessage;

        // Properties.
        public MailMessage Message{ get; private set; }


        // constructor
        private MailContractMessageConfigurator(Contract contract, string pdfFilePath, MailTypeMessage typeMessage){
            detail = contract.Details[0];
            this.pdfFilePath = pdfFilePath;
            this.typeMessage = typeMessage;
            ConfigureMailHeader();
        }


        // Named Constructor.
        public static MailContractMessageConfigurator CreateMessage(Contract contract, string pdfFilePath,
            MailTypeMessage typeMessage){
            return new MailContractMessageConfigurator(contract, pdfFilePath, typeMessage);
        }


        private void ConfigureMailHeader(){
            var addressTo = new MailAddress(detail.Customer.Credentials.Email, detail.Customer.ToString());
            var addressFrom = new MailAddress("maipogrande.fv@gmail.com", "Lucas Claudio Avalos Asathor");
            var data = new Attachment(pdfFilePath, MediaTypeNames.Application.Octet);
            Message = new MailMessage(addressFrom, addressTo){
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
            Message.Attachments.Add(data);
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
            Message.Subject = "Maipo Grande: Contrato aceptado.";
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{detail.Customer}</b></p>");
            body.Append(
                "<p>Adjuntamos el contrato aceptado por usted mediante nuestro portal web 'Feria virtual', </p>");
            body.Append(
                "<p>Cualquier duda o consulta puede realizarlas por nuestros metodos de contactos oficiales.</p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            Message.Body = body.ToString();
        }


        private void CreateBodyContractRefused(){ }

    }

}