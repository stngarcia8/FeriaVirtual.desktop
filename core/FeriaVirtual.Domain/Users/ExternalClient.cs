using System.Collections.Generic;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Domain.Users{

    public class ExternalClient : Person{

        public IList<Order> OrderList{ get; set; }


        private ExternalClient(){
            OrderList = new List<Order>();
        }


        private ExternalClient(string id, string firstName, string lastName, string dni) :
            base(id, firstName, lastName, dni){
            OrderList = new List<Order>();
        }


        public static ExternalClient CreateClient(){
            return new ExternalClient();
        }


        public static ExternalClient CreateClient(string id, string firstName, string lastName, string dni){
            return new ExternalClient(id, firstName, lastName, dni);
        }


        public void AddOrder(Order order){
            OrderList.Add(order);
        }


        public void RemoveOrder(Order order){
            OrderList.Remove(order);
        }

    }

}