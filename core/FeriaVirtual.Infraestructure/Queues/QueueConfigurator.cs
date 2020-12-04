using RabbitMQ.Client;


namespace FeriaVirtual.Infraestructure.Queues{

    public class QueueConfigurator{

        const string _hostName = "localhost";
        const string _password = "fv_pwd";
        const string _userName = "fv_user";

        public string ExchangeName{ get; }
        public string RoutingKey{ get; set; }
        public string TopicName{ get; }
        public string QueueName{ get; }


        private QueueConfigurator(string exchangeName, string topicName, string queueName){
            ExchangeName = exchangeName;
            TopicName = topicName;
            RoutingKey = $"{exchangeName}.{topicName}.{queueName}";
            QueueName = queueName;
        }


        public static QueueConfigurator CreateQueue(string exchangeName, string topicName, string queueName){
            return new QueueConfigurator(exchangeName, topicName, queueName);
        }


        public IConnection GetConnection(){
            var queueConnection = new ConnectionFactory{
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };
            queueConnection.CreateConnection();
            return queueConnection.CreateConnection();
        }

    }

}