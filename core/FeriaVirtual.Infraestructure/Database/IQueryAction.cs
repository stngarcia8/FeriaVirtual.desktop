using System.Data;

namespace FeriaVirtual.Infraestructure.Database {
    public interface IQueryAction {

        void AddParameter(string parameterName,object parameterValue,DbType parameterValueType);

        void CleanParameters();

        int ExecuteQuery();

    }
}
