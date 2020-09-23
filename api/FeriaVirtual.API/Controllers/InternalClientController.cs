﻿using System;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{

    public class InternalClientController : ApiController
    {


        [HttpGet]
        public IHttpActionResult Get(string clientID) {
            try {
                InternalClientUseCase usecase = InternalClientUseCase.CreateUseCase();
                InternalClient client = usecase.FindClientById( clientID );
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
