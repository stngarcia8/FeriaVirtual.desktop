using System;
using FeriaVirtual.Business.Documents;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Contracts;

namespace FeriaVirtual.Business.Contracts {

    public class ContractUseCase {
        private readonly ContractRepository repository;
        private readonly string singleProfileName;
        private readonly string profileName;

        // constructor
        private ContractUseCase(int profileID) {
            repository = ContractRepository.OpenRepository(profileID);
            this.singleProfileName= (profileID.Equals(5)?"Productor":"Transportista");
            this.profileName= (profileID.Equals(5) ? "Productores" : "Transportistas");
        }


        private ContractUseCase(int profileID,string singleProfileName) {
            repository = ContractRepository.OpenRepository(profileID);
            this.singleProfileName= singleProfileName;
            this.profileName= (singleProfileName.ToLower().Equals("productor") ? "Productores" : "Transportistas");
        }

        // Named constructors.
        public static ContractUseCase CreateUseCase(int profileID) {
            return new ContractUseCase(profileID);
        }
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

        public Contract FindOneContractByID(string contractID) {
            return repository.FindOneContractById(contractID);
        }

        public void NewContract(Contract contract) {
            try {
                IValidator validator = ContractValidator.CreateValidator(contract,false,singleProfileName);
                validator.Validate();
                repository.NewContract(contract);
            } catch(Exception ex) {
                throw;
            }
        }

        public void EditContract(Contract contract) {
            try {
                IValidator validator = ContractValidator.CreateValidator(contract,true,singleProfileName);
                validator.Validate();
                repository.EditContract(contract);
            } catch(Exception ex) {
                throw;
            }
        }

        public void DeleteContract(string contractID) {
            try {
                repository.DeleteContract(contractID);
            } catch(Exception ex) {
                throw;
            }
        }

        public void AcceptContract(string contractID, string clientID, string observation) {
            try {
                Contract contract = repository.FindOneContractAceptedById(contractID);
                foreach(ContractDetail d in contract.Details) {
                    if(d.Customer.ID!=clientID) {
                        contract.RemoveDetail(d);
                    } else {
                        d.ClientObservation= observation;
                    }
                }
                ContractGenerator generator = ContractGenerator.CreateContract(contract, singleProfileName, profileName);
                generator.Generate();
                string filePath = generator.PdfFilePath;
                generator= null;
                repository.AcceptContract(contract, filePath);
            } catch(Exception ex) {
                throw;
            }
        }


        public void ContractRefuse(string contractID,string clientID,string observation) {
            try {
                repository.RefuseContract(contractID,clientID,observation);
            } catch(Exception ex) {
                throw;
            }
        }




    }
}