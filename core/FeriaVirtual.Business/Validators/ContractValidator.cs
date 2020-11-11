using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Contracts;


namespace FeriaVirtual.Business.Validators{

    public class ContractValidator : Validator, IValidator{

        private readonly Contract contract;
        private readonly string singleProfileName;


        // Constructor.
        private ContractValidator(Contract contract, bool editMode, string singleProfileName){
            this.contract = contract;
            EditMode = editMode;
            this.singleProfileName = singleProfileName;
            ProcessName = !editMode
                ? $"registrar contrato de {singleProfileName}"
                : $"editar contrato de {singleProfileName}";
        }


        // Validate contract method.
        public void Validate(){
            ValidatingEmptyField(contract.ContractId,
                $"El identificador del contrado de {singleProfileName} no puede quedar vacío.");
            ValidatingValueField(contract.ContractCommission,
                $"El valor de la comisiónidentificador del contrato de {singleProfileName} no puede ser menor a cero.");
            if (ErrorMessages.Count > 0) throw new InvalidContractException(GenerateErrorMessage());
        }


        // Named constructor.
        public static ContractValidator CreateValidator(Contract contract, bool editMode, string singleProfileName){
            return new ContractValidator(contract, editMode, singleProfileName);
        }

    }

}