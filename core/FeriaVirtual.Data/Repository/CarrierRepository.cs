using System.Data;
using FeriaVirtual.Domain.DTO;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class CarrierRepository:Repository {


        // Properties
        public Carrier Carrier => carrier;

        private Carrier carrier;

        // Constructor
        private CarrierRepository() : base() {
            carrier = Carrier.CreateCarrier();
        }

        // Named constructor.
        public static CarrierRepository OpenRepository() {
            return new CarrierRepository();
        }


        public new void FindById(string id) {
            FindCarrierUserData( id );
            GetCarrierUserData();
            if(carrier==null) {
                return;
            }
            FindCarrierComercialData( id );
            carrier.ComercialInfo= GetCarrierComercialData();
        }


        private void FindCarrierUserData(string id) {
            sql.Append( "select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=6 " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            //connection.CloseConnection();
        }


        private void GetCarrierUserData() {
            if(dataTable.Rows.Count.Equals( 0 )) {
                carrier= null;
                return;
            }
            DataRow row = dataTable.Rows[0];
            carrier.ID = row["id_cliente"].ToString();
            carrier.FirstName= row["nombre_cliente"].ToString();
            carrier.LastName= row["apellido_cliente"].ToString();
            carrier.DNI= row["DNI"].ToString();
            carrier.Profile.ProfileID=6;
            carrier.Profile.ProfileName= row["Rol"].ToString();
        }


        private void FindCarrierComercialData(string id) {
            sql.Clear();
            sql.Append( "select * from vwObtenerDatosComerciales where id_cliente=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            // connection.CloseConnection();
        }


        private ComercialDataDTO GetCarrierComercialData() {
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
