using System;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Elements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Business.Validators{

    public class ProductValidator:Validator {

        private Product data;
        private readonly bool editMode;


        // Constructor
        private ProductValidator(Product data,bool editMode) : base() {
            this.data= data;
            this.editMode= editMode;
            processName= string.Format( "{0} producto",(editMode ? "actualizar" : "registrar") );
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

        private void ValidatingValueField(float  value,string fieldName) {
            if(value<0) {
                ErrorMessages.Add( string.Format( "El campo {0} no puede tener un valor menor a cero.",fieldName ) );
            }
        }


    }

}
