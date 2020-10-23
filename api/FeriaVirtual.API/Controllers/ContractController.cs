using System;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{
    public class ContractController : ApiController
    {

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
                usecase.AcceptContract(model.ContractID,model.ClientID,model.Observation);
                return Ok("Contrato procesado correctamente.");
            } catch (Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        [Route("api/v1/contracts/refuse")]
        [HttpPatch]
        public IHttpActionResult PatchRefuse(RequestContractModel model) {
            if(model == null) {
                return BadRequest("Parámetros inválidos, los parámetros enviados no corresponden.");
            }
            try {
                ContractUseCase usecase = ContractUseCase.CreateUseCase(model.ProfileID);
                usecase.ContractRefuse(model.ContractID,model.ClientID,model.Observation);
                return Ok("Contrato procesado correctamente.");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }





    }
}
