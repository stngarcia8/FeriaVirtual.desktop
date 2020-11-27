using System;
using System.Threading;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Infraestructure.Mailer;


namespace FeriaVirtual.Data.Notifiers{

    public abstract class EmailNotifier{

        protected readonly MailerClientSender sender;
        protected MailTypeMessage typeMessage;


        protected EmailNotifier(){
            sender = MailerClientSender.CreateSender();
        }


        protected void SendTheEmail(){
            //new Thread(() => {
                try{
                    sender.SendMail();
                }
                catch (Exception ex){
                    Console.Write("Aqui esta el error.");
                    Console.Write(ex.Message);
                }
            //}).Start();
        }


        protected void DisposeNotifier(){
            sender.Dispose();
        }


    }

}