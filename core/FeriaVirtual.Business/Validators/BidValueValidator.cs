using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Business.Validators{

    public class BidValueValidator : Validator, IValidator{

        private readonly AuctionBidValue bidValue;


        // Constructor
        private BidValueValidator(AuctionBidValue bidValue){
            this.bidValue = bidValue;
            ProcessName = "ingresando puja de transporte.";
        }


        // Validate bid value method.
        public void Validate(){
            ValidatingEmptyField(bidValue.AuctionId, "identificador de subasta");
            ValidatingEmptyField(bidValue.ClientId, "identificador del transportista");
            ValidatingEmptyField(bidValue.Value, "valor propuesto");
            ValidatingValueField(bidValue.Value, "valor propuesto");
            if (ErrorMessages.Count > 0) throw new InvalidBidValueException(GenerateErrorMessage());
        }


        // Named constructor
        public static BidValueValidator CreateValidator(AuctionBidValue bidValue){
            return new BidValueValidator(bidValue);
        }

    }

}