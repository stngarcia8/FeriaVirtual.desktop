using System;

namespace FeriaVirtual.Infraestructure.Mailer {
    public class MailerClientSender:IDisposable {

        private bool disposed = false;
        private MailerClientConfigurator configurator;


        public string Email { get; set; }
        public string UserEmail { get; set; }
        public string Subject { get; set; }
        public string MessageBody;


        private MailerClientSender() {
            //configurator = MailerClientConfigurator.CreateSmtp();
        }


        public static MailerClientSender CreateSender() {
            return new MailerClientSender();
        }

        public void SendMail() {
            using (var configurator = MailerClientConfigurator.CreateSmtp()){
                ConfigureEmail(configurator);
                configurator.ClientSmtp.SendMailAsync(configurator.GetMessage(MessageBody));
                //configurator.ClientSmtp.Send(configurator.GetMessage(MessageBody));
            }
        }


        private void ConfigureEmail(MailerClientConfigurator configurator) {
            configurator.EmailTo = Email;
            configurator.UserTo = UserEmail;
            configurator.Subject = Subject;
        }


        public void AddAttach(string filePath) {
            configurator.AddAttachFile(filePath);
        }


        public void RemoveAttach(string filePath) {
            configurator.RemoveAttachFile(filePath);
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

        ~MailerClientSender()
        {
            Dispose(false);
        }




    }
}
