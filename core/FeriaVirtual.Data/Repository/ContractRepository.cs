using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.Infraestructure.Database;
using FeriaVirtual.Infraestructure.Queues;


namespace FeriaVirtual.Data.Repository {

    public class ContractRepository:Repository {

        private readonly int profileId;


        // Constructor
        private ContractRepository(int profileId) {
            this.profileId = profileId;
        }


        // Named constructor.
        public static ContractRepository OpenRepository(int profileId) {
            return new ContractRepository(profileId);
        }


        public new void FindAll() {
            Sql.Append("select * from fv_user.vwObtenerContratos  where perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdPerfil",profileId,DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }


        public new void FindById(string id) {
            Sql.Append(
                "select * from fv_user.vwObtenerContratos where id_contrato=:pId and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            querySelect.AddParameter("pIdPerfil",profileId,DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }


        public void FindValidContracts() {
            Sql.Append("select * from fv_user.vwObtenerContratos where esta_vigente=1 and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdPerfil",profileId,DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }


        public void FindInvalidContracts() {
            Sql.Append("select * from fv_user.vwObtenerContratos where esta_vigente=0 and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdPerfil",profileId,DbType.Int32);
            DataTable = querySelect.ExecuteQuery();
        }


        public void NewContract(Contract contract) {
            IQueryAction query = DefineQueryAction("spAgregarContratos ");
            query = DefineQueryParameters(contract,query);
            query.AddParameter("pPerfil",profileId,DbType.Int32);
            query.ExecuteQuery();
            StoreContractDetails(contract.Details,contract.ContractId);
        }


        private IQueryAction DefineQueryParameters(Contract contract,IQueryAction query) {
            query.AddParameter("pIdContrato",contract.ContractId,DbType.String);
            query.AddParameter("pIdTipo",contract.TypeContract.ContractTypeId,DbType.Int32);
            query.AddParameter("pInicio",contract.StartDate,DbType.Date);
            query.AddParameter("pTermino",contract.EndDate,DbType.Date);
            query.AddParameter("pDescripcion",contract.ContractDescription,DbType.String);
            query.AddParameter("pComision",contract.ContractCommission,DbType.Decimal);
            return query;
        }


        public void EditContract(Contract contract) {
            IQueryAction query = DefineQueryAction("spActualizarContratos ");
            query = DefineQueryParameters(contract,query);
            query.AddParameter("pVigente",contract.IsValid,DbType.Int32);
            query.ExecuteQuery();
            StoreContractDetails(contract.Details,contract.ContractId);
        }


        private void StoreContractDetails(IEnumerable<ContractDetail> details,string contractId) {
            foreach(ContractDetail detail in details) {
                IQueryAction queryDetail = DefineQueryAction("spAgregarDetalleContrato ");
                queryDetail.AddParameter("pIdContrato",contractId,DbType.String);
                queryDetail.AddParameter("pIdCliente",detail.Customer.Id,DbType.String);
                queryDetail.AddParameter("pObsContrato",detail.ContractObservation,DbType.String);
                queryDetail.AddParameter("pAdicional",detail.AdditionalValue,DbType.Decimal);
                queryDetail.AddParameter("pMulta",detail.FineValue,DbType.Decimal);
                queryDetail.ExecuteQuery();
                PublishContractsToQueue(contractId,detail.Customer.Id );
            }
        }


        private void PublishContractsToQueue(string contractId, string clientId){
            ContractDto con= FindContractToPublishById(contractId, clientId);
            IPublishEvent publisher = ContractEvent.CreateEvent(con);
            publisher.PublishEvent();
        }


        public void DeleteContract(string contractId) {
            IQueryAction query = DefineQueryAction("spEliminarContratos ");
            query.AddParameter("pIdContrato",contractId,DbType.String);
            query.ExecuteQuery();
        }


        public Contract FindOneContractById(string id) {
            Sql.Clear();
            Sql.Append(
                "select * from fv_user.vwObtenerContratos where id_contrato=:pId and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            querySelect.AddParameter("pIdPerfil",profileId,DbType.Int32);
            return GetContractData(querySelect.ExecuteQuery());
        }


        private Contract GetContractData(DataTable contractInfo) {
            DataRow row = contractInfo.Rows[0];
            Contract contract = Contract.CreateContract();
            contract.ContractId = row["id_contrato"].ToString();
            contract.ContractDescription = row["Descripcion"].ToString();
            contract.TypeContract.ContractTypeId = int.Parse(row["id_tipo_contrato"].ToString());
            contract.TypeContract.ContractTypeName = row["Tipo"].ToString();
            contract.StartDate = DateTime.Parse(row["Inicio"].ToString());
            contract.EndDate = DateTime.Parse(row["Termino"].ToString());
            contract.IsValid = int.Parse(row["esta_vigente"].ToString());
            contract.ContractCommission = float.Parse(row["Comision"].ToString());
            contract.Details = new List<ContractDetail>();
            contract.Details = FindDetails(contract.ContractId);
            return contract;
        }


        private IList<ContractDetail> FindDetails(string contractId) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwAsociadosContrato where id_contrato=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId",contractId,DbType.String);
            return GetDetailsData(querySelect.ExecuteQuery());
        }


        private IList<ContractDetail> GetDetailsData(DataTable data) {
            IList<ContractDetail> detailList = new List<ContractDetail>();
            if(data.Rows.Count.Equals(0)) {
                return detailList;
            }

            foreach(DataRow row in data.Rows) {
                detailList.Add(ExtractDetailInfoFromDataRow(row));
            }

            return detailList;
        }


        private ContractDetail ExtractDetailInfoFromDataRow(DataRow row) {
            ContractDetail detail = ContractDetail.CreateDetail();
            detail.Customer.Id = row["id_cliente"].ToString();
            detail.Customer.FirstName = row["Cliente"].ToString();
            detail.Customer.Dni = row["Rut"].ToString();
            detail.Customer.Credentials.Email = row["email"].ToString();
            detail.ContractObservation = row["Observacion contrato"].ToString();
            detail.ClientObservation = row["Observacion cliente"].ToString();
            detail.AdditionalValue = float.Parse(row["Valor adicional"].ToString());
            detail.FineValue = float.Parse(row["Valor multa"].ToString());
            detail.Status = int.Parse(row["estado_aceptacion"].ToString());
            detail.StatusDescription = row["Estado"].ToString();
            ComercialDataRepository r = ComercialDataRepository.OpenRepository();
            detail.Customer.ComercialInfo = r.FindById(detail.Customer.Id);
            return detail;
        }


        public void AcceptContract(Contract contract) {
            ContractDetail detail = contract.Details[0];
            IQueryAction query = DefineQueryAction("spAceptarRechazarContrato  ");
            query.AddParameter("pIdContrato",contract.ContractId,DbType.String);
            query.AddParameter("pIdCliente",detail.Customer.Id,DbType.String);
            query.AddParameter("pEstado",1,DbType.Int32);
            query.AddParameter("pObservacion",detail.ClientObservation,DbType.String);
            query.ExecuteQuery();
            //MailContractSender sender = MailContractSender.CreateSender(contract,contractFilePath, MailTypeMessage.ContractAccepted);
            //sender.SendMail();
        }


        public void RefuseContract(string contractId,string clientId,string observation) {
            IQueryAction query = DefineQueryAction("spAceptarRechazarContrato  ");
            query.AddParameter("pIdContrato",contractId,DbType.String);
            query.AddParameter("pIdCliente",clientId,DbType.String);
            query.AddParameter("pEstado",2,DbType.Int32);
            query.AddParameter("pObservacion",observation,DbType.String);
            query.ExecuteQuery();
        }


        public Contract FindOneContractAceptedById(string contractId) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwObtenerContratos where id_contrato=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pId",contractId,DbType.String);
            return GetContractData(querySelect.ExecuteQuery());
        }


        public IList<ContractDto> FindContractByCustomerId(string clientId) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwContratoPorAsociado where id_cliente=:pIdCliente ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdCliente",clientId,DbType.String);
            return GetAssociateContractData(querySelect.ExecuteQuery());
        }


        private IList<ContractDto> GetAssociateContractData(DataTable data) {
            if(data.Rows.Count.Equals(0)) {
                return null;
            }

            return (from DataRow row in data.Rows
                    select new ContractDto {
                        ContractId = row["id_contrato"].ToString(),
                        ClientId = row["id_cliente"].ToString(),
                        Customername = row["Cliente"].ToString(),
                        CustomerDni = row["Rut"].ToString(),
                        CustomerEmail = row["email"].ToString(),
                        ContractObservation = row["Observacion contrato"].ToString(),
                        CustomerObservation = row["Observacion cliente"].ToString(),
                        StartDate = DateTime.Parse(row["Inicio"].ToString()).ToString("yyyy-MM-dd"),
                        EndDate = DateTime.Parse(row["Termino"].ToString()).ToString("yyyy-MM-dd"),
                        IsValid = row["esta_vigente"].ToString(),
                        ValidDescription = row["Vigente"].ToString(),
                        ContractDescription = row["Descripcion"].ToString(),
                        CommisionValue = float.Parse(row["Comision"].ToString()),
                        AdditionalValue = float.Parse(row["Valor adicional"].ToString()),
                        FineValue = float.Parse(row["Valor multa"].ToString()),
                        Status = row["estado_aceptacion"].ToString(),
                        StatusDescription = row["Estado"].ToString()
                    }).ToList();
        }

        public ContractDto FindContractToPublishById(string contractId, string clientId) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwContratoPorAsociado where id_contrato=:pIdContrato and id_cliente=:pIdCliente ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdContrato",contractId,DbType.String);
            querySelect.AddParameter("pIdCliente", clientId, DbType.String);
            return GetContractDataFromDto(querySelect.ExecuteQuery());
        }


        private ContractDto GetContractDataFromDto(DataTable data){
            if(data.Rows.Count.Equals(0)) return null;
            DataRow row = data.Rows[0];
            ContractDto con = new ContractDto{
                ContractId = row["id_contrato"].ToString(),
                ClientId = row["id_cliente"].ToString(),
                Customername = row["Cliente"].ToString(),
                CustomerDni = row["Rut"].ToString(),
                CustomerEmail = row["email"].ToString(),
                ContractObservation = row["Observacion contrato"].ToString(),
                CustomerObservation = row["Observacion cliente"].ToString(),
                StartDate = DateTime.Parse(row["Inicio"].ToString()).ToString("yyyy-MM-dd"),
                EndDate = DateTime.Parse(row["Termino"].ToString()).ToString("yyyy-MM-dd"),
                IsValid = row["esta_vigente"].ToString(),
                ValidDescription = row["Vigente"].ToString(),
                ContractDescription = row["Descripcion"].ToString(),
                CommisionValue = float.Parse(row["Comision"].ToString()),
                AdditionalValue = float.Parse(row["Valor adicional"].ToString()),
                FineValue = float.Parse(row["Valor multa"].ToString()),
                Status = row["estado_aceptacion"].ToString(),
                StatusDescription = row["Estado"].ToString()
            };
            return con;
        }




    }

}