using System;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{

    public class ProducerController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(string producerID) {
            try {
                ProducerUseCase usecase = ProducerUseCase.CreateUseCase();
                Producer producer = usecase.FindProducerById( producerID );
                if(producer==null) {
                    return NotFound();
                }
                return Ok(producer);
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }

    }


}
