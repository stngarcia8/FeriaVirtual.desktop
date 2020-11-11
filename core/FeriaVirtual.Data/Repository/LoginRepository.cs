using System.Data;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Data.Repository{

    public class LoginRepository : Repository{

        private readonly Credential user;


        // Constructor
        private LoginRepository(Credential user){
            this.user = user;
        }


        // Named constructor.
        public static LoginRepository OpenRepository(Credential user){
            return new LoginRepository(user);
        }


        // Sign-in
        public void SignIn(){
            Sql.Append(
                "select * from fv_user.vwLogin where trim(username)=trim(:pUsername) and trim(password)=trim(:pPassword) ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pUsername", user.Username, DbType.String);
            querySelect.AddParameter("pPassword", user.EncriptedPassword, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }

    }

}