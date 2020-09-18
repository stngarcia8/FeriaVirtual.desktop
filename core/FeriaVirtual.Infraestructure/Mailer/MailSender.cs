using System;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Infraestructure.Mailer {

    public class MailSender {

        private MailTypeMessage typeMessage;
        private Client client;

        // constructor
        private MailSender(Client client, MailTypeMessage typeMessage) {
            this.client=client;
            this.typeMessage= typeMessage;
        }

        // Named Constructor.
        public static MailSender CreateSender(Client client,MailTypeMessage typeMessage) {
            return new MailSender( client,typeMessage );
        }

        public void SendMail() {
                MailConfigurator configurator = MailConfigurator.CreateConfigurator();
            MailMessageConfigurator messageConfigurator = MailMessageConfigurator.CreateMessage( this.client,this.typeMessage);
            configurator.SMTP.SendMailAsync( messageConfigurator.Message );
        }

    }
}
