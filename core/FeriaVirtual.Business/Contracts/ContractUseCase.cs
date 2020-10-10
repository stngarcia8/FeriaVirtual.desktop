using System;
using FeriaVirtual.Domain.Contracts;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Contracts;

namespace FeriaVirtual.Business.Contracts {

    public class ContractUseCase {

        private ContractRepository repository;
        private readonly int profileID;
        private readonly string singleProfileName;


        // constructor
        private ContractUseCase(int profileID,string singleProfileName) {
            repository = ContractRepository.OpenRepository(profileID);
            this.profileID= profileID;
            this.singleProfileName=singleProfileName;
        }

        // Named constructor.
        public static ContractUseCase CreateUseCase(int profileID,string singleProfileName) {
            return new ContractUseCase(profileID,singleProfileName);
        }


        public DataTable FindAll() {
            repository.FindAll();
            return repository.DataSource;
        }


        public DataTable FindValidContract() {
            repository.FindValidContracts();
            return repository.DataSource;
        }


        public DataTable FindInvalidContracts() {
            repository.FindInvalidContracts();
            return repository.DataSource;
        }


        public DataTable FindContractById(string contractID) {
            repository.FindById(contractID);
            return repository.DataSource;
        }

        public Contract  FindOneContractByID(string contractID) {
            return repository.FindOneContractById(contractID);
        }

        public void NewContract(Contract contract) {
            try {
                IValidator validator = ContractValidator.CreateValidator(contract,false,profileID,singleProfileName);
                validator.Validate();
                repository.NewContract(contract);
            } catch(Exception ex) {
                throw ex;
            }
        }


        public void EditContract(Contract contract) {
            try {
                IValidator validator = ContractValidator.CreateValidator(contract,true,profileID,singleProfileName);
                validator.Validate();
                repository.EditContract(contract);
            } catch(Exception ex) {
                throw ex;
            }
        }


        public void DeleteContract(string contractID) {
            try {
                repository.DeleteContract(contractID);
            } catch(Exception ex) {
                throw ex;
            }
        }



    }

}
