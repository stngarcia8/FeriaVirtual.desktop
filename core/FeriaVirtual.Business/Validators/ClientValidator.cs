﻿using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;
using FeriaVirtual.Business.Exceptions;
using FeriaVirtual.Business.Users;
using FeriaVirtual.Domain.Users;

namespace FeriaVirtual.Business.Validators {

    public class ClientValidator:Validator {

        private Client client;
        private readonly bool editMode;
        private readonly bool changedPassword;
        private readonly int usernameLength = 6;
        private readonly int passwordLength = 8;
        private readonly int profileID;
        private readonly string singleProfileName;

        // Constructor
        private ClientValidator(Client client,bool editMode,bool changedPassword,int profileID,string singleProfileName) : base() {
            this.client= client;
            this.editMode= editMode;
            this.changedPassword= changedPassword;
            this.profileID= profileID;
            this.singleProfileName= singleProfileName;
            processName= (!editMode ? string.Format( "registrar {0}",singleProfileName ) : string.Format( "editar {0}",singleProfileName ));
        }

        // Named constructor.
        public static ClientValidator CreateValidator(Client client,bool editMode,bool changedPassword,int profileID,string singleProfileName) {
            return new ClientValidator( client,editMode,changedPassword,profileID,singleProfileName );
        }


        // Validate client method.
        public void Validate() {
            ValidateUsername();
            ValidatePassword();
            ValidateEmail();
            ValidateProfile();
            ValidateFirstName();
            ValidateLastName();
            if(ErrorMessages.Count>0) {
                throw new InvalidClientException( GenerateErrorMessage() );
            }
        }


        private void ValidateUsername() {
            if(string.IsNullOrEmpty( client.Credentials.Username )) {
                ErrorMessages.Add( string.Format( "El campo nombre de {0} no puede quedar vacío.",singleProfileName ) );
                return;
            }
            if(client.Credentials.Username.Length < usernameLength) {
                ErrorMessages.Add( string.Format( "El largo del nombre de {0} no puede ser inferior a {1} caracteres",singleProfileName,usernameLength ) );
                return;
            }
            if(editMode) {
                return;
            }
            ClientUseCase useCase = ClientUseCase.CreateUseCase( profileID,singleProfileName );
            DataTable dataTable = useCase.FindClientById( client.Credentials.Username );
            if(dataTable.Rows.Count > 0) {
                ErrorMessages.Add( "El username ingresado no esta disponible." );
            }
        }


        private void ValidatePassword() {
            if(!changedPassword) {
                return;
            }
            if(string.IsNullOrEmpty( client.Credentials.Password )) {
                ErrorMessages.Add( "El campo password no puede quedar vacío." );
                return;
            }
            if(client.Credentials.Password.Length < passwordLength) {
                ErrorMessages.Add( string.Format( "El largo del password no puede ser inferior a {0} caracteres",passwordLength ) );
            }
            Regex expresion = new Regex( "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,128}$" );
            if(!expresion.IsMatch( client.Credentials.Password )) {
                ErrorMessages.Add( "La password debe contener caracteres en mayusculas, simbolos, números y caracteres en minusculas, por ejemplo @PassWord.1234#" );
            }
        }


        private void ValidateEmail() {
            if(string.IsNullOrEmpty( client.Credentials.Email )) {
                ErrorMessages.Add( "El campo email no puede quedar vacío." );
                return;
            }
            try {
                MailAddress mail = new MailAddress( client.Credentials.Email );
            } catch {
                ErrorMessages.Add( "El email ingresado no es una dirección de correo válida." );
            }
        }


        private void ValidateProfile() {
            if(client.Profile.ProfileID.Equals( 0 )) {
                ErrorMessages.Add( "Debe seleccionar el tipo de rol para el cliente." );
            }
        }


        private void ValidateFirstName() {
            if(string.IsNullOrEmpty( client.FirstName )) {
                ErrorMessages.Add( string.Format( "Debe ingresar el nombre real del {0}.",singleProfileName ) );
            }
        }


        private void ValidateLastName() {
            if(string.IsNullOrEmpty( client.LastName )) {
                ErrorMessages.Add( string.Format( "Debe ingresar el apellido del {0}.",singleProfileName ) );
            }
        }

    }
}
