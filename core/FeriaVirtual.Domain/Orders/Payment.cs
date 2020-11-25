using System;


namespace FeriaVirtual.Domain.Orders{

    public class Payment{

        public string PaymentId{ get; set; }
        public PaymentMethod PaymentMethod{ get; set; }
        public string OrderId{ get; set; }
        public DateTime PaymentDate{ get; set; }
        public float Amount{ get; set; }
        public string Observation{ get; set; }


        private Payment(){
            PaymentId = Guid.NewGuid().ToString();
            PaymentMethod = PaymentMethod.CreatePaimentMethod();
            OrderId = string.Empty;
            PaymentDate = DateTime.Now.Date;
            Amount = 0;
            Observation = string.Empty;
        }


        public static Payment CreatePayment(){
            return new Payment();
        }

    }

}