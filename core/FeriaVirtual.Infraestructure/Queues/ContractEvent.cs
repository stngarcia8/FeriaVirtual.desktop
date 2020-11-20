using System.Collections.Generic;
using System.Text;
using FeriaVirtual.Domain.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;


namespace FeriaVirtual.Infraestructure.Queues {


    public class ContractEvent : IPublishEvent{

        private readonly QueueConfigurator configurator;
        private readonly IConnection connection;

        private readonly ContractDto contract;
        private readonly IModel model;


        private ContractEvent(ContractDto contractDto) {
            configurator = QueueConfigurator.CreateQueue("ContractQueue");
            connection = configurator.GetConnection();
            model = connection.CreateModel();
            model.QueueDeclare(configurator.QueueName,true,false,false,null);
            this.contract = contractDto;
        }


        public static IPublishEvent CreateEvent(ContractDto contractDto) {
            return new ContractEvent(contractDto);
        }


        public void PublishEvent() {
            string jsonified = JsonConvert.SerializeObject(this.contract);
            IBasicProperties props = model.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;
            byte[] buffer = Encoding.UTF8.GetBytes(jsonified);
            model.BasicPublish("",configurator.QueueName,props,buffer);
            connection.Close();
            connection.Dispose();
        }

    }

}