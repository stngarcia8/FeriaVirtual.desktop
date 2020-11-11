using System;
using System.Data;
using FeriaVirtual.Infraestructure.Exceptions;
using Oracle.ManagedDataAccess.Client;


namespace FeriaVirtual.Infraestructure.Database{

    public class OracleConnect : IOracleConnect, IDisposable{

        private readonly string conecctionString;
        private OracleConnection connection;
        private bool disposed;
        private OracleTransaction transaction;


        // Constructor.
        private OracleConnect(){
            conecctionString = GenerateConnectionString();
        }


        // Get connection method.
        public OracleConnection GetConnection(){
            if (connection == null) InitializeObjects();
            return connection;
        }


        // Get transaction method.
        public OracleTransaction GetTransaction(){
            if (transaction == null) InitializeObjects();
            return transaction;
        }


        // Commit method.
        public void Commit(){
            transaction?.Commit();
        }


        // Rollback method.
        public void RollBack(){
            transaction?.Rollback();
        }


        // Create selection objects method.
        public IQuerySelect CreateQuerySelect(string sql){
            var command = GetConnection().CreateCommand();
            command.CommandText = sql;
            command.Transaction = transaction;
            return QuerySelect.CreateQuery(command);
        }


        // Create action query method.
        public IQueryAction CreateQueryAction(string storedProcedureName){
            var command = GetConnection().CreateCommand();
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Transaction = transaction;
            return QueryAction.CreateQuery(command);
        }


        // Close connection method.
        public void CloseConnection(){
            ClosingTransaction();
            ClosingConnection();
        }


        // Named constructor
        public static OracleConnect CreateConnection(){
            return new OracleConnect();
        }


        // Generate connection string
        private string GenerateConnectionString(){
            return "Data Source=localhost/xe;User Id=fv_user;Password=fv_pwd;";
        }


        // Initialize objects method.
        private void InitializeObjects(){
            try{
                connection = new OracleConnection(conecctionString);
                connection.Open();
                var info = connection.GetSessionInfo();
                info.Language = "SPANISH";
                info.Territory = "CHILE";
                connection.SetSessionInfo(info);
                transaction = connection.BeginTransaction();
            }
            catch{
                throw new ConnectionFailedException(
                    "El servidor de base de datos no se encuentra disponible, comunique este problema al administrador del servicio de base de datos.");
            }
        }


        // Close transaction method.
        private void ClosingTransaction(){
            if (transaction == null) return;
            transaction.Dispose();
            transaction = null;
        }


        // Close oracle connection.
        private void ClosingConnection(){
            if (connection == null) return;
            connection.Dispose();
            connection = null;
        }


        // Disposed method.

        #region "Destructor."

        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing){
            if (disposed) return;
            if (disposing){
                ClosingTransaction();
                ClosingConnection();
            }

            disposed = true;
        }


        ~OracleConnect(){
            Dispose(false);
        }

        #endregion "Destructor."

    }

}