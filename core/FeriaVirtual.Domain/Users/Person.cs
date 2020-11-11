using System;
using FeriaVirtual.Domain.CommercialsData;


namespace FeriaVirtual.Domain.Users{

    public abstract class Person{

        // properties.
        public string Id{ get; set; }

        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Dni{ get; set; }
        public UserProfile Profile{ get; set; }
        public ComercialData ComercialInfo{ get; set; }


        // Constructors
        protected Person(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, string.Empty, string.Empty);
        }


        protected Person(string id, string firstName, string lastName, string dni){
            InitializeObjects(id, firstName, lastName, dni);
        }


        private void InitializeObjects(string id, string firstName, string lastName, string dni){
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Dni = dni;
            Profile = UserProfile.CreateProfile();
            ComercialInfo = ComercialData.CreateComercialData();
        }


        public override string ToString(){
            return FirstName + " " + LastName;
        }

    }

}