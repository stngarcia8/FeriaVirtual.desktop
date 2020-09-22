using System;

namespace FeriaVirtual.Domain.Elements {

    public class Product {

        // Properties.
        public string ProductID { get; set; }
        public string ClientID { get; set; }
        public string ProductName { get; set; }
        public string Observation { get; set; }
        public float ProductValue { get; set; }
        public float ProductQuantity { get; set; }


        // constructors
        private Product() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,string.Empty,0,0 );
        }

        private Product(string productID,string clientID,string productName,float productValue,float productQuantity) {
            InitializeObjects( productID,clientID,productName,productValue,productQuantity );
        }


        private void InitializeObjects(string productID,string clientID,string productName,float productValue,float productQuantity) {
            ProductID=productID;
            ClientID=clientID;
            ProductName=productName;
            Observation= string.Empty;
            ProductValue= productValue;
            ProductQuantity=productQuantity;
        }


        // Named constructors.
        public static Product CreateProduct() {
            return new Product();
        }

        public static Product CreateProduct(string productID,string clientID,string productName,float productValue,float productQuantity) {
            return new Product( productID,clientID,productName,productValue,productQuantity );
        }


        public override string ToString() {
            return ProductName;
        }








    }
}
