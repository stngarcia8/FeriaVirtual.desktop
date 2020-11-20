using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.API.Controllers{

    /// <summary>
    ///     Controlador para las ordenes de despacho de productos.
    /// </summary>
    public class OrderDispatchController : ApiController{

        private readonly OrderDispatchUseCase usecase = OrderDispatchUseCase.CreateUseCase();


        /// <summary>
        ///     Obtiene las ordenes de despacho de los transportistas.
        /// </summary>
        /// <param name="clientId">
        ///     Corresponde al identificador del transportista que despachará los productos.
        /// </param>
        /// <returns>
        ///     Ok y la lista de ordenes de despachos asociados al transportista,
        ///     notfound si no encuentra orden alguna del transportista y
        ///     badrequest si ocurre algún error en el proceso.
        /// </returns>
        [Route("api/v1/dispatchorders/available/{clientId}")]
        [HttpGet]
        public IHttpActionResult GetAllDispatchOrders(string clientId){
            if (string.IsNullOrEmpty(clientId)) return BadRequest("Identificador de transportista inválido.");
            try{
                IList<OrderDispatch> orderList = new List<OrderDispatch>();
                IList<OrderDispatchModel> dispatchorders = new List<OrderDispatchModel>();
                orderList = usecase.GetAllOrderDispatch(clientId);
                foreach (var od in orderList) // if(a.CarrierID.Equals(clientId) && a.Status>4 ) {
                    dispatchorders.Add(TransformAuctionToOrdeDispatchModel(od));
                //}
                return Ok(dispatchorders);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Acepta una orden de despachopor parte del transportista.
        /// </summary>
        /// <param name="acceptModel">
        ///     Objeto que contiene los datos de la respuesta.
        /// </param>
        /// <returns>
        ///     Ok si la respuesta fue procesada correctamente,
        ///     badrequest si ocurrió algún error en el proceso.
        /// </returns>
        [Route("api/v1/dispatchorders/deliver")]
        [HttpPatch]
        public IHttpActionResult AcceptOrderDispatch(AcceptOrderDispatchModel acceptModel){
            if (acceptModel == null) return BadRequest("Argumentos inválidos.");
            try{
                usecase.AcceptOrderDispatch(acceptModel.DispatchId, acceptModel.CarrierObservation);
                return Ok("Orden de despacho procesada correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Cancela una orden de despacho por parte del transportista.
        /// </summary>
        /// <param name="acceptModel">
        ///     objeto que contiene la información de la respuesta.
        /// </param>
        /// <returns>
        ///     Ok si la respuesta fue correctamente almacenada,
        ///     badrequest si ocurrió algún error en el proceso.
        /// </returns>
        [Route("api/v1/dispatchorders/cancel")]
        [HttpPatch]
        public IHttpActionResult RefuseOrderDispatch(AcceptOrderDispatchModel acceptModel){
            if (acceptModel == null) return BadRequest("Argumentos inválidos.");
            try{
                usecase.RefuseOrderDispatch(acceptModel.DispatchId, acceptModel.CarrierObservation);
                return Ok("Orden de despacho procesada correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        private OrderDispatchModel TransformAuctionToOrdeDispatchModel(OrderDispatch od){
            var odm = new OrderDispatchModel{
                DispatchId = od.DispatchId,
                OrderId = od.OrderId,
                ClientId = od.CarrierId,
                DispatchDate = od.DispatchDate,
                DispatchValue = od.DispatchValue,
                DispatchWeight = od.DispatchWeight,
                Observation = od.Observation,
                CompanyName = od.CompanyName,
                Destination = od.Destination,
                PhoneNumber = od.PhoneNumber,
                Status = od.Status,
                Products = od.Products
            };
            return odm;
        }

    }

}