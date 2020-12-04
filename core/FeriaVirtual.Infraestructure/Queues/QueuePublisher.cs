using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;


namespace FeriaVirtual.Infraestructure.Queues{

    public class QueuePublisher : IPublishEvent{

        private readonly QueueConfigurator configurator;
        private readonly IConnection connection;
        private readonly IModel model;
        private readonly object objectToPublish;


        public void PublishEvent(){
            model.BasicPublish(
                configurator.ExchangeName,
                configurator.RoutingKey,
                GenerateProperties(),
                GenerateBody()
            );
            //connection.Close();
            //connection.Dispose();
        }


        private QueuePublisher(string exchangeName, string topicName, string queueName, object objectToPublish){
            configurator = QueueConfigurator.CreateQueue(exchangeName, topicName, queueName);
            connection = configurator.GetConnection();
            model = connection.CreateModel();
            model.ExchangeDeclare(configurator.ExchangeName, "topic");
            this.objectToPublish = objectToPublish;
        }


        public static IPublishEvent CreateEvent(string exchangeName, string topicName, string queueName,
            object objectToPublish){
            return new QueuePublisher(exchangeName, topicName, queueName, objectToPublish);
        }


        private byte[] GenerateBody(){
            var jsonified = JsonConvert.SerializeObject(objectToPublish);
            var body = Encoding.UTF8.GetBytes(jsonified);
            return body;
        }


        private IBasicProperties GenerateProperties(){
            var props = model.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;
            return props;
        }

    }

}