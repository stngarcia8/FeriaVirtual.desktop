using System.Data;
using FeriaVirtual.Data.Stats;


namespace FeriaVirtual.Business.Stats{

    public class StatsUsecase{

        private readonly StatRepository repository;


        private StatsUsecase(){
            repository = StatRepository.OpenRepository();
        }


        public static StatsUsecase CreateUsecase(){
            return new StatsUsecase();
        }


        public DataTable GetUserStats(){
            repository.UsersStats();
            return repository.DataSource;
        }

        public DataTable GetExternalCustomerOrderStats(){
            repository.ExternalCustomerOrdersStats();
            return repository.DataSource;
        }

        public DataTable GetInternalCustomerOrderStats(){
            repository.InternalCustomerOrdersStats();
            return repository.DataSource;
        }



    }

}