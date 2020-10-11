using System;
using NLog;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace FeriaVirtual.Infraestructure.Database {

    public class QueryAction:Query, IQueryAction {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // Constructor
        private QueryAction(OracleCommand command) : base(command) { }

        // Named constructor.
        public static QueryAction CreateQuery(OracleCommand command) {
            return new QueryAction(command);
        }

        // Add parameters to query.
        public new void AddParameter(string parameterName,object parameterValue,DbType parameterValueType) {
            base.AddParameter(parameterName,parameterValue,parameterValueType);
        }

        // Excecute query.
        public int ExecuteQuery() {
            int recordCount = 0;
            try {
                recordCount = command.ExecuteNonQuery();
            } catch (Exception ex) {
                logger.Error(ex,"Error al ejecutar consulta de acción");
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