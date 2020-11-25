namespace FeriaVirtual.Domain.Orders{

    public class OrderResult{

        public string OrderId{ get; set; }
        public float NetValue{ get; set; }
        public float Iva{ get; set; }
        public float TotalValue{ get; set; }
        public float DiscountValue{ get; set; }
        public float Amount{ get; set; }


        private OrderResult(){
            OrderId = string.Empty;
            NetValue = 0;
            Iva = 0;
            TotalValue = 0;
            DiscountValue = 0;
            Amount = 0;
        }


        public static OrderResult CreateResults(){
            return new OrderResult();
        }

    }

}