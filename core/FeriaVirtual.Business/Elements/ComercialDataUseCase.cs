using System;
using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.DTO;
using FeriaVirtual.Domain.Elements;

namespace FeriaVirtual.Business.Elements {

    public class ComercialDataUseCase {

        private ComercialDataRepository repository;

        // Constructor.
        private ComercialDataUseCase() {
            repository= ComercialDataRepository.OpenRepository();
        }


        // Named constructor.
        public static ComercialDataUseCase CreateUseCase() {
            return new ComercialDataUseCase();
        }


        public void NewCommercialData(ComercialData data,string clientID) {
            try {
                IValidator validator = ComercialDataValidator.CreateValidator( data,false );
                validator.Validate();
                repository.NewComercialData( data,clientID );
            } catch(Exception ex) {
                throw ex;
            }
        }


        public void EditCommercialData(ComercialData data,string clientID) {
            try {
                IValidator validator = ComercialDataValidator.CreateValidator( data,true );
                validator.Validate();
                repository.EditComercialData( data,clientID );
            } catch(Exception ex) {
                throw ex;
            }
        }


        public ComercialData FindComercialDataByID(string id) {
            repository.FindById( id );
            return ConvertToComercialData( repository.DataSource );
        }


        private ComercialData ConvertToComercialData(DataTable table) {
            ComercialData data = ComercialData.CreateComercialData();
            if(table.Rows.Count.Equals( 0 )) {
                return data;
            }
            DataRow row = table.Rows[0];
            data.ComercialID= row["id_comercial"].ToString();
            data.ClientID = row["id_cliente"].ToString();
            data.CompanyName= row["Razon social"].ToString();
            data.FantasyName= row["Nombre de fantasia"].ToString();
            data.ComercialBusiness= row["Giro comercial"].ToString();
            data.Email= row["Email"].ToString();
            data.ComercialDNI= row["DNI"].ToString();
            data.Address= row["Direccion"].ToString();
            data.City = row["Ciudad"].ToString();
            data.Country= row["Pais"].ToString();
            data.PhoneNumber= row["Telefono"].ToString();
            return data;
        }


        public void DeleteCommercialData(string comercialID) {
            try {
                repository.DeleteComercialData( comercialID );
            } catch(Exception ex) {
                throw ex;
            }
        }

    }
}
