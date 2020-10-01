using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Contracts;
using FeriaVirtual.Domain.Contracts;

namespace FeriaVirtual.Business.Validators {

    public class ContractValidator: Validator, IValidator {

        private Contract contract;
        private readonly int profileID;
        private readonly string singleProfileName;

        // Constructor.
        private ContractValidator(Contract contract,bool editMode,int profileID,string singleProfileName) : base() {
            this.contract= contract;
            this.editMode= editMode;
            this.profileID= profileID;
            this.singleProfileName= singleProfileName;
            processName= !editMode ? string.Format("registrar contrato de {0}",singleProfileName) : string.Format("editar contrato de {0}",singleProfileName);
        }


        // Named constructor.
        public static ContractValidator CreateValidator(Contract contract,bool editMode,int profileID,string singleProfileName) {
            return new ContractValidator(contract,editMode,profileID,singleProfileName);
        }


        // Validate contract method.
        public void Validate() {
            ValidatingEmptyField(contract.ContractID, string.Format("El identificador del contrado de {0} no puede quedar vacío.", this.singleProfileName));
            ValidatingValueField(contract.ContractCommission,string.Format("El valor de la comisiónidentificador del contrato de {0} no puede ser menor a cero.",this.singleProfileName));
            if(ErrorMessages.Count>0) {
                throw new InvalidContractException(GenerateErrorMessage());
            }
        }



        }
}
