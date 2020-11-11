using System.Data;
using FeriaVirtual.Domain.Users;


namespace FeriaVirtual.Data.Repository{

    public class ExternalClientRepository : Repository{

        // Properties
        public ExternalClient Client{ get; private set; }


        // Constructor
        private ExternalClientRepository(){
            Client = ExternalClient.CreateClient();
        }


        // Named constructor.
        public static ExternalClientRepository OpenRepository(){
            return new ExternalClientRepository();
        }


        public new void FindById(string id){
            FindClientUserData(id);
            GetClientUserData();
            if (Client == null) return;
            var dataRepository = ComercialDataRepository.OpenRepository();
            Client.ComercialInfo = dataRepository.FindById(id);
        }


        private void FindClientUserData(string id){
            Sql.Append("select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=3 ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", id, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }


        private void GetClientUserData(){
            if (DataTable.Rows.Count.Equals(0)){
                Client = null;
                return;
            }

            var row = DataTable.Rows[0];
            Client.Id = row["id_cliente"].ToString();
            Client.FirstName = row["nombre_cliente"].ToString();
            Client.LastName = row["apellido_cliente"].ToString();
            Client.Dni = row["DNI"].ToString();
            Client.Profile.ProfileId = 3;
            Client.Profile.ProfileName = row["Rol"].ToString();
        }

    }

}