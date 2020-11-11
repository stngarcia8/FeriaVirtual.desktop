using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Domain.Vehicles;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository{

    public class CarrierRepository : Repository{

        // Properties
        public Carrier Carrier{ get; private set; }


        // Constructor
        private CarrierRepository(){
            Carrier = Carrier.CreateCarrier();
        }


        // Named constructor.
        public static CarrierRepository OpenRepository(){
            return new CarrierRepository();
        }


        public new void FindById(string id){
            FindCarrierUserData(id);
            GetCarrierUserData();
            if (Carrier == null) return;
            var dataRepository = ComercialDataRepository.OpenRepository();
            Carrier.ComercialInfo = dataRepository.FindById(id);
            Carrier.VehicleList = FindAllVehicles(id);
        }


        private void FindCarrierUserData(string id){
            Sql.Append("select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=6 ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", id, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }


        private void GetCarrierUserData(){
            if (DataTable.Rows.Count.Equals(0)){
                Carrier = null;
                return;
            }

            var row = DataTable.Rows[0];
            Carrier.Id = row["id_cliente"].ToString();
            Carrier.FirstName = row["nombre_cliente"].ToString();
            Carrier.LastName = row["apellido_cliente"].ToString();
            Carrier.Dni = row["DNI"].ToString();
            Carrier.Profile.ProfileId = 6;
            Carrier.Profile.ProfileName = row["Rol"].ToString();
        }


        public void NewVehicle(Vehicle vehicle, string clientId){
            var query = DefineQueryAction("spAgregarVehiculos ");
            query.AddParameter("pIdCliente", clientId, DbType.String);
            query = DefineParameters(vehicle, query);
            query.ExecuteQuery();
        }


        public void EditVehicle(Vehicle vehicle){
            var query = DefineQueryAction("spActualizarVehiculos ");
            query = DefineParameters(vehicle, query);
            query.AddParameter("pDisponibilidad", vehicle.VehicleAvailable, DbType.Int32);
            query.ExecuteQuery();
        }


        private IQueryAction DefineParameters(Vehicle vehicle, IQueryAction query){
            query.AddParameter("pIdVehiculo", vehicle.VehicleId, DbType.String);
            query.AddParameter("pIdTipo", vehicle.VehicleType.VehicleTypeId, DbType.Int32);
            query.AddParameter("pPatente", vehicle.VehiclePatent, DbType.String);
            query.AddParameter("pModelo", vehicle.VehicleModel, DbType.String);
            query.AddParameter("pCapacidad", vehicle.VehicleCapacity, DbType.Decimal);
            query.AddParameter("pObservacion", vehicle.Observation, DbType.String);
            return query;
        }


        public void DeleteVehicle(string vehicleId){
            var query = DefineQueryAction("spEliminarVehiculos ");
            query.AddParameter("pIdVehiculo", vehicleId, DbType.String);
            query.ExecuteQuery();
        }


        public Vehicle FindVehicleById(string vehicleId){
            Sql.Clear();
            Sql.Append("select * from vwVehiculos where id_vehiculo=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", vehicleId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            return GetVehicleData();
        }


        private Vehicle GetVehicleData(){
            var row = DataTable.Rows[0];
            return row == null ? null : ExtractVehicleInfoToDataRow(row);
        }


        private Vehicle ExtractVehicleInfoToDataRow(DataRow row){
            var vehicle = Vehicle.CreateVehicle();
            vehicle.VehicleId = row["id_vehiculo"].ToString();
            vehicle.ClientId = row["id_cliente"].ToString();
            vehicle.VehicleType.VehicleTypeId = int.Parse(row["id_tipo_transporte"].ToString());
            vehicle.VehicleType.VehicleTypeDescription = row["Tipo"].ToString();
            vehicle.VehiclePatent = row["Patente"].ToString();
            vehicle.VehicleModel = row["Modelo"].ToString();
            vehicle.VehicleCapacity = float.Parse(row["Capacidad"].ToString());
            vehicle.VehicleAvailable = int.Parse(row["Disponible"].ToString());
            vehicle.Observation = row["Observacion"].ToString();
            return vehicle;
        }


        public IList<Vehicle> FindAllVehicles(string clientId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerVehiculos where id_cliente=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", clientId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            return GetVehiclesData();
        }


        private IList<Vehicle> GetVehiclesData(){
            IList<Vehicle> vehicleList = new List<Vehicle>();
            if (DataTable.Rows.Count.Equals(0)) return vehicleList;
            foreach (DataRow row in DataTable.Rows) vehicleList.Add(ExtractVehicleInfoToDataRow(row));
            return vehicleList;
        }

    }

}