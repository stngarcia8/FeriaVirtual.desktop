namespace FeriaVirtual.Domain.Orders {

    public class OrderStatus {

        // Properties
        public int StatusID { get; set; }
        public string StatusDescription { get; set; }

        // Constructor
        private OrderStatus() {
            StatusID= 0;
            StatusDescription= string.Empty;
        }

        private OrderStatus(int statusID,string statusDescription) {
            StatusID= statusID;
            StatusDescription= statusDescription;
        }

        // Named constructors.
        public static OrderStatus CreateStatus() {
            return new OrderStatus();
        }

        public static OrderStatus CreateStatus(int statusID,string statusDescription) {
            return new OrderStatus(statusID,statusDescription);
        }

        public override string ToString() {
            return StatusDescription;
        }
    }
}
