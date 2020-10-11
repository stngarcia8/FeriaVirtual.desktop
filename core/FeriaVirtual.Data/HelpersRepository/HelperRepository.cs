using System.Data;
using System.Text;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.HelpersRepository {

    public abstract class HelperRepository {
        protected IOracleConnect connection;
        protected StringBuilder sql = new StringBuilder();
        protected DataTable dataTable = new DataTable();

        // Properties.
        public DataTable DataSource => dataTable;

        // Constructor
        protected HelperRepository() { }

        // Define query selection.
        protected IQuerySelect DefineQuerySelect(string sqlString) {
            connection = OracleConnect.CreateConnection();
            return connection.CreateQuerySelect(sqlString);
        }

        // Find all items
        protected void FindAll() {
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }
    }
}