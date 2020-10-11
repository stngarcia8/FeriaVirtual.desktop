using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Validators {

    public class VehicleValidator:Validator, IValidator {
        private readonly Vehicle data;

        // Constructor
        private VehicleValidator(Vehicle data,bool editMode) : base() {
            this.data= data;
            this.editMode= editMode;
            processName= string.Format("{0} vehiculo",editMode ? "actualizar" : "registrar");
        }

        // Named constructor
        public static VehicleValidator CreateValidator(Vehicle data,bool editMode) {
            return new VehicleValidator(data,editMode);
        }

        // Validate vehicle method.
        public void Validate() {
            ValidatingEmptyField(data.VehicleID,"id vehiculo");
            ValidatingEmptyField(data.VehiclePatent,"patente del vehiculo");
            ValidatingEmptyField(data.VehicleModel,"modelo del vehiculo");
            ValidatingEmptyField(data.VehicleCapacity,"capacidad del behiculo");
            ValidatingValueField(data.VehicleCapacity,"capacidad del vehiculo");
            if(ErrorMessages.Count>0) {
                throw new InvalidVehicleException(GenerateErrorMessage());
            }
        }
    }
}