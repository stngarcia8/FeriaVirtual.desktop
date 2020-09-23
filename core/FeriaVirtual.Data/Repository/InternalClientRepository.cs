using System.Data;
using FeriaVirtual.Domain.DTO;
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
            FindClientUserData( id );
            GetClientUserData();
            if(client==null) {
                return;
            }
            FindClientComercialData( id );
            client.ComercialInfo= GetClientComercialData();
        }

        private void FindClientUserData(string id) {
            sql.Append( "select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=4 " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            //connection.CloseConnection();
        }


        private void GetClientUserData() {
            if(dataTable.Rows.Count.Equals( 0 )) {
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


        private void FindClientComercialData(string id) {
            sql.Clear();
            sql.Append( "select * from vwObtenerDatosComerciales where id_cliente=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            // connection.CloseConnection();
        }


        private ComercialDataDTO GetClientComercialData() {
            ComercialDataDTO data = new ComercialDataDTO();
            if(dataTable.Rows.Count.Equals( 0 )) {
                return null;
            }
            DataRow row = dataTable.Rows[0];
            data.ComercialID= row["id_comercial"].ToString();
            data.CompanyName= row["Razon social"].ToString();
            data.FantasyName=row["Nombre de fantasia"].ToString();
            data.ComercialBusiness= row["Giro comercial"].ToString();
            data.Email= row["Email"].ToString();
            data.ComercialDNI= row["DNI"].ToString();
            data.Address= row["Direccion"].ToString();
            data.CityID=int.Parse( row["cod_ciudad"].ToString() );
            data.CityName=row["Ciudad"].ToString();
            data.CountryID= int.Parse( row["cod_pais"].ToString() );
            data.CountryName= row["Pais"].ToString();
            return data;
        }





    }

}
