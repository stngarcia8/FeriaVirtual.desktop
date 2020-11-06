using System;
using FeriaVirtual.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeriaVirtual.API.Models {

    public class AuctionModel {

        public string AuctionID { get; set; }
        public string AuctionDate { get; set; }
        public float Percent { get; set; }
        public float Value { get; set; }
        public float Weight { get; set; }
        public string LimitDate { get; set; }
        public string Observation { get; set; }
        public string CompanyName { get; set; }
        public string Destination { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }
        public IList<AuctionProduct> Products { get; set; }


    }

}