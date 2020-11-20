using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Business.Validators{

    public class AuctionValidator : Validator, IValidator{

        private readonly Auction auction;


        private AuctionValidator(Auction auction, bool editMode){
            this.auction= auction;
            ProcessName = (editMode ? "ingresando subasta" : "editando subasta");
        }


        public void Validate(){
            ValidatingEmptyField(auction.Observation, "observación de subasta");
            if (ErrorMessages.Count > 0) throw new InvalidBidValueException(GenerateErrorMessage());
        }


        public static AuctionValidator CreateValidator(Auction auction, bool editMode){
            return new AuctionValidator(auction, editMode);
        }

    }

}