using System;
using System.Collections.Generic;


namespace FeriaVirtual.Domain.Orders{

    public class OrderDispatch{

        public string DispatchId{ get; set; }
        public string OrderId{ get; set; }
        public string ClientId{ get; set; }
        public string ClientName{ get; set; }
        public string CarrierId{ get; set; }
        public string CarrierName{ get; set; }
        public string CarrierEmail{ get; set; }
        public DateTime PreparationDate{ get; set; }
        public string DispatchDate{ get; set; }
        public float DispatchValue{ get; set; }
        public float DispatchWeight{ get; set; }
        public string Observation{ get; set; }
        public string CompanyName{ get; set; }
        public string Destination{ get; set; }
        public string PhoneNumber{ get; set; }
        public int Status{ get; set; }
        public Safe Safe{ get; set; }
        public IList<OrderDispatchDetail> Products{ get; set; }


        private OrderDispatch(){
            DispatchId = Guid.NewGuid().ToString();
            OrderId = string.Empty;
            ClientId = string.Empty;
            ClientName = string.Empty;
            CarrierId = string.Empty;
            CarrierName = string.Empty;
            CarrierEmail = string.Empty;
            PreparationDate = DateTime.Now.Date;
            DispatchDate = string.Empty;
            DispatchValue = 0;
            DispatchWeight = 0;
            Observation = string.Empty;
            CompanyName = string.Empty;
            Destination = string.Empty;
            PhoneNumber = string.Empty;
            Status = 0;
            Safe = Safe.CreateSafe();
            Products = new List<OrderDispatchDetail>();
        }


        public static OrderDispatch CreateOrder(){
            return new OrderDispatch();
        }

    }

}