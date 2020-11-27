using FeriaVirtual.Business.Validators;
using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Orders;

namespace FeriaVirtual.Business.Orders {
    public class PaymentUsecase {

        private readonly PaymentRepository repository;


        private PaymentUsecase() {
            repository = PaymentRepository.OpenRepository();
        }


        public static PaymentUsecase CreateUsecase() {
            return new PaymentUsecase();
        }


        public void NewPayment(Payment payment) {
            IValidator validator = PaymentValidator.CreateValidator(payment,false);
            validator.Validate();
            repository.NewPayment(payment);
        }

        public void EditPayment(Payment payment) {
            IValidator validator = PaymentValidator.CreateValidator(payment,true);
            validator.Validate();
            repository.NewPayment(payment);
        }


        public DataTable GetPaymentByEstatus(int filterType){
            int status = 0, profileId = 0;
            if (filterType.Equals(0)){
                status = 0;
                profileId = 3;
            }
            if (filterType.Equals(1)){
                status = 0;
                profileId = 4;
            }
            if (filterType.Equals(2)){
                status = 1;
                profileId = 3;
            }
            if (filterType.Equals(3)){
                status = 1;
                profileId = 4;
            }
            repository.GetPaymentByStatus(status, profileId);
            return repository.DataSource;
        }


        public DataTable GetPaymentById(string paymentId){
            repository.GetPaymentById(paymentId);
            return repository.DataSource;
        }

        public DataTable GetProducerIntoPayment(string orderId){
            repository.GetProducerIntoPayment(orderId);
            return repository.DataSource;
        }


        public void NotifyProducer(IList<PaymentResult> paymentResults){
            foreach (PaymentResult result in paymentResults){
                repository.NewNotificationPayment(result);
            }
        }




    }
}
