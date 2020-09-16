using System.Data;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {
    public class LoginRepository: Repository {

        private Credential user;


        // Constructor
        private LoginRepository(Credential user) : base() {
            this.user = user;
        }


        // Named constructor.
        public static LoginRepository OpenRepository(Credential user) {
            return new LoginRepository( user );
        }


        // Sign-in
        public void SignIn() {
            sql.Append( "select * from fv_user.vwObtenerUsuarios where username=:pUsername and password=:pPassword " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pUsername",user.Username,DbType.String );
            querySelect.AddParameter( "pPassword",user.EncriptedPassword,DbType.String );
            dataTable = querySelect.ExecuteQuery();
        }

    }
}
