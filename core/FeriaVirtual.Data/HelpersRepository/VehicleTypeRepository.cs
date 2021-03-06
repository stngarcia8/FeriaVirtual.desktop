﻿namespace FeriaVirtual.Data.HelpersRepository{

    public class VehicleTypeRepository : HelperRepository{

        // Constructor
        private VehicleTypeRepository(){ }


        // Named constructor
        public static VehicleTypeRepository OpenRepository(){
            return new VehicleTypeRepository();
        }


        // Find all vehicles type in the database.
        public new void FindAll(){
            Sql.Append("select * from fv_user.tipo_transporte order by id_tipo_transporte  ");
            base.FindAll();
        }

    }

}