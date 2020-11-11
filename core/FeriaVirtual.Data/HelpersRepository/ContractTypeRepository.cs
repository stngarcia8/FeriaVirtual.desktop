namespace FeriaVirtual.Data.HelpersRepository{

    public class ContractTypeRepository : HelperRepository{

        // Constructor
        private ContractTypeRepository(){ }


        // Named constructor
        public static ContractTypeRepository OpenRepository(){
            return new ContractTypeRepository();
        }


        // Find all contract type in the database.
        public new void FindAll(){
            Sql.Append("select * from fv_user.tipo_contrato order by id_tipo_contrato  ");
            base.FindAll();
        }

    }

}