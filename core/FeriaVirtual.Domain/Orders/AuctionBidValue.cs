using System;


namespace FeriaVirtual.Domain.Orders{

    public class AuctionBidValue{

        public string ValueId{ get; set; }
        public string AuctionId{ get; set; }
        public string ClientId{ get; set; }
        public int Value{ get; set; }


        // Constructor
        private AuctionBidValue(){
            ValueId = Guid.NewGuid().ToString();
            AuctionId = string.Empty;
            ClientId = string.Empty;
            Value = 0;
        }


        // Named constructor
        public static AuctionBidValue CreateBidValue(){
            return new AuctionBidValue();
        }

    }

}