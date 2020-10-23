using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Contracts;

namespace FeriaVirtual.Infraestructure.Mailer {

    public class MailContractSender {
        private readonly MailTypeMessage typeMessage;
        private readonly Contract contract;
        private readonly string pdfFilePath;

        // constructor
        private MailContractSender(Contract contract, string pdfFilePath, MailTypeMessage typeMessage) {
            this.contract=contract;
            this.pdfFilePath= pdfFilePath;
            this.typeMessage= typeMessage;
        }

        // Named Constructor.
        public static MailContractSender CreateSender(Contract contract,string pdfFilePath,  MailTypeMessage typeMessage) {
            return new MailContractSender(contract, pdfFilePath, typeMessage);
        }

        public void SendMail() {
            MailConfigurator configurator = MailConfigurator.CreateConfigurator();
            MailContractMessageConfigurator messageConfigurator = MailContractMessageConfigurator.CreateMessage(contract, pdfFilePath, typeMessage);
            configurator.SMTP.SendMailAsync(messageConfigurator.Message);
        }
    }
}