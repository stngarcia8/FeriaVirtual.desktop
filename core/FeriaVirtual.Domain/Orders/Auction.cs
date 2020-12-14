using System;
using System.Collections.Generic;


namespace FeriaVirtual.Domain.Orders{

    public class Auction{

        public string AuctionId{ get; set; }
        public DateTime AuctionDate{ get; set; }
        public float Percent{ get; set; }
        public float Value{ get; set; }
        public float Weight{ get; set; }
        public DateTime LimitDate{ get; set; }
        public string Observation{ get; set; }
        public string CarrierId{ get; set; }
        public string CarrierName{ get; set; }
        public float BidValue{ get; set; }
        public DateTime? BidValueDate{ get; set; }
        public string DispachObservation{ get; set; }
        public DateTime? DispachDate{ get; set; }
        public string CompanyName{ get; set; }
        public string Destination{ get; set; }
        public string Email{ get; set; }
        public string PhoneNumber{ get; set; }
        public int Status{ get; set; }
        public IList<AuctionProduct> Products{ get; set; }


        private Auction(){
            InitializeObjects(Guid.NewGuid().ToString(), 0, 0, 0);
        }


        private Auction(string auctionId, float value, float weight, int status){
            InitializeObjects(auctionId, value, weight, status);
        }


        private void InitializeObjects(string auctionId, float value, float weight, int status){
            AuctionId = auctionId;
            AuctionDate = DateTime.Now.Date;
            Value = value;
            Weight = weight;
            LimitDate = DateTime.Now.AddDays(15);
            Observation = string.Empty;
            CarrierId = string.Empty;
            CarrierName = string.Empty;
            BidValue = 0;
            BidValueDate = null;
            DispachObservation = string.Empty;
            DispachDate = null;
            CompanyName = string.Empty;
            Destination = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Status = status;
            Products = new List<AuctionProduct>();
        }


        public static Auction CreateAuction(){
            return new Auction();
        }


        public static Auction CreateAuction(string auctionId, float value, float weight, int status){
            return new Auction(auctionId, value, weight, status);
        }


        public void AddProduct(AuctionProduct product){
            Products.Add(product);
        }


        public void RemoveProduct(AuctionProduct product){
            Products.Remove(product);
        }


        public override string ToString(){
            return $"Valor {Value}, peso {Weight}";
        }

    }

}