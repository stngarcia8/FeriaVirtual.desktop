using System.Data;


namespace FeriaVirtual.Infraestructure.Database{

    public interface IQuerySelect{

        void AddParameter(string parameterName, object parameterValue, DbType parameterValueType);


        void CleanParameters();


        DataTable ExecuteQuery();

    }

}