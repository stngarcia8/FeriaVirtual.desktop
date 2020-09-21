using System;
using FeriaVirtual.Domain.DTO;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Business.Elements;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeriaVirtual.API.Controllers
{

    public class ComercialDataController : ApiController
    {

        public IHttpActionResult Get(string ComercialID) {
            try {
                ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();
                return Ok( usecase.FindComercialDataByID( ComercialID ) );
            } catch (Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }


        [HttpPost]
        public IHttpActionResult Post(ComercialDataDTO data) {
            try {
                ComercialData infoData = ComercialData.CreateComercialData();
                infoData.CityID= data.CityID;
                infoData.CompanyName= data.CompanyName;
                infoData.FantasyName= data.FantasyName;
                infoData.ComercialBusiness= data.ComercialBusiness;
                infoData.Email= data.Email;
                infoData.ComercialDNI= data.ComercialDNI;
                infoData.Address= data.Address;
                ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();
                usecase.NewCommercialData( infoData,data.ClientID );
                return Ok();
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }

        [HttpPut]
        public IHttpActionResult Put(ComercialDataDTO data) {
            try {
                ComercialData infoData = ComercialData.CreateComercialData();
                infoData.ComercialID= data.ComercialID;
                infoData.CityID= data.CityID;
                infoData.CompanyName= data.CompanyName;
                infoData.FantasyName= data.FantasyName;
                infoData.ComercialBusiness= data.ComercialBusiness;
                infoData.Email= data.Email;
                infoData.ComercialDNI= data.ComercialDNI;
                infoData.Address= data.Address;
                ComercialDataUseCase usecase = ComercialDataUseCase.CreateUseCase();
                usecase.EditCommercialData( infoData,data.ClientID );
                return Ok();
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }






    }


}
