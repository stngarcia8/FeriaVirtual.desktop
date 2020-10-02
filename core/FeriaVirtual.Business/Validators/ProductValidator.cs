using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Validators {

    public class ProductValidator:Validator, IValidator {

        private Product data;


        // Constructor
        private ProductValidator(Product data,bool editMode) : base() {
            this.data= data;
            this.editMode= editMode;
            processName= string.Format( "{0} producto",editMode ? "actualizar" : "registrar" );
        }


        // Named constructor
        public static ProductValidator CreateValidator(Product data,bool editMode) {
            return new ProductValidator( data,editMode );
        }


        // Validate product method.
        public void Validate() {
            ValidatingEmptyField( data.ProductID,"id producto" );
            ValidatingEmptyField( data.ProductName,"nombre producto" );
            ValidatingEmptyField( data.ProductValue,"valor producto" );
            ValidatingValueField( data.ProductValue,"valor producto" );
            ValidatingEmptyField( data.ProductQuantity,"cantidad producto" );
            ValidatingValueField( data.ProductQuantity,"cantidad producto" );
            if(ErrorMessages.Count>0) {
                throw new InvalidProductException( GenerateErrorMessage() );
            }
        }


    }

}
