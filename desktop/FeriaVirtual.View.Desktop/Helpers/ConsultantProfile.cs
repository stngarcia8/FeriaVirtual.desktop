﻿namespace FeriaVirtual.View.Desktop.Helpers {

    public class ConsultantProfile:IProfileInfo {

        //Properties
        public int ProfileID => (int)EnumProfileInfo.Consultant;

        public string ProfileName => "Consultores";
        public string SingleProfileName => "Consultor";

        // constructor
        private ConsultantProfile() { }

        // Named constructor
        public static ConsultantProfile CreateProfile() {
            return new ConsultantProfile();
        }

        // Methods
        public override string ToString() {
            return SingleProfileName;
        }
    }
}
