using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;

namespace FeriaVirtual.API.Controllers {

    public class ExternalOrderController:ApiController {
        private OrderUseCase usecase = OrderUseCase.CreateUseCase();

        [Route("api/v1/customer/external/orders/status/{statusID}/{customerID}")]
        [HttpGet]
        public IHttpActionResult GetAll(int statusID, string customerID) {
            if(string.IsNullOrEmpty(customerID)) {
                return BadRequest("Parámetros inválidos, el identificador del cliente es incorrecto.");
            }
            try {
                IList<OrderDto> orderList = new List<OrderDto>();
                orderList= usecase.GetOrderToPublish(statusID, customerID);
                if(orderList == null) {
                    return NotFound();
                }
                return Ok(orderList);
            } catch (Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }



        [Route("api/v1/customers/external/orders/add")]
        [HttpPost]
        public IHttpActionResult Post(OrderModel orderModel) {
            if(orderModel == null) {
                return BadRequest("Parámetros de orden de compra incorrectos.");
            }
            try {
                Order order = PutOrderModelIntoOrder(orderModel);
                usecase.NewOrder(order,order.ClientID);
                return Ok("Orden de compra almacenada correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("api/v1/customers/external/orders/edit")]
        [HttpPut]
        public IHttpActionResult Put(OrderModel orderModel) {
            if(orderModel == null) {
                return BadRequest("Parámetros de orden de compra incorrectos.");
            }
            try {
                Order order = PutOrderModelIntoOrder(orderModel);
                usecase.EditOrder(order,order.ClientID);
                return Ok("Orden de compra actualizada correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("api/v1/customers/external/orders/{orderID}")]
        [HttpDelete]
        public IHttpActionResult Delete(string orderID) {
            if(string.IsNullOrEmpty(orderID)) {
                return BadRequest("Parámetro inválido, el identificador del pedido es incorrecto.");
            }
            try {
                usecase.DeleteOrder(orderID);
                return Ok("El pedido ha sido eliminado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        private Order PutOrderModelIntoOrder(OrderModel orderModel) {
            Order o = Order.CreateOrder();
            o.OrderID = orderModel.OrderID;
            o.ClientID= orderModel.ClientID;
            o.Condition.ConditionID = orderModel.ConditionId;
            o.Condition.ConditionDescription= orderModel.ConditionDescription;
            o.OrderDiscount = orderModel.OrderDiscount;
            o.Observation = orderModel.Observation;
            o.OrderDetailList = orderModel.OrderDetail;
            return o;
        }
    }
}
