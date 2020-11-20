using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Business.Orders {

    public class OrderUseCase{

        private readonly OrderRepository repository;


        // Constructor
        private OrderUseCase(){
            repository = OrderRepository.OpenRepository();
        }


        // Named constructor
        public static OrderUseCase CreateUseCase(){
            return new OrderUseCase();
        }


        public DataTable GetOrderByStatus(int statusId, int rolId){
            repository.GetOrderByStatus(statusId, rolId);
            return repository.DataSource;
        }


        public DataTable GetOrderDetailById(string orderId){
            repository.GetOrderDetailById(orderId);
            return repository.DataSource;
        }


        public void NewOrder(Order order, string clientId){
            IValidator validator = OrderValidator.CreateValidator(order, false);
            validator.Validate();
            repository.NewOrder(order, clientId);
        }


        public void EditOrder(Order order, string clientId){
            IValidator validator = OrderValidator.CreateValidator(order, true);
            validator.Validate();
            repository.EditOrder(order, clientId);
        }


        public void DeleteOrder(string orderId){
            repository.DeleteOrder(orderId);
        }


        public IList<OrderDto> GetOrderToPublish(int statusId, string customerId){
            return repository.PublishOrdersToApi(statusId, customerId);
        }


        public DataTable GetGenerateProposeProduct(string orderId){
            repository.GenerateProposeProduct(orderId);
            repository.GetProposeProduct(orderId);
            return repository.DataSource;
        }

        public DataTable GetOnlyGenerateProposeProduct(string orderId){
            repository.GetProposeProduct(orderId);
            return repository.DataSource;
        }

        public void AceptProposeProducts(string orderId){
            repository.AceptProposeProducts(orderId);
        }

    }

}