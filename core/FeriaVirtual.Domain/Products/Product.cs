using System;


namespace FeriaVirtual.Domain.Products{

    public class Product{

        // Properties.
        public string ProductId{ get; set; }
        public string ClientId{ get; set; }
        public string ProductName{ get; set; }
        public ProductCategory Category{ get; set; }
        public float ProductValue{ get; set; }
        public float ProductQuantity{ get; set; }
        public string Observation{ get; set; }


        // constructors
        private Product(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, string.Empty, 0, 0);
        }


        private Product(string productId, string clientId, string productName, float productValue,
            float productQuantity){
            InitializeObjects(productId, clientId, productName, productValue, productQuantity);
        }


        private void InitializeObjects(string productId, string clientId, string productName, float productValue,
            float productQuantity){
            ProductId = productId;
            ClientId = clientId;
            ProductName = productName;
            ProductValue = productValue;
            ProductQuantity = productQuantity;
            Category = ProductCategory.CreateCategory();
            Observation = string.Empty;
        }


        // Named constructors.
        public static Product CreateProduct(){
            return new Product();
        }


        public static Product CreateProduct(string productId, string clientId, string productName, float productValue,
            float productQuantity){
            return new Product(productId, clientId, productName, productValue, productQuantity);
        }


        public override string ToString(){
            return ProductName;
        }

    }

}