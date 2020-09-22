using System;
using System.Data;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Infraestructure.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Data.Repository {

    public class ComercialDataRepository:Repository {


        // Constructor
        private ComercialDataRepository() : base() { }

        // Named constructor
        public static ComercialDataRepository OpenRepository() {
            return new ComercialDataRepository();
        }

        public void NewComercialData(ComercialData data, string clientID) {
            IQueryAction query = DefineQueryAction( "spAgregarDatosComerciales " );
            query.AddParameter( "pIdComercial",data.ComercialID,DbType.String );
            query.AddParameter( "pIdCliente",clientID,DbType.String );
            query.AddParameter( "pIdCiudad",data.CityID,DbType.Int32 );
            query.AddParameter( "pRSocial",data.CompanyName,DbType.String );
            query.AddParameter( "pFantasia",data.FantasyName,DbType.String );
            query.AddParameter( "pGiro",data.ComercialBusiness,DbType.String );
            query.AddParameter( "pEmail",data.Email,DbType.String );
            query.AddParameter( "pDNI",data.ComercialDNI,DbType.String );
            query.AddParameter( "pDireccion",data.Address,DbType.String );
            query.ExecuteQuery();
        }


        public void EditComercialData(ComercialData data,string clientID) {
            try {
                IQueryAction query = DefineQueryAction( "spActualizarDatosComerciales " );
                query.AddParameter( "pIdComercial",data.ComercialID,DbType.String );
                query.AddParameter( "pIdCiudad",data.CityID,DbType.Int32 );
                query.AddParameter( "pRSocial",data.CompanyName,DbType.String );
                query.AddParameter( "pFantasia",data.FantasyName,DbType.String );
                query.AddParameter( "pGiro",data.ComercialBusiness,DbType.String );
                query.AddParameter( "pEmail",data.Email,DbType.String );
                query.AddParameter( "pDNI",data.ComercialDNI,DbType.String );
                query.AddParameter( "pDireccion",data.Address,DbType.String );
                query.ExecuteQuery();
            } catch (Exception ex) {
                throw ex;
            }
        }


    public new void FindById(string id) {
            sql.Append( "select * from fv_user.vwObtenerDatosComerciales where id_comercial=:pId " );
            base.FindById( id );
        }





    }
}
