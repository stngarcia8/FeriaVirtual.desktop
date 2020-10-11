using System.Data;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class InternalClientRepository:Repository {

        // Properties
        public InternalClient Client => client;

        private InternalClient client;

        // Constructor
        private InternalClientRepository() : base() {
            client = InternalClient.CreateClient();
        }

        // Named constructor.
        public static InternalClientRepository OpenRepository() {
            return new InternalClientRepository();
        }

        public new void FindById(string id) {
            FindClientUserData(id);
            GetClientUserData();
            if(client==null) {
                return;
            }
            ComercialDataRepository dataRepository = ComercialDataRepository.OpenRepository();
            client.ComercialInfo= dataRepository.FindById(id);
        }

        private void FindClientUserData(string id) {
            sql.Append("select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=4 ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            dataTable = querySelect.ExecuteQuery();
        }

        private void GetClientUserData() {
            if(dataTable.Rows.Count.Equals(0)) {
                client= null;
                return;
            }
            DataRow row = dataTable.Rows[0];
            client.ID = row["id_cliente"].ToString();
            client.FirstName= row["nombre_cliente"].ToString();
            client.LastName= row["apellido_cliente"].ToString();
            client.DNI= row["DNI"].ToString();
            client.Profile.ProfileID=3;
            client.Profile.ProfileName= row["Rol"].ToString();
        }
    }
}