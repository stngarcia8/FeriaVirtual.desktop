using System.Collections.Generic;
using FeriaVirtual.Domain.Products;


namespace FeriaVirtual.Domain.Users{

    public class Producer : Person{

        // Properties
        public IList<Product> ProductList{ get; set; }


        // constructors
        private Producer(){
            ProductList = new List<Product>();
        }


        private Producer(string id, string firstName, string lastName, string dni) :
            base(id, firstName, lastName, dni){
            ProductList = new List<Product>();
        }


        // Named constructors.
        public static Producer CreateProducer(){
            return new Producer();
        }


        public static Producer CreateProducer(string id, string firstName, string lastName, string dni){
            return new Producer(id, firstName, lastName, dni);
        }


        public void AddProduct(Product product){
            ProductList.Add(product);
        }


        public void RemoveProduct(Product product){
            ProductList.Remove(product);
        }

    }

}