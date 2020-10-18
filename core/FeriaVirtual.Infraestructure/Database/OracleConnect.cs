using System;
using FeriaVirtual.Infraestructure.Exceptions;
using Oracle.ManagedDataAccess.Client;

namespace FeriaVirtual.Infraestructure.Database {

    public class OracleConnect:IOracleConnect, IDisposable {
        private bool disposed = false;
        private OracleConnection connection;
        private OracleTransaction transaction;
        private readonly string conecctionString;

        // Constructor.
        private OracleConnect() {
            conecctionString = GenerateConnectionString();
        }

        // Named constructor
        public static OracleConnect CreateConnection() {
            return new OracleConnect();
        }

        // Generate connection string
        private string GenerateConnectionString() {
            return string.Format("Data Source={0};User Id={1};Password={2};","localhost/xe","fv_user","fv_pwd");
        }

        // Get connection method.
        public OracleConnection GetConnection() {
            if(connection == null) {
                InitializeObjects();
            }
            return connection;
        }

        // Get transaction method.
        public OracleTransaction GetTransaction() {
            if(transaction == null) {
                InitializeObjects();
            }
            return transaction;
        }

        // Initialize objects method.
        private void InitializeObjects() {
            try {
                connection = new OracleConnection(conecctionString);
                connection.Open();
                transaction = connection.BeginTransaction();
            } catch {
                ConnectionFailedException ex = new ConnectionFailedException("El servidor de base de datos no se encuentra disponible, comunique este problema al administrador del servicio de base de datos.");
                throw;
            }
        }

        // Commit method.
        public void Commit() {
            if(transaction != null) {
                transaction.Commit();
            }
        }

        // Rollback method.
        public void RollBack() {
            if(transaction != null) {
                transaction.Rollback();
            }
        }

        // Create selection objects method.
        public IQuerySelect CreateQuerySelect(string sql) {
            try {
                OracleCommand command = GetConnection().CreateCommand();
                command.CommandText = sql;
                command.Transaction = transaction;
                return QuerySelect.CreateQuery(command);
            } catch(Exception ex) {
                throw;
            }
        }

        // Create action query method.
        public IQueryAction CreateQueryAction(string storedProcedureName) {
            try {
                OracleCommand command = GetConnection().CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Transaction = transaction;
                return QueryAction.CreateQuery(command);
            } catch(Exception ex) {
                throw;
            }
        }

        // Close connection method.
        public void CloseConnection() {
            ClosingTransaction();
            ClosingConnection();
        }

        // Close transaction method.
        private void ClosingTransaction() {
            if(transaction != null) {
                transaction.Dispose();
                transaction = null;
            }
        }

        // Close oracle connection.
        private void ClosingConnection() {
            if(connection != null) {
                connection.Dispose();
                connection = null;
            }
        }

        // Disposed method.

        #region "Destructor."

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if(disposed) {
                return;
            }
            if(disposing) {
                ClosingTransaction();
                ClosingConnection();
            }
            disposed = true;
        }

        ~OracleConnect() {
            Dispose(false);
        }

        #endregion "Destructor."
    }
}