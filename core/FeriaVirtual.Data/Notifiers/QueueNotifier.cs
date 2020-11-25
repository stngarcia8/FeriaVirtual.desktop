using FeriaVirtual.Infraestructure.Queues;


namespace FeriaVirtual.Data.Notifiers{

    public class QueueNotifier : IQueueNotifier{

        private QueueNotifier(){}


        public static IQueueNotifier CreateNotifier(){
            return new QueueNotifier();
        }


        public void Notify(string publishingGroup, string eventToPost, object objectToPublish){
            var pubs = QueuePublisher.CreateEvent(publishingGroup, eventToPost, objectToPublish);
            pubs.PublishEvent();
        }

    }

}