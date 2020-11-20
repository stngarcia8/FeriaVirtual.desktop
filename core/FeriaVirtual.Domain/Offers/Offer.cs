using System;
using System.Collections.Generic;


namespace FeriaVirtual.Domain.Offers{

    public class Offer{

        public string OfferId{ get; set; }
        public string Description{ get; set; }
        public float Discount{ get; set; }
        public int OfferType{ get; set; }
        public DateTime PublishDate{ get; set; }
        public int Status{ get; set; }
        public IList<OfferDetail> Details{ get; set; }


        private Offer(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, 0, 1);
        }


        public Offer(string offerId, string description, float discount, int offerType){
            InitializeObjects(offerId, description, discount, offerType);
        }


        private void InitializeObjects(string offerId, string description, float discount, int offerType){
            OfferId = offerId;
            Description = description;
            Discount = discount;
            OfferType = offerType;
            PublishDate = DateTime.Now.Date;
            Status = 1;
            Details = new List<OfferDetail>();
        }


        public static Offer CreateOffer(){
            return new Offer();
        }


        public static Offer CreateOffer(string offerId, string description, float discount, int offerType){
            return new Offer(offerId, description, discount, offerType);
        }


        public void AddDetail(OfferDetail detail){
            Details.Add(detail);
        }


        public void RemoveDetail(OfferDetail detail){
            Details.Remove(detail);
        }


        public override string ToString(){
            return Description;
        }

    }

}