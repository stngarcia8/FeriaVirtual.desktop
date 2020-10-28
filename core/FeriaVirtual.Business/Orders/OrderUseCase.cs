using System;
using System.Collections.Generic;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Orders;

namespace FeriaVirtual.Business.Orders {

    public class OrderUseCase {
        private readonly OrderRepository repository;

        // Constructor
        private OrderUseCase() {
            repository=OrderRepository.OpenRepository();
        }

        // Named constructor
        public static OrderUseCase CreateUseCase() {
            return new OrderUseCase();
        }

        public void NewOrder(Order order,string clientID) {
            try {
                IValidator validator = OrderValidator.CreateValidator(order,false);
                validator.Validate();
                repository.NewOrder(order,clientID);
            } catch(Exception) {
                throw;
            }
        }

        public void EditOrder(Order order,string clientID) {
            try {
                IValidator validator = OrderValidator.CreateValidator(order,true);
                validator.Validate();
                repository.EditOrder(order,clientID);
            } catch(Exception) {
                throw;
            }
        }

        public void DeleteOrder(string orderID) {
            try {
                repository.DeleteOrder(orderID);
            } catch(Exception ex) {
                throw;
            }
        }

        public IList<OrderDto> GetOrderToPublish(int statusID, string customerID) {
            try {
                return repository.PublishOrdersToApi(statusID, customerID);
            }catch (Exception ex) {
                throw ex;
            }
        }





    }
}