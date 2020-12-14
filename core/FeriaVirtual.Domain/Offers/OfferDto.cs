using System.Collections.Generic;


namespace FeriaVirtual.Domain.Offers{

    public class OfferDto{

        public string OfferId{ get; set; }
        public string Description{ get; set; }
        public float Discount{ get; set; }
        public int OfferType{ get; set; }
        public string TypeDescription{ get; set; }
        public string PublishDate{ get; set; }
        public int Status{ get; set; }
        public string StatusDescription{ get; set; }
        public IList<OfferDetail> Details{ get; set; }


        public OfferDto(){
            Details = new List<OfferDetail>();
        }

    }

}