using System.Text;
using System.IO;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Domain.Enums;


namespace FeriaVirtual.Data.Notifiers{

    public class EmailReportNotifier : EmailNotifier{

        private ReportRecipientsDto recipient;


        private EmailReportNotifier(){ }


        public static EmailReportNotifier CreateNotifier(){
            return new  EmailReportNotifier();
        }


        public void Notify(ReportRecipientsDto recipient){
            this.recipient = recipient;
            GenerateBody();
            SendAnEmail();
        }


        private void SendAnEmail(){
            email.EmailTo = recipient.Email;
            email.UserTo = recipient.Name;
            email.AddAttachment(recipient.Filename);
            SendTheEmailToQueue();
        }


        private void GenerateBody(){
            email.Subject = recipient.Subject;
            var body = new StringBuilder();
            body.Append($"<p>Estimado(a) Sr(a). <b>{recipient.Name}</b></p>");
            body.Append($"<p>Adjuntamos el {recipient.Subject} generado mediante nuestra aplicación</p>");
            body.Append("<p>Saludos cordiales.</p><br><br> ");
            email.Body = body.ToString();
        }



    }

}