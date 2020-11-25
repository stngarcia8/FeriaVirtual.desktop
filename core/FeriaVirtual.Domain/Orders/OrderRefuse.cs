using System;


namespace FeriaVirtual.Domain.Orders{

    public class OrderRefuse{

        public string RefuseId{ get; set; }
        public string OrderId{ get; set; }
        public int RefuseType{ get; set; }
        public string Observation{ get; set; }


        private OrderRefuse(){
            RefuseId = Guid.NewGuid().ToString();
            OrderId = string.Empty;
            RefuseType = 0;
            Observation = string.Empty;
        }


        public static OrderRefuse CreateRefuse(){
            return new OrderRefuse();
        }

    }

}