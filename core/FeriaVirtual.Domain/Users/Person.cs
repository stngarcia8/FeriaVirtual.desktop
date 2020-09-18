﻿using System;

namespace FeriaVirtual.Domain.Users {
    public abstract class Person {

        // properties.
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public UserProfile Profile { get; set; }
        public Credential Credentials { get; set; }
        public ComercialData ComercialInfo { get; set; }


        // Constructors
        protected Person() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,string.Empty,string.Empty );
        }

        protected Person(string id,string firstName,string lastName,string dni) {
            InitializeObjects( id,firstName,lastName,dni );
        }

        private void InitializeObjects(string id,string firstName,string lastName,string dni) {
            ID= id;
            FirstName= firstName;
            LastName= lastName;
            this.DNI = dni;
            Profile= UserProfile.CreateProfile();
            Credentials = Credential.CreateCredential();
            ComercialInfo= ComercialData.CreateComercialData();
        }


        public override string ToString() {
            return FirstName+ " " + LastName;
        }


    }
}
