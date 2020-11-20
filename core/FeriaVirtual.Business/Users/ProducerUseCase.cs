using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Products;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Users{

    public class ProducerUseCase{

        private readonly ProducerRepository repository;


        // Constructor
        private ProducerUseCase(){
            repository = ProducerRepository.OpenRepository();
        }


        // Named constructor
        public static ProducerUseCase CreateUseCase(){
            return new ProducerUseCase();
        }


        public Producer FindProducerById(string producerId){
            repository.FindById(producerId);
            return repository.Producer;
        }


        public void NewProduct(Product product, string clientId){
            IValidator validator = ProductValidator.CreateValidator(product, false);
            validator.Validate();
            repository.NewProduct(product, clientId);
        }


        public void EditProduct(Product product){
            IValidator validator = ProductValidator.CreateValidator(product, true);
            validator.Validate();
            repository.EditProduct(product);
        }


        public void DeleteProduct(string productId){
            repository.DeleteProduct(productId);
        }


        public Product FindProductById(string productId){
            var product = repository.FindProductById(productId);
            return product;
        }


        public IList<Product> FindAllProducts(string clientId){
            var productList = repository.FindAllProducts(clientId);
            return productList;
        }


        public IList<ProductDto> FindAllProductByCategory(int categoryId){
            // var productList = repository.(categoryId);
            // return productList;
            return null;
        }


        public DataTable SearchProductByCategory(int categoryId){
            repository.SearchProductByCategory(categoryId);
            return repository.DataSource;
        }




    }

}