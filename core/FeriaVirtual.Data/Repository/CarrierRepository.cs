using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class CarrierRepository:Repository {
        private Carrier carrier;

        // Properties
        public Carrier Carrier => carrier;

        // Constructor
        private CarrierRepository() : base() {
            carrier = Carrier.CreateCarrier();
        }

        // Named constructor.
        public static CarrierRepository OpenRepository() {
            return new CarrierRepository();
        }

        public new void FindById(string id) {
            FindCarrierUserData(id);
            GetCarrierUserData();
            if(carrier==null) {
                return;
            }
            ComercialDataRepository dataRepository = ComercialDataRepository.OpenRepository();
            carrier.ComercialInfo= dataRepository.FindById(id);
            carrier.VehicleList=FindAllVehicles(id);
        }

        private void FindCarrierUserData(string id) {
            sql.Append("select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=6 ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            dataTable = querySelect.ExecuteQuery();
        }

        private void GetCarrierUserData() {
            if(dataTable.Rows.Count.Equals(0)) {
                carrier= null;
                return;
            }
            DataRow row = dataTable.Rows[0];
            carrier.ID = row["id_cliente"].ToString();
            carrier.FirstName= row["nombre_cliente"].ToString();
            carrier.LastName= row["apellido_cliente"].ToString();
            carrier.DNI= row["DNI"].ToString();
            carrier.Profile.ProfileID=6;
            carrier.Profile.ProfileName= row["Rol"].ToString();
        }

        public void NewVehicle(Vehicle vehicle,string clientID) {
            IQueryAction query = DefineQueryAction("spAgregarVehiculos ");
            query.AddParameter("pIdVehiculo",vehicle.VehicleID,DbType.String);
            query.AddParameter("pIdCliente",clientID,DbType.String);
            query = DefineParameters(vehicle,query);
            query.ExecuteQuery();
        }

        public void EditVehicle(Vehicle vehicle) {
            IQueryAction query = DefineQueryAction("spActualizarVehiculos ");
            query.AddParameter("pIdVehiculo",vehicle.VehicleID,DbType.String);
            query = DefineParameters(vehicle,query);
            query.AddParameter("pDisponibilidad",vehicle.VehicleAvailable,DbType.Int32);
            query.ExecuteQuery();
        }

        private IQueryAction DefineParameters(Vehicle vehicle,IQueryAction query) {
            query.AddParameter("pIdTipo",vehicle.VehicleType.VehicleTypeID,DbType.Int32);
            query.AddParameter("pPatente",vehicle.VehiclePatent,DbType.String);
            query.AddParameter("pModelo",vehicle.VehicleModel,DbType.String);
            query.AddParameter("pCapacidad",vehicle.VehicleCapacity,DbType.Decimal);
            return query;
        }

        public void DeleteVehicle(string vehicleID) {
            IQueryAction query = DefineQueryAction("spEliminarVehiculos ");
            query.AddParameter("pIdVehiculo",vehicleID,DbType.String);
            query.ExecuteQuery();
        }

        public Vehicle FindVehicleByID(string vehicleID) {
            sql.Clear();
            sql.Append("select * from vwVehiculos where id_vehiculo=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",vehicleID,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            return GetVehicleData();
        }

        private Vehicle GetVehicleData() {
            DataRow row = dataTable.Rows[0];
            if(row==null) {
                return null;
            }
            return ExtractVehicleInfoToDataRow(row);
        }

        private Vehicle ExtractVehicleInfoToDataRow(DataRow row) {
            Vehicle vehicle = Vehicle.CreateVehicle();
            vehicle.VehicleID=  row["id_vehiculo"].ToString();
            vehicle.ClientID= row["id_cliente"].ToString();
            vehicle.VehicleType.VehicleTypeID = int.Parse(row["id_tipo_transporte"].ToString());
            vehicle.VehicleType.VehicleTypeDescription = row["Tipo"].ToString();
            vehicle.VehiclePatent= row["Patente"].ToString();
            vehicle.VehicleModel=   row["Modelo"].ToString();
            vehicle.VehicleCapacity= float.Parse(row["Capacidad"].ToString());
            vehicle.VehicleAvailable = int.Parse(row["Disponible"].ToString());
            return vehicle;
        }

        public IList<Vehicle> FindAllVehicles(string clientID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwVehiculos where id_cliente=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",clientID,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            return GetVehiclesData();
        }

        private IList<Vehicle> GetVehiclesData() {
            IList<Vehicle> vehicleList = new List<Vehicle>();
            if(dataTable.Rows.Count.Equals(0)) {
                return vehicleList;
            }
            foreach(DataRow row in dataTable.Rows) {
                vehicleList.Add(ExtractVehicleInfoToDataRow(row));
            }
            return vehicleList;
        }
    }
}