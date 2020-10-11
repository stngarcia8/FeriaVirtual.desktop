﻿using System;
using System.Collections.Generic;
using System.Data;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class ContractRepository:Repository {
        private readonly int profileID;

        // Constructor
        private ContractRepository(int profileId) : base() {
            profileID= profileId;
        }

        // Named constructor.
        public static ContractRepository OpenRepository(int profileId) {
            return new ContractRepository(profileId);
        }

        public new void FindAll() {
            sql.Append("select * from fv_user.vwObtenerContratos  where perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdPerfil",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
        }

        public new void FindById(string id) {
            sql.Append("select * from fv_user.vwObtenerContratos where id_contrato=:pId and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            querySelect.AddParameter("pIdPerfil",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
        }

        public void FindValidContracts() {
            sql.Append("select * from fv_user.vwObtenerContratos where esta_vigente=1 and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdPerfil",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
        }

        public void FindInvalidContracts() {
            sql.Append("select * from fv_user.vwObtenerContratos where esta_vigente=0 and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pIdPerfil",profileID,DbType.Int32);
            dataTable = querySelect.ExecuteQuery();
        }

        public void NewContract(Contract contract) {
            IQueryAction query = DefineQueryAction("spAgregarContratos ");
            query = DefineQueryParameters(contract,query);
            query.AddParameter("pPerfil",profileID,DbType.Int32);
            query.ExecuteQuery();
            StoreContractDetails(contract.Details,contract.ContractID);
        }

        private IQueryAction DefineQueryParameters(Contract contract,IQueryAction query) {
            query.AddParameter("pIdContrato",contract.ContractID,DbType.String);
            query.AddParameter("pIdTipo",contract.TypeContract.ContractTypeID,DbType.Int32);
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
            StoreContractDetails(contract.Details,contract.ContractID);
        }

        private void StoreContractDetails(IList<ContractDetail> details,string contractID) {
            foreach(ContractDetail detail in details) {
                IQueryAction queryDetail = DefineQueryAction("spAgregarDetalleContrato ");
                queryDetail.AddParameter("pIdContrato",contractID,DbType.String);
                queryDetail.AddParameter("pIdCliente",detail.Customer.ID,DbType.String);
                queryDetail.AddParameter("pObsContrato",detail.ContractObservation,DbType.String);
                queryDetail.AddParameter("pAdicional",detail.AdditionalValue,DbType.Decimal);
                queryDetail.AddParameter("pMulta",detail.FineValue,DbType.Decimal);
                queryDetail.ExecuteQuery();
            }
        }

        public void DeleteContract(string contractID) {
            IQueryAction query = DefineQueryAction("spEliminarContratos ");
            query.AddParameter("pIdContrato",contractID,DbType.String);
            query.ExecuteQuery();
        }

        public Contract FindOneContractById(string id) {
            sql.Clear();
            sql.Append("select * from fv_user.vwObtenerContratos where id_contrato=:pId and perfil_contrato=:pIdPerfil ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",id,DbType.String);
            querySelect.AddParameter("pIdPerfil",profileID,DbType.Int32);
            return GetContractData(querySelect.ExecuteQuery());
        }

        private Contract GetContractData(DataTable contractInfo) {
            DataRow row = contractInfo.Rows[0];
            Contract contract = Contract.CreateContract();
            contract.ContractID = row["id_contrato"].ToString();
            contract.ContractDescription= row["Descripcion"].ToString();
            contract.TypeContract.ContractTypeID = int.Parse(row["id_tipo_contrato"].ToString());
            contract.TypeContract.ContractTypeName= row["Tipo"].ToString();
            contract.StartDate = DateTime.Parse(row["Inicio"].ToString());
            contract.EndDate = DateTime.Parse(row["Termino"].ToString());
            contract.IsValid = int.Parse(row["esta_vigente"].ToString());
            contract.ContractCommission = float.Parse(row["Comision"].ToString());
            contract.Details = new List<ContractDetail>();
            contract.Details = FindDetails(contract.ContractID);
            return contract;
        }

        private IList<ContractDetail> FindDetails(string contractID) {
            sql.Clear();
            sql.Append("select * from fv_user.vwAsociadosContrato where id_contrato=:pId ");
            IQuerySelect querySelect = DefineQuerySelect(sql.ToString());
            querySelect.AddParameter("pId",contractID,DbType.String);
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
            detail.Customer.ID = row["id_cliente"].ToString();
            detail.Customer.FirstName= row["Cliente"].ToString();
            detail.ContractObservation= row["Observacion contrato"].ToString();
            detail.ClientObservation= row["Observacion cliente"].ToString();
            detail.AdditionalValue=float.Parse(row["Valor adicional"].ToString());
            detail.FineValue = float.Parse(row["Valor multa"].ToString());
            return detail;
        }
    }
}