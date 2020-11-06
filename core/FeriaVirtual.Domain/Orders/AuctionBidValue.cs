using System;

namespace FeriaVirtual.Domain.Orders {

    public class AuctionBidValue {
        public string ValueID { get; set; }
        public string AuctionID { get; set; }
        public string ClientID { get; set; }
        public int Value { get; set; }

        // Constructor
        private AuctionBidValue() {
            ValueID = Guid.NewGuid().ToString();
            AuctionID = string.Empty;
            ClientID = string.Empty;
            Value= 0;
        }

        // Named constructor
        public static AuctionBidValue CreateBidValue() {
            return new AuctionBidValue();
        }
    }
}
