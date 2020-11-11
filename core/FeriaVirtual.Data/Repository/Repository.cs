using System.Data;
using System.Text;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository{

    public abstract class Repository{

        protected IOracleConnect Connection;
        protected DataTable DataTable = new DataTable();
        protected StringBuilder Sql = new StringBuilder();

        // Properties.
        public DataTable DataSource => DataTable;


        // Constructor


        // Define query selection.
        protected IQuerySelect DefineQuerySelect(string sqlString){
            Connection = OracleConnect.CreateConnection();
            return Connection.CreateQuerySelect(sqlString);
        }


        //Define action query.
        protected IQueryAction DefineQueryAction(string storeProcedureName){
            Connection = OracleConnect.CreateConnection();
            return Connection.CreateQueryAction(storeProcedureName);
        }


        // Find all items
        protected void FindAll(){
            var querySelect = DefineQuerySelect(Sql.ToString());
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }


        protected void FindById(int id){
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", id, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }


        protected void FindById(string id){
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", id, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }


        // Find items by name.
        protected void FindByName(string name){
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pName", name, DbType.String);
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }

    }

}