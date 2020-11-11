using System.Data;
using FeriaVirtual.Data.Exceptions;
using FeriaVirtual.Domain.CommercialsData;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository{

    public class ComercialDataRepository : Repository{

        // Constructor
        private ComercialDataRepository(){ }


        // Named constructor
        public static ComercialDataRepository OpenRepository(){
            return new ComercialDataRepository();
        }


        public void NewComercialData(ComercialData data, string clientId){
            SearchExistingBusinessData(clientId);
            var query = DefineQueryAction("spAgregarDatosComerciales ");
            query.AddParameter("pIdComercial", data.CommercialId, DbType.String);
            query.AddParameter("pIdCliente", clientId, DbType.String);
            query = DefineParameters(data, query);
            query.ExecuteQuery();
        }


        private void SearchExistingBusinessData(string clientId){
            FindById(clientId);
            if (DataTable.Rows.Count >= 1)
                throw new RepeatedBusinessDataException(
                    "No esta permitido agregar multiples instancias de un dato comercial de una persona.");
        }


        private IQueryAction DefineParameters(ComercialData data, IQueryAction query){
            query.AddParameter("pRSocial", data.CompanyName, DbType.String);
            query.AddParameter("pFantasia", data.FantasyName, DbType.String);
            query.AddParameter("pGiro", data.ComercialBusiness, DbType.String);
            query.AddParameter("pEmail", data.Email, DbType.String);
            query.AddParameter("pDNI", data.ComercialDni, DbType.String);
            query.AddParameter("pDireccion", data.Address, DbType.String);
            query.AddParameter("pIdCiudad", data.City.CityId, DbType.Int32);
            query.AddParameter("pTelefono", data.PhoneNumber, DbType.String);
            return query;
        }


        public void EditComercialData(ComercialData data, string clientId){
            var query = DefineQueryAction("spActualizarDatosComerciales ");
            query.AddParameter("pIdComercial", data.CommercialId, DbType.String);
            query = DefineParameters(data, query);
            query.ExecuteQuery();
        }


        public new ComercialData FindById(string id){
            Sql.Append("select * from fv_user.vwObtenerDatosComerciales where id_cliente=:pId ");
            base.FindById(id);
            return GetComercialData();
        }


        public void DeleteComercialData(string comercialId){
            var query = DefineQueryAction("spEliminarDatosComerciales ");
            query.AddParameter("pIdComercial", comercialId, DbType.String);
            query.ExecuteQuery();
        }


        private ComercialData GetComercialData(){
            if (DataTable.Rows.Count.Equals(0)) return null;
            var row = DataTable.Rows[0];
            var data = ComercialData.CreateComercialData();
            data.CommercialId = row["id_comercial"].ToString();
            data.CompanyName = row["Razon social"].ToString();
            data.FantasyName = row["Nombre de fantasia"].ToString();
            data.ComercialBusiness = row["Giro comercial"].ToString();
            data.Email = row["Email"].ToString();
            data.ComercialDni = row["DNI"].ToString();
            data.Address = row["Direccion"].ToString();
            data.City.CityId = int.Parse(row["id_ciudad"].ToString());
            data.City.CityName = row["Ciudad"].ToString();
            data.Country.CountryId = int.Parse(row["id_pais"].ToString());
            data.Country.CountryName = row["Pais"].ToString();
            data.Country.CountryPrefix = row["Prefijo"].ToString();
            data.PhoneNumber = row["Telefono"].ToString();
            return data;
        }

    }

}