using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Contracts;

namespace FeriaVirtual.Business.Validators {

    public class ContractValidator:Validator, IValidator {
        private readonly Contract contract;
        private readonly string singleProfileName;

        // Constructor.
        private ContractValidator(Contract contract,bool editMode,string singleProfileName) : base() {
            this.contract= contract;
            this.editMode= editMode;
            this.singleProfileName= singleProfileName;
            processName= !editMode ? string.Format("registrar contrato de {0}",singleProfileName) : string.Format("editar contrato de {0}",singleProfileName);
        }

        // Named constructor.
        public static ContractValidator CreateValidator(Contract contract,bool editMode,string singleProfileName) {
            return new ContractValidator(contract,editMode,singleProfileName);
        }

        // Validate contract method.
        public void Validate() {
            ValidatingEmptyField(contract.ContractID,string.Format("El identificador del contrado de {0} no puede quedar vacío.",singleProfileName));
            ValidatingValueField(contract.ContractCommission,string.Format("El valor de la comisiónidentificador del contrato de {0} no puede ser menor a cero.",singleProfileName));
            if(ErrorMessages.Count>0) {
                throw new InvalidContractException(GenerateErrorMessage());
            }
        }
    }
}