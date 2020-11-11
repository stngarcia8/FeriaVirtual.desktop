using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Products;


namespace FeriaVirtual.Business.Validators{

    public class ProductValidator : Validator, IValidator{

        private readonly Product data;


        // Constructor
        private ProductValidator(Product data, bool editMode){
            this.data = data;
            EditMode = editMode;
            ProcessName = $"{(editMode ? "actualizar" : "registrar")} producto";
        }


        // Validate product method.
        public void Validate(){
            ValidatingEmptyField(data.ProductId, "id producto");
            ValidatingEmptyField(data.ProductName, "nombre producto");
            ValidatingEmptyField(data.ProductValue, "valor producto");
            ValidatingValueField(data.ProductValue, "valor producto");
            ValidatingEmptyField(data.ProductQuantity, "cantidad producto");
            ValidatingValueField(data.ProductQuantity, "cantidad producto");
            if (ErrorMessages.Count > 0) throw new InvalidProductException(GenerateErrorMessage());
        }


        // Named constructor
        public static ProductValidator CreateValidator(Product data, bool editMode){
            return new ProductValidator(data, editMode);
        }

    }

}