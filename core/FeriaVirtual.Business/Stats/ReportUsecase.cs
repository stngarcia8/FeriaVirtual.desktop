using System.Data;
using System;
using FeriaVirtual.Data.Stats;


namespace FeriaVirtual.Business.Stats{

    public class ReportUsecase{

        private readonly ReportRepository repository;

        public DataSet SourceDataSet{get;set;}


        private ReportUsecase(){
            repository = ReportRepository.OpenRepository();
            SourceDataSet = new DataSet("Reports");
        }


        public static ReportUsecase CreateUsecase(){
            return new ReportUsecase();
        }


        public void GetReportByYear(int rolId, int year){
            SourceDataSet.Tables.Add( repository.ResumeSalesByYear(rolId, year));
            SourceDataSet.Tables.Add(repository.SalesByYear(rolId, year));
            SourceDataSet.Tables.Add( repository.ResumeLossesByYear(rolId, year));
            SourceDataSet.Tables.Add( repository.LossesByYear(rolId, year));
            RenameTables();
        }


        private void RenameTables(){
            if (SourceDataSet == null) return;
            SourceDataSet.Tables[0].TableName = "ResumeSales";
            SourceDataSet.Tables[1].TableName = "Sales";
            SourceDataSet.Tables[2].TableName = "ResumeLosses";
            SourceDataSet.Tables[3].TableName = "Losses";
        }

        public void GetReportByMonthAndYear(int rolId, int month, int year){
            SourceDataSet.Tables.Add( repository.ResumeSalesByMonthAndYear(rolId, month, year));
            SourceDataSet.Tables.Add(repository.SalesByMonthAndYear(rolId, month, year));
            SourceDataSet.Tables.Add( repository.ResumeLossesByMonthAndYear(rolId, month, year));
            SourceDataSet.Tables.Add( repository.LossesByMonthAndYear(rolId, month, year));
            RenameTables();
        }

        public void GetReportBySemesterAndYear(int rolId, int semester, int year){
            SourceDataSet.Tables.Add( repository.ResumeSalesBySemesterAndYear(rolId, semester, year));
            SourceDataSet.Tables.Add(repository.SalesBySemesterAndYear(rolId, semester, year));
            SourceDataSet.Tables.Add( repository.ResumeLossesBySemesterAndYear(rolId, semester, year));
            SourceDataSet.Tables.Add( repository.LossesBySemesterAndYear(rolId, semester, year));
            RenameTables();
        }
            
        public void GetReportByDate(int rolId, DateTime date){
            SourceDataSet.Tables.Add( repository.ResumeSalesByDate(rolId, date));
            SourceDataSet.Tables.Add(repository.SalesByDate(rolId, date));
            SourceDataSet.Tables.Add( repository.ResumeLossesByDate(rolId, date));
            SourceDataSet.Tables.Add( repository.LossesByDate(rolId, date));
            RenameTables();
        }

        public void GetReportByRange(int rolId, DateTime dateFrom, DateTime dateTo){
            SourceDataSet.Tables.Add( repository.ResumeSalesByRange(rolId, dateFrom, dateTo));
            SourceDataSet.Tables.Add(repository.SalesByRange(rolId, dateFrom, dateTo));
            SourceDataSet.Tables.Add( repository.ResumeLossesByRange(rolId, dateFrom, dateTo));
            SourceDataSet.Tables.Add( repository.LossesByRange(rolId, dateFrom, dateTo));
            RenameTables();
        }







    }

}