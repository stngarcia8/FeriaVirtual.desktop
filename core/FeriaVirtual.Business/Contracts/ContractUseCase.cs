using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Contracts;


namespace FeriaVirtual.Business.Contracts {

    public class ContractUseCase{

        private readonly ContractRepository repository;
        private readonly string singleProfileName;


        // constructor
        private ContractUseCase(int profileId){
            repository = ContractRepository.OpenRepository(profileId);
            singleProfileName = profileId.Equals(5) ? "Productor" : "Transportista";
        }


        private ContractUseCase(int profileId, string singleProfileName){
            repository = ContractRepository.OpenRepository(profileId);
            this.singleProfileName = singleProfileName;
        }


        // Named constructors.
        public static ContractUseCase CreateUseCase(int profileId){
            return new ContractUseCase(profileId);
        }


        public static ContractUseCase CreateUseCase(int profileId, string singleProfileName){
            return new ContractUseCase(profileId, singleProfileName);
        }


        public DataTable FindAll(){
            repository.FindAll();
            return repository.DataSource;
        }


        public DataTable FindValidContract(){
            repository.FindValidContracts();
            return repository.DataSource;
        }


        public DataTable FindInvalidContracts(){
            repository.FindInvalidContracts();
            return repository.DataSource;
        }


        public DataTable FindContractById(string contractId){
            repository.FindById(contractId);
            return repository.DataSource;
        }


        public Contract FindOneContractByID(string contractId){
            return repository.FindOneContractById(contractId);
        }


        public void NewContract(Contract contract){
            IValidator validator = ContractValidator.CreateValidator(contract, false, singleProfileName);
            validator.Validate();
            repository.NewContract(contract);
        }


        public void EditContract(Contract contract){
            IValidator validator = ContractValidator.CreateValidator(contract, true, singleProfileName);
            validator.Validate();
            repository.EditContract(contract);
        }


        public void DeleteContract(string contractId){
            repository.DeleteContract(contractId);
        }


        public void AcceptContract(string contractId, string clientId, string observation){
            var contract = repository.FindOneContractAceptedById(contractId);
            foreach (var d in contract.Details) if (d.Customer.Id != clientId)
                    contract.RemoveDetail(d);
                else
                    d.ClientObservation = observation;
            //ContractGenerator generator = ContractGenerator.CreateContract(contract, singleProfileName, profileName);
            //generator.Generate();
            //string filePath = generator.PdfFilePath;
            //generator= null;
            repository.AcceptContract(contract);
        }


        public void ContractRefuse(string contractId, string clientId, string observation){
            repository.RefuseContract(contractId, clientId, observation);
        }


        public IList<ContractDto> GetContractByCustomerId(string customerId){
            return repository.FindContractByCustomerId(customerId);
        }

    }

}