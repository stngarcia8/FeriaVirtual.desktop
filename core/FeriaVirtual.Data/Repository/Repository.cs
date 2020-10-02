using System.Data;
using System.Text;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {
    public abstract class Repository {

        protected IOracleConnect connection;
        protected StringBuilder sql = new StringBuilder();
        protected DataTable dataTable = new DataTable();


        // Properties.
        public DataTable DataSource => dataTable;


        // Constructor
        protected Repository() { }


        // Define query selection.
        protected IQuerySelect DefineQuerySelect(string sqlString) {
            connection = OracleConnect.CreateConnection();
            return connection.CreateQuerySelect(sqlString);
        }


        //Define action query.
        protected IQueryAction DefineQueryAction(string storeProcedureName) {
            connection = OracleConnect.CreateConnection();
            return connection.CreateQueryAction(storeProcedureName);
        }


        // Find all items
        protected void FindAll() {
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        // Find items by idntifier.
        protected void FindById(int id) {
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        protected void FindById(string id) {
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        // Find items by name.
        protected void FindByName(string name) {
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pName",name,DbType.String);
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }



    }
}
