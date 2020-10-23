﻿using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Products;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class ProducerRepository:Repository {
        private Producer producer;

        // Properties
        public Producer Producer => producer;

        // Constructor
        private ProducerRepository() : base() {
            producer= Producer.CreateProducer();
        }

        // Named constructor.
        public static ProducerRepository OpenRepository() {
            return new ProducerRepository();
        }

        public new void FindById(string clientID) {
            FindProducerUserData(clientID);
            GetProducerUserData();
            if(producer==null) {
                return;
            }
            ComercialDataRepository dataRepository = ComercialDataRepository.OpenRepository();
            producer.ComercialInfo= dataRepository.FindById(clientID);
            producer.ProductList =FindAllProducts(clientID);
        }

        private void FindProducerUserData(string id) {
            sql.Append("select * from fv_user.vwObtenerClientes where id_cliente=:pId and id_rol=5 ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            dataTable = querySelect.ExecuteQuery();
        }

        private void GetProducerUserData() {
            if(dataTable.Rows.Count.Equals(0)) {
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

        public void NewProduct(Product product,string clientID) {
            IQueryAction query = DefineQueryAction("spAgregarProductos ");
            query.AddParameter("pIdCliente",clientID,DbType.String);
            query = DefineProductParameters(product,query);
            query.ExecuteQuery();
        }

        private IQueryAction DefineProductParameters(Product product,IQueryAction query) {
            query.AddParameter("pIdProducto",product.ProductID,DbType.String);
            query.AddParameter("pNombre",product.ProductName,DbType.String);
            query.AddParameter("pObservacion",product.Observation,DbType.String);
            query.AddParameter("pValor",product.ProductValue,DbType.Decimal);
            query.AddParameter("pCantidad",product.ProductQuantity,DbType.Decimal);
            query.AddParameter("pIdCategoria",product.Category.CategoryID,DbType.Int32);
            return query;
        }

        public void EditProduct(Product product) {
            IQueryAction query = DefineQueryAction("spActualizarProductos ");
            query = DefineProductParameters(product,query);
            query.ExecuteQuery();
        }

        public void DeleteProduct(string productID) {
            IQueryAction query = DefineQueryAction("spEliminarProductos ");
            query.AddParameter("pIdProducto",productID,DbType.String);
            query.ExecuteQuery();
        }

        public Product FindProductByID(string productID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerProductos where id_producto=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",productID,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            return GetProductData();
        }

        private Product GetProductData() {
            DataRow row = dataTable.Rows[0];
            if(row==null) {
                return null;
            }
            return ExtractProductValues(row);
        }

        private Product ExtractProductValues(DataRow row) {
            Product product = Product.CreateProduct();
            product.ProductID = row["id_producto"].ToString();
            product.ClientID = row["id_cliente"].ToString();
            product.ProductName= row["Producto"].ToString();
            product.Category.CategoryID= int.Parse(row["id_categoria"].ToString());
            product.Category.CategoryName= row["Categoria"].ToString();
            product.ProductValue= float.Parse(row["Valor"].ToString());
            product.ProductQuantity= float.Parse(row["Cantidad"].ToString());
            product.Observation= row["Observacion"].ToString();
            return product;
        }

        public IList<Product> FindAllProducts(string clientID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerProductos where id_cliente=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",clientID,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            return GetProductsData();
        }

        private IList<Product> GetProductsData() {
            IList<Product> productList = new List<Product>();
            if(dataTable.Rows.Count.Equals(0)) {
                return productList;
            }
            foreach(DataRow row in dataTable.Rows) {
                productList.Add(ExtractProductValues(row));
            }
            return productList;
        }

        public IList<ProductDto> FindAllExportProducts() {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerProductosExportacion where id_categoria=1 order by nombre_producto ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            dataTable = querySelect.ExecuteQuery();
            return GetExportProductsData();
        }

        private IList<ProductDto> GetExportProductsData() {
            IList<ProductDto> productList = new List<ProductDto>();
            if(dataTable.Rows.Count.Equals(0)) {
                return productList;
            }
            foreach(DataRow row in dataTable.Rows) {
                productList.Add(new ProductDto(row["nombre_producto"].ToString()));
            }
            return productList;
        }






    }
}