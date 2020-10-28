using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Domain.Orders {

    public class OrderDto {

        // Properties
        public string OrderID { get; set; }
        public string ClientID { get; set; }
        public PaymentCondition Condition { get; set; }
        public string OrderDate { get; set; }
        public float OrderDiscount { get; set; }
        public string Observation { get; set; }
        public IList<OrderDetail> OrderDetailList { get; set; }

        // Constructor
        public OrderDto() {
            this.Condition = PaymentCondition.CreateCondition();
            this.OrderDetailList = new List<OrderDetail>();
                }

    }

}
