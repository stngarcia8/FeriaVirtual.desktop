using System;
using System.Net;
using System.Net.Mime;
using System.Collections.Generic;
using FeriaVirtual.Infraestructure.Exceptions;
using System.Net.Mail;
using System.Text;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailerClientConfigurator: IDisposable{

        private bool disposed = false;
        private string emailFrom;
        private string userFrom;
        private IList<string> pathFiles;

        public SmtpClient ClientSmtp{ get; }
        public MailMessage Message{get; set;}

        public string EmailTo{get;set;}
        public string UserTo{get;set;}
        public string Subject{get;set;}
        public string Body{get;set;}

        private MailerClientConfigurator(){
            this.emailFrom = "maipogrande.fv@gmail.com";
            this.userFrom = "Lucas Claudio Avalos Asathor";
            this.pathFiles = new List<string>();
            this.Body = string.Empty;
            ClientSmtp = new SmtpClient();
            ConfigureSmtpClient();
        }


        public static MailerClientConfigurator CreateSmtp(){
            return new MailerClientConfigurator();
        }


        private void ConfigureSmtpClient(){
            ClientSmtp.Host = "smtp.gmail.com";
            ClientSmtp.Port = 587;
            ClientSmtp.EnableSsl = true;
            ClientSmtp.Timeout = 20000;
            ClientSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            ClientSmtp.UseDefaultCredentials = false;
            ClientSmtp.Credentials = new NetworkCredential("maipogrande.fv@gmail.com", "avaras08");
        }


        public MailMessage GetMessage(string body){
            try{
                this.Body = body;
                this.ParametersValidator();
                this.ConfigureMessage();
            }
            catch (Exception ex){
                throw ex;
            }
            return this.Message;
        }


        private void ParametersValidator(){
            if (string.IsNullOrEmpty(this.EmailTo)){
                throw new InvalidEmailParameterException(
                    "No ha definido una dirección de correo electrónico de destino");
            }
            if (string.IsNullOrEmpty(this.UserTo)){
                throw new InvalidEmailParameterException(
                    "No ha definido un nombre de usuario destino para el mensaje");
            }
            if (string.IsNullOrEmpty(this.Subject)){
                throw new InvalidEmailParameterException(
                    "No ha definido un asunto para el correo electrónico.");
            }
        }



        private void ConfigureMessage(){
            var addressTo = new MailAddress(this.EmailTo, this.UserTo);
            var addressFrom = new MailAddress(this.emailFrom, this.userFrom);
            Message = new MailMessage(addressFrom, addressTo){
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
            if (this.pathFiles.Count > 0){
                foreach (string file in this.pathFiles){
                    var atch = new Attachment(file, MediaTypeNames.Application.Octet);
                    Message.Attachments.Add(atch);
                }
            }
            Message.Subject = this.Subject;
            Message.Body = this.Body;
        }


        public void AddAttachFile(string filePath){
            this.pathFiles.Add(filePath);
        }


        public void RemoveAttachFile(string filePath){
            this.pathFiles.Remove(filePath);
        }







        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if(disposed) {
                return;
            }
            disposed = true;
        }

        ~MailerClientConfigurator()
        {
            Dispose(false);
        }



    }

}