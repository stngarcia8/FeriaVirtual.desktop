using System;
using System.Data;
using FeriaVirtual.Data.HelpersRepository;
using NLog;

namespace FeriaVirtual.Business.HelpersUseCases {

    public class ContractTypeUseCase {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ContractTypeRepository repository;

        // Constructor.
        public ContractTypeUseCase() {
            repository = ContractTypeRepository.OpenRepository();
        }

        // Named constructor
        public static ContractTypeUseCase CreateUseCase() {
            return new ContractTypeUseCase();
        }

        public DataTable FindAll() {
            try {
                repository.FindAll();
                return repository.DataSource;
            } catch(Exception ex) {
                logger.Error(ex,"Error cargando tipos de contratos");
                throw;
            }
        }
    }
}