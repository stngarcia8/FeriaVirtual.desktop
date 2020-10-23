namespace FeriaVirtual.Domain.Products {

    public class ProductDto {

        // Properties
        public string ProductName { get; set; }

        // Constructors
        private ProductDto() {
            ProductName = string.Empty;
        }

        public ProductDto(string productName) {
            ProductName = productName;
        }

        public override string ToString() {
            return ProductName;
        }
    }
}
