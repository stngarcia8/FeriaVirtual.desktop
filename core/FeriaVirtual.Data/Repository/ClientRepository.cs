using System.Data;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;
using FeriaVirtual.Infraestructure.Mailer;

namespace FeriaVirtual.Data.Repository {

public     class ClientRepository:Repository {

        private int profileID;

        // Constructor
        private ClientRepository(int profileId) : base() {
            this.profileID= profileId;
        }

        // Named constructor.
        public static ClientRepository OpenRepository(int profileId) {
            return new ClientRepository(profileId);
        }


        public new void FindAll() {
            sql.Append( "select * from fv_user.vwObtenerClientes  where id_rol=:pIdRol " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pIdRol",profileID,DbType.Int32 );
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        public new void FindByName(string name) {
            sql.Append( "select * from fv_user.vwObtenerClientes where Nombre=:pName and id_rol=:pIdRol " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pName",name,DbType.String );
            querySelect.AddParameter( "pIdRol",profileID,DbType.Int32 );
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        public new void FindById(string id) {
            sql.Append( "select * from fv_user.vwObtenerClientes where id_usuario=:pId and id_rol=:pIdRol " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pId",id,DbType.String );
            querySelect.AddParameter( "pIdRol",profileID,DbType.Int32 );
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        public void FindActiveClients() {
            sql.Append( "select * from fv_user.vwObtenerClientes where is_active=1 and id_rol=:pIdRol " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pIdRol",profileID,DbType.Int32 );
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        public void FindInactiveClients() {
            sql.Append( "select * from fv_user.vwObtenerClientes where is_active=0 and id_rol=:pIdRol " );
            IQuerySelect querySelect = DefineQuerySelect( sql.ToString() );
            querySelect.AddParameter( "pIdRol",profileID,DbType.Int32 );
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }


        public void NewClient(Client client) {
            IQueryAction query = DefineQueryAction( "spAgregarCliente" );
            query.AddParameter( "pIdUsuario",client.Credentials.UserId,DbType.String );
            query.AddParameter( "pUserName",client.Credentials.Username,DbType.String );
            query.AddParameter( "pPassword",client.Credentials.EncriptedPassword,DbType.String );
            query.AddParameter( "pEmail",client.Credentials.Email,DbType.String );
            query.AddParameter( "pIdCliente",client.ID,DbType.String );
            query.AddParameter( "pIdRol",this.profileID,DbType.Int32 );
            query.AddParameter( "pNombre",client.FirstName,DbType.String );
            query.AddParameter( "pApellido",client.LastName,DbType.String );
            query.AddParameter( "pDNI",client.DNI,DbType.String );
            query.ExecuteQuery();
            MailSender sender = MailSender.CreateSender( client,MailTypeMessage.NewClient );
            sender.SendMail();
        }


        public void EditClient(Client client) {
            IQueryAction query = DefineQueryAction( "spActualizarCliente" );
            query.AddParameter( "pIdUsuario",client.Credentials.UserId,DbType.String );
            query.AddParameter( "pPassword",client.Credentials.EncriptedPassword,DbType.String );
            query.AddParameter( "pEmail",client.Credentials.Email,DbType.String );
            query.AddParameter( "pIdCliente",client.ID,DbType.String );
            query.AddParameter( "pIdRol",this.profileID,DbType.Int32 );
            query.AddParameter( "pNombre",client.FirstName,DbType.String );
            query.AddParameter( "pApellido",client.LastName,DbType.String );
            query.AddParameter( "pDNI",client.DNI,DbType.String );
            query.ExecuteQuery();
        }




    }
}
