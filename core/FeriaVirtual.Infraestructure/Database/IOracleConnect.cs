using Oracle.ManagedDataAccess.Client;

namespace FeriaVirtual.Infraestructure.Database {

    public interface IOracleConnect {

        void CloseConnection();

        void Commit();

        IQueryAction CreateQueryAction(string storedProcedureName);

        IQuerySelect CreateQuerySelect(string sql);

        OracleConnection GetConnection();

        OracleTransaction GetTransaction();

        void RollBack();
    }
}