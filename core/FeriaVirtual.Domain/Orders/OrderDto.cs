using System.Collections.Generic;


namespace FeriaVirtual.Domain.Orders{

    public class OrderDto{

        // Properties
        public string OrderId{ get; set; }
        public string ClientId{ get; set; }
        public PaymentCondition Condition{ get; set; }
        public string OrderDate{ get; set; }
        public float OrderDiscount{ get; set; }
        public string Observation{ get; set; }
        public IList<OrderDetail> OrderDetailList{ get; set; }


        // Constructor
        public OrderDto(){
            Condition = PaymentCondition.CreateCondition();
            OrderDetailList = new List<OrderDetail>();
        }

    }

}