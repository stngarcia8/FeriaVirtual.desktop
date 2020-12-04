using System;


namespace FeriaVirtual.Infraestructure.Mailer{

    public class MailerClientSender : IDisposable, IMailerSender{

        private bool disposed;
        private  MailerClientConfigurator configurator;
        public string MessageBody;



        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public string Email{ get; set; }
        public string UserEmail{ get; set; }
        public string Subject{ get; set; }


        public void SendMail(){
            using ( configurator = MailerClientConfigurator.CreateSmtp()){
                ConfigureEmail(configurator);
                configurator.ClientSmtp.SendMailAsync(configurator.GetMessage(MessageBody));
            }
        }


        public void AddAttach(string filePath){
            configurator.AddAttachFile(filePath);
        }


        public void RemoveAttach(string filePath){
            configurator.RemoveAttachFile(filePath);
        }


        private MailerClientSender(){ }


        public static MailerClientSender CreateSender(){
            return new MailerClientSender();
        }


        private void ConfigureEmail(MailerClientConfigurator configurator){
            configurator.EmailTo = Email;
            configurator.UserTo = UserEmail;
            configurator.Subject = Subject;
        }


        protected virtual void Dispose(bool disposing){
            if (disposed) return;

            disposed = true;
        }


        ~MailerClientSender(){
            Dispose(false);
        }

    }

}