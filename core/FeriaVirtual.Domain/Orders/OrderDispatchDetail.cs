using System;


namespace FeriaVirtual.Domain.Orders{

    public class OrderDispatchDetail{

        public string DetailId{ get; set; }
        public string Product{ get; set; }
        public float UnitValue{ get; set; }
        public float Quantity{ get; set; }
        public float TotalValue{ get; set; }


        private OrderDispatchDetail(){
            DetailId = Guid.NewGuid().ToString();
            Product = string.Empty;
            UnitValue = 0;
            Quantity = 0;
            TotalValue = 0;
        }


        public static OrderDispatchDetail CreateDetail(){
            return new OrderDispatchDetail();
        }

    }

}