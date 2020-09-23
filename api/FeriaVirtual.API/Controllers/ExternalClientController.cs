using System;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.API.Controllers {

    public class ExternalClientController:ApiController {

        [HttpGet]
        public IHttpActionResult Get(string clientID) {
            if(string.IsNullOrEmpty( clientID )) {
                return BadRequest( "Parámetro inválido, el id del cliente es incorrecto" );
            }
            try {
                ExternalClientUseCase usecase = ExternalClientUseCase.CreateUseCase();
                ExternalClient client = usecase.FindClientById( clientID );
                if(client==null) {
                    return NotFound();
                }
                return Ok( client );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }

    }

}
