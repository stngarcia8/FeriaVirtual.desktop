using FeriaVirtual.Data.Repository;
using System.Collections.Generic;
using System;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Users {

    public class ProducerUseCase {

        private ProducerRepository repository;


        // Constructor
        private ProducerUseCase() {
            repository= ProducerRepository.OpenRepository();
        }


        // Named constructor
        public static ProducerUseCase CreateUseCase() {
            return new ProducerUseCase();
        }


        public Producer FindProducerById(string producerID) {
            repository.FindById( producerID );
            return repository.Producer;
        }

        public void NewProduct(Product product, string clientID) {
            try {
                ProductValidator validator = ProductValidator.CreateValidator( product,false );
                validator.Validate();
                repository.NewProduct( product,clientID );
            } catch (Exception ex) {
                throw ex;
            }
        }


        public void EditProduct(Product product) {
            try {
                ProductValidator validator = ProductValidator.CreateValidator( product,true);
                validator.Validate();
                repository.EditProduct( product);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void DeleteProduct(string productID) {
            try {
                repository.DeleteProduct(productID);
            } catch(Exception ex) {
                throw ex;
            }
        }


        public Product FindProductByID(string productID) {
            Product product = Product.CreateProduct();
            try {
                product =  repository.FindProductByID( productID );
            } catch(Exception ex) {
                product = null;
                throw ex;
            }
            return product;
        }


        public IList<Product> FindAllProducts(string clientID) {
            IList<Product> productList = new List<Product>();
            try {
                productList= repository.FindAllProducts( clientID );
            } catch(Exception ex) {
                productList= null;
                throw ex;
            }
            return productList;
        }


    }

}
