using System.Data;
using FeriaVirtual.Domain.DTO;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class ProducerRepository:Repository {

        // Properties
        public Producer Producer => producer;

        private Producer producer;

        // Constructor
        private ProducerRepository() : base() {
            producer= Producer.CreateProducer();
        }

        // Named constructor.
        public static ProducerRepository OpenRepository() {
            return new ProducerRepository();
        }

        public new void FindById(string id) {
            FindProducerUserData( id );
            GetProducerUserData();
            if(producer==null) {
                return;
            }
            FindProducerComercialData( id );
            producer.ComercialInfo= GetProducerComercialData();
        }

        private void FindProducerUserData(string id) {
            sql.Append( "select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=5 " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            //connection.CloseConnection();
        }

        private void GetProducerUserData() {
            if(dataTable.Rows.Count.Equals( 0 )) {
                producer=null;
                return;
            }
            DataRow row = dataTable.Rows[0];
            producer.ID = row["id_cliente"].ToString();
            producer.FirstName= row["nombre_cliente"].ToString();
            producer.LastName= row["apellido_cliente"].ToString();
            producer.DNI= row["DNI"].ToString();
            producer.Profile.ProfileID=5;
            producer.Profile.ProfileName= row["Rol"].ToString();
        }


        private void FindProducerComercialData(string id) {
            sql.Clear();
            sql.Append( "select * from vwObtenerDatosComerciales where id_cliente=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            // connection.CloseConnection();
        }


        private ComercialDataDTO GetProducerComercialData() {
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
