using System;
using NLog;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace FeriaVirtual.Infraestructure.Database {

    public class QuerySelect:Query, IQuerySelect {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // Constructor
        private QuerySelect(OracleCommand command) : base(command) { }

        // Named constructor.
        public static QuerySelect CreateQuery(OracleCommand command) {
            return new QuerySelect(command);
        }

        // Add parameter to the query.
        public new void AddParameter(string parameterName,object parameterValue,DbType parameterValueType) {
            base.AddParameter(parameterName,parameterValue,parameterValueType);
        }

        // Excecute query.
        public DataTable ExecuteQuery() {
            DataTable dataTable = new DataTable();
            try {
                OracleDataAdapter dataAdapter = new OracleDataAdapter {
                    SelectCommand = command
                };
                dataAdapter.Fill(dataTable);
            } catch (Exception ex) {
                logger.Error(ex,"Error al ejecutar consulta de selección");
                throw;
            }
            return dataTable;
        }

        // Clean parameters.
        public void CleanParameters() {
            base.ClearParameters();
        }
    }
}