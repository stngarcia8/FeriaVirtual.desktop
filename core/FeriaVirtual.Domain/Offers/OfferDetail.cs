using System;


namespace FeriaVirtual.Domain.Offers{

    public class OfferDetail{

        public string OfferDetailId{ get; set; }
        public string ProductId{ get; set; }
        public string ProductName{ get; set; }
        public float ActualValue{ get; set; }
        public string Percent{ get; set; }
        public float OfferValue{ get; set; }


        private OfferDetail(){
            OfferDetailId = Guid.NewGuid().ToString();
            ProductId = string.Empty;
            ProductName = string.Empty;
            ActualValue = 0;
            Percent = string.Empty;
            OfferValue = 0;
        }


        public static OfferDetail CreateDetail(){
            return new OfferDetail();
        }

    }

}