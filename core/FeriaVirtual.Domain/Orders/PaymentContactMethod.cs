namespace FeriaVirtual.Domain.Orders{

    public class PaymentContactMethod{

        public string CustomerName{ get; set; }
        public string CustomerEmail{ get; set; }


        private PaymentContactMethod(){
            CustomerName = string.Empty;
            CustomerEmail = string.Empty;
        }


        public static PaymentContactMethod Create(){
            return new PaymentContactMethod();
        }


        public override string ToString(){
            return CustomerName;
        }

    }

}