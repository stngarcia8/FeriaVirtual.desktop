using System;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Elements;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Business.Orders {

    public class OrderUseCase {

        private OrderRepository repository;

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
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void EditOrder(Order order,string clientID) {
            try {
                IValidator validator = OrderValidator.CreateValidator(order,true);
                validator.Validate();
                repository.EditOrder(order,clientID);
            } catch(Exception ex) {
                throw ex;
            }
        }


    }
}
