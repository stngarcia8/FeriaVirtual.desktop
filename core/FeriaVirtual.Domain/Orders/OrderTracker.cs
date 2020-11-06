using System;

namespace FeriaVirtual.Domain.Orders {

    public class OrderTracker {

        // Properties
        public string TrackerID { get; set; }
    public string OrderID { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime TrackerDate { get; set; }

        private OrderTracker() {
            InitializeObjects(Guid.NewGuid().ToString(),string.Empty);
        }

        private OrderTracker(string trackerID,string orderID) {
            InitializeObjects(trackerID,orderID);
        }

        private void InitializeObjects(string trackerID,string orderID) {
            TrackerID = trackerID;
            OrderID = orderID;
            Status= OrderStatus.CreateStatus();
            TrackerDate= DateTime.Now.Date;
        }

        // Named constructor.
        public static OrderTracker CreateTracker() {
            return new OrderTracker();
        }

        public static OrderTracker CreateTracker(string trackerID,string orderID) {
            return new OrderTracker(trackerID,orderID);
        }

        public override string ToString() {
            return OrderID;
        }
    }
}
