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

    public class CarrierController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get(string carrierID) {
            try {
                CarrierUseCase usecase = CarrierUseCase.CreateUseCase();
                Carrier carrier = usecase.FindCarrierById( carrierID );
                if(carrier==null) {
                    return NotFound();
                }
                return Ok( carrier);
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }

    }


}
