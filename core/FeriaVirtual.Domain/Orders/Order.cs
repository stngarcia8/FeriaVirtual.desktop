using System;
using System.Collections.Generic;
using FeriaVirtual.Domain.Dto;

namespace FeriaVirtual.Domain.Orders {

    public class Order {

        // Properties
        public string OrderID { get; set; }
        public string ClientID { get; set; }
        public PaymentCondition Condition { get; set; }
        public OrderStatus Status { get; set; }
        public OrderTracker Tracker { get; set; }
        public OrderProcess ActualProcess { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderDiscount { get; set; }
        public IList<OrderDetail> OrderDetailList { get; set; }

        // Constructors
        private Order() {
            InitializeObjects(Guid.NewGuid().ToString(),string.Empty,DateTime.Now,0);
        }

        private Order(string orderID,string clientID,DateTime dateOrder,float discount) {
            InitializeObjects(orderID,clientID,dateOrder,discount);
        }

        private void InitializeObjects(string orderID,string clientID,DateTime dateOrder,float discount) {
            OrderID=orderID;
            ClientID=clientID;
            Condition= PaymentCondition.CreateCondition();
            OrderDate=dateOrder;
            OrderDiscount = discount;
            OrderDetailList= new List<OrderDetail>();
        }

        // Named constructors
        public static Order CreateOrder() {
            return new Order();
        }

        public static Order CreateOrder(string orderID,string clientID,DateTime dateOrder,float orderDiscount) {
            return new Order(orderID,clientID,dateOrder,orderDiscount);
        }

        public void AddDetail(OrderDetail detail) {
            OrderDetailList.Add(detail);
        }

        public void RemoveDetail(OrderDetail detail) {
            OrderDetailList.Remove(detail);
        }
    }
}