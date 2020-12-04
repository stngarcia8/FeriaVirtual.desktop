using FeriaVirtual.Infraestructure.Queues;


namespace FeriaVirtual.Data.Notifiers{

    public class QueueNotifier : IQueueNotifier{

        public void Notify(string exchange, string publishingGroup, string eventToPost, object objectToPublish){
            var pubs = QueuePublisher.CreateEvent(exchange, publishingGroup, eventToPost, objectToPublish);
            pubs.PublishEvent();
        }


        private QueueNotifier(){ }


        public static IQueueNotifier CreateNotifier(){
            return new QueueNotifier();
        }

    }

}