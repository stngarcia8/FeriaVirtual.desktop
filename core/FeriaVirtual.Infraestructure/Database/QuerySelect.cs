using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace FeriaVirtual.Infraestructure.Database {
    
    public class QuerySelect : Query, IQuerySelect{

        private QuerySelect(OracleCommand command) : base(command){ }


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


        public void CleanParameters(){
            ClearParameters();
        }


        public static QuerySelect CreateQuery(OracleCommand command){
            return new QuerySelect(command);
        }

    }

}