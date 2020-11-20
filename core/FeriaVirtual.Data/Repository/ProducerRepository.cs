using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Products;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository{

    public class ProducerRepository : Repository{

        public Producer Producer{ get; private set; }


        private ProducerRepository(){
            Producer = Producer.CreateProducer();
        }


        public static ProducerRepository OpenRepository(){
            return new ProducerRepository();
        }


        public new void FindById(string clientId){
            FindProducerUserData(clientId);
            GetProducerUserData();
            if (Producer == null) return;
            var dataRepository = ComercialDataRepository.OpenRepository();
            Producer.ComercialInfo = dataRepository.FindById(clientId);
            Producer.ProductList = FindAllProducts(clientId);
        }


        private void FindProducerUserData(string id){
            Sql.Append("select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=5 ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", id, DbType.String);
            DataTable = querySelect.ExecuteQuery();
        }


        private void GetProducerUserData(){
            if (DataTable.Rows.Count.Equals(0)){
                Producer = null;
                return;
            }

            var row = DataTable.Rows[0];
            Producer.Id = row["id_cliente"].ToString();
            Producer.FirstName = row["nombre_cliente"].ToString();
            Producer.LastName = row["apellido_cliente"].ToString();
            Producer.Dni = row["DNI"].ToString();
            Producer.Profile.ProfileId = 5;
            Producer.Profile.ProfileName = row["Rol"].ToString();
        }


        public void NewProduct(Product product, string clientId){
            var query = DefineQueryAction("spAgregarProductos ");
            query.AddParameter("pIdCliente", clientId, DbType.String);
            query = DefineProductParameters(product, query);
            query.ExecuteQuery();
        }


        private IQueryAction DefineProductParameters(Product product, IQueryAction query){
            query.AddParameter("pIdProducto", product.ProductId, DbType.String);
            query.AddParameter("pNombre", product.ProductName, DbType.String);
            query.AddParameter("pObservacion", product.Observation, DbType.String);
            query.AddParameter("pValor", product.ProductValue, DbType.Decimal);
            query.AddParameter("pCantidad", product.ProductQuantity, DbType.Decimal);
            query.AddParameter("pIdCategoria", product.Category.CategoryId, DbType.Int32);
            return query;
        }


        public void EditProduct(Product product){
            var query = DefineQueryAction("spActualizarProductos ");
            query = DefineProductParameters(product, query);
            query.ExecuteQuery();
        }


        public void DeleteProduct(string productId){
            var query = DefineQueryAction("spEliminarProductos ");
            query.AddParameter("pIdProducto", productId, DbType.String);
            query.ExecuteQuery();
        }


        public Product FindProductById(string productId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerProductos where id_producto=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", productId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            return GetProductData();
        }


        private Product GetProductData(){
            var row = DataTable.Rows[0];
            return row == null ? null : ExtractProductValues(row);
        }


        private Product ExtractProductValues(DataRow row){
            var product = Product.CreateProduct();
            product.ProductId = row["id_producto"].ToString();
            product.ClientId = row["id_cliente"].ToString();
            product.ProductName = row["Producto"].ToString();
            product.Category.CategoryId = int.Parse(row["id_categoria"].ToString());
            product.Category.CategoryName = row["Categoria"].ToString();
            product.ProductValue = float.Parse(row["Valor"].ToString());
            product.ProductQuantity = float.Parse(row["Cantidad"].ToString());
            product.Observation = row["Observacion"].ToString();
            return product;
        }


        public IList<Product> FindAllProducts(string clientId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerProductos where id_cliente=:pId ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", clientId, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            return GetProductsData();
        }


        private IList<Product> GetProductsData(){
            IList<Product> productList = new List<Product>();
            if (DataTable.Rows.Count.Equals(0)) return productList;
            foreach (DataRow row in DataTable.Rows) productList.Add(ExtractProductValues(row));
            return productList;
        }





        private IList<ProductDto> GetExportProductsData(){
            IList<ProductDto> productList = new List<ProductDto>();
            if (DataTable.Rows.Count.Equals(0)) return productList;
            foreach (DataRow row in DataTable.Rows) productList.Add(new ProductDto(row["nombre_producto"].ToString()));
            return productList;
        }


        public void SearchProductByCategory(int categoryId){
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerProductos where id_categoria=:pIdCategoria ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdCategoria", categoryId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }





    }

}