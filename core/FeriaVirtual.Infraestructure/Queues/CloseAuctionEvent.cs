using System.Text;
using FeriaVirtual.Domain.Orders;
using Newtonsoft.Json;
using RabbitMQ.Client;


namespace FeriaVirtual.Infraestructure.Queues{

    public class CloseAuctionEvent : IPublishEvent{

        private readonly AuctionClose auction;

        private readonly QueueConfigurator configurator;
        private readonly IConnection connection;
        private readonly IModel model;


        public void PublishEvent(){
            var jsonified = JsonConvert.SerializeObject(auction);
            var props = model.CreateBasicProperties();
            props.ContentType = "text/plain";
            props.DeliveryMode = 2;
            var buffer = Encoding.UTF8.GetBytes(jsonified);
            model.BasicPublish("", configurator.QueueName, props, buffer);
            connection.Close();
            connection.Dispose();
        }


        private CloseAuctionEvent(AuctionClose auction){
            configurator = QueueConfigurator.CreateQueue("AuctionWasClose");
            connection = configurator.GetConnection();
            model = connection.CreateModel();
            model.QueueDeclare(configurator.QueueName, true, false, false, null);
            this.auction = auction;
        }


        public static IPublishEvent CreateEvent(AuctionClose auction){
            return new CloseAuctionEvent(auction);
        }

    }

}