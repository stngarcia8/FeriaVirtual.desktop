using System.Text;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Infraestructure.Mailer;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace FeriaVirtual.Infraestructure.Queues{

    public class QueueConsumer : IConsumerEvent{

        private readonly IModel chanel;

        private readonly QueueConfigurator configurator;
        public IConnection Connection{ get; }
        private readonly string routingKey;
        public string Message{ get; set; }


        public void ConsumerEvent(){
            var queueName = chanel.QueueDeclare().QueueName;
            chanel.QueueBind(queueName,
                configurator.ExchangeName,
                routingKey);
            var consumer = new EventingBasicConsumer(chanel);
            consumer.Received += (model, ea) => {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                SendEmail(message);
            };
            chanel.BasicConsume(queueName,
                true,
                consumer);
        }


        private QueueConsumer(string exchangeName, string topicName, string queueName){
            configurator = QueueConfigurator.CreateQueue(exchangeName, topicName, queueName);
            Connection = configurator.GetConnection();
            chanel = Connection.CreateModel();
            chanel.ExchangeDeclare(configurator.ExchangeName, "topic");
            routingKey = $"{configurator.ExchangeName}.#";
        }


        public static IConsumerEvent CreateConsumer(string exchangeName, string topicName, string queueName){
            return new QueueConsumer(exchangeName, topicName, queueName);
        }


        private void SendEmail(string message){
            var email = JsonConvert.DeserializeObject<EmailDto>(message);
            var sender = MailerClientSender.CreateSender();
            sender.Email = email.EmailTo;
            sender.UserEmail = email.UserTo;
            sender.Subject = email.Subject;
            sender.MessageBody = email.Body;
            if (email.Attachments.Count > 0)
                foreach (var file in email.Attachments)
                    sender.AddAttach(file);

            sender.SendMail();
        }

    }

}