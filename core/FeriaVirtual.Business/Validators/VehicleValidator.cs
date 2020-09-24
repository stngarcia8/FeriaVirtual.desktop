using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Validators {

    public class VehicleValidator:Validator {

        private Vehicle data;
        private readonly bool editMode;


        // Constructor
        private VehicleValidator(Vehicle data,bool editMode) : base() {
            this.data= data;
            this.editMode= editMode;
            processName= string.Format( "{0} vehiculo",(editMode ? "actualizar" : "registrar") );
        }


        // Named constructor
        public static VehicleValidator CreateValidator(Vehicle data,bool editMode) {
            return new VehicleValidator( data,editMode );
        }

        // Validate vehicle method.
        public void Validate() {
            ValidatingEmptyField( data.VehicleID,"id vehiculo" );
            ValidatingEmptyField( data.VehiclePatent,"patente del vehiculo" );
            ValidatingEmptyField( data.VehicleModel,"modelo del vehiculo" );
            ValidatingEmptyField( data.VehicleCapacity,"capacidad del behiculo" );
            ValidatingValueField( data.VehicleCapacity,"capacidad del vehiculo" );
            if(ErrorMessages.Count>0) {
                throw new InvalidVehicleException( GenerateErrorMessage() );
            }
        }


        private void ValidatingEmptyField(string value,string fieldName) {
            if(string.IsNullOrEmpty( value )) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede quedar vacío.",fieldName ) );
            }
        }

        private void ValidatingEmptyField(float value,string fieldName) {
            if(value.Equals( 0 )) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede tener un valor de cero.",fieldName ) );
            }
        }

        private void ValidatingValueField(float value,string fieldName) {
            if(value<0) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede tener un valor menor a cero.",fieldName ) );
            }
        }


    }

}
