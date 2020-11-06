using System;
using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class OrderRepository:Repository {
        private readonly Order order;

        // properties
        public Order Order => order;

        // Constructor
        private OrderRepository() : base() {
            order = Order.CreateOrder();
        }

        // Named constructor
        public static OrderRepository OpenRepository() {
            return new OrderRepository();
        }

        public void GetOrderByStatus(int statusID,int rolID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerPedidoToApi where id_estado=:pIdEstado and id_rol=:pIdRol ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdEstado",statusID,DbType.Int32);
            querySelect.AddParameter("pIdRol",rolID,DbType.Int32);
            dataTable= querySelect.ExecuteQuery();
        }

        public DataTable GetOrderDetailById(string orderID) {
            sql.Clear();
            sql.Append("select * from fv_user.detalle_pedido where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            return DataSource;
        }

        public void GenerateProposeProduct(string orderID) {
            try {
                IQueryAction queryAction = DefineQueryAction("spGenerarPropuestaProductos  ");
                queryAction.AddParameter("idped",orderID,DbType.String);
                queryAction.ExecuteQuery();
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void GetProposeProduct(string orderID) {
            sql.Clear();
            sql.Append("select * from vwObtenerResultadoPropuesta where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            dataTable= querySelect.ExecuteQuery();
        }

        public void NewOrder(Order order,string clientID) {
            IQueryAction query = DefineQueryAction("spAgregarPedido ");
            query.AddParameter("pIdCliente",clientID,DbType.String);
            query = DefineParameters(order,query);
            query.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
            query.ExecuteQuery();
            OrderDetailSave(order);
        }

        public void EditOrder(Order order,string clientID) {
            IQueryAction query = DefineQueryAction("spActualizarPedido ");
            query = DefineParameters(order,query);
            query.ExecuteQuery();
            OrderDetailSave(order);
        }

        private IQueryAction DefineParameters(Order order,IQueryAction query) {
            query.AddParameter("pIdPedido",order.OrderID,DbType.String);
            query.AddParameter("pIdCondicion",order.Condition.ConditionID,DbType.Int32);
            query.AddParameter("pDescuento",order.OrderDiscount,DbType.Double);
            query.AddParameter("pObservacion",order.Observation,DbType.String);
            return query;
        }

        private void OrderDetailSave(Order order) {
            foreach(OrderDetail d in order.OrderDetailList) {
                IQueryAction queryDetail = DefineQueryAction("spAgregarDetallePedido ");
                queryDetail.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
                queryDetail.AddParameter("pIdPedido",order.OrderID,DbType.String);
                queryDetail.AddParameter("pProducto",d.ProductName,DbType.String);
                queryDetail.AddParameter("pCantidad",d.Quantity,DbType.Double);
                queryDetail.ExecuteQuery();
            }
        }

        public void DeleteOrder(string orderID) {
            IQueryAction query = DefineQueryAction("spEliminarPedido ");
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query.ExecuteQuery();
        }

        public IList<OrderDto> PublishOrdersToApi(int statusID,string customerID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerPedidoToApi where id_cliente=:pId and id_estado=:pIdEstado ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",customerID,DbType.String);
            querySelect.AddParameter("pIdEstado",statusID,DbType.Int32);
            return GetOrderDataToPublish(querySelect.ExecuteQuery());
        }

        private IList<OrderDto> GetOrderDataToPublish(DataTable data) {
            if(data.Rows.Count.Equals(0)) {
                return null;
            }
            IList<OrderDto> orderList = new List<OrderDto>();
            foreach(DataRow row in data.Rows) {
                orderList.Add(GetOrderDataFromDataRow(row));
            }
            return orderList;
        }

        private OrderDto GetOrderDataFromDataRow(DataRow row) {
            OrderDto o = new OrderDto {
                OrderID = row["id_pedido"].ToString(),
                ClientID= row["id_cliente"].ToString()
            };
            o.Condition.ConditionID = int.Parse(row["id_condicion"].ToString());
            o.Condition.ConditionDescription= row["Condicion pago"].ToString();
            o.OrderDate= DateTime.Parse(row["Fecha orden"].ToString()).ToString("YYYY/MM/dd");
            o.OrderDiscount = float.Parse(row["Descuento"].ToString());
            o.Observation = row["Observación"].ToString();
            o.OrderDetailList = SearchDetailsFromOrder(o.OrderID);
            return o;
        }

        public IList<OrderDetail> SearchDetailsFromOrder(string orderID) {
            sql.Clear();
            sql.Append("select * from fv_user.detalle_pedido where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            return GetOrderDetailDataToOrder(querySelect.ExecuteQuery());
        }

        public IList<OrderDetail> GetOrderDetailDataToOrder(DataTable dataDetail) {
            IList<OrderDetail> detailList = new List<OrderDetail>();
            if(dataDetail.Rows.Count.Equals(0)) {
                return detailList;
            }
            foreach(DataRow r in dataDetail.Rows) {
                detailList.Add(GetDetailDataFromRow(r));
            }
            return detailList;
        }

        private OrderDetail GetDetailDataFromRow(DataRow r) {
            OrderDetail d = OrderDetail.CreateDetail();
            d.OrderDetailID = r["id"].ToString();
            d.OrderID = r["id_pedido"].ToString();
            d.ProductName = r["nombre_producto"].ToString();
            d.Quantity = float.Parse(r["cantidad"].ToString());
            return d;
        }

        public void AceptProposeProducts(string orderID) {
            IQueryAction query = DefineQueryAction("spAceptarPropuestaProductos ");
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
            query.ExecuteQuery();
        }

        public void NewAuction(Auction auction,string orderID) {
            IQueryAction query = DefineQueryAction("spAgregarSubasta ");
            query.AddParameter("pIdSubasta",auction.AuctionID,DbType.String);
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query = DefineAuctionParameters(auction,query);
            query.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
            query.ExecuteQuery();
        }

        public void EditAuction(Auction auction,string orderID) {
            IQueryAction query = DefineQueryAction("spActualizarSubasta ");
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query = DefineAuctionParameters(auction,query);
            query.ExecuteQuery();
        }

        private IQueryAction DefineAuctionParameters(Auction auction,IQueryAction query) {
            query.AddParameter("pPorcentaje",auction.Percent,DbType.Double);
            query.AddParameter("pValor",auction.Value,DbType.Double);
            query.AddParameter("pPeso",auction.Weight,DbType.Double);
            query.AddParameter("pFechaLimite",auction.LimitDate,DbType.Date);
            query.AddParameter("pObservacion",auction.Observation,DbType.String);
            return query;
        }

        public void DeleteAuction(string orderID) {
            IQueryAction query = DefineQueryAction("spEliminarSubasta ");
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query.ExecuteQuery();
        }

        public void CloseAuction(string orderID, string auctionID) {
            IQueryAction query = DefineQueryAction("spCerrarSubasta ");
            query.AddParameter("pIdSubasta",auctionID,DbType.String);
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
            query.ExecuteQuery();
        }

        public void ChangeAuctionStatus(string auctionID,int status) {
            IQueryAction query = DefineQueryAction("spCambiarEstadoSubasta ");
            query.AddParameter("pIdSubasta",auctionID,DbType.String);
            query.AddParameter("pEstado",status,DbType.Int32);
            query.ExecuteQuery();
        }

        public  IList<Auction> FinAllAuction() {
            sql.Clear();
            sql.Append("select * from fv_user.vwSubastas where estado_subasta=1 ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            return GetAllAvailableAuction(querySelect.ExecuteQuery());
        }

        public new  IList<Auction> GetAllAvailableAuction(DataTable data) {
            IList<Auction> auctionList = new List<Auction>();
            if(data.Rows.Count.Equals(0)) {
                return auctionList;
            }
            string orderID = string.Empty;
            foreach(DataRow row in data.Rows) {
                orderID = row["id_pedido"].ToString();
                auctionList.Add(ExtractAuctionDataFromDatarow(row, orderID));
            }
            return auctionList;
        }

        public Auction GetAuctionById(string orderID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwSubastas where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            return GetAuctionData(querySelect.ExecuteQuery(),orderID);
        }

        private Auction GetAuctionData(DataTable data,string orderID) {
            if(data.Rows.Count.Equals(0)) {
                return null;
            }
            DataRow row = data.Rows[0];
            return ExtractAuctionDataFromDatarow(row, orderID);
        }

        private Auction ExtractAuctionDataFromDatarow(DataRow row,string orderID) {
            Auction a = Auction.CreateAuction();
            a.AuctionID = row["id_subasta"].ToString();
            a.AuctionDate = DateTime.Parse(row["Fecha subasta"].ToString());
            a.Percent = float.Parse(row["valor_porcentaje"].ToString());
            a.Value = float.Parse(row["valor_propuesto"].ToString());
            a.Weight = float.Parse(row["peso_comprometido"].ToString());
            a.LimitDate=DateTime.Parse(row["Fecha limite"].ToString());
            a.Observation= row["Observación"].ToString();
            a.CarrierName= row["Transportista"].ToString();
            a.BidValue= float.Parse(row["valor_puja"].ToString());
            if (!string.IsNullOrEmpty(row["Fecha puja"].ToString())) {
                a.BidValueDate= DateTime.Parse(row["Fecha puja"].ToString());
            }
            a.DispachObservation= row["Observacion transportista"].ToString();
            if(!string.IsNullOrEmpty(row["Fecha respuesta"].ToString())) {
                a.DispachDate= DateTime.Parse(row["Fecha respuesta"].ToString());
            }
            a.CompanyName = row["empresa"].ToString();
            a.Destination = row["dir"].ToString();
            a.PhoneNumber = row["fono"].ToString();
            a.Status= int.Parse(row["estado_subasta"].ToString());
            a.Products = GetAuctionProduct(orderID);
            return a;
        }

        private IList<AuctionProduct> GetAuctionProduct(string orderID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerProductosSubasta where id_pedido=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",orderID,DbType.String);
            return GetAuctionProductDetail(querySelect.ExecuteQuery());
        }

        private IList<AuctionProduct> GetAuctionProductDetail(DataTable data) {
            IList<AuctionProduct> products = new List<AuctionProduct>();
            if(data.Rows.Count.Equals(0)) {
                return products;
            }
            foreach(DataRow row in data.Rows) {
                products.Add(GetAuctionProductDetail(row));
            }
            return products;
        }

        private AuctionProduct GetAuctionProductDetail(DataRow row) {
            AuctionProduct ap = AuctionProduct.CreateAuctionProduct();
            ap.Product = row["Producto"].ToString();
            ap.UnitValue = float.Parse(row["Valor unitario"].ToString());
            ap.Quantity = float.Parse(row["Cantidad"].ToString());
            ap.TotalValue = float.Parse(row["Total producto"].ToString());
            return ap;
        }

        public void SaveAuctionBidValue(AuctionBidValue bidValue) {
            IQueryAction query = DefineQueryAction("spGrabarPropuestaSubasta ");
            query.AddParameter("pIdResultado",bidValue.ValueID,DbType.String);
            query.AddParameter("pIdSubasta",bidValue.AuctionID,DbType.String);
            query.AddParameter("pIdCliente",bidValue.ClientID,DbType.String);
            query.AddParameter("pValor",bidValue.Value,DbType.Int32);
            query.ExecuteQuery();
        }

        public void GetBidValueByAuctionID(string auctionID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerPujaSubasta where id_subasta=:pIdSubasta ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdSubasta",auctionID,DbType.String);
            dataTable= querySelect.ExecuteQuery();
        }

        public void NewOrderDispatch(Auction auction, string orderID, string clientID, int safeID) {
            IQueryAction query = DefineQueryAction("spAgregarOrdenDespacho ");
            query.AddParameter("pIdOrden",auction.AuctionID,DbType.String);
            query.AddParameter("pIdPedido",orderID,DbType.String);
            query.AddParameter("pFechaRetiro",auction.DispachDate,DbType.Date);
            query.AddParameter("pObservacion",auction.DispachObservation,DbType.String);
            query.AddParameter("pIdCliente",clientID,DbType.String);
            query.AddParameter("pIdSeguro",safeID,DbType.Int32);
            query.AddParameter("pCosto",auction.Value,DbType.Double);
            query.AddParameter("pGuid",Guid.NewGuid().ToString(),DbType.String);
            query.ExecuteQuery();
            OrderDispatchDetailSave(auction,auction.AuctionID);
        }

        private void OrderDispatchDetailSave(Auction auction, string orderID) {
            foreach(AuctionProduct p in auction.Products) {
                IQueryAction queryDetail = DefineQueryAction("spAgregarDetalleDespacho ");
                queryDetail.AddParameter("pId",Guid.NewGuid().ToString(),DbType.String);
                queryDetail.AddParameter("pIdOrden",orderID,DbType.String);
                queryDetail.AddParameter("pProducto",p.Product,DbType.String);
                queryDetail.AddParameter("pValor",p.UnitValue,DbType.Double);
                queryDetail.AddParameter("pCantidad",p.Quantity,DbType.Double);
                queryDetail.AddParameter("pTotal",p.TotalValue,DbType.Double);
                queryDetail.ExecuteQuery();
            }
        }






    }
}