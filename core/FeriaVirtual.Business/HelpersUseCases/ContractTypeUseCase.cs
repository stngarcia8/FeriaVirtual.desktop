﻿using System;
using System.Data;
using FeriaVirtual.Data.HelpersRepository;

namespace FeriaVirtual.Business.HelpersUseCases {

    public class ContractTypeUseCase {
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
                throw ex;
            }
        }
    }
}