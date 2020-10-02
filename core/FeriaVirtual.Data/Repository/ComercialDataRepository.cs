using System;
using System.Data;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class ComercialDataRepository:Repository {


        // Constructor
        private ComercialDataRepository() : base() { }

        // Named constructor
        public static ComercialDataRepository OpenRepository() {
            return new ComercialDataRepository();
        }

        public void NewComercialData(ComercialData data,string clientID) {
            try {
                SearchExistingBusinessData(clientID);
                IQueryAction query = DefineQueryAction("spAgregarDatosComerciales ");
                query.AddParameter("pIdComercial",data.ComercialID,DbType.String);
                query.AddParameter("pIdCliente",clientID,DbType.String);
                query = DefineParameters(data,query);
                query.ExecuteQuery();
            } catch(Exception ex) {
                throw ex;
            }
        }

        private void SearchExistingBusinessData(string clientID) {
            FindById(clientID);
            if(dataTable.Rows.Count>=1) {
                throw new Exception("No esta permitido agregar multiples instancias de un dato comercial de una persona.");
            }
        }


        private IQueryAction DefineParameters(ComercialData data,IQueryAction query) {
            query.AddParameter("pRSocial",data.CompanyName,DbType.String);
            query.AddParameter("pFantasia",data.FantasyName,DbType.String);
            query.AddParameter("pGiro",data.ComercialBusiness,DbType.String);
            query.AddParameter("pEmail",data.Email,DbType.String);
            query.AddParameter("pDNI",data.ComercialDNI,DbType.String);
            query.AddParameter("pDireccion",data.Address,DbType.String);
            query.AddParameter("pCiudad",data.City,DbType.String);
            query.AddParameter("pPais",data.Country,DbType.String);
            query.AddParameter("pTelefono",data.PhoneNumber,DbType.String);
            return query;
        }

        public void EditComercialData(ComercialData data,string clientID) {
            try {
                IQueryAction query = DefineQueryAction("spActualizarDatosComerciales ");
                query.AddParameter("pIdComercial",data.ComercialID,DbType.String);
                query = DefineParameters(data,query);
                query.ExecuteQuery();
            } catch(Exception ex) {
                throw ex;
            }
        }

        public new ComercialData FindById(string id) {
            sql.Append("select * from fv_user.vwObtenerDatosComerciales where id_cliente=:pId ");
            base.FindById(id);
            return GetComercialData();
        }


        public void DeleteComercialData(string comercialID) {
            IQueryAction query = DefineQueryAction("spEliminarDatosComerciales ");
            query.AddParameter("pIdComercial",comercialID,DbType.String);
            query.ExecuteQuery();
        }


        private ComercialData GetComercialData() {
            if(dataTable.Rows.Count.Equals(0)) {
                return null;
            }
            DataRow row = dataTable.Rows[0];
            ComercialData data = ComercialData.CreateComercialData();
            data.ComercialID= row["id_comercial"].ToString();
            data.CompanyName= row["Razon social"].ToString();
            data.FantasyName=row["Nombre de fantasia"].ToString();
            data.ComercialBusiness= row["Giro comercial"].ToString();
            data.Email= row["Email"].ToString();
            data.ComercialDNI= row["DNI"].ToString();
            data.Address= row["Direccion"].ToString();
            data.City= row["Ciudad"].ToString();
            data.Country= row["Pais"].ToString();
            data.PhoneNumber= row["Telefono"].ToString();
            return data;
        }



    }
}
