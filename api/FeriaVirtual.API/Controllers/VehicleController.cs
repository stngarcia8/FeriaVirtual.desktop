using System;
using System.Web.Http;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Vehicles;


namespace FeriaVirtual.API.Controllers{

    /// <summary>
    ///     Controlador para el tratamiento de los vehículos de un transportista.
    /// </summary>
    public class VehicleController : ApiController{

        private readonly CarrierUseCase usecase = CarrierUseCase.CreateUseCase();


        /// <summary>
        ///     Devuelve un vehiculo asociado a un transportista.
        /// </summary>
        /// <param name="vehicleId">
        ///     Corresponde al identificador del vehiculo a consultar.
        /// </param>
        /// <returns>
        ///     Vehicle - objeto que contiene la información del vehiculo.
        ///     Badreuqest - en caso de parámetros inválidos.
        /// </returns>
        [Route("api/v1/vehicles/{vehicleId}")]
        [HttpGet]
        public IHttpActionResult Get(string vehicleId){
            if (string.IsNullOrEmpty(vehicleId))
                return BadRequest("Parámetro inválido, el id del vehiculo es incorrecto");
            try{
                var vehicle = usecase.FindVehicleById(vehicleId);
                return Ok(vehicle);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Devuelve los vehiculos asociados a un transportista.
        /// </summary>
        /// <param name="clientId">
        ///     Corresponde al identificador del transportista.
        /// </param>
        /// <returns>
        ///     Retorna la lista de vehiculos, badrequest en caso de parámetros inválidos.
        /// </returns>
        [Route("api/v1/vehicles/all/{clientId}")]
        [HttpGet]
        public IHttpActionResult GetAll(string clientId){
            if (string.IsNullOrEmpty(clientId))
                return BadRequest("Parámetro inválido, el id del cliente es incorrecto");
            try{
                var vehicleList = usecase.FindAllVehicles(clientId);
                return Ok(vehicleList);
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Almacena un vehiculo en la base de datos.
        /// </summary>
        /// <param name="vehicle">
        ///     Objeto que contiene la información del vehiculo a grabar.
        /// </param>
        /// <returns>
        ///     Ok - si el vehiculo fue almacenado correctamente.
        ///     Badrequest, si los parámetros son inválidos.
        /// </returns>
        [Route("api/v1/vehicles/")]
        [HttpPost]
        public IHttpActionResult Post(Vehicle vehicle){
            if (vehicle == null) return BadRequest("Parámetros inválidos, los datos del vehiculo son incorrectos");
            try{
                usecase.NewVehicle(vehicle, vehicle.ClientId);
                return Ok("Vehiculoalmacenado correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Actualiza la información de un vehiculo.
        /// </summary>
        /// <param name="vehicle">
        ///     Objeto que contiene la información del vehiculo
        /// </param>
        /// <returns>
        ///     Ok, si el vehiculo fue actualizado correctamente.
        ///     Badrequest, si los parámetros son inválidos.
        /// </returns>
        [Route("api/v1/vehicles/")]
        [HttpPut]
        public IHttpActionResult Put(Vehicle vehicle){
            if (vehicle == null) return BadRequest("Parámetro inválido, los datos del vehiculo son  incorrectos");
            try{
                usecase.EditVehicle(vehicle);
                return Ok("Vehiculo actualizado correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        ///     Elimina un vehiculo de untransportista en la base de datos.
        /// </summary>
        /// <param name="vehicleId">
        ///     Corresponde al identificador del vehiculo que se desea eliminar.
        /// </param>
        /// <returns>
        ///     Ok, si el vehiculo fue eliminado correctamente.
        ///     Badrequest, si los parámetros enviados son inválidos.
        /// </returns>
        [Route("api/v1/vehicles/{vehicleId}")]
        [HttpDelete]
        public IHttpActionResult Delete(string vehicleId){
            if (string.IsNullOrEmpty(vehicleId))
                return BadRequest("Parámetro inválido, el id de vehiculo es incorrecto");
            try{
                usecase.DeleteVehicle(vehicleId);
                return Ok("Vehiculo eliminado correctamente.");
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }

}