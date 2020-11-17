using System;
using System.Security.Cryptography;
using System.Text;


namespace FeriaVirtual.Domain.Users{

    public class Credential{

        public string UserId{ get; set; }

        public string Username{ get; set; }
        public string Password{ get; set; }
        public string EncriptedPassword{ get; set; }
        public string Email{ get; set; }
        public bool IsActive{ get; set; }


        private Credential(){
            InitializeObjects(Guid.NewGuid().ToString(), string.Empty, string.Empty);
        }


        private Credential(string userId, string username, string password){
            InitializeObjects(userId, username, password);
        }


        private void InitializeObjects(string userId, string username, string password){
            UserId = userId;
            Username = username;
            Password = password;
            EncriptedPassword = string.Empty;
            Email = string.Empty;
            IsActive = true;
        }


        public static Credential CreateCredential(){
            return new Credential();
        }


        public static Credential CreateCredential(string userId, string username, string password){
            return new Credential(userId, username, password);
        }


        public string EncryptPassword(){
            if (string.IsNullOrEmpty(Password)){
                EncriptedPassword = string.Empty;
                return string.Empty;
            }

            var sha1 = SHA1.Create();
            var originalPassword = Encoding.Default.GetBytes(Password);
            var hash = sha1.ComputeHash(originalPassword);
            var encriptedString = new StringBuilder();
            foreach (var i in hash) encriptedString.AppendFormat("{0:x2}", i);
            return encriptedString.ToString();
        }


        public override string ToString(){
            return Username;
        }

    }

}