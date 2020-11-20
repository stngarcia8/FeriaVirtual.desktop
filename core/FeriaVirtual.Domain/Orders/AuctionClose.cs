namespace FeriaVirtual.Domain.Orders{

    public class AuctionClose{

        public string AuctionId{ get; set; }
        public int Status{ get; set; }


        private AuctionClose(string auctionId, int status){
            AuctionId = auctionId;
            Status = status;
        }


        public static AuctionClose CloseAuction(string auctionId, int status){
            return new AuctionClose(auctionId, status);
        }

    }

}