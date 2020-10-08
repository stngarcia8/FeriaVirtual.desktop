using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.API.Controllers {

    public class ProductController:ApiController {


        [HttpGet]
        public IHttpActionResult Get(string productID) {
            if(string.IsNullOrEmpty(productID)) {
                return BadRequest("Parámetro inválido, el id del producto es incorrecto");
            }
            try {
                ProducerUseCase usecase = ProducerUseCase.CreateUseCase();
                Product product = usecase.FindProductByID(productID);
                return Ok(product);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpGet]
        public IHttpActionResult GetAll(string clientID) {
            if(string.IsNullOrEmpty(clientID)) {
                return BadRequest("Parámetro inválido, el id del cliente es incorrecto");
            }
            try {
                ProducerUseCase usecase = ProducerUseCase.CreateUseCase();
                IList<Product> productList = usecase.FindAllProducts(clientID);
                return Ok(productList);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpPost]
        public IHttpActionResult Post(Product product) {
            if( product==null) {
                return BadRequest("Parámetros inválidos, los datos del producto son incorrectos");
            }
            try {
                string newID = Guid.NewGuid().ToString();
                product.ProductID = newID;
                ProducerUseCase usecase = ProducerUseCase.CreateUseCase();
                usecase.NewProduct(product,product.ClientID);
                return Ok("Producto almacenado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpPut]
        public IHttpActionResult Put(Product product) {
            if(product==null) {
                return BadRequest("Parámetro inválido, los datos del producto son  incorrectos");
            }
            try {
                ProducerUseCase usecase = ProducerUseCase.CreateUseCase();
                usecase.EditProduct(product);
                return Ok("Producto actualizado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }



        [HttpDelete]
        public IHttpActionResult Delete(string productID) {
            if(string.IsNullOrEmpty(productID)) {
                return BadRequest("Parámetro inválido, el id de producto es incorrecto");
            }
            try {
                ProducerUseCase usecase = ProducerUseCase.CreateUseCase();
                usecase.DeleteProduct(productID);
                return Ok("Producto eliminado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

    }

}
