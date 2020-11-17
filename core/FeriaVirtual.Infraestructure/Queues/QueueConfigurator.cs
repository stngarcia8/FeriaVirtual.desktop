using RabbitMQ.Client;


namespace FeriaVirtual.Infraestructure.Queues{

    public class QueueConfigurator{

        private readonly string _hostName = "localhost";
        private readonly string _password = "fv_pwd";
        private readonly string _userName = "fv_user";
        private readonly IConnection queueConnection;

        public string QueueName{ get; }


        private QueueConfigurator(string queueName){
            this.QueueName = queueName;
        }


        public static QueueConfigurator CreateQueue(string queueName){
            return new QueueConfigurator(queueName);
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