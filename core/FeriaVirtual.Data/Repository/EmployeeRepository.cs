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

        public new void FindAll() {
            sql.Append("select * from fv_user.vwObtenerUsuarios ");
            base.FindAll();
        }

        public void FindTableByName(string username) {
            sql.Append("select * from fv_user.vwObtenerUsuarios where username=:pName ");
            base.FindByName(username);
        }

        public new Employee FindByName(string username) {
            sql.Append("select * from fv_user.vwObtenerUsuarios where username=:pName ");
            base.FindByName(username);
            return GetEmployeeData();
        }

        private Employee GetEmployeeData() {
            if(dataTable.Rows.Count.Equals(0)) {
                return null;
            }
            DataRow row = dataTable.Rows[0];
            Employee employee = Employee.CreateEmployee();
            employee.EmployeeID = row["id_empleado"].ToString();
            employee.FirstName = row["Nombre"].ToString();
            employee.LastName=  row["Apellido"].ToString();
            employee.Credentials.UserId = row["id_usuario"].ToString();
            employee.Credentials.Username= row["username"].ToString();
            employee.Credentials.Password = row["password"].ToString();
            employee.Credentials.EncriptedPassword= row["password"].ToString();
            employee.Credentials.Email= row["Email"].ToString();
            employee.Credentials.IsActive= int.Parse(row["is_active"].ToString())== (int)Enums.UserStatus.Active;
            employee.Profile.ProfileID= int.Parse(row["id_rol"].ToString());
            employee.Profile.ProfileName= row["Rol"].ToString();
            return employee;
        }

        public new Employee FindById(string id) {
            sql.Append("select * from fv_user.vwObtenerUsuarios where id_usuario=:pId ");
            base.FindById(id);
            return GetEmployeeData();
        }

        public void FindActiveUsers() {
            sql.Append("select * from fv_user.vwObtenerUsuarios where is_active=1 ");
            base.FindAll();
        }

        public void FindInactiveUsers() {
            sql.Append("select * from fv_user.vwObtenerUsuarios where is_active=0 ");
            base.FindAll();
        }

        public void EnableOrDisableUser(string id,int typeAction) {
            IQueryAction query = DefineQueryAction("spHabilitarUsuario");
            query.AddParameter("pIdUsuario",id,DbType.String);
            query.AddParameter("pTipoAccion",typeAction,DbType.Int32);
            query.ExecuteQuery();
        }

        public void NewEmployee(Employee employee) {
            IQueryAction query = DefineQueryAction("spAgregarUsuario");
            query.AddParameter("pUserName",employee.Credentials.Username,DbType.String);
            query = DefineEmployeeParameters(employee,query);
            query.ExecuteQuery();
        }

        private IQueryAction DefineEmployeeParameters(Employee employee,IQueryAction query) {
            query.AddParameter("pIdUsuario",employee.Credentials.UserId,DbType.String);
            query.AddParameter("pPassword",employee.Credentials.EncriptedPassword,DbType.String);
            query.AddParameter("pEmail",employee.Credentials.Email,DbType.String);
            query.AddParameter("pIdEmpleado",employee.EmployeeID,DbType.String);
            query.AddParameter("pIdRol",employee.Profile.ProfileID,DbType.Int32);
            query.AddParameter("pNombre",employee.FirstName,DbType.String);
            query.AddParameter("pApellido",employee.LastName,DbType.String);
            return query;
        }

        public void EditEmployee(Employee employee) {
            IQueryAction query = DefineQueryAction("spActualizarUsuario");
            query = DefineEmployeeParameters(employee,query);
            query.ExecuteQuery();
        }
    }
}