using System;
using System.Web.Http;
using FeriaVirtual.Business.Elements;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.API.Controllers {

    public class ComercialDataController:ApiController {

        [HttpGet]
        public IHttpActionResult Get(string clientID) {
            if(string.IsNullOrEmpty(clientID)) {
                return BadRequest("Parámetro inválido, el id del cliente es incorrecto");
            }
            try {
                ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();
                return Ok(usecase.FindComercialDataByID(clientID));
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpPost]
        public IHttpActionResult Post(ComercialData data) {
            if(data==null) {
                return BadRequest("Parámetro inválido, los datos comerciales son incorrectos");
            }
            try {
                data.ComercialID = Guid.NewGuid().ToString();
                ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();
                usecase.NewCommercialData(data,data.ClientID);
                return Ok("Datos comerciales almacenados correctamente");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut]
        public IHttpActionResult Put(ComercialData data) {
            if(data==null) {
                return BadRequest("Parámetro inválido, los datos comerciales son incorrectos");
            }
            try {
                ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();
                usecase.EditCommercialData(data,data.ClientID);
                return Ok("Datos comerciales actualizados correctamente");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }


        [HttpDelete]
        public IHttpActionResult Delete(string comercialID) {
            if(string.IsNullOrEmpty(comercialID)) {
                return BadRequest("Parámetro inválido, el identificador del dato comercial es incorrecto");
            }
            try {
                ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();
                usecase.DeleteCommercialData(comercialID);
                return Ok("Datos comerciales eliminados correctamente");
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }





    }


}
