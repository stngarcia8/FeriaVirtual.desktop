﻿namespace FeriaVirtual.Domain.Orders{

    public class Safe{

        public int SafeId{ get; set; }
        public string SafeName{ get; set; }
        public string SafeCompany{ get; set; }
        public float SafeValue{ get; set; }


        // Constructor
        private Safe(){
            SafeId = 0;
            SafeName = string.Empty;
            SafeCompany = string.Empty;
            SafeValue = 0;
        }


        // named constructor
        public static Safe CreateSafe(){
            return new Safe();
        }


        public override string ToString(){
            return SafeName;
        }

    }

}