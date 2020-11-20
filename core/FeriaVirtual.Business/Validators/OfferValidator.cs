using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Offers;


namespace FeriaVirtual.Business.Validators {

    public class OfferValidator:Validator, IValidator {

        private readonly Offer offer;


        private OfferValidator(Offer offer,bool editMode) {
            this.offer= offer;
            EditMode = editMode;
            ProcessName = !editMode ? "registrar oferta" : "editar oferta";
        }


        public void Validate(){
            ValidatingEmptyField(offer.Description, "descripción de oferta");
            ValidatingValueField(offer.Discount,"descuento aplicado");
            if(ErrorMessages.Count > 0) {
                throw new InvalidOfferException(GenerateErrorMessage());
            }
        }


        public static OfferValidator CreateValidator(Offer offer,bool editMode){
            return new OfferValidator(offer, editMode);
        }

    }

}