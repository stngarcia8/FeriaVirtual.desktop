using System;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Elements;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{

    public class OrderController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(Order order) {
            if(order==null) {
                return BadRequest("Parámetros inválidos, los datos de la solicitud son incorrectos");
            }
            try {
                string newID = Guid.NewGuid().ToString();
                order.OrderID = newID;
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                usecase.NewOrder(order,order.ClientID);
                return Ok("solicitud almacenada correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut]
        public IHttpActionResult Put(Order order) {
            if(order==null) {
                return BadRequest("Parámetros inválidos, los datos de la solicitud son incorrectos");
            }
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                usecase.EditOrder(order,order.ClientID);
                return Ok("solicitud actualizada correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


    }


}
