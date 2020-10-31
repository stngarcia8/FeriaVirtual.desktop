using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Products;

namespace FeriaVirtual.API.Controllers {

    public class ProductController:ApiController {
        private ProducerUseCase usecase = ProducerUseCase.CreateUseCase();

        /// <summary>
        /// Obtiene un producto  desde la base de datos.
        /// </summary>
        /// <param name="productID">
        /// Identificador del producto a buscar
        /// </param>
        /// <returns>
        /// &gt;Product&gt; - Objeto producto con la información correspondiente. Badrequest - Si
        /// los parámetros son inválidos.
        /// </returns>
        [Route("api/v1/products/{productID}")]
        [HttpGet]
        public IHttpActionResult Get(string productID) {
            if(string.IsNullOrEmpty(productID)) {
                return BadRequest("Parámetro inválido, el id del producto es incorrecto");
            }
            try {
                return Ok(usecase.FindProductByID(productID));
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Devuelve la lista de productos asociados a un productor.
        /// </summary>
        /// <param name="clientID">
        /// corresponde al identificador del productor.
        /// </param>
        /// <returns>
        /// Ok, con los productos asociados al productor.
        /// Badrequest, si los parámetros enviados son incorrectos.
        /// </returns>
        [Route("api/v1/products/all/{clientID}")]
        [HttpGet]
        public IHttpActionResult GetAll(string clientID) {
            if(string.IsNullOrEmpty(clientID)) {
                return BadRequest("Parámetro inválido, el id del cliente es incorrecto");
            }
            try {
                IList<Product> productList = usecase.FindAllProducts(clientID);
                return Ok(productList);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Devuelve la lista de los productos de exportacion
        /// </summary>
        /// <returns>
        /// Ok, con los productos del exportación
        /// Badrequest, si los parámetros enviados son incorrectos.
        /// </returns>
        [Route("api/v1/products/export/all/")]
        [HttpGet]
        public IHttpActionResult GetAllExportProducts() {
            try {
                IList<ProductDto> productList = usecase.FindAllProductByCategory(1);
                return Ok(productList);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Obtiene los productos para los clientes internos de la plataforma.
        /// </summary>
        /// <returns>
        /// Ok, con la lista de productos para clientes internos,
        /// badrequest, si ocurre algun problema.
        /// </returns>
        [Route("api/v1/products/import/all/")]
        [HttpGet]
        public IHttpActionResult GetAllImportProducts() {
            try {
                IList<ProductDto> productList = usecase.FindAllProductByCategory(2);
                return Ok(productList);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Carga los productos en oferta a los clientes internos.
        /// </summary>
        /// <returns>
        /// Ok, con la lista de productos en oferta, 
        /// Badrequest si es invalido
        /// </returns>
        [Route("api/v1/products/offer/all/")]
        [HttpGet]
        public IHttpActionResult GetAllOfferProducts() {
            try {
                IList<ProductDto> productList = usecase.FindAllProductByCategory(3);
                return Ok(productList);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Almacena un nuevo producto para el productor.
        /// </summary>
        /// <param name="product">
        /// Objeto que contiene la información del producto a grabar.
        /// </param>
        /// <returns>
        /// Ok - cuando el producto fue almacenado correctamente. Badrequest - si los párametros
        /// enviados son inválidos.
        /// </returns>
        [Route("api/v1/products/")]
        [HttpPost]
        public IHttpActionResult Post(Product product) {
            if(product==null) {
                return BadRequest("Parámetros inválidos, los datos del producto son incorrectos");
            }
            try {
                usecase.NewProduct(product,product.ClientID);
                return Ok("Producto almacenado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Actualiza la información de un producto
        /// </summary>
        /// <param name="product">
        /// Objeto que contiene la información del producto.
        /// </param>
        /// <returns>
        /// Ok - cuando el producto se actualiza correctamente. Badrequest - en caso de enviar
        /// parámetros inválidos.
        /// </returns>
        [Route("api/v1/products/")]
        [HttpPut]
        public IHttpActionResult Put(Product product) {
            if(product==null) {
                return BadRequest("Parámetro inválido, los datos del producto son  incorrectos");
            }
            try {
                usecase.EditProduct(product);
                return Ok("Producto actualizado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Elimina un producto asociado a un productor.
        /// </summary>
        /// <param name="productID">
        /// Corresponde al identificador del producto que se desea eliminar.
        /// </param>
        /// <returns>
        /// Ok - al eliminar el producto satisfactoriamente. Badrequest - si el parámetro solicitado
        /// es inválido.
        /// </returns>
        [Route("api/v1/products/{productID}")]
        [HttpDelete]
        public IHttpActionResult Delete(string productID) {
            if(string.IsNullOrEmpty(productID)) {
                return BadRequest("Parámetro inválido, el id de producto es incorrecto");
            }
            try {
                usecase.DeleteProduct(productID);
                return Ok("Producto eliminado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
