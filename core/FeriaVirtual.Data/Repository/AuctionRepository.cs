using System;
using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Data.Notifiers;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository{

    public class AuctionRepository : Repository{

        private readonly IQueueNotifier Notifier;


        private AuctionRepository(){
            Notifier = QueueNotifier.CreateNotifier();
        }


        public static AuctionRepository OpenRepository(){
            return new AuctionRepository();
        }


        public void NewAuction(Auction auction, string orderId){
            var query = DefineQueryAction("spAgregarSubasta ");
            query.AddParameter("pIdSubasta", auction.AuctionId, DbType.String);
            query.AddParameter("pIdPedido", orderId, DbType.String);
            query = DefineAuctionParameters(auction, query);
            query.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
            Notifier.Notify("maipogrande", "Order", "ChangeStatus", ChangeMessageStatus.Create(orderId, 3));
            var xAuction = TransformAuctionToAuctionDto(GetAuctionById(orderId));
            Notifier.Notify("maipogrande", "Auction", "AuctionWasCreate", xAuction);
        }


        public void EditAuction(Auction auction, string orderId){
            var query = DefineQueryAction("spActualizarSubasta ");
            query.AddParameter("pIdPedido", orderId, DbType.String);
            query = DefineAuctionParameters(auction, query);
            query.ExecuteQuery();
        }


        private IQueryAction DefineAuctionParameters(Auction auction, IQueryAction query){
            query.AddParameter("pPorcentaje", auction.Percent, DbType.Double);
            query.AddParameter("pValor", auction.Value, DbType.Double);
            query.AddParameter("pPeso", auction.Weight, DbType.Double);
            query.AddParameter("pFechaLimite", auction.LimitDate, DbType.Date);
            query.AddParameter("pObservacion", auction.Observation, DbType.String);
            return query;
        }


        public void DeleteAuction(string orderId){
            var query = DefineQueryAction("spEliminarSubasta ");
            query.AddParameter("pIdPedido", orderId, DbType.String);
            query.ExecuteQuery();
            Notifier.Notify("maipogrande", "Order", "ChangeStatus", ChangeMessageStatus.Create(orderId, 2));
        }


        public void CloseAuction(string orderId, string auctionId){
            var query = DefineQueryAction("spCerrarSubasta ");
            query.AddParameter("pIdSubasta", auctionId, DbType.String);
            query.AddParameter("pIdPedido", orderId, DbType.String);
            query.AddParameter("pGuid", Guid.NewGuid().ToString(), DbType.String);
            query.ExecuteQuery();
            Notifier.Notify("maipogrande", "Auction", "AuctionWasClose", ChangeMessageStatus.Create(auctionId, 3));
            Notifier.Notify("maipogrande", "Order", "ChangeStatus", ChangeMessageStatus.Create(orderId, 4));
        }


        public void ChangeAuctionStatus(string auctionId, int status){
            var query = DefineQueryAction("spCambiarEstadoSubasta ");
            query.AddParameter("pIdSubasta", auctionId, DbType.String);
            query.AddParameter("pEstado", status, DbType.Int32);
            query.ExecuteQuery();
        }


        public void RemoveAuctionBidValue(string auctionId, string orderId){
            var query = DefineQueryAction("spQuitarPujasSubasta ");
            query.AddParameter("pIdSubasta", auctionId, DbType.String);
            query.AddParameter("pIdPedido", orderId, DbType.String);
            query.ExecuteQuery();
            Notifier.Notify("maipogrande", "Auction", "AuctionWasPublish", ChangeMessageStatus.Create(auctionId, 1));
            Notifier.Notify("maipogrande", "Order", "ChangeStatus", ChangeMessageStatus.Create(orderId, 3));
        }


        public IList<Auction> FinAllAuction(){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwSubastas where estado_subasta=1 ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            return GetAllAvailableAuction(querySelect.ExecuteQuery());
        }


        public IList<Auction> GetAllAvailableAuction(DataTable data){
            IList<Auction> auctionList = new List<Auction>();
            if (data.Rows.Count.Equals(0)) return auctionList;

            foreach (DataRow row in data.Rows){
                var orderId = row["id_pedido"].ToString();
                auctionList.Add(ExtractAuctionDataFromDatarow(row, orderId));
            }

            return auctionList;
        }


        public Auction GetAuctionById(string orderId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwSubastas where id_pedido=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", orderId, DbType.String);
            return GetAuctionData(querySelect.ExecuteQuery(), orderId);
        }


        private Auction GetAuctionData(DataTable data, string orderId){
            if (data.Rows.Count.Equals(0)) return null;

            var row = data.Rows[0];
            return ExtractAuctionDataFromDatarow(row, orderId);
        }


        private Auction ExtractAuctionDataFromDatarow(DataRow row, string orderId){
            var a = Auction.CreateAuction();
            a.AuctionId = row["id_subasta"].ToString();
            a.AuctionDate = DateTime.Parse(row["Fecha subasta"].ToString());
            a.Percent = float.Parse(row["valor_porcentaje"].ToString());
            a.Value = float.Parse(row["valor_propuesto"].ToString());
            a.Weight = float.Parse(row["peso_comprometido"].ToString());
            a.LimitDate = DateTime.Parse(row["Fecha limite"].ToString());
            a.Observation = row["obs"].ToString();
            a.CarrierId = row["id_transportista"].ToString();
            a.CarrierName = row["Transportista"].ToString();
            a.BidValue = float.Parse(row["valor_puja"].ToString());
            if (!string.IsNullOrEmpty(row["Fecha puja"].ToString()))
                a.BidValueDate = DateTime.Parse(row["Fecha puja"].ToString());

            a.DispachObservation = row["Observacion transportista"].ToString();
            if (!string.IsNullOrEmpty(row["Fecha respuesta"].ToString()))
                a.DispachDate = DateTime.Parse(row["Fecha respuesta"].ToString());

            a.CompanyName = row["empresa"].ToString();
            a.Destination = row["dir"].ToString();
            a.Email = row["email"].ToString();
            a.PhoneNumber = row["fono"].ToString();
            a.Status = int.Parse(row["estado_subasta"].ToString());
            a.Products = GetAuctionProduct(orderId);
            return a;
        }


        private IList<AuctionProduct> GetAuctionProduct(string orderId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerProductosSubasta where id_pedido=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", orderId, DbType.String);
            return GetAuctionProductDetail(querySelect.ExecuteQuery());
        }


        private IList<AuctionProduct> GetAuctionProductDetail(DataTable data){
            IList<AuctionProduct> products = new List<AuctionProduct>();
            if (data.Rows.Count.Equals(0)) return products;

            foreach (DataRow row in data.Rows) products.Add(GetAuctionProductDetail(row));

            return products;
        }


        private AuctionProduct GetAuctionProductDetail(DataRow row){
            var ap = AuctionProduct.CreateAuctionProduct();
            ap.Product = row["Producto"].ToString();
            ap.UnitValue = float.Parse(row["Valor unitario"].ToString());
            ap.Quantity = float.Parse(row["Cantidad"].ToString());
            ap.TotalValue = float.Parse(row["Total producto"].ToString());
            return ap;
        }


        public void SaveAuctionBidValue(AuctionBidValue bidValue){
            var query = DefineQueryAction("spGrabarPropuestaSubasta ");
            query.AddParameter("pIdResultado", bidValue.ValueId, DbType.String);
            query.AddParameter("pIdSubasta", bidValue.AuctionId, DbType.String);
            query.AddParameter("pIdCliente", bidValue.ClientId, DbType.String);
            query.AddParameter("pValor", bidValue.Value, DbType.Int32);
            query.ExecuteQuery();
        }


        public void GetBidValueByAuctionId(string auctionId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerPujaSubasta where id_subasta=:pIdSubasta ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdSubasta", auctionId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }


        private AuctionDto TransformAuctionToAuctionDto(Auction a){
            var am = new AuctionDto{
                AuctionId = a.AuctionId,
                AuctionDate = a.AuctionDate.ToString("yyyy-MM-dd"),
                Percent = a.Percent,
                Value = a.Value,
                Weight = a.Weight,
                LimitDate = a.LimitDate.ToString("yyyy-MM-dd"),
                Observation = a.Observation,
                CompanyName = a.CompanyName,
                Destination = a.Destination,
                PhoneNumber = a.PhoneNumber,
                Status = a.Status,
                Products = a.Products
            };
            return am;
        }

    }

}