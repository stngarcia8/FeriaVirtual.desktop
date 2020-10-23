using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Contracts;

namespace FeriaVirtual.Infraestructure.Mailer {

    public class MailContractMessageConfigurator {
        private MailMessage mailMessage;
        private readonly Contract contract;
        private readonly ContractDetail detail;
        private readonly MailTypeMessage typeMessage;
        private readonly string pdfFilePath;

        // Properties.
        public MailMessage Message => mailMessage;

        // constructor
        private MailContractMessageConfigurator(Contract contract, string pdfFilePath, MailTypeMessage typeMessage) {
            this.contract= contract;
            this.detail = this.contract.Details[0];
            this.pdfFilePath= pdfFilePath;
            this.typeMessage= typeMessage;
            ConfigureMailHeader();
        }

        // Named Constructor.
        public static MailContractMessageConfigurator CreateMessage(Contract contract, string pdfFilePath, MailTypeMessage typeMessage) {
            return new MailContractMessageConfigurator(contract, pdfFilePath, typeMessage);
        }

        private void ConfigureMailHeader() {
            MailAddress addressTo = new MailAddress(detail.Customer.Credentials.Email,detail.Customer.ToString());
            MailAddress addressFrom = new MailAddress("maipogrande.fv@gmail.com","Lucas Claudio Avalos Asathor");
            Attachment data = new Attachment(this.pdfFilePath,MediaTypeNames.Application.Octet);
            mailMessage = new MailMessage(addressFrom,addressTo) {
                IsBodyHtml= true,
                Priority= MailPriority.High
            };
            mailMessage.Attachments.Add(data);
            if(typeMessage== MailTypeMessage.ContractAccepted) {
                CreateBodyContractAccepted();
            }
            if(typeMessage== MailTypeMessage.ContractRefused) {
                CreateBodyContractRefused();
            }
        }

        private void CreateBodyContractAccepted() {
            mailMessage.Subject= "Maipo Grande: Contrato aceptado.";
            StringBuilder body = new StringBuilder();
            body.Append(string.Format("<p>Estimado(a) Sr(a). <b>{0}</b></p>",detail.Customer.ToString()));
            body.Append("<p>Adjuntamos el contrato aceptado por usted mediante nuestro portal web 'Feria virtual', </p>");
            body.Append("<p>Cualquier duda o consulta puede realizarlas por nuestros metodos de contactos oficiales.</p>");
            body.Append("<p>Gracias por su preferencia, saludos cordiales.</p><br><br> ");
            mailMessage.Body= body.ToString();
        }

        private void CreateBodyContractRefused() {
        }
    }
}