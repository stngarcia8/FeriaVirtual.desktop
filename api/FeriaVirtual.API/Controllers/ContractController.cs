using System;
using System.Web.Http;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Contracts;


namespace FeriaVirtual.API.Controllers{

    /// <summary>
    ///     Controlador para los contratos de los transportistas/productores asociados a maipo grande.
    /// </summary>
    public class ContractController : ApiController{

        /// <summary>
        ///     Permite obtener el contrato de un productor/transportista.
        /// </summary>
        /// <param name="profileId">Corresponde al identificador del perfil del productor/transportista.</param>
        /// <param name="clientId">Corresponde al identificador del productor/transportista</param>
        /// <returns>
        ///     Ok, con la lista de contratos del productor/transportista,
        ///     Notfount, si no se encuentra ningun contrato asociado al productor/transportista,
        ///     Badrequest, en caso de parámetros inválidos o errores durante el proceso.
        /// </returns>
        [Route("api/v1/contracts")]
        [HttpGet]
        public IHttpActionResult GetByClientID(int profileId, string clientId){
            if (string.IsNullOrEmpty(clientId) || profileId <= 0)
                return BadRequest("Parámetros inválidos, el identificador del cliente es incorrecto.");
            try{
                var usecase = ContractUseCase.CreateUseCase(profileId);
                var contractList = usecase.GetContractByCustomerId(clientId);
                if (contractList == null) return NotFound();
                return Ok(contractList);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Permite aceptar el contrato por parte de un productor o transportista.
        /// </summary>
        /// <param name="model">
        ///     Objeto que contiene la información del contrato que será aceptado.
        /// </param>
        /// <returns>
        ///     Ok si el contrato fue aceptado correctamente,
        ///     BadRequest en caso de problemas o errores.
        /// </returns>
        [Route("api/v1/contracts/accept")]
        [HttpPatch]
        public IHttpActionResult PatchAccept(RequestContractModel model){
            if (model == null) return BadRequest("Parámetros inválidos, los parámetros enviados no corresponden.");
            try{
                var usecase = ContractUseCase.CreateUseCase(model.ProfileId);
                usecase.AcceptContract(model.ContractId, model.ClientId, model.CustomerObservation);
                return Ok("Contrato procesado correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Permite rechazar un contrato por parte de los productores/transportista.
        /// </summary>
        /// <param name="model">
        ///     Objeto con los datos de la respuesta del productor/transportista.
        /// </param>
        /// <returns>
        ///     Ok, si el contrato se proceso correctamente,
        ///     Badrequest, si ocurrio un error.
        /// </returns>
        [Route("api/v1/contracts/refuse")]
        [HttpPatch]
        public IHttpActionResult PatchRefuse(RequestContractModel model){
            if (model == null) return BadRequest("Parámetros inválidos, los parámetros enviados no corresponden.");
            try{
                var usecase = ContractUseCase.CreateUseCase(model.ProfileId);
                usecase.ContractRefuse(model.ContractId, model.ClientId, model.CustomerObservation);
                return Ok("Contrato procesado correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }

}