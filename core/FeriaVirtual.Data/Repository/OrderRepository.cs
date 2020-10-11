using System.Data;
using FeriaVirtual.Domain.Elements;
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

        public void NewOrder(Order order,string clientID) {
            IQueryAction query = DefineQueryAction("spAgregarPedido ");
            query.AddParameter("pIdCliente",clientID,DbType.String);
            query = DefineParameters(order,query);
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
            query.AddParameter("pDescuento",order.OrderDiscount,DbType.Decimal);
            return query;
        }

        private void OrderDetailSave(Order order) {
            foreach(OrderDetail d in order.OrderDetailList) {
                IQueryAction queryDetail = DefineQueryAction("spAgregarDetallePedido ");
                queryDetail.AddParameter("pIdPedido",order.OrderID,DbType.String);
                queryDetail.AddParameter("pIdProducto",d.ProductID,DbType.String);
                queryDetail.AddParameter("pCantidad",d.Quantity,DbType.Decimal);
                queryDetail.ExecuteQuery();
            }
        }
    }
}