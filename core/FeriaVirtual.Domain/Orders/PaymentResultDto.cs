using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Domain.Orders {
    public class PaymentResultDto {

        public string PaymentId{ get; set; }
        public string ClientId{get;set;}
        public string SalesDate{ get; set; }
        public int Quantity{ get; set; }
        public string ProductName{ get; set; }
        public float UnitPrice{ get; set; }
        public float ProductPrice{ get; set; }


        public PaymentResultDto(){
            PaymentId = string.Empty;
            ClientId = string.Empty;
            SalesDate = string.Empty;
            Quantity = 0;
            ProductName = string.Empty;
            UnitPrice = 0;
            ProductPrice = 0;
        }



    }
}
