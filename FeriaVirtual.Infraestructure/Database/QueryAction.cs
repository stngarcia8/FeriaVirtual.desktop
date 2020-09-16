using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace FeriaVirtual.Infraestructure.Database {
    public class QueryAction:Query, IQueryAction {

        // Constructor
        private QueryAction(OracleCommand command) : base( command ) { }


        // Named constructor.
        public static QueryAction CreateQuery(OracleCommand command) {
            return new QueryAction( command );
        }


        // Add parameters to query.
        public new void AddParameter(string parameterName,object parameterValue,DbType parameterValueType) {
            base.AddParameter( parameterName,parameterValue,parameterValueType );
        }


        // Excecute query.
        public int ExecuteQuery() {
            int recordCount = 0;
            try {
                recordCount = command.ExecuteNonQuery();
            } catch {
                throw;
            }

            return recordCount;
        }


        // Clean parameters.
        public void CleanParameters() {
            base.ClearParameters();
        }

    }
}
