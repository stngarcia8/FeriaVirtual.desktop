using System;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.API.Controllers {

    public class CarrierController:ApiController {

        [HttpGet]
        public IHttpActionResult Get(string carrierID) {
            if(string.IsNullOrEmpty( carrierID )) {
                return BadRequest( "Parámetro inválido, el id del transportista es incorrecto" );
            }
            try {
                CarrierUseCase usecase = CarrierUseCase.CreateUseCase();
                Carrier carrier = usecase.FindCarrierById( carrierID );
                if(carrier==null) {
                    return NotFound();
                }
                return Ok( carrier );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }

    }


}
