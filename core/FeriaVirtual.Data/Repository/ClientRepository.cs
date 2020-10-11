using System.Data;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;
using FeriaVirtual.Infraestructure.Mailer;

namespace FeriaVirtual.Data.Repository {

    public class ClientRepository:Repository {
        private readonly int profileID;

        // Constructor
        private ClientRepository(int profileId) : base() {
            profileID= profileId;
        }

        // Named constructor.
        public static ClientRepository OpenRepository(int profileId) {
            return new ClientRepository(profileId);
        }

        public new void FindAll() {
            sql.Append("select * from fv_user.vwObtenerClientes  where id_rol=:pIdRol ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdRol",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }

        public new void FindByName(string name) {
            sql.Append("select * from fv_user.vwObtenerClientes where (nombre_cliente like :pName or apellido_cliente like :pApellido) and id_rol=:pIdRol ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pName",name,DbType.String);
            querySelect.AddParameter("pApellido",name,DbType.String);
            querySelect.AddParameter("pIdRol",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }

        public new void FindById(string id) {
            sql.Append("select * from fv_user.vwObtenerClientes where id_usuario=:pId and id_rol=:pIdRol ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            querySelect.AddParameter("pIdRol",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
        }

        public void FindActiveClients() {
            sql.Append("select * from fv_user.vwObtenerClientes where is_active=1 and id_rol=:pIdRol ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdRol",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }

        public void FindInactiveClients() {
            sql.Append("select * from fv_user.vwObtenerClientes where is_active=0 and id_rol=:pIdRol ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdRol",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
            connection.CloseConnection();
        }

        public void NewClient(Client client) {
            IQueryAction query = DefineQueryAction("spAgregarCliente");
            query.AddParameter("pIdUsuario",client.Credentials.UserId,DbType.String);
            query.AddParameter("pUserName",client.Credentials.Username,DbType.String);
            query = DefineQueryParameters(client,query);
            query.ExecuteQuery();
            SendMailMessage(client,MailTypeMessage.NewClient);
        }

        private IQueryAction DefineQueryParameters(Client client,IQueryAction query) {
            query.AddParameter("pPassword",client.Credentials.EncriptedPassword,DbType.String);
            query.AddParameter("pEmail",client.Credentials.Email,DbType.String);
            query.AddParameter("pIdCliente",client.ID,DbType.String);
            query.AddParameter("pIdRol",profileID,DbType.Int32);
            query.AddParameter("pNombre",client.FirstName,DbType.String);
            query.AddParameter("pApellido",client.LastName,DbType.String);
            query.AddParameter("pDNI",client.DNI,DbType.String);
            return query;
        }

        private void SendMailMessage(Client client,MailTypeMessage mailTypeMessage) {
            MailSender sender = MailSender.CreateSender(client,mailTypeMessage);
            sender.SendMail();
        }

        public void EditClient(Client client) {
            IQueryAction query = DefineQueryAction("spActualizarCliente");
            query.AddParameter("pIdUsuario",client.Credentials.UserId,DbType.String);
            query = DefineQueryParameters(client,query);
            query.ExecuteQuery();
            SendMailMessage(client,MailTypeMessage.EditClient);
        }

        public void EnableOrDisableClient(string id,int typeAction) {
            IQueryAction query = DefineQueryAction("spHabilitarCliente");
            query.AddParameter("pIdUsuario",id,DbType.String);
            query.AddParameter("pTipoAccion",typeAction,DbType.Int32);
            query.ExecuteQuery();
        }
    }
}