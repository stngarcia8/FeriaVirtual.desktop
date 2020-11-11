using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.Business.Orders {

    public class AuctionUseCase{

        private readonly AuctionRepository repository;


        // Constructor
        private AuctionUseCase(){
            repository = AuctionRepository.OpenRepository();
        }


        public static AuctionUseCase CreateUseCase(){
            return new AuctionUseCase();
        }


        public void NewAuction(Auction auction, string orderId){
            repository.NewAuction(auction, orderId);
        }


        public void EditAuction(Auction auction, string orderId){
            repository.EditAuction(auction, orderId);
        }


        public void DeleteAuction(string orderId){
            repository.DeleteAuction(orderId);
        }


        public void CloseAuction(string orderId, string auctionId){
            repository.CloseAuction(orderId, auctionId);
        }


        public void RemoveBidValue(string auctionId, string orderId){
            repository.RemoveAuctionBidValue(auctionId, orderId);
        }


        public Auction GetAuctionById(string orderId){
            return repository.GetAuctionById(orderId);
        }


        public void ChangeAuctionStatus(string auctionId, int status){
            repository.ChangeAuctionStatus(auctionId, status);
        }


        public IList<Auction> GetAllAvailableAuction(){
            return repository.FinAllAuction();
        }


        public void RegisterBidValue(AuctionBidValue bidValue){
            var validator = BidValueValidator.CreateValidator(bidValue);
            validator.Validate();
            repository.SaveAuctionBidValue(bidValue);
        }


        public DataTable GetAuctionBidValue(string auctionId){
            repository.GetBidValueByAuctionId(auctionId);
            return repository.DataSource;
        }

    }

}