using System;
using System.Collections.Generic;


namespace FeriaVirtual.Domain.Orders{

    public class Order{

        // Properties
        public string OrderId{ get; set; }
        public string ClientId{ get; set; }
        public PaymentCondition Condition{ get; set; }
        public OrderTracker Tracker{ get; set; }
        public DateTime OrderDate{ get; set; }
        public float OrderDiscount{ get; set; }
        public string Observation{ get; set; }
        public IList<OrderDetail> OrderDetailList{ get; set; }


        // Constructors
        private Order(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, DateTime.Now, 0);
        }


        private Order(string orderId, string clientId, DateTime dateOrder, float discount){
            InitializeObjects(orderId, clientId, dateOrder, discount);
        }


        private void InitializeObjects(string orderId, string clientId, DateTime dateOrder, float discount){
            OrderId = orderId;
            ClientId = clientId;
            Condition = PaymentCondition.CreateCondition();
            Tracker = OrderTracker.CreateTracker();
            OrderDate = dateOrder;
            OrderDiscount = discount;
            Observation = string.Empty;
            OrderDetailList = new List<OrderDetail>();
        }


        // Named constructors
        public static Order CreateOrder(){
            return new Order();
        }


        public static Order CreateOrder(string orderId, string clientId, DateTime dateOrder, float orderDiscount){
            return new Order(orderId, clientId, dateOrder, orderDiscount);
        }


        public void AddDetail(OrderDetail detail){
            OrderDetailList.Add(detail);
        }


        public void RemoveDetail(OrderDetail detail){
            OrderDetailList.Remove(detail);
        }

    }

}