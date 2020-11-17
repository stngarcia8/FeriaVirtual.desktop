using System.Text;
using FeriaVirtual.Domain.Dto;
using Newtonsoft.Json;
using RabbitMQ.Client;


namespace FeriaVirtual.Infraestructure.Queues{

    public class UserEvent{

        private readonly SessionDto session;
        private readonly QueueConfigurator configurator;
        private readonly IConnection connection;
        private readonly IModel model;


        private UserEvent(SessionDto sessionDto){
            configurator = QueueConfigurator.CreateQueue("UserWasCreated");
            connection = configurator.GetConnection();
            model = connection.CreateModel();
            model.QueueDeclare(configurator.QueueName, true, false, false, null);
            session = sessionDto;
        }


        public static UserEvent CreateEvent(SessionDto sessionDto){
            return new UserEvent(sessionDto);
        }


        public void PublishEvent(){
            var jsonified = JsonConvert.SerializeObject(session);
            var props = model.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;
            var buffer = Encoding.UTF8.GetBytes(jsonified);
            model.BasicPublish("", configurator.QueueName, props, buffer);
            connection.Close();
            connection.Dispose();
        }

    }

}