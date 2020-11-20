using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FeriaVirtual.Domain.Offers;
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

        public void NewOffer(Offer offer){
            var query = DefineQueryAction("spCrearofertas ");
            DefineOfferParameters(offer, query);
            query.ExecuteQuery();
            OfferDetailSave(offer);
        }

        public void EditOffer(Offer offer){
            var query = DefineQueryAction("spActualizarOfertas ");
            DefineOfferParameters(offer, query);
            query.ExecuteQuery();
            OfferDetailSave(offer);
        }

        private void DefineOfferParameters(Offer offer, IQueryAction queryAction){
            queryAction.AddParameter("pIdOferta", offer.OfferId, DbType.String);
            queryAction.AddParameter("pDescripcion", offer.Description, DbType.String);
            queryAction.AddParameter("pDescuento", offer.Discount, DbType.Double);
            queryAction.AddParameter("pTipo", offer.OfferType, DbType.Int32);
        }

        private void OfferDetailSave(Offer offer){
            foreach (var d in offer.Details){
                var queryDetail = DefineQueryAction("spAgregarDetalleOferta ");
                queryDetail.AddParameter("pIdDetalle", d.OfferDetailId, DbType.String);
                queryDetail.AddParameter("pIdOferta", offer.OfferId, DbType.String);
                queryDetail.AddParameter("pIdProducto", d.ProductId, DbType.String);
                queryDetail.AddParameter("pValor", d.ActualValue, DbType.Double);
                queryDetail.ExecuteQuery();
            }
        }

        public void DeleteOffer(string offerId){
            var query = DefineQueryAction("spEliminarOferta ");
            query.AddParameter("pIdOferta", offerId, DbType.String);
            query.ExecuteQuery();
        }

        public void EnableOffer(string offerId){
            var query = DefineQueryAction("spCambiarEstadoOferta ");
            query.AddParameter("pIdOferta", offerId, DbType.String);
            query.AddParameter("pEstado", 1, DbType.Int32);
            query.ExecuteQuery();
        }

        public void DisableOffer(string offerId){
            var query = DefineQueryAction("spCambiarEstadoOferta ");
            query.AddParameter("pIdOferta", offerId, DbType.String);
            query.AddParameter("pEstado", 2, DbType.Int32);
            query.ExecuteQuery();
        }


        public IList<OfferDto> PublishOffersToApi(){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerOfertas where estado_oferta=1 ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            return GetOfferDataToPublish(querySelect.ExecuteQuery());
        }

        private IList<OfferDto> GetOfferDataToPublish(DataTable data){
            return data.Rows.Count.Equals(0)
                ? null
                : (from DataRow row in data.Rows select GetOfferDataFromDataRow(row)).ToList();
        }


        public OfferDto FindOfferById(string offerId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerOfertas where id_oferta=:pIdOferta ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdOferta", offerId, DbType.String);
            return GetOfferDataByIdFromDataTable(querySelect.ExecuteQuery());
        }


        private OfferDto GetOfferDataByIdFromDataTable(DataTable data){
            if(data.Rows.Equals(0)) return null;
            return GetOfferDataFromDataRow(data.Rows[0]);
        }

        private OfferDto GetOfferDataFromDataRow(DataRow row){
            var o = new OfferDto{
                OfferId = row["id_oferta"].ToString(),
                Description = row["Descripcion"].ToString(),
                Discount = float.Parse(row["Descuento"].ToString()),
                PublishDate = DateTime.Parse( row["Fecha publicacion"].ToString()).ToString("yyyy-MM-dd"),
                OfferType = int.Parse(row["tipo_oferta"].ToString()),
                TypeDescription = row["Tipo"].ToString(),
                Status = int.Parse(row["estado_oferta"].ToString()),
                StatusDescription = row["Estado"].ToString()
            };
            o.Details= SearchDetailsFromOffer(o.OfferId);
            return o;
        }

        public IList<OfferDetail> SearchDetailsFromOffer(string offerId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerDetalleOfertas where id_oferta=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", offerId, DbType.String);
            return GetOrderDetailDataToOrder(querySelect.ExecuteQuery());
        }

        public IList<OfferDetail> GetOrderDetailDataToOrder(DataTable dataDetail){
            IList<OfferDetail> detailList = new List<OfferDetail>();
            if (dataDetail.Rows.Count.Equals(0)) return detailList;
            foreach (DataRow r in dataDetail.Rows) detailList.Add(GetDetailDataFromRow(r));
            return detailList;
        }

        private OfferDetail GetDetailDataFromRow(DataRow r){
            var d = OfferDetail.CreateDetail();
            d.OfferDetailId= r["id_detalle"].ToString();
            d.ProductId = r["id_producto"].ToString();
            d.ProductName = r["Producto"].ToString();
            d.ActualValue = float.Parse(r["valor_original"].ToString());
            d.Percent = r["Descuento aplicado"].ToString();
            d.OfferValue = float.Parse(r["Valor oferta"].ToString());
            return d;
        }






    }
}
