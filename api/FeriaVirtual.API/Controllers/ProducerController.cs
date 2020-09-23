using System;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.API.Controllers {

    public class ProducerController:ApiController {

        [HttpGet]
        public IHttpActionResult Get(string producerID) {
            if(string.IsNullOrEmpty( producerID )) {
                return BadRequest( "Parámetro inválido, el id del productor es incorrecto" );
            }
            try {
                ProducerUseCase usecase = ProducerUseCase.CreateUseCase();
                Producer producer = usecase.FindProducerById( producerID );
                if(producer==null) {
                    return NotFound();
                }
                return Ok( producer );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }

    }


}
