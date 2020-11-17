using System;
using System.Data;
using FeriaVirtual.Domain.Offers;
using FeriaVirtual.Data;
using System.Collections.Generic;
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



    }
}
