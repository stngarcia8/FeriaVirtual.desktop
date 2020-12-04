namespace FeriaVirtual.Domain.Dto{

    public class SalesProductDto{

        public string ProductName{ get; set; }
        public int Quantity{ get; set; }
        public float UnitPrice{ get; set; }
        public float ProductPrice{ get; set; }


        public SalesProductDto(){
            ProductName = string.Empty;
            Quantity = 0;
            UnitPrice = 0;
            ProductPrice = 0;
        }

    }

}