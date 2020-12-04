using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using FeriaVirtual.Infraestructure.Exceptions;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailerClientConfigurator : IDisposable{

        private readonly string emailFrom;
        private readonly string userFrom;

        private bool disposed;
        private readonly IList<string> pathFiles;

        public SmtpClient ClientSmtp{ get; }
        public MailMessage Message{ get; set; }

        public string EmailTo{ get; set; }
        public string UserTo{ get; set; }
        public string Subject{ get; set; }
        public string Body{ get; set; }


        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private MailerClientConfigurator(){
            emailFrom = "maipogrande.fv@gmail.com";
            userFrom = "Lucas Claudio Avalos Asathor";
            pathFiles = new List<string>();
            Body = string.Empty;
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
                Body = body;
                ParametersValidator();
                ConfigureMessage();
            }
            catch (Exception ex){
                throw ex;
            }
            return Message;
        }


        private void ParametersValidator(){
            if (string.IsNullOrEmpty(EmailTo))
                throw new InvalidEmailParameterException(
                    "No ha definido una dirección de correo electrónico de destino");
            if (string.IsNullOrEmpty(UserTo))
                throw new InvalidEmailParameterException(
                    "No ha definido un nombre de usuario destino para el mensaje");
            if (string.IsNullOrEmpty(Subject))
                throw new InvalidEmailParameterException(
                    "No ha definido un asunto para el correo electrónico.");
        }


        private void ConfigureMessage(){
            var addressTo = new MailAddress(EmailTo, UserTo);
            var addressFrom = new MailAddress(emailFrom, userFrom);
            Message = new MailMessage(addressFrom, addressTo){
                IsBodyHtml = true,
                Priority = MailPriority.High
            };
            if (pathFiles.Count > 0)
                foreach (var file in pathFiles){
                    var atch = new Attachment(file, MediaTypeNames.Application.Octet);
                    Message.Attachments.Add(atch);
                }
            Message.Subject = Subject;
            Message.Body = Body;
        }


        public void AddAttachFile(string filePath){
            pathFiles.Add(filePath);
        }


        public void RemoveAttachFile(string filePath){
            pathFiles.Remove(filePath);
        }


        protected virtual void Dispose(bool disposing){
            if (disposed) return;
            disposed = true;
        }


        ~MailerClientConfigurator(){
            Dispose(false);
        }

    }

}