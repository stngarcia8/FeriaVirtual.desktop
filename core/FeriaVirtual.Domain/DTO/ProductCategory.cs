namespace FeriaVirtual.Domain.Dto {

    public class ProductCategory {

        // Properties
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Constructor.
        private ProductCategory() {
            CategoryID= 0;
            CategoryName= string.Empty;
        }

        // Named constructor.
        public static ProductCategory CreateCategory() {
            return new ProductCategory();
        }

        public override string ToString() {
            return CategoryName;
        }
    }
}
