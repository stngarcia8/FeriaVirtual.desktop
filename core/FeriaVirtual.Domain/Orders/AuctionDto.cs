using System.Collections.Generic;


namespace FeriaVirtual.Domain.Orders{

    public class AuctionDto{

        public string AuctionId{ get; set; }
        public string AuctionDate{ get; set; }
        public float Percent{ get; set; }
        public float Value{ get; set; }
        public float Weight{ get; set; }
        public string LimitDate{ get; set; }
        public string Observation{ get; set; }
        public string CompanyName{ get; set; }
        public string Destination{ get; set; }
        public string PhoneNumber{ get; set; }
        public int Status{ get; set; }
        public IList<AuctionProduct> Products{ get; set; }


        public AuctionDto(){
            InitializeObjects();
        }


        private void InitializeObjects(){
            AuctionId = string.Empty;
            AuctionDate = string.Empty;
            Percent = 0;
            Value = 0;
            Weight = 0;
            LimitDate = string.Empty;
            Observation = string.Empty;
            CompanyName = string.Empty;
            Destination = string.Empty;
            PhoneNumber = string.Empty;
            Status = 0;
            Products = new List<AuctionProduct>();
        }

    }

}