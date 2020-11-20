﻿using System.Data;
using FeriaVirtual.Infraestructure.Queues;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Domain.Enums;
using FeriaVirtual.Domain.Users;
using FeriaVirtual.Infraestructure.Database;
using FeriaVirtual.Infraestructure.Mailer;


namespace FeriaVirtual.Data.Repository{

    public class ClientRepository : Repository{

        private readonly int profileId;


        // Constructor
        private ClientRepository(int profileId){
            this.profileId = profileId;
        }


        // Named constructor.
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
            SendMailMessage(client, MailTypeMessage.NewClient);
            PublishNewUserEvent(client);
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


        private void SendMailMessage(Client client, MailTypeMessage mailTypeMessage){
            var sender = MailSender.CreateSender(client, mailTypeMessage);
            sender.SendMail();
        }


        private void PublishNewUserEvent(Client client){
            SessionDto session = CreateSession(client);
            IPublishEvent publisher = UserEvent.CreateEvent(session);
            publisher.PublishEvent();
        }


        private SessionDto CreateSession(Client client){
            SessionDto session = new SessionDto{
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
            SendMailMessage(client, MailTypeMessage.EditClient);
        }


        public void EnableOrDisableClient(string id, int typeAction){
            var query = DefineQueryAction("spHabilitarCliente");
            query.AddParameter("pIdUsuario", id, DbType.String);
            query.AddParameter("pTipoAccion", typeAction, DbType.Int32);
            query.ExecuteQuery();
        }

    }

}