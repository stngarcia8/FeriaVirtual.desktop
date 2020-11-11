using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.Domain.Enums;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailContractSender{

        private readonly Contract contract;
        private readonly string pdfFilePath;
        private readonly MailTypeMessage typeMessage;


        // constructor
        private MailContractSender(Contract contract, string pdfFilePath, MailTypeMessage typeMessage){
            this.contract = contract;
            this.pdfFilePath = pdfFilePath;
            this.typeMessage = typeMessage;
        }


        // Named Constructor.
        public static MailContractSender CreateSender(Contract contract, string pdfFilePath,
            MailTypeMessage typeMessage){
            return new MailContractSender(contract, pdfFilePath, typeMessage);
        }


        public void SendMail(){
            var configurator = MailConfigurator.CreateConfigurator();
            var messageConfigurator = MailContractMessageConfigurator.CreateMessage(contract, pdfFilePath, typeMessage);
            configurator.Smtp.SendMailAsync(messageConfigurator.Message);
        }

    }

}