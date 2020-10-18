using System;
using System.Collections.Generic;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {

    public class ProducerUseCase {
        private readonly ProducerRepository repository;

        // Constructor
        private ProducerUseCase() {
            repository= ProducerRepository.OpenRepository();
        }

        // Named constructor
        public static ProducerUseCase CreateUseCase() {
            return new ProducerUseCase();
        }

        public Producer FindProducerById(string producerID) {
            repository.FindById(producerID);
            return repository.Producer;
        }

        public void NewProduct(Product product,string clientID) {
            try {
                IValidator validator = ProductValidator.CreateValidator(product,false);
                validator.Validate();
                repository.NewProduct(product,clientID);
            } catch(Exception ex) {
                throw;
            }
        }

        public void EditProduct(Product product) {
            try {
                IValidator validator = ProductValidator.CreateValidator(product,true);
                validator.Validate();
                repository.EditProduct(product);
            } catch(Exception ex) {
                throw;
            }
        }

        public void DeleteProduct(string productID) {
            try {
                repository.DeleteProduct(productID);
            } catch(Exception ex) {
                throw;
            }
        }

        public Product FindProductByID(string productID) {
            Product product;
            try {
                product =  repository.FindProductByID(productID);
            } catch(Exception ex) {
                throw;
            }
            return product;
        }

        public IList<Product> FindAllProducts(string clientID) {
            IList<Product> productList;
            try {
                productList= repository.FindAllProducts(clientID);
            } catch(Exception ex) {
                throw;
            }
            return productList;
        }
    }
}