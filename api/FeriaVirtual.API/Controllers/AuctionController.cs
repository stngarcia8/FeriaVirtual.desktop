using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.API.Models;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;


namespace FeriaVirtual.API.Controllers{

    /// <summary>
    ///     Controlador para las subastas de productos a transportar en maipo grande.
    /// </summary>
    public class AuctionController : ApiController{

        private readonly AuctionUseCase usecase = AuctionUseCase.CreateUseCase();


        /// <summary>
        ///     Obtiene la lista de subastas disponibles
        /// </summary>
        /// <returns>
        ///     Ok, con la lista de subastas disponibles,
        ///     Badrequest en caso de error de conectividad.
        /// </returns>
        [Route("api/v1/auctions/available")]
        [HttpGet]
        public IHttpActionResult GetAllAuction(){
            try{
                IList<Auction> auctionsList = new List<Auction>();
                IList<AuctionModel> auctions = new List<AuctionModel>();
                auctionsList = usecase.GetAllAvailableAuction();
                foreach (var a in auctionsList) auctions.Add(TransformAuctionToAuctionModel(a));
                return Ok(auctions);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Almacena la puja realizada por un transportista.
        /// </summary>
        /// <param name="bidValueModel">
        ///     Objeto qu e contiene los elementos para almacenar el valor de la puja en la base de datos.
        /// </param>
        /// <returns>
        ///     Ok si el valor pujado fue almacenado correctamente,
        ///     Bad request si ocurrio algún problema.
        /// </returns>
        [Route("api/v1/auctions/bidvalue")]
        [HttpPost]
        public IHttpActionResult PostBidValue(AuctionBidValue bidValueModel){
            if (bidValueModel == null) return BadRequest("Parámetro inválido, los datos de propuesta es incorrecto.");
            try{
                usecase.RegisterBidValue(bidValueModel);
                return Ok("Valor aceptado.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        private AuctionModel TransformAuctionToAuctionModel(Auction a){
            var am = new AuctionModel{
                AuctionId = a.AuctionId,
                AuctionDate = a.AuctionDate.ToString("yyyy-MM-dd"),
                Percent = a.Percent,
                Value = a.Value,
                Weight = a.Weight,
                LimitDate = a.LimitDate.ToString("yyyy-MM-dd"),
                Observation = a.Observation,
                CompanyName = a.CompanyName,
                Destination = a.Destination,
                PhoneNumber = a.PhoneNumber,
                Status = a.Status,
                Products = a.Products
            };
            return am;
        }

    }

}