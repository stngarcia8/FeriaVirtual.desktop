using System.Data;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Enums;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Business.Users {

    public class LoginUseCase{

        private Credential user;

        // Properties.
        public Employee EmployeeLogged{ get; private set; }


        // Constructor
        private LoginUseCase(string anUsername, string aPassword){
            user = Credential.CreateCredential();
            user.Username = anUsername;
            user.Password = aPassword;
        }


        // Named constructor
        public static LoginUseCase CreateLogin(string anUsername, string aPassword){
            return new LoginUseCase(anUsername, aPassword);
        }


        public void StartSession(){
            IValidator validator = LoginValidator.CreateValidator(user.Username, user.Password);
            user.EncriptedPassword = user.Password;
            validator.Validate();
            var repository = LoginRepository.OpenRepository(user);
            repository.SignIn();
            var userData = repository.DataSource;
            if (userData.Rows.Count.Equals(0))
                throw new InvalidLoginException("El nombre de usuario o contraseña no son correctos");
            GetUserData(userData);
            if (!user.IsActive)
                throw new InvalidLoginException(
                    "El usuario tiene su cuenta inactiva, informe este inconveniente al administrador del sistema.");
        }


        private void GetUserData(DataTable userInfo){
            var row = userInfo.Rows[0];
            user = Credential.CreateCredential(row["id_usuario"].ToString(),
                row["username"].ToString(),
                row["password"].ToString());
            EmployeeLogged = Employee.CreateEmployee(
                row["id_empleado"].ToString(),
                row["Nombre"].ToString(),
                row["Apellido"].ToString());
            EmployeeLogged.Credentials = user;
            EmployeeLogged.Credentials.EncriptedPassword = row["password"].ToString();
            EmployeeLogged.Credentials.Email = row["Email"].ToString();
            EmployeeLogged.Credentials.IsActive = int.Parse(row["is_active"].ToString()) == (int) UserStatus.Active;
            EmployeeLogged.Profile.ProfileId = int.Parse(row["id_rol"].ToString());
            EmployeeLogged.Profile.ProfileName = row["Rol"].ToString();
        }

    }

}