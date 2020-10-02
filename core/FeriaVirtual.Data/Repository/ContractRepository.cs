using System.Data;
using FeriaVirtual.Domain.Contracts;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Repository {

    public class ContractRepository: Repository {

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
        }


        public void DeleteContract(string contractID) {
            IQueryAction query = DefineQueryAction("spEliminarContratos ");
            query.AddParameter("pIdContrato",contractID,DbType.String);
            query.ExecuteQuery();
        }







    }

}
