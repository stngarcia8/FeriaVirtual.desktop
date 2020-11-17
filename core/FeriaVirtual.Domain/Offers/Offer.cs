using System;
using System.Collections.Generic;


namespace FeriaVirtual.Domain.Offers{

    public class Offer{

        public string OfferId{ get; set; }
        public string Description{ get; set; }
        public float Discount{ get; set; }
        public DateTime PublishDate{ get; set; }
        public int Status{ get; set; }
        public IList<OfferDetail> Details{ get; set; }


        private Offer(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, 0);
        }


        public Offer(string offerId, string description, float discount){
            InitializeObjects(offerId, description, discount);
        }


        private void InitializeObjects(string offerId, string description, float discount){
            OfferId = offerId;
            Description = description;
            Discount = discount;
            PublishDate = DateTime.Now.Date;
            Status = 1;
            Details = new List<OfferDetail>();
        }


        public static Offer CreateOffer(){
            return new Offer();
        }


        public static Offer CreateOffer(string offerId, string description, float discount){
            return new Offer(offerId, description, discount);
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