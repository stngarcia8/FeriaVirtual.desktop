using System;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.DTO;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.API.Controllers {

    public class LoginController:ApiController {


        [HttpPost]
        public IHttpActionResult LoginPos(LoginDTO loginDTO) {
            try {
                LoginUseCase login = LoginUseCase.CreateLogin( loginDTO.Username,loginDTO.Password );
                login.StartSession();
                return Ok( GetSessionLogged( login ) );
            } catch(Exception ex) {
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
