using System.Collections.Generic;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Business.Orders {

    public class OrderDispatchUseCase{

        private readonly OrderDispatchRepository repository;


        private OrderDispatchUseCase(){
            repository = OrderDispatchRepository.OpenRepository();
        }


        public static OrderDispatchUseCase CreateUseCase(){
            return new OrderDispatchUseCase();
        }


        public void CreateOrderDispatch(OrderDispatch orderDispatch){
            repository.NewOrderDispatch(orderDispatch);
        }


        public OrderDispatch GetOrderDispatchById(string orderId){
            return repository.FindOrderDispatchById(orderId);
        }

        public IList<OrderDispatch> GetAllOrderDispatch(string carrierId){
            return repository.FinAllOrderDispatch(carrierId);
        }


        public void AcceptOrderDispatch(string orderId, string observation){
            repository.AcceptOrderDispatch(orderId, observation);
        }


        public void RefuseOrderDispatch(string orderId, string observation){
            repository.RefuseOrderDispatch(orderId, observation);
        }

    }

}