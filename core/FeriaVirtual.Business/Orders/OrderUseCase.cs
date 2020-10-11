using System;
using NLog;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Orders {

    public class OrderUseCase {
        private static Logger logger = LogManager.GetCurrentClassLogger();
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
            } catch(Exception ex) {
                logger.Error(ex,"Error creando solicitud");
                throw;
            }
        }

        public void EditOrder(Order order,string clientID) {
            try {
                IValidator validator = OrderValidator.CreateValidator(order,true);
                validator.Validate();
                repository.EditOrder(order,clientID);
            } catch(Exception ex) {
                logger.Error(ex,"Error al editar solicitud de compra");
                throw;
            }
        }
    }
}