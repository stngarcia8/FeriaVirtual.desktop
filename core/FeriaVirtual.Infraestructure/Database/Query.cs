using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace FeriaVirtual.Infraestructure.Database {

    public abstract class Query {

        protected OracleCommand Command;


        protected Query(OracleCommand command) {
            Command = command;
            Command.BindByName = true;
        }


        protected void AddParameter(string parameterName,object parameterValue,DbType parameterValueType) {
            var parameter = new OracleParameter {
                ParameterName = parameterName,
                Value = parameterValue,
                DbType = parameterValueType
            };
            Command.Parameters.Add(parameter);
        }


        protected void ClearParameters() {
            Command.Parameters.Clear();
        }

    }

}