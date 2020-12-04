using System.Data;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Stats {
    public class StatRepository:Data.Repository.Repository {


        private StatRepository() {
        }


        public static StatRepository OpenRepository() {
            return new StatRepository();
        }


        public void UsersStats() {
            Sql.Clear();
            Sql.Append("select * from fv_user.stats_usuarios ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            this.DataTable= querySelect.ExecuteQuery();
        }

        public void ExternalCustomerOrdersStats() {
            Sql.Clear();
            Sql.Append("select * from fv_user.stats_ordenes_clientesexternos ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            this.DataTable= querySelect.ExecuteQuery();
        }

        public void InternalCustomerOrdersStats() {
            Sql.Clear();
            Sql.Append("select * from fv_user.stats_ordenes_clientesinternos ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            this.DataTable= querySelect.ExecuteQuery();
        }


    }
}
