using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.API.Controllers
{

    public class LoginController : ApiController
    {

        /// <summary>
        /// Permite el inicio de sesión en la plataforma "Feria virtual"
        /// </summary>
        /// <param name="loginData">
        /// Objeto que contiene las credenciales del usuario a iniciar sesión.
        /// </param>
        /// <returns>
        /// Ok - Con el objeto de sesión permitido.
        /// Badrequest - si el login falla o los parámetros son inválidos.
        /// </returns>
        [Route("api/v1/login/autenticate")]
        [HttpPost]
        public IHttpActionResult LoginPos(LoginDto loginData) {
            try {
                LoginUseCase login = LoginUseCase.CreateLogin(loginData.Username,loginData.Password);
                login.StartSession();
                return Ok(GetSessionLogged(login));
            } catch(Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        private SessionDto GetSessionLogged(LoginUseCase login) {
            SessionDto sesion = new SessionDto();
            Employee employee = login.EmployeeLogged;
            sesion.ClientID= employee.EmployeeID;
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
