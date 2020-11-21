using System;
using System.Data;
using FeriaVirtual.Domain.Offers;
using FeriaVirtual.Data;
using System.Collections.Generic;
using FeriaVirtual.Business.Validators;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Business.Offers {
    public class OfferUseCase{

        private Data.Repository.OfferRepository repository;


        private OfferUseCase(){
            repository = Data.Repository.OfferRepository.OpenRepository();
        }


        public static OfferUseCase CreateUsecase(){
            return new OfferUseCase();
        }


        public DataTable FindOffersByStatus(int status){
            repository.FindOffersByStatus(status);
            return repository.DataSource;
        }


        public DataTable FindOfferDetailByOffer(string offerId){
            repository.FindOfferDetailByOffer(offerId);
            return repository.DataSource;
        }


        public OfferDto GetOfferById(string offerId){
            return repository.FindOfferById(offerId);
        }


        public void NewOffer(Offer offer){
            OfferValidator validator = OfferValidator.CreateValidator(offer, false);
            validator.Validate();
            repository.NewOffer(offer);
        }

        public void EditOffer(Offer offer){
            OfferValidator validator = OfferValidator.CreateValidator(offer, true);
            validator.Validate();
            repository.EditOffer(offer);
        }

        public void DeleteOffer(string offerId){
            repository.DeleteOffer(offerId);
        }

        public void EnableOffer(string offerId){
            repository.EnableOffer(offerId);
        }

        public void DisableOffer(string offerId){
            repository.DisableOffer(offerId);
        }






    }
}
