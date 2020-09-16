using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace FeriaVirtual.Infraestructure.Database {
    public abstract class Query {

        protected OracleCommand command;

        protected Query(OracleCommand command) {
            this.command = command;
            this.command.BindByName = true;
        }


        protected void AddParameter(string parameterName,object parameterValue,DbType parameterValueType) {
            OracleParameter parameter = new OracleParameter {
                ParameterName = parameterName,
                Value = parameterValue,
                DbType = parameterValueType
            };
            command.Parameters.Add( parameter );
        }


        protected void ClearParameters() {
            command.Parameters.Clear();
        }

    }
}
