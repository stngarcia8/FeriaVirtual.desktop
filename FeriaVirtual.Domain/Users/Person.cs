using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Domain.Users {
    public abstract  class Person {

        // properties.
        public string ID { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Dni { get; set; }
        public UserProfile Profile { get; set; }
        public Credential Credentials { get; set; }


        // Constructors
        protected Person() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,string.Empty, string.Empty );
        }

        protected Person(string id,string name,string firstSurname, string dni) {
            InitializeObjects( id, name, firstSurname, dni);
        }

        private void InitializeObjects(string id,string name,string firstSurname, string dni) {
            this.ID= id;
            this.Name= name;
            this.FirstSurname= firstSurname;
            this.Dni= dni;
            Profile= UserProfile.CreateProfile();
            Credentials = Credential.CreateCredential();
        }


        public override string ToString() {
            return Name+ ' ' + FirstSurname; 
        }


    }
}
