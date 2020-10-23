using System;
using System.Web.Http;
using FeriaVirtual.Business.Elements;
using FeriaVirtual.Domain.CommercialsData;

namespace FeriaVirtual.API.Controllers {
    public class CommercialDataController:ApiController {

        private ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();

        /// <summary>
        /// Devuelve los datos comerciales del cliente requerido.
        /// </summary>
        /// <param name="clientID">
        /// Corresponde al identificador del cliente.
        /// </param>
        /// <returns>
        /// - Objeto datos comerciales, en caso de encontrar el cliente.
        /// - Error 404: En caso de parámetros inválidos.
        /// </returns>
        [Route("api/v1/commercial/{clientID}")]
        [HttpGet]
        public IHttpActionResult Get(string clientID) {
            if(string.IsNullOrEmpty(clientID)) {
                return BadRequest("Parámetro inválido, el id del cliente es incorrecto");
            }
            try {
                ComercialData comercialData;
                comercialData = usecase.FindComercialDataByID(clientID);
                if(comercialData == null) {
                    return NotFound();
                }
                return Ok(comercialData);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        /// <summary>
        ///  Almacena los datos del cliente en la base de datos.
        /// </summary>
        /// <param name="data">
        /// Objeto con los datos comerciales del cliente.
        /// </param>
        /// <returns>
        /// Ok - Datos comerciales almacenados correctamente
        /// Badrequest: Datos son inválidos.
        /// </returns>
        [Route("api/v1/commercial/")]
        [HttpPost]
        public IHttpActionResult Post(ComercialData data) {
            if(data==null) {
                return BadRequest("Parámetro inválido, los datos comerciales son incorrectos");
            }
            try {
                usecase.NewCommercialData(data,data.ClientID);
                return Ok("Datos comerciales almacenados correctamente");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Actualiza los datos comerciales de un cliente.
        /// </summary>
        /// <param name="data">
        /// Objeto con los datos comerciales del cliente
        /// </param>
        /// <returns>
        /// Ok - Datos comerciales actualizados correctamente.
        /// Badrequest - Parámetros inválidos.
        /// </returns>
        [Route("api/v1/commercial/")]
        [HttpPut]
        public IHttpActionResult Put(ComercialData data) {
            if(data==null) {
                return BadRequest("Parámetro inválido, los datos comerciales son incorrectos");
            }
            try {
                usecase.EditCommercialData(data,data.ClientID);
                return Ok("Datos comerciales actualizados correctamente");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        ///  Elimina los datos comerciales de un cliente.
        /// </summary>
        /// <param name="comercialID">
        /// Identificador del cliente
        /// </param>
        /// <returns>
        /// Ok - Datos comerciales eliminados correctamente.
        /// Badrequest - Datos inválidos.
        /// </returns>
        [Route("api/v1/commercial/{clientID}")]
        [HttpDelete]
        public IHttpActionResult Delete(string comercialID) {
            if(string.IsNullOrEmpty(comercialID)) {
                return BadRequest("Parámetro inválido, el identificador del dato comercial es incorrecto");
            }
            try {
                usecase.DeleteCommercialData(comercialID);
                return Ok("Datos comerciales eliminados correctamente");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }




    }

}
