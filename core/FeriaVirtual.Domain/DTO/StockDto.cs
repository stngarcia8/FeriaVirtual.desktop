namespace FeriaVirtual.Domain.Dto{

    public class StockDto{

        public string ProductId{ get; set; }
        public int Stock{ get; set; }


        public StockDto(){
            ProductId = string.Empty;
            Stock = 0;
        }

    }

}