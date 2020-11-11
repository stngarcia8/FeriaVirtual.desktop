using System;
using System.Web.Http;
using FeriaVirtual.Business.Elements;
using FeriaVirtual.Domain.CommercialsData;


namespace FeriaVirtual.API.Controllers{

    /// <summary>
    ///     Controlador para los datos comerciales de los clientes de maipo grande.
    /// </summary>
    public class CommercialDataController : ApiController{

        private readonly ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();


        /// <summary>
        ///     Devuelve los datos comerciales del cliente requerido.
        /// </summary>
        /// <param name="clientId">
        ///     Corresponde al identificador del cliente.
        /// </param>
        /// <returns>
        ///     - Objeto datos comerciales, en caso de encontrar el cliente.
        ///     - Error 404: En caso de parámetros inválidos.
        /// </returns>
        [Route("api/v1/commercial/{clientId}")]
        [HttpGet]
        public IHttpActionResult Get(string clientId){
            if (string.IsNullOrEmpty(clientId))
                return BadRequest("Parámetro inválido, el id del cliente es incorrecto");
            try{
                ComercialData comercialData;
                comercialData = usecase.FindComercialDataById(clientId);
                if (comercialData == null) return NotFound();
                return Ok(comercialData);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Almacena los datos del cliente en la base de datos.
        /// </summary>
        /// <param name="data">
        ///     Objeto con los datos comerciales del cliente.
        /// </param>
        /// <returns>
        ///     Ok - Datos comerciales almacenados correctamente
        ///     Badrequest: Datos son inválidos.
        /// </returns>
        [Route("api/v1/commercial/")]
        [HttpPost]
        public IHttpActionResult Post(ComercialData data){
            if (data == null) return BadRequest("Parámetro inválido, los datos comerciales son incorrectos");
            try{
                usecase.NewCommercialData(data, data.ClientId);
                return Ok("Datos comerciales almacenados correctamente");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Actualiza los datos comerciales de un cliente.
        /// </summary>
        /// <param name="data">
        ///     Objeto con los datos comerciales del cliente
        /// </param>
        /// <returns>
        ///     Ok - Datos comerciales actualizados correctamente.
        ///     Badrequest - Parámetros inválidos.
        /// </returns>
        [Route("api/v1/commercial/")]
        [HttpPut]
        public IHttpActionResult Put(ComercialData data){
            if (data == null) return BadRequest("Parámetro inválido, los datos comerciales son incorrectos");
            try{
                usecase.EditCommercialData(data, data.ClientId);
                return Ok("Datos comerciales actualizados correctamente");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Elimina los datos comerciales de un cliente.
        /// </summary>
        /// <param name="comercialId">
        ///     Identificador del cliente
        /// </param>
        /// <returns>
        ///     Ok - Datos comerciales eliminados correctamente.
        ///     Badrequest - Datos inválidos.
        /// </returns>
        [Route("api/v1/commercial/{clientId}")]
        [HttpDelete]
        public IHttpActionResult Delete(string comercialId){
            if (string.IsNullOrEmpty(comercialId))
                return BadRequest("Parámetro inválido, el identificador del dato comercial es incorrecto");
            try{
                usecase.DeleteCommercialData(comercialId);
                return Ok("Datos comerciales eliminados correctamente");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }

}