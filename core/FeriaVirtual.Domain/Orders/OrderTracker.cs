using System;


namespace FeriaVirtual.Domain.Orders{

    public class OrderTracker{

        public string TrackerId{ get; set; }
        public string OrderId{ get; set; }
        public OrderStatus Status{ get; set; }
        public DateTime TrackerDate{ get; set; }


        private OrderTracker(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty);
        }


        private OrderTracker(string trackerId, string orderId){
            InitializeObjects(trackerId, orderId);
        }


        private void InitializeObjects(string trackerId, string orderId){
            TrackerId = trackerId;
            OrderId = orderId;
            Status = OrderStatus.CreateStatus();
            TrackerDate = DateTime.Now.Date;
        }


        public static OrderTracker CreateTracker(){
            return new OrderTracker();
        }


        public static OrderTracker CreateTracker(string trackerId, string orderId){
            return new OrderTracker(trackerId, orderId);
        }


        public override string ToString(){
            return OrderId;
        }

    }

}