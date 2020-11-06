using System;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{

    public class AuctionController : ApiController
    {

        OrderUseCase usecase = OrderUseCase.CreateUseCase();

        /// <summary>
        /// Obtiene la lista de subastas disponibles
        /// </summary>
        /// <returns>
        /// Ok, con la lista de subastas disponibles, 
        /// Badrequest en caso de error de conectividad.
        /// </returns>
        [Route("api/v1/auctions/available")]
        [HttpGet]
        public IHttpActionResult GetAllAuction() {
            try {
                IList<Auction> auctionsList = new List<Auction>();
                IList<AuctionModel> auctions = new List<AuctionModel>();
                auctionsList= usecase.GetAllAvailableAuction();
                foreach(Auction a in auctionsList) {
                    auctions.Add(TransformAuctionToAuctionModel(a));
                }
                return Ok(auctions);
            } catch (Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }

        [Route("api/v1/auctions/bidvalue")]
        [HttpPost]
        public IHttpActionResult PostBidValue(AuctionBidValue bidValueModel) {
            if(bidValueModel==null) {
                return BadRequest("Parámetro inválido, los datos de propuesta es incorrecto.");
            }
            try {
                usecase.RegisterBidValue(bidValueModel);
                return Ok("Valor aceptado.");
            } catch (Exception ex) {
                return BadRequest(ex.Message.ToString());
            }
        }





        private AuctionModel TransformAuctionToAuctionModel(Auction a) {
            AuctionModel am = new AuctionModel();
            am.AuctionID = a.AuctionID;
            am.AuctionDate = a.AuctionDate.ToString("yyyy-MM-dd");
            am.Percent = a.Percent;
            am.Value= a.Value;
            am.Weight= a.Weight;
            am.LimitDate= a.LimitDate.ToString("yyyy-MM-dd");
            am.Observation = a.Observation;
            am.CompanyName = a.CompanyName;
            am.Destination = a.Destination;
            am.PhoneNumber = a.PhoneNumber;
            am.Status= a.Status;
            am.Products= a.Products;
           return am;
        }


        




    }
}
