using System;
using FeriaVirtual.API.Models.Request;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Domain.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{

    public class LoginController : ApiController
    {


        [HttpPost]
        public IHttpActionResult LoginPos(LoginRequest loginRequest) {
            try {
                    LoginUseCase login = LoginUseCase.CreateLogin( loginRequest.Username,loginRequest.Password);
                    login.StartSession();
                return Ok( GetSessionLogged( login ) );
            } catch (Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }

        private SessionDTO GetSessionLogged(LoginUseCase login) {
            SessionDTO sesion = new SessionDTO();
            Employee employee = login.EmployeeLogged;
            sesion.UserId=employee.Credentials.UserId;
            sesion.Username=employee.Credentials.Username;
            sesion.FullName= employee.ToString();
            sesion.Email=employee.Credentials.Email;
            sesion.ProfileID= employee.Profile.ProfileID;
            sesion.ProfileName= employee.Profile.ProfileName;
            return sesion;
        }





    }


}
