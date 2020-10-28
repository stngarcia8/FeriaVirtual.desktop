using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.Domain.Contracts;

namespace FeriaVirtual.API.Controllers {
    public class ContractController:ApiController {

        /// <summary>
        /// Permite obtener el contrato de un productor/transportista.
        /// </summary>
        /// <param name="profileID">Corresponde al identificador del perfil del productor/transportista.</param>
        /// <param name="clientID">Corresponde al identificador del productor/transportista</param>
        /// <returns>
        /// Ok, con la lista de contratos del productor/transportista, 
        /// Notfount, si no se encuentra ningun contrato asociado al productor/transportista, 
        /// Badrequest, en caso de parámetros inválidos o errores durante el proceso.
        /// </returns>
        [Route("api/v1/contracts")]
        [HttpGet]
        public IHttpActionResult GetByClientID(int profileID,string clientID) {
            if(string.IsNullOrEmpty(clientID) || (profileID<=0)) {
                return BadRequest("Parámetros inválidos, el identificador del cliente es incorrecto.");
            }
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(profileID);
                IList<ContractDto> contractList = usecase.GetContractByCustomerID(clientID);
                if(contractList == null) {
                    return NotFound();
                }
                return Ok(contractList);
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Permite aceptar el contrato por parte de un productor o transportista.
        /// </summary>
        /// <param name="model">
        /// Objeto que contiene la información del contrato que será aceptado.
        /// </param>
        /// <returns>
        /// Ok si el contrato fue aceptado correctamente, 
        /// BadRequest en caso de problemas o errores.
        /// </returns>
        [Route("api/v1/contracts/accept")]
        [HttpPatch]
        public IHttpActionResult PatchAccept(RequestContractModel model) {
            if(model == null) {
                return BadRequest("Parámetros inválidos, los parámetros enviados no corresponden.");
            }
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(model.ProfileID);
                usecase.AcceptContract(model.ContractID,model.ClientID,model.CustomerObservation);
                return Ok("Contrato procesado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Permite rechazar un contrato por parte de los productores/transportista.
        /// </summary>
        /// <param name="model">
        /// Objeto con los datos de la respuesta del productor/transportista.
        /// </param>
        /// <returns>
        /// Ok, si el contrato se proceso correctamente,
        /// Badrequest, si ocurrio un error.
        /// </returns>
        [Route("api/v1/contracts/refuse")]
        [HttpPatch]
        public IHttpActionResult PatchRefuse(RequestContractModel model) {
            if(model == null) {
                return BadRequest("Parámetros inválidos, los parámetros enviados no corresponden.");
            }
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(model.ProfileID);
                usecase.ContractRefuse(model.ContractID,model.ClientID,model.CustomerObservation);
                return Ok("Contrato procesado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }





    }
}
