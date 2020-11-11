namespace FeriaVirtual.Domain.Products{

    public class ProductCategory{

        // Properties
        public int CategoryId{ get; set; }
        public string CategoryName{ get; set; }


        // Constructor.
        private ProductCategory(){
            CategoryId = 0;
            CategoryName = string.Empty;
        }


        // Named constructor.
        public static ProductCategory CreateCategory(){
            return new ProductCategory();
        }


        public override string ToString(){
            return CategoryName;
        }

    }

}