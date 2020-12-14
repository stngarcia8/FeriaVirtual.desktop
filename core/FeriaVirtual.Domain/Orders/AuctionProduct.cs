﻿namespace FeriaVirtual.Domain.Orders{

    public class AuctionProduct{

        public string Product{ get; set; }
        public float UnitValue{ get; set; }
        public float Quantity{ get; set; }
        public float TotalValue{ get; set; }


        private AuctionProduct(){
            Product = string.Empty;
            UnitValue = 0;
            Quantity = 0;
            TotalValue = 0;
        }


        public static AuctionProduct CreateAuctionProduct(){
            return new AuctionProduct();
        }

    }

}