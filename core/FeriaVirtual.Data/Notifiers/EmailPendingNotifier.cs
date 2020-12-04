using FeriaVirtual.Infraestructure.Queues;


namespace FeriaVirtual.Data.Notifiers{

    public class EmailPendingNotifier{

        private readonly IConsumerEvent consumer;


        private EmailPendingNotifier(){
            consumer = QueueConsumer.CreateConsumer("Email", "Mailer", "SendAnEmail");
        }


        public static EmailPendingNotifier CreateNotifier(){
            return new EmailPendingNotifier();
        }


        public void Notify(){
            consumer.ConsumerEvent();
        }

    }

}