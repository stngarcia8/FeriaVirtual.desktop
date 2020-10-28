using System;
using FeriaVirtual.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeriaVirtual.API.Models {

    public class OrderModel {

        // Properties
        public string OrderID { get; set; }
        public string ClientID { get; set; }
        public int ConditionId { get; set; }
        public string ConditionDescription { get; set; }
        public float OrderDiscount { get; set; }
        public string Observation { get; set; }
        public IList<OrderDetail> OrderDetail { get; set; }

                                         // Constructor
        public OrderModel() {

    }

    }
}