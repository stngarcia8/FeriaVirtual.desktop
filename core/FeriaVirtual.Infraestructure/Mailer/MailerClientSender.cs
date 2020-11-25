using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Infraestructure.Mailer {
    public class MailerClientSender{

        private MailerClientConfigurator configurator;

        public string Email{get;set;}
        public string UserEmail{get;set;}
        public string Subject{get;set;}
        public string MessageBody;


        private MailerClientSender(){
            this.configurator = MailerClientConfigurator.CreateSmtp();
        }


        public static MailerClientSender CreateSender(){
            return new MailerClientSender();
        }

        public void SendMail(){
            this.ConfigureEmail();
            configurator.ClientSmtp.SendMailAsync(configurator.GetMessage(this.MessageBody));
        }


        private void ConfigureEmail(){
            configurator.EmailTo = this.Email;
            configurator.UserTo = this.UserEmail;
            configurator.Subject = this.Subject;
        }


        public void AddAttach(string filePath){
            configurator.AddAttachFile(filePath);
        }


        public void RemoveAttach(string filePath){
            configurator.RemoveAttachFile(filePath);
        }

    }
}
