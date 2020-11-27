using System;


namespace FeriaVirtual.Domain.Orders{

    public class PaymentResult{

        public string PaymentResultId{ get; set; }
        public string PaymentId{ get; set; }
        public string ClientId{get;set;}
        public DateTime SalesDate{ get; set; }
        public int Quantity{ get; set; }
        public string ProductName{ get; set; }
        public float UnitPrice{ get; set; }
        public float ProductPrice{ get; set; }
        public string ProducerName{ get; set; }
        public string ProducerEmail{ get; set; }


        private PaymentResult(){
            InitializeObjects();
        }


        public static PaymentResult CreateResult(){
            return new PaymentResult();
        }


        private void InitializeObjects(){
            PaymentResultId = Guid.NewGuid().ToString();
            PaymentId = string.Empty;
            SalesDate = DateTime.Now.Date;
            Quantity = 0;
            ProductName = string.Empty;
            UnitPrice = 0;
            ProductPrice = 0;
            ClientId = string.Empty;
            ProducerName = string.Empty;
            ProducerEmail = string.Empty;
        }

    }

}