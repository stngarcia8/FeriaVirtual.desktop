using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace FeriaVirtual.Infraestructure.Queues {
    public class QueuePublisher: IPublishEvent {

        private readonly QueueConfigurator configurator;
        private readonly IConnection connection;
        private readonly IModel model;
        private readonly string routingKey;
        private readonly Object objectToPublish;


        private QueuePublisher(string topicName, string queueName,  Object objectToPublish){
            configurator = QueueConfigurator.CreateQueue(queueName);
            connection = configurator.GetConnection();
            model = connection.CreateModel();
            model.ExchangeDeclare(exchange: "maipogrande", type: "topic");
            this.routingKey= $"maipogrande.{topicName}.{configurator.QueueName}";
            this.objectToPublish = objectToPublish;
        }


        public static IPublishEvent CreateEvent(string topicName, string queueName, Object objectToPublish){
            return new QueuePublisher(topicName, queueName, objectToPublish);
        }


        public void PublishEvent(){
            var jsonified = JsonConvert.SerializeObject(this.objectToPublish);
            var props = model.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;
            var body = Encoding.UTF8.GetBytes(jsonified);
            model.BasicPublish(exchange: "maipogrande", routingKey: this.routingKey, basicProperties: props, body: body);
            connection.Close();
            connection.Dispose();
        }

    }
}
