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
                IQueryAction query = DefineQueryAction( "spAgregarDatosComerciales " );
                query.AddParameter( "pIdComercial",data.ComercialID,DbType.String );
                query.AddParameter( "pIdCliente",clientID,DbType.String );
                query.AddParameter( "pRSocial",data.CompanyName,DbType.String );
                query.AddParameter( "pFantasia",data.FantasyName,DbType.String );
                query.AddParameter( "pGiro",data.ComercialBusiness,DbType.String );
                query.AddParameter( "pEmail",data.Email,DbType.String );
                query.AddParameter( "pDNI",data.ComercialDNI,DbType.String );
                query.AddParameter( "pDireccion",data.Address,DbType.String );
                query.AddParameter( "pCiudad",data.City,DbType.String );
                query.AddParameter( "pPais",data.Country,DbType.String );
                query.AddParameter( "pTelefono",data.PhoneNumber,DbType.String );
                query.ExecuteQuery();
            } catch(Exception ex) {
                throw ex;
            }
        }


        public void EditComercialData(ComercialData data,string clientID) {
            try {
                IQueryAction query = DefineQueryAction( "spActualizarDatosComerciales " );
                query.AddParameter( "pIdComercial",data.ComercialID,DbType.String );
                query.AddParameter( "pRSocial",data.CompanyName,DbType.String );
                query.AddParameter( "pFantasia",data.FantasyName,DbType.String );
                query.AddParameter( "pGiro",data.ComercialBusiness,DbType.String );
                query.AddParameter( "pEmail",data.Email,DbType.String );
                query.AddParameter( "pDNI",data.ComercialDNI,DbType.String );
                query.AddParameter( "pDireccion",data.Address,DbType.String );
                query.AddParameter( "pCiudad",data.City,DbType.String );
                query.AddParameter( "pPais",data.Country,DbType.String );
                query.AddParameter( "pTelefono",data.PhoneNumber,DbType.String );
                query.ExecuteQuery();
            } catch(Exception ex) {
                throw ex;
            }
        }


        public new void FindById(string id) {
            sql.Append( "select * from fv_user.vwObtenerDatosComerciales where id_cliente=:pId " );
            base.FindById( id );
        }

        public void DeleteComercialData(string comercialID) {
            IQueryAction query = DefineQueryAction( "spEliminarDatosComerciales " );
            query.AddParameter( "pIdComercial",comercialID,DbType.String );
            query.ExecuteQuery();
        }



    }
}
