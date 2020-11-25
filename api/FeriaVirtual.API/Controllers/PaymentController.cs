using System;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{


    /// <summary>
    ///  Controlador para los pagos de productos.
    /// </summary>
    public class PaymentController : ApiController
    {

        private PaymentUsecase usecase;



        /// <summary>
        ///  Permite registrar el pago de los productos.
        /// </summary>
        /// <param name="payment">
        ///Objeto que contiene la información del pago.
        /// </param>
        /// <returns>
        ///Ok si el pago fue registrado correctamente,
        /// badrequest en caso de error.
        /// </returns>
        [Route("api/v1/payments/new")]
        [HttpPost]
        public IHttpActionResult Post(Payment payment){
            if (payment == null){
                return BadRequest("Parámetros de pago inválidos.");
            }
            try{
                usecase = PaymentUsecase.CreateUsecase();
                usecase.NewPayment(payment);
                return Ok("Pago realizado correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message.ToString());
            }
        }


    }
}
