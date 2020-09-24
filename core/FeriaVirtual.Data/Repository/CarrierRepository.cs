using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.DTO;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository {

    public class CarrierRepository:Repository {


        // Properties
        public Carrier Carrier => carrier;

        private Carrier carrier;

        // Constructor
        private CarrierRepository() : base() {
            carrier = Carrier.CreateCarrier();
        }

        // Named constructor.
        public static CarrierRepository OpenRepository() {
            return new CarrierRepository();
        }


        public new void FindById(string id) {
            FindCarrierUserData( id );
            GetCarrierUserData();
            if(carrier==null) {
                return;
            }
            FindCarrierComercialData( id );
            carrier.ComercialInfo= GetCarrierComercialData();
            carrier.VehicleList=FindAllVehicles( id);
        }


        private void FindCarrierUserData(string id) {
            sql.Append( "select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=6 " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            //connection.CloseConnection();
        }


        private void GetCarrierUserData() {
            if(dataTable.Rows.Count.Equals( 0 )) {
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


        private void FindCarrierComercialData(string id) {
            sql.Clear();
            sql.Append( "select * from vwObtenerDatosComerciales where id_cliente=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            // connection.CloseConnection();
        }


        private ComercialData GetCarrierComercialData() {
            ComercialData data = ComercialData.CreateComercialData();
            if(dataTable.Rows.Count.Equals( 0 )) {
                return null;
            }
            DataRow row = dataTable.Rows[0];
            data.ComercialID= row["id_comercial"].ToString();
            data.CompanyName= row["Razon social"].ToString();
            data.FantasyName=row["Nombre de fantasia"].ToString();
            data.ComercialBusiness= row["Giro comercial"].ToString();
            data.Email= row["Email"].ToString();
            data.ComercialDNI= row["DNI"].ToString();
            data.Address= row["Direccion"].ToString();
            data.City= row["Ciudad"].ToString();
            data.Country= row["Pais"].ToString();
            data.PhoneNumber= row["Telefono"].ToString();
            return data;
        }


        public void NewVehicle(Vehicle vehicle,string clientID) {
            IQueryAction query = DefineQueryAction( "spAgregarVehiculos " );
            query.AddParameter( "pIdVehiculo",vehicle.VehicleID,DbType.String );
            query.AddParameter( "pIdCliente",clientID,DbType.String );
            query.AddParameter( "pTipo",vehicle.VehicleType,DbType.String );
            query.AddParameter( "pPatente",vehicle.VehiclePatent,DbType.String );
            query.AddParameter( "pModelo",vehicle.VehicleModel,DbType.String );
            query.AddParameter( "pCapacidad",vehicle.VehicleCapacity,DbType.Decimal );
            query.ExecuteQuery();
        }


        public void EditVehicle(Vehicle vehicle) {
            IQueryAction query = DefineQueryAction( "spActualizarVehiculos " );
            query.AddParameter( "pIdVehiculo",vehicle.VehicleID,DbType.String );
            query.AddParameter( "pTipo",vehicle.VehicleType,DbType.String );
            query.AddParameter( "pPatente",vehicle.VehiclePatent,DbType.String );
            query.AddParameter( "pModelo",vehicle.VehicleModel,DbType.String );
            query.AddParameter( "pCapacidad",vehicle.VehicleCapacity,DbType.Decimal );
            query.ExecuteQuery();
        }


        public void DeleteVehicle(string vehicleID) {
            IQueryAction query = DefineQueryAction( "spEliminarVehiculos " );
            query.AddParameter( "pIdVehiculo",vehicleID,DbType.String );
            query.ExecuteQuery();
        }


        public Vehicle FindVehicleByID(string vehicleID) {
            sql.Clear();
            sql.Append( "select * from vwVehiculos where id_vehiculo=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",vehicleID,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            return GetVehicleData();
        }


        private Vehicle GetVehicleData() {
            DataRow row = dataTable.Rows[0];
            if(row==null) {
                return null;
            }
            Vehicle vehicle = Vehicle.CreateVehicle();
            vehicle.VehicleID=  row["id_vehiculo"].ToString() ;
            vehicle.ClientID= row["id_cliente"].ToString();
            vehicle.VehicleType= row["Tipo"].ToString();
            vehicle.VehiclePatent= row["patente_vehiculo"].ToString();
            vehicle.VehicleModel=   row["modelo_vehiculo"].ToString();
            vehicle.VehicleCapacity= float.Parse( row["capacidad_vehiculo"].ToString() );
            return vehicle;
        }


        public IList<Vehicle> FindAllVehicles(string clientID) {
            sql.Clear();
            sql.Append( "select * from fv_user.vwVehiculos where id_cliente=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",clientID,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            return GetVehiclesData();
        }


        private IList<Vehicle> GetVehiclesData() {
            IList<Vehicle> vehicleList = new List<Vehicle>();
            if(dataTable.Rows.Count.Equals( 0 )) {
                return vehicleList;
            }
            foreach(DataRow row in dataTable.Rows) {
                Vehicle vehicle = Vehicle.CreateVehicle();
                vehicle.VehicleID=  row["id_vehiculo"].ToString() ;
                vehicle.ClientID= row["id_cliente"].ToString();
                vehicle.VehicleType=  row["Tipo"].ToString();
                vehicle.VehiclePatent= row["patente_vehiculo"].ToString();
                vehicle.VehicleModel=   row["modelo_vehiculo"].ToString();
                vehicle.VehicleCapacity= float.Parse( row["capacidad_vehiculo"].ToString() );
                vehicleList.Add( vehicle );
            }
            return vehicleList;
        }



    }
}
