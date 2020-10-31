using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable GetOrderByStatus(int statusID, int rolID) {
            try {
                repository.GetOrderByStatus(statusID, rolID);
                return repository.DataSource;
            } catch(Exception ex) {
                throw ex;
            }
        }

        public DataTable GetOrderDetailByID(string orderID) {
            try {
                repository.GetOrderDetailById(orderID);
                return repository.DataSource;
            } catch(Exception ex) {
                throw ex;
            }
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
            } catch(Exception) {
                throw;
            }
        }

        public IList<OrderDto> GetOrderToPublish(int statusID,string customerID) {
            try {
                return repository.PublishOrdersToApi(statusID,customerID);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public DataTable GetGenerateProposeProduct(string orderID) {
            try {
                repository.GenerateProposeProduct(orderID);
                repository.GetProposeProduct(orderID);
                return repository.DataSource;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void AceptProposeProducts(string orderID) {
            try {
                repository.AceptProposeProducts(orderID);
            }catch (Exception ex) {
                throw ex;
            }
        }




    }
}
