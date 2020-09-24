using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Elements;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class ProducerRepository:Repository {

        // Properties
        public Producer Producer => producer;

        private Producer producer;

        // Constructor
        private ProducerRepository() : base() {
            producer= Producer.CreateProducer();
        }

        // Named constructor.
        public static ProducerRepository OpenRepository() {
            return new ProducerRepository();
        }

        public new void FindById(string clientID) {
            FindProducerUserData( clientID );
            GetProducerUserData();
            if(producer==null) {
                return;
            }
            FindProducerComercialData( clientID );
            producer.ComercialInfo= GetProducerComercialData();
            producer.ProductList =FindAllProducts( clientID );
        }

        private void FindProducerUserData(string id) {
            sql.Append( "select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=5 " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            //connection.CloseConnection();
        }

        private void GetProducerUserData() {
            if(dataTable.Rows.Count.Equals( 0 )) {
                producer=null;
                return;
            }
            DataRow row = dataTable.Rows[0];
            producer.ID = row["id_cliente"].ToString();
            producer.FirstName= row["nombre_cliente"].ToString();
            producer.LastName= row["apellido_cliente"].ToString();
            producer.DNI= row["DNI"].ToString();
            producer.Profile.ProfileID=5;
            producer.Profile.ProfileName= row["Rol"].ToString();
        }


        private void FindProducerComercialData(string id) {
            sql.Clear();
            sql.Append( "select * from vwObtenerDatosComerciales where id_cliente=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            // connection.CloseConnection();
        }


        private ComercialData GetProducerComercialData() {
            ComercialData data = ComercialData.CreateComercialData();
            if(dataTable.Rows.Count.Equals( 0 )) {
                return null;
            }
            DataRow row = dataTable.Rows[0];
            data.ComercialID= row["id_comercial"].ToString();
            data.ClientID = row["id_cliente"].ToString();
            data.CompanyName= row["Razon social"].ToString();
            data.FantasyName=row["Nombre de fantasia"].ToString();
            data.ComercialBusiness= row["Giro comercial"].ToString();
            data.Email= row["Email"].ToString();
            data.ComercialDNI= row["DNI"].ToString();
            data.Address= row["Direccion"].ToString();
            data.City= row["Ciudad"].ToString();
            data.Country= row["Pais"].ToString();
            data.PhoneNumber = row["Telefono"].ToString();
            return data;
        }


        public void NewProduct(Product product,string clientID) {
            IQueryAction query = DefineQueryAction( "spAgregarProductos " );
            query.AddParameter( "pIdProducto",product.ProductID,DbType.String );
            query.AddParameter( "pIdCliente",clientID,DbType.String );
            query.AddParameter( "pNombre",product.ProductName,DbType.String );
            query.AddParameter( "pObservacion",product.Observation,DbType.String );
            query.AddParameter( "pValor",product.ProductValue,DbType.Decimal );
            query.AddParameter( "pCantidad",product.ProductQuantity,DbType.Decimal );
            query.ExecuteQuery();
        }


        public void EditProduct(Product product) {
            IQueryAction query = DefineQueryAction( "spActualizarProductos " );
            query.AddParameter( "pIdProducto",product.ProductID,DbType.String );
            query.AddParameter( "pNombre",product.ProductName,DbType.String );
            query.AddParameter( "pObservacion",product.Observation,DbType.String );
            query.AddParameter( "pValor",product.ProductValue,DbType.Decimal );
            query.AddParameter( "pCantidad",product.ProductQuantity,DbType.Decimal );
            query.ExecuteQuery();
        }


        public void DeleteProduct(string productID) {
            IQueryAction query = DefineQueryAction( "spEliminarProductos " );
            query.AddParameter( "pIdProducto",productID,DbType.String );
            query.ExecuteQuery();
        }


        public Product FindProductByID(string productID) {
            sql.Clear();
            sql.Append( "select * from fv_user.producto where id_producto=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",productID,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            return GetProductData();
        }

        private Product GetProductData() {
            DataRow row = dataTable.Rows[0];
            if(row==null) {
                return null;
            }
            Product product = Product.CreateProduct();
            product.ProductID = row["id_producto"].ToString();
            product.ClientID = row["id_cliente"].ToString();
            product.ProductName= row["nombre_producto"].ToString();
            product.Observation= row["obs_producto"].ToString();
            product.ProductValue= float.Parse( row["valor_producto"].ToString() );
            product.ProductQuantity= float.Parse( row["cantidad_producto"].ToString() );
            return product;
        }


        public IList<Product> FindAllProducts(string clientID) {
            sql.Clear();
            sql.Append( "select * from fv_user.producto where id_cliente=:pId " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",clientID,DbType.String );
            dataTable = querySelect.ExecuteQuery();
            return GetProductsData();
        }

        private IList<Product> GetProductsData() {
            IList<Product> productList = new List<Product>();
            if(dataTable.Rows.Count.Equals( 0 )) {
                return productList;
            }
            foreach(DataRow row in dataTable.Rows) {
                Product product = Product.CreateProduct();
                product.ProductID=row["id_producto"].ToString();
                product.ClientID=row["id_cliente"].ToString();
                product.ProductName=row["nombre_producto"].ToString();
                product.Observation= row["obs_producto"].ToString();
                product.ProductValue = float.Parse( row["valor_producto"].ToString() );
                product.ProductQuantity=float.Parse( row["cantidad_producto"].ToString() );
                productList.Add( product );
            }
            return productList;
        }





    }
}
