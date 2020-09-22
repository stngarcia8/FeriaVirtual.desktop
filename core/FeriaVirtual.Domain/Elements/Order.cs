using System;
using System.Collections.Generic;

namespace FeriaVirtual.Domain.Elements {
    public class Order {

        public string OrderID { get; set; }
        public string ClientID { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
        public IList<OrderDetail> OrderDetailList { get; set; }


        // Constructors
        private Order() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,DateTime.Now,false );
        }

        private Order(string orderID,string clientID,DateTime dateOrder,bool statusOrder) {
            InitializeObjects( orderID,clientID,dateOrder,statusOrder );
        }

        private void InitializeObjects(string orderID,string clientID,DateTime dateOrder,bool statusOrder) {
            OrderID=orderID;
            ClientID=clientID;
            OrderDate=OrderDate;
            OrderStatus=OrderStatus;
            OrderDetailList= new List<OrderDetail>();
        }


        // Named constructors
        public static Order CreateOrder() {
            return new Order();
        }

        public static Order CreateOrder(string orderID,string clientID,DateTime dateOrder,bool statusOrder) {
            return new Order( orderID,clientID,dateOrder,statusOrder );
        }


        public void AddDetail(OrderDetail detail) {
            OrderDetailList.Add( detail );
        }

        public void RemoveDetail(OrderDetail detail) {
            OrderDetailList.Remove( detail );
        }



    }
}
