using System;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Dto;


namespace FeriaVirtual.API.Controllers{

    /// <summary>
    ///     Controlador para el login de los usuarios al sistema web.
    /// </summary>
    public class LoginController : ApiController{

        /// <summary>
        ///     Permite el inicio de sesión en la plataforma "Feria virtual"
        /// </summary>
        /// <param name="loginData">
        ///     Objeto que contiene las credenciales del usuario a iniciar sesión.
        /// </param>
        /// <returns>
        ///     Ok - Con el objeto de sesión permitido.
        ///     Badrequest - si el login falla o los parámetros son inválidos.
        /// </returns>
        [Route("api/v1/login/autenticate")]
        [HttpPost]
        public IHttpActionResult LoginPos(LoginDto loginData){
            try{
                var login = LoginUseCase.CreateLogin(loginData.Username, loginData.Password);
                login.StartSession();
                return Ok(GetSessionLogged(login));
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        private SessionDto GetSessionLogged(LoginUseCase login){
            var sesion = new SessionDto();
            var employee = login.EmployeeLogged;
            sesion.ClientId = employee.EmployeeId;
            sesion.UserId = employee.Credentials.UserId;
            sesion.Username = employee.Credentials.Username;
            sesion.FullName = employee.ToString();
            sesion.Email = employee.Credentials.Email;
            sesion.ProfileId = employee.Profile.ProfileId;
            sesion.ProfileName = employee.Profile.ProfileName;
            return sesion;
        }

    }

}