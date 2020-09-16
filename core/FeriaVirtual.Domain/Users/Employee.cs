using System;

namespace FeriaVirtual.Domain.Users {
    public class Employee {

        // properties.
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserProfile Profile { get; set; }
        public Credential Credentials { get; set; }


        // Constructors
        private Employee() {
            InitializeObjects( Guid.NewGuid().ToString(),string.Empty,string.Empty );
        }

        private Employee(string employeeId,string firstName,string lastName) {
            InitializeObjects( employeeId,firstName,lastName );
        }

        private void InitializeObjects(string employeeId,string firstName,string lastName) {
            EmployeeID = employeeId;
            FirstName= firstName;
            LastName= lastName;
            Profile= UserProfile.CreateProfile();
            Credentials = Credential.CreateCredential();
        }


        // Named constructors.
        public static Employee CreateEmployee() {
            return new Employee();
        }

        public static Employee CreateEmployee(string employeeId,string firstName,string lastName) {
            return new Employee( employeeId,firstName,lastName );
        }

        public override string ToString() {
            return FirstName + ' ' + LastName;
        }

    }
}
