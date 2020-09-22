using System;

namespace FeriaVirtual.Domain.Elements {
    public class OrderDetail {

        public string OrderDetailID { get; set; }
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public float Quantity { get; set; }


        // Constructors.
        private OrderDetail() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,string.Empty,0 );
        }

        private OrderDetail(string orderDetailID,string orderID,string productID,float quantity) {
            InitializeObjects( orderDetailID,orderID,ProductID,quantity );
        }

        private void InitializeObjects(string orderDetailID,string orderID,string productID,float quantity) {
            OrderDetailID=OrderDetailID;
            OrderID = orderID;
            ProductID = ProductID;
            Quantity=quantity;
        }


        // Named constructors.
        public static OrderDetail CreateDetail() {
            return new OrderDetail();
        }

        public static OrderDetail CreateDetail(string orderDetailID,string orderID,string productID,float quantity) {
            return new OrderDetail( orderDetailID,orderID,productID,quantity );
        }




    }
}
