using System.Data;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class EmployeeRepository:Repository {

        // Constructor.
        private EmployeeRepository() { }


        // Named constructor.
        public static EmployeeRepository OpenRepository() {
            return new EmployeeRepository();
        }


        public void FindAll() {
            sql.Append( "select * from fv_user.vwObtenerUsuarios " );
            base.FindAll();
        }


        public void FindByName(string username) {
            sql.Append( "select * from fv_user.vwObtenerUsuarios where username=:pName " );
            base.FindByName( username );
        }


        public void FindById(string id) {
            sql.Append( "select * from fv_user.vwObtenerUsuarios where id_usuario=:pId " );
            base.FindById( id );
        }


        public void FindActiveUsers() {
            sql.Append( "select * from fv_user.vwObtenerUsuarios where is_active=1 " );
            base.FindAll();
        }


        public void FindInactiveUsers() {
            sql.Append( "select * from fv_user.vwObtenerUsuarios where is_active=0 " );
            base.FindAll();
        }


        public void EnableOrDisableUser(string id,int typeAction) {
            IQueryAction query = DefineQueryAction( "spHabilitarUsuario" );
            query.AddParameter( "pIdUsuario",id,DbType.String);
            query.AddParameter( "pTipoAccion",typeAction,DbType.Int32 );
            query.ExecuteQuery();
        }


        public void NewEmployee(Employee employee) {
            IQueryAction query = DefineQueryAction( "spAgregarUsuario" );
            query.AddParameter( "pIdUsuario",employee.Credentials.UserId,DbType.String );
            query.AddParameter( "pUserName",employee.Credentials.Username,DbType.String );
            query.AddParameter( "pPassword", employee.Credentials.EncriptedPassword, DbType.String);
            query.AddParameter( "pEmail", employee.Credentials.Email, DbType.String);
            query.AddParameter( "pIdEmpleado", employee.EmployeeID, DbType.String);
            query.AddParameter( "pIdRol", employee.Profile.ProfileID, DbType.Int32);
            query.AddParameter( "pNombre", employee.FirstName, DbType.String );
            query.AddParameter( "pApellido", employee.LastName, DbType.String );
            query.ExecuteQuery();
        }


        public void EditEmployee(Employee employee) {
            IQueryAction query = DefineQueryAction( "spActualizarUsuario" );
            query.AddParameter( "pIdUsuario",employee.Credentials.UserId,DbType.String );
            query.AddParameter( "pPassword",employee.Credentials.EncriptedPassword,DbType.String );
            query.AddParameter( "pEmail",employee.Credentials.Email,DbType.String );
            query.AddParameter( "pIdEmpleado",employee.EmployeeID,DbType.String );
            query.AddParameter( "pIdRol",employee.Profile.ProfileID,DbType.Int32 );
            query.AddParameter( "pNombre",employee.FirstName,DbType.String );
            query.AddParameter( "pApellido",employee.LastName,DbType.String );
            query.ExecuteQuery();
        }

    }
}
