using System.Data;
using FeriaVirtual.Data.HelpersRepository;


namespace FeriaVirtual.Business.HelpersUseCases {

    public class SafeUseCase{

        private readonly SafeRepository repository;


        // Constructor.
        public SafeUseCase(){
            repository = SafeRepository.OpenRepository();
        }


        // Named constructor
        public static SafeUseCase CreateUseCase(){
            return new SafeUseCase();
        }


        public DataTable FindAll(){
            repository.FindAll();
            return repository.DataSource;
        }

    }

}