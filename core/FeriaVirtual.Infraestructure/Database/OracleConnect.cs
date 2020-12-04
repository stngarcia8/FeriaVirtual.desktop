using System;
using System.Data;
using FeriaVirtual.Infraestructure.Exceptions;
using Oracle.ManagedDataAccess.Client;


namespace FeriaVirtual.Infraestructure.Database {

    public class OracleConnect:IOracleConnect, IDisposable {

        private readonly string conecctionString;

        private readonly string host;
        private readonly string password;
        private readonly string username;
        private OracleConnection connection;
        private bool disposed;
        private OracleTransaction transaction;


        public OracleConnection GetConnection() {
            if(connection == null) {
                InitializeObjects();
            }

            return connection;
        }


        public OracleTransaction GetTransaction() {
            if(transaction == null) {
                InitializeObjects();
            }

            return transaction;
        }


        public void Commit() {
            transaction?.Commit();
        }


        public void RollBack() {
            transaction?.Rollback();
        }


        public IQuerySelect CreateQuerySelect(string sql) {
            OracleCommand command = GetConnection().CreateCommand();
            command.CommandText = sql;
            command.Transaction = transaction;
            return QuerySelect.CreateQuery(command);
        }


        public IQueryAction CreateQueryAction(string storedProcedureName) {
            OracleCommand command = GetConnection().CreateCommand();
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Transaction = transaction;
            return QueryAction.CreateQuery(command);
        }


        public void CloseConnection() {
            ClosingTransaction();
            ClosingConnection();
        }


        private OracleConnect() {
            host = "maipogrande-fv.duckdns.org";
            username = "fv_user";
            password = "fv_pwd";
            conecctionString = GenerateConnectionString();
        }


        public static OracleConnect CreateConnection() {
            return new OracleConnect();
        }


        private string GenerateConnectionString() {
            // return "Data Source=localhost/xe;User Id=fv_user;Password=fv_pwd;";
            // return $"Data Source={host}/xe;User Id={username};Password={password};";
            return $"Data Source={host}/xe;User Id={username};Password={password};Load Balancing=false;HA Events = false;";
        }


        private void InitializeObjects() {
            try {
                connection = new OracleConnection(conecctionString);
                connection.Open();
                OracleGlobalization info = connection.GetSessionInfo();
                info.Language = "SPANISH";
                info.Territory = "CHILE";
                connection.SetSessionInfo(info);
                transaction = connection.BeginTransaction();
            } catch {
                throw new ConnectionFailedException(
                    "El servidor de base de datos no se encuentra disponible, comunique este problema al administrador del servicio de base de datos.");
            }
        }


        private void ClosingTransaction() {
            if(transaction == null) {
                return;
            }

            transaction.Dispose();
            transaction = null;
        }


        private void ClosingConnection() {
            if(connection == null) {
                return;
            }

            connection.Dispose();
            connection = null;
        }


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