using System;
using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.Orders;

namespace FeriaVirtual.Business.Orders {

    public class OrderUseCase {
        private readonly OrderRepository repository;

        // Constructor
        private OrderUseCase() {
            repository=OrderRepository.OpenRepository();
        }

        // Named constructor
        public static OrderUseCase CreateUseCase() {
            return new OrderUseCase();
        }

        public DataTable GetOrderByStatus(int statusID, int rolID) {
            try {
                repository.GetOrderByStatus(statusID, rolID);
                return repository.DataSource;
            } catch(Exception ex) {
                throw ex;
            }
        }

        public DataTable GetOrderDetailByID(string orderID) {
            try {
                repository.GetOrderDetailById(orderID);
                return repository.DataSource;
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void NewOrder(Order order,string clientID) {
            try {
                IValidator validator = OrderValidator.CreateValidator(order,false);
                validator.Validate();
                repository.NewOrder(order,clientID);
            } catch(Exception) {
                throw;
            }
        }

        public void EditOrder(Order order,string clientID) {
            try {
                IValidator validator = OrderValidator.CreateValidator(order,true);
                validator.Validate();
                repository.EditOrder(order,clientID);
            } catch(Exception) {
                throw;
            }
        }

        public void DeleteOrder(string orderID) {
            try {
                repository.DeleteOrder(orderID);
            } catch(Exception) {
                throw;
            }
        }

        public IList<OrderDto> GetOrderToPublish(int statusID,string customerID) {
            try {
                return repository.PublishOrdersToApi(statusID,customerID);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public DataTable GetGenerateProposeProduct(string orderID) {
            try {
                repository.GenerateProposeProduct(orderID);
                repository.GetProposeProduct(orderID);
                return repository.DataSource;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void AceptProposeProducts(string orderID) {
            try {
                repository.AceptProposeProducts(orderID);
            }catch (Exception ex) {
                throw ex;
            }
        }

        public void NewAuction(Auction auction, string orderID) {
            try {
                repository.NewAuction(auction,orderID);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void EditAuction(Auction auction,string orderID) {
            try {
                repository.EditAuction(auction,orderID);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public void DeleteAuction(string orderID) {
            try {
                repository.DeleteAuction(orderID);
            } catch (Exception ex) {
                throw ex;
            }
        }


        public void CloseAuction(string orderID, string auctionID) {
            try {
                repository.CloseAuction(orderID, auctionID);
            } catch(Exception ex) {
                throw ex;
            }
        }



        public Auction GetAuctionById(string orderID) {
            try {
                return repository.GetAuctionById(orderID);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void ChangeAuctionStatus(string auctionID, int status) {
            try {
                repository.ChangeAuctionStatus(auctionID,status);
            } catch (Exception ex) {
                throw ex;
            }
        }

public IList<Auction> GetAllAvailableAuction() {
            try {
                return repository.FinAllAuction();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void RegisterBidValue(AuctionBidValue bidValue) {
            try {
                BidValueValidator validator = BidValueValidator.CreateValidator(bidValue);
                validator.Validate();
                repository.SaveAuctionBidValue(bidValue);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable GetAuctionBidValue(string auctionID) {
            try {
                repository.GetBidValueByAuctionID(auctionID);
                return repository.DataSource;
            } catch (Exception ex) {
                throw ex;
            }
        } 

        public void CreateOrderDispatch(Auction auction,string orderID,string clientID,int safeID) {
            try {
                repository.NewOrderDispatch(auction,orderID,clientID,safeID);
            } catch (Exception ex) {
                throw ex;
            }
        }





    }
}
