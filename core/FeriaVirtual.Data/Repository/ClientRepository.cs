using System.Data;
using FeriaVirtual.Data.Notifiers;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;


namespace FeriaVirtual.Data.Repository{

    public class ClientRepository : Repository{

        private readonly int profileId;
        private readonly IQueueNotifier queueNotifier;
        private readonly EmailUserNotifier mailNotifier;


        private ClientRepository(int profileId){
            this.profileId = profileId;
            queueNotifier = QueueNotifier.CreateNotifier();
            mailNotifier = EmailUserNotifier.CreateNotifier();
        }


        public static ClientRepository OpenRepository(int profileId){
            return new ClientRepository(profileId);
        }


        public new void FindAll(){
            Sql.Append("select * from fv_user.vwObtenerClientes  where id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", profileId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }


        public new void FindByName(string name){
            Sql.Append(
                "select * from fv_user.vwObtenerClientes where (nombre_cliente like :pName or apellido_cliente like :pApellido) and id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pName", name, DbType.String);
            querySelect.AddParameter("pApellido", name, DbType.String);
            querySelect.AddParameter("pIdRol", profileId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }


        public new void FindById(string id){
            Sql.Append("select * from fv_user.vwObtenerClientes where id_usuario=:pId and id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId", id, DbType.String);
            querySelect.AddParameter("pIdRol", profileId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }


        public void FindActiveClients(){
            Sql.Append("select * from fv_user.vwObtenerClientes where is_active=1 and id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", profileId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }


        public void FindInactiveClients(){
            Sql.Append("select * from fv_user.vwObtenerClientes where is_active=0 and id_rol=:pIdRol ");
            var querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", profileId, DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
            Connection.CloseConnection();
        }


        public void NewClient(Client client){
            var query = DefineQueryAction("spAgregarCliente");
            query.AddParameter("pIdUsuario", client.Credentials.UserId, DbType.String);
            query.AddParameter("pUserName", client.Credentials.Username, DbType.String);
            query = DefineQueryParameters(client, query);
            query.ExecuteQuery();
            mailNotifier.Notify(client, MailTypeMessage.NewClient);
            queueNotifier.Notify("User", "UserWasCreate", CreateSession(client));
        }


        private IQueryAction DefineQueryParameters(Client client, IQueryAction query){
            query.AddParameter("pPassword", client.Credentials.EncriptedPassword, DbType.String);
            query.AddParameter("pEmail", client.Credentials.Email, DbType.String);
            query.AddParameter("pIdCliente", client.Id, DbType.String);
            query.AddParameter("pIdRol", profileId, DbType.Int32);
            query.AddParameter("pNombre", client.FirstName, DbType.String);
            query.AddParameter("pApellido", client.LastName, DbType.String);
            query.AddParameter("pDNI", client.Dni, DbType.String);
            return query;
        }


        private SessionDto CreateSession(Client client){
            var session = new SessionDto{
                SessionId = "",
                UserId = client.Credentials.UserId,
                ClientId = client.Id,
                Username = client.Credentials.Username,
                Password = client.Credentials.EncriptedPassword,
                FullName = client.ToString(),
                Email = client.Credentials.Email,
                ProfileId = client.Profile.ProfileId,
                ProfileName = client.Profile.ProfileName
            };
            return session;
        }


        public void EditClient(Client client){
            var query = DefineQueryAction("spActualizarCliente");
            query.AddParameter("pIdUsuario", client.Credentials.UserId, DbType.String);
            query = DefineQueryParameters(client, query);
            query.ExecuteQuery();
            mailNotifier.Notify(client, MailTypeMessage.EditClient);
            queueNotifier.Notify("User", "UserWasModify", CreateSession(client));
        }


        public void EnableOrDisableClient(string id, int typeAction){
            var query = DefineQueryAction("spHabilitarCliente");
            query.AddParameter("pIdUsuario", id, DbType.String);
            query.AddParameter("pTipoAccion", typeAction, DbType.Int32);
            query.ExecuteQuery();
            queueNotifier.Notify("User", typeAction.Equals(0) ? "UserWasDisable" : "UserWasEnable",
                ChangeMessageStatus.Create(id, typeAction));
        }

    }

}