using System;
using FeriaVirtual.Data.Notifiers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Business.HelpersUseCases {
    public class EmailUsecase{

        private EmailUsecase(){}


        public static EmailUsecase CreateUsecase(){
            return new EmailUsecase();
        }


        public void SendingEmails(){
            EmailPendingNotifier emails = EmailPendingNotifier.CreateNotifier();
            emails.Notify();
        }



    }
}
