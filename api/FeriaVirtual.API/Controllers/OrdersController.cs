using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.API.Controllers{

    /// <summary>
    ///     Controlador para el manejo de las ordenes de compra.
    /// </summary>
    public class OrdersController : ApiController{

        private readonly OrderUseCase usecase = OrderUseCase.CreateUseCase();


        /// <summary>
        ///     Obtiene el listado de las ordenes de compra realizadas por un cliente.
        /// </summary>
        /// <param name="statusID">
        ///     Indica el estado de las ordenes que se quiere listar.
        /// </param>
        /// <param name="customerId">
        ///     Corresponde al identificador del cliente que se desea listar sus ordenes realizadas.
        /// </param>
        /// <returns>
        ///     Ok y la lista de ordenes del cliente,
        ///     Notfound si no encuentra ordenes del cliente y
        ///     badrequest si ocurrió algún error en el proceso.
        /// </returns>
        [Route("api/v1/customers/orders/status/{statusID}/{customerId}")]
        [HttpGet]
        public IHttpActionResult GetAll(int statusID, string customerId){
            if (string.IsNullOrEmpty(customerId))
                return BadRequest("Parámetros inválidos, el identificador del cliente es incorrecto.");
            try{
                IList<OrderDto> orderList = new List<OrderDto>();
                orderList = usecase.GetOrderToPublish(statusID, customerId);
                if (orderList == null) return NotFound();
                return Ok(orderList);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Almacena una orden
        /// </summary>
        /// <param name="orderModel">
        ///     objeto con la información de la orden.
        /// </param>
        /// <returns>
        ///     Ok si la orden se almaceno correctamente,
        ///     badrequest si ocurrió algún error en el proceso.
        /// </returns>
        [Route("api/v1/customers/orders/add")]
        [HttpPost]
        public IHttpActionResult Post(OrderModel orderModel){
            if (orderModel == null) return BadRequest("Parámetros de orden de compra incorrectos.");
            try{
                var order = PutOrderModelIntoOrder(orderModel);
                usecase.NewOrder(order, order.ClientId);
                return Ok("Orden de compra almacenada correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Almacena una orden de compra.
        /// </summary>
        /// <param name="orderModel">
        ///     Objeto que contiene la información de la orden de compra a grabar.
        /// </param>
        /// <returns>
        ///     Ok si la orden se grabo correctamente,
        ///     badrequest si ocurrió algún error en el proceso.
        /// </returns>
        [Route("api/v1/customers/orders/edit")]
        [HttpPut]
        public IHttpActionResult Put(OrderModel orderModel){
            if (orderModel == null) return BadRequest("Parámetros de orden de compra incorrectos.");
            try{
                var order = PutOrderModelIntoOrder(orderModel);
                usecase.EditOrder(order, order.ClientId);
                return Ok("Orden de compra actualizada correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Elimina una orden de despacho
        /// </summary>
        /// <param name="orderId">
        ///     Corresponde al identificador de la orden de compra a eliminar.
        /// </param>
        /// <returns>
        ///     Ok si la orden de compra se elimino crrectamente,
        ///     badrequest si ocurrió algún error en el proceso.
        /// </returns>
        [Route("api/v1/customers/orders/{orderId}")]
        [HttpDelete]
        public IHttpActionResult Delete(string orderId){
            if (string.IsNullOrEmpty(orderId))
                return BadRequest("Parámetro inválido, el identificador del pedido es incorrecto.");
            try{
                usecase.DeleteOrder(orderId);
                return Ok("El pedido ha sido eliminado correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        private Order PutOrderModelIntoOrder(OrderModel orderModel){
            var o = Order.CreateOrder();
            o.OrderId = orderModel.OrderId;
            o.ClientId = orderModel.ClientId;
            o.Condition.ConditionId = orderModel.ConditionId;
            o.Condition.ConditionDescription = orderModel.ConditionDescription;
            o.OrderDiscount = orderModel.OrderDiscount;
            o.Observation = orderModel.Observation;
            o.OrderDetailList = orderModel.OrderDetail;
            return o;
        }

    }

}