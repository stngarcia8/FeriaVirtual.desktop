namespace FeriaVirtual.Domain.Orders{

    public class PaymentMethod{

        public int MethodId{ get; set; }
        public string MethodDescription{ get; set; }


        private PaymentMethod(){
            MethodId = 0;
            MethodDescription = string.Empty;
        }


        public static PaymentMethod CreatePaimentMethod(){
            return new PaymentMethod();
        }


        public override string ToString(){
            return MethodDescription;
        }

    }

}