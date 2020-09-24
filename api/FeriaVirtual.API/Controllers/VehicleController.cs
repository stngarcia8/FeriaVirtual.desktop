using System;
using System.Collections.Generic;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.API.Controllers {

    public class VehicleController:ApiController {

        [HttpGet]
        public IHttpActionResult Get(string vehicleID) {
            if(string.IsNullOrEmpty( vehicleID )) {
                return BadRequest( "Parámetro inválido, el id del vehiculo es incorrecto" );
            }
            try {
                CarrierUseCase usecase = CarrierUseCase.CreateUseCase();
                Vehicle vehicle = usecase.FindVehicleByID( vehicleID );
                return Ok( vehicle );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }


        [HttpGet]
        public IHttpActionResult GetAll(string clientID) {
            if(string.IsNullOrEmpty( clientID )) {
                return BadRequest( "Parámetro inválido, el id del cliente es incorrecto" );
            }
            try {
                CarrierUseCase usecase = CarrierUseCase.CreateUseCase();
                IList<Vehicle> vehicleList = usecase.FindAllVehicles( clientID );
                return Ok( vehicleList );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }




        [HttpPost]
        public IHttpActionResult Post(string clientID,Vehicle vehicle) {
            if(string.IsNullOrEmpty( clientID )) {
                return BadRequest( "Parámetros inválidos, el id de cliente o los datos del vehiculo son incorrectos" );
            }
            try {
                string newID = Guid.NewGuid().ToString();
                vehicle.VehicleID= newID;
                CarrierUseCase usecase = CarrierUseCase.CreateUseCase();
                usecase.NewVehicle( vehicle,clientID );
                return Ok( "Vehiculoalmacenado correctamente." );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }


        [HttpPut]
        public IHttpActionResult Put(Vehicle vehicle) {
            if(vehicle==null) {
                return BadRequest( "Parámetro inválido, los datos del vehiculo son  incorrectos" );
            }
            try {
                CarrierUseCase usecase = CarrierUseCase.CreateUseCase();
                usecase.EditVehicle( vehicle );
                return Ok( "Vehiculo actualizado correctamente." );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }


        [HttpDelete]
        public IHttpActionResult Delete(string vehicleID) {
            if(string.IsNullOrEmpty( vehicleID )) {
                return BadRequest( "Parámetro inválido, el id de vehiculo es incorrecto" );
            }
            try {
                CarrierUseCase usecase = CarrierUseCase.CreateUseCase();
                usecase.DeleteVehicle( vehicleID );
                return Ok( "Vehiculo eliminado correctamente." );
            } catch(Exception ex) {
                return BadRequest( ex.Message.ToString() );
            }
        }



    }

}
