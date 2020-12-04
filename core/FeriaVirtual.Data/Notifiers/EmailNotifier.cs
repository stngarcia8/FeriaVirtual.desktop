using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Domain.Enums;


namespace FeriaVirtual.Data.Notifiers{

    public abstract class EmailNotifier{

        protected EmailDto email;
        protected MailTypeMessage typeMessage;


        protected EmailNotifier(){
            email = EmailDto.CreateModel();
        }


        protected void SendTheEmailToQueue(){
            var notifyToQueue = QueueNotifier.CreateNotifier();
            notifyToQueue.Notify("Email", "Mailer", "SendAnEmail", email);
        }

    }

}