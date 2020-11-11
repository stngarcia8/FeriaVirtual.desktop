using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace FeriaVirtual.Infraestructure.Database {

    public class QueryAction : Query, IQueryAction{

        // Constructor
        private QueryAction(OracleCommand command) : base(command){ }


        // Add parameters to query.
        public new void AddParameter(string parameterName, object parameterValue, DbType parameterValueType){
            base.AddParameter(parameterName, parameterValue, parameterValueType);
        }


        public int ExecuteQuery(){
            return Command.ExecuteNonQuery();
        }


        // Clean parameters.
        public void CleanParameters(){
            ClearParameters();
        }


        // Named constructor.
        public static QueryAction CreateQuery(OracleCommand command){
            return new QueryAction(command);
        }

    }

}