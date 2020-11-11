using System.Data;
using FeriaVirtual.Business.Validators;
using FeriaVirtual.Data.Repository;
using FeriaVirtual.Domain.CommercialsData;


namespace FeriaVirtual.Business.Elements{

    public class ComercialDataUseCase{

        private readonly ComercialDataRepository repository;


        // Constructor.
        private ComercialDataUseCase(){
            repository = ComercialDataRepository.OpenRepository();
        }


        // Named constructor.
        public static ComercialDataUseCase CreateUseCase(){
            return new ComercialDataUseCase();
        }


        public void NewCommercialData(ComercialData data, string clientId){
            IValidator validator = ComercialDataValidator.CreateValidator(data, false);
            validator.Validate();
            repository.NewComercialData(data, clientId);
        }


        public void EditCommercialData(ComercialData data, string clientId){
            IValidator validator = ComercialDataValidator.CreateValidator(data, true);
            validator.Validate();
            repository.EditComercialData(data, clientId);
        }


        public ComercialData FindComercialDataById(string id){
            repository.FindById(id);
            return ConvertToComercialData(repository.DataSource);
        }


        private ComercialData ConvertToComercialData(DataTable table){
            if (table.Rows.Count.Equals(0)) return null;
            var data = ComercialData.CreateComercialData();
            var row = table.Rows[0];
            data.CommercialId = row["id_comercial"].ToString();
            data.ClientId = row["id_cliente"].ToString();
            data.CompanyName = row["Razon social"].ToString();
            data.FantasyName = row["Nombre de fantasia"].ToString();
            data.ComercialBusiness = row["Giro comercial"].ToString();
            data.Email = row["Email"].ToString();
            data.ComercialDni = row["DNI"].ToString();
            data.Address = row["Direccion"].ToString();
            data.City.CityId = int.Parse(row["id_ciudad"].ToString());
            data.City.CityName = row["Ciudad"].ToString();
            data.Country.CountryId = int.Parse(row["id_pais"].ToString());
            data.Country.CountryName = row["Pais"].ToString();
            data.Country.CountryPrefix = row["Prefijo"].ToString();
            data.PhoneNumber = row["Telefono"].ToString();
            return data;
        }


        public void DeleteCommercialData(string comercialId){
            repository.DeleteComercialData(comercialId);
        }

    }

}