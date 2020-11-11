using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace FeriaVirtual.Infraestructure.Database {
    
    public class QuerySelect : Query, IQuerySelect{

        // Constructor
        private QuerySelect(OracleCommand command) : base(command){ }


        // Add parameter to the query.
        public new void AddParameter(string parameterName, object parameterValue, DbType parameterValueType){
            base.AddParameter(parameterName, parameterValue, parameterValueType);
        }


        public DataTable ExecuteQuery(){
            var dataTable = new DataTable();
            var dataAdapter = new OracleDataAdapter{
                SelectCommand = Command
            };
            dataAdapter.Fill(dataTable);

            return dataTable;
        }


        // Clean parameters.
        public void CleanParameters(){
            ClearParameters();
        }


        // Named constructor.
        public static QuerySelect CreateQuery(OracleCommand command){
            return new QuerySelect(command);
        }

    }

}