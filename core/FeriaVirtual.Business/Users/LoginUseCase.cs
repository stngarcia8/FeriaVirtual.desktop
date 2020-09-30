using System;
using System.Data;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Users {
    public class LoginUseCase {

        private Credential user;
        private Employee empLogged;

        // Properties.
        public Employee EmployeeLogged => empLogged;


        // Constructor
        private LoginUseCase(string anUsername,string aPassword) {
            user = Credential.CreateCredential();
            user.Username= anUsername;
            user.Password= aPassword;
        }

        // Named constructor
        public static LoginUseCase CreateLogin(string anUsername,string aPassword) {
            return new LoginUseCase( anUsername,aPassword );
        }


        public void StartSession() {
            try {
                IValidator validator = LoginValidator.CreateValidator( user.Username,user.Password );
                user.EncriptedPassword = user.Password;
                validator.Validate();
                LoginRepository repository = LoginRepository.OpenRepository( user );
                repository.SignIn();
                DataTable userData = repository.DataSource;
                if(userData.Rows.Count.Equals( 0 )) {
                    throw new InvalidLoginException( "El nombre de usuario o contraseña no son correctos" );
                }
                GetUserData( userData );
                if(!user.IsActive) {
                    throw new InvalidLoginException( "El usuario tiene su cuenta inactiva, informe este inconveniente al administrador del sistema." );
                }
            } catch(Exception ex) {
                throw ex;
            }
        }


        private void GetUserData(DataTable userInfo) {
            DataRow row = userInfo.Rows[0];
            user = Credential.CreateCredential( row["id_usuario"].ToString(),
                row["username"].ToString(),
                row["password"].ToString() );
            empLogged = Employee.CreateEmployee(
                row["id_empleado"].ToString(),
                row["Nombre"].ToString(),
                row["Apellido"].ToString() );
            empLogged.Credentials= user;
            empLogged.Credentials.EncriptedPassword= row["password"].ToString();
            empLogged.Credentials.Email= row["Email"].ToString();
            empLogged.Credentials.IsActive= (int.Parse( row["is_active"].ToString() ).Equals( 1 ) ? true : false);
            empLogged.Profile.ProfileID= int.Parse( row["id_rol"].ToString() );
            empLogged.Profile.ProfileName= row["Rol"].ToString();
        }


    }
}
