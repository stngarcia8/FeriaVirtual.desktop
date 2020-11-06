using System;
using System.Collections.Generic;

namespace FeriaVirtual.Domain.Orders {

    public class Auction {
        public string AuctionID { get; set; }
        public DateTime AuctionDate { get; set; }
        public float Percent { get; set; }
        public float Value { get; set; }
        public float Weight { get; set; }
        public DateTime LimitDate { get; set; }
        public string Observation { get; set; }
        public string CarrierName { get; set; }
        public float BidValue { get; set; }
        public DateTime? BidValueDate { get; set; }
        public string DispachObservation { get; set; }
        public DateTime? DispachDate { get; set; }
        public string CompanyName { get; set; }
        public string Destination { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public IList<AuctionProduct> Products { get; set; }

        // Constructor
        private Auction() {
            InitializeObjects(Guid.NewGuid().ToString(),0,0,0);
        }

        private Auction(string auctionID,float value,float weight,int status) {
            InitializeObjects(auctionID,value,weight,status);
        }

        private void InitializeObjects(string auctionID,float value,float weight,int status) {
            AuctionID= auctionID;
            AuctionDate = DateTime.Now.Date;
            Value= value;
            Weight= weight;
            LimitDate = DateTime.Now.AddDays(15);
            Observation = string.Empty;
            CarrierName = string.Empty;
            BidValue= 0;
            BidValueDate = null;
            DispachObservation = string.Empty;
            DispachDate= null;
            CompanyName= string.Empty;
            Destination= string.Empty;
            PhoneNumber = string.Empty;
            Status= Status;
            Products = new List<AuctionProduct>();
        }

        // Named constructors
        public static Auction CreateAuction() {
            return new Auction();
        }

        public static Auction CreateAuction(string auctionID,float value,float weight,int status) {
            return new Auction(auctionID,value,weight,status);
        }

        public void AddProduct(AuctionProduct product) {
            Products.Add(product);
        }

        public void RemoveProduct(AuctionProduct product) {
            Products.Remove(product);
        }

        public override string ToString() {
            return string.Format("Valor {0}, peso {1}",Value,Weight);
        }
    }
}
