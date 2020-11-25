using System;
using System.Data;
using FeriaVirtual.Infraestructure.Exceptions;
using Oracle.ManagedDataAccess.Client;


namespace FeriaVirtual.Infraestructure.Database{

    public class OracleConnect : IOracleConnect, IDisposable{

        private readonly string host;
        private readonly string username;
        private readonly string password;


        private readonly string conecctionString;
        private OracleConnection connection;
        private bool disposed;
        private OracleTransaction transaction;


        private OracleConnect(){
            this.host = "maipogrande-fv.duckdns.org";
            this.username = "fv_user";
            this.password = "fv_pwd";
            conecctionString = GenerateConnectionString();
        }


        public OracleConnection GetConnection(){
            if (connection == null) InitializeObjects();
            return connection;
        }


        public OracleTransaction GetTransaction(){
            if (transaction == null) InitializeObjects();
            return transaction;
        }


        public void Commit(){
            transaction?.Commit();
        }


        public void RollBack(){
            transaction?.Rollback();
        }


        public IQuerySelect CreateQuerySelect(string sql){
            var command = GetConnection().CreateCommand();
            command.CommandText = sql;
            command.Transaction = transaction;
            return QuerySelect.CreateQuery(command);
        }


        public IQueryAction CreateQueryAction(string storedProcedureName){
            var command = GetConnection().CreateCommand();
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Transaction = transaction;
            return QueryAction.CreateQuery(command);
        }


        public void CloseConnection(){
            ClosingTransaction();
            ClosingConnection();
        }


        public static OracleConnect CreateConnection(){
            return new OracleConnect();
        }


        private string GenerateConnectionString(){
            // return "Data Source=localhost/xe;User Id=fv_user;Password=fv_pwd;";
            return $"Data Source={this.host}/xe;User Id={this.username};Password={this.password};";
        }


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


        private void ClosingTransaction(){
            if (transaction == null) return;
            transaction.Dispose();
            transaction = null;
        }


        private void ClosingConnection(){
            if (connection == null) return;
            connection.Dispose();
            connection = null;
        }


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