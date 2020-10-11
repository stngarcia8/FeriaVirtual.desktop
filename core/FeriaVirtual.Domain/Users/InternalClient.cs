﻿using System.Collections.Generic;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Domain.Users {

    public class InternalClient:Person {

        // Properties
        public IList<Order> OrderList { get; set; }

        // constructors
        private InternalClient() : base() {
            OrderList= new List<Order>();
        }

        private InternalClient(string id,string firstName,string lastName,string dni) :
            base(id,firstName,lastName,dni) {
            OrderList= new List<Order>();
        }

        // Named constructors.
        public static InternalClient CreateClient() {
            return new InternalClient();
        }

        public static InternalClient CreateClient(string id,string firstName,string lastName,string dni) {
            return new InternalClient(id,firstName,lastName,dni);
        }

        public void AddOrder(Order order) {
            OrderList.Add(order);
        }

        public void RemoveOrder(Order order) {
            OrderList.Remove(order);
        }
    }
}