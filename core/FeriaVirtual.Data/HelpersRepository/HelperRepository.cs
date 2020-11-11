using System.Data;
using System.Text;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.HelpersRepository{

    public abstract class HelperRepository{

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


        // Find all items
        protected void FindAll(){
            var querySelect = DefineQuerySelect(Sql.ToString());
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }

    }

}