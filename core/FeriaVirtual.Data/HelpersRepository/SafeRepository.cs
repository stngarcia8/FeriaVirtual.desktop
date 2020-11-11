namespace FeriaVirtual.Data.HelpersRepository{

    public class SafeRepository : HelperRepository{

        // Constructor
        private SafeRepository(){ }


        // Named constructor
        public static SafeRepository OpenRepository(){
            return new SafeRepository();
        }


        // Find all safe type in the database.
        public new void FindAll(){
            Sql.Clear();
            Sql.Append("select * from fv_user.seguro order by id_seguro  ");
            base.FindAll();
        }

    }

}