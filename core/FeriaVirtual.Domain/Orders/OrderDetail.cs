using System;


namespace FeriaVirtual.Domain.Orders{

    public class OrderDetail{

        public string OrderDetailId{ get; set; }
        public string OrderId{ get; set; }
        public string ProductName{ get; set; }
        public float Quantity{ get; set; }


        private OrderDetail(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, string.Empty, 0);
        }


        private OrderDetail(string orderDetailId, string orderId, string productName, float quantity){
            InitializeObjects(orderDetailId, orderId, productName, quantity);
        }


        private void InitializeObjects(string orderDetailId, string orderId, string productName, float quantity){
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
        }


        public static OrderDetail CreateDetail(){
            return new OrderDetail();
        }


        public static OrderDetail CreateDetail(string orderDetailId, string orderId, string productName,
            float quantity){
            return new OrderDetail(orderDetailId, orderId, productName, quantity);
        }

    }

}