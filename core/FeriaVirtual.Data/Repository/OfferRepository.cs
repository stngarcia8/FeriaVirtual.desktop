using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {
    public class OfferRepository:Repository {

        private OfferRepository(){}


        public static OfferRepository OpenRepository(){
            return new OfferRepository();
        }

        public void FindOffersByStatus( int status){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerOfertas where estado_oferta =:pEstado ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pEstado", status, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }

        public void FindOfferDetailByOffer( string offerId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerDetalleOfertas where id_oferta=:pIdOferta ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdOferta", offerId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }





    }
}
