using System.Data;
using System.Collections.Generic;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.Data.Notifiers;
using System;
using FeriaVirtual.Infraestructure.Database;

namespace FeriaVirtual.Data.Stats {
    public class ReportRepository:Data.Repository.Repository{

        private EmailReportNotifier notifier;


        private ReportRepository(){
            notifier = EmailReportNotifier.CreateNotifier();
        }


        public static ReportRepository OpenRepository() {
            return new ReportRepository();
        }

         



        public DataTable SalesByYear(int rolId, int year) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable  ResumeSalesByYear(int rolId, int year) {
            Sql.Clear();
            Sql.Append("select to_char(fecha_orden, 'dd-MM-yyyy') as fecha_compra, sum(monto_pagado) as monto ");
            Sql.Append("from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("group by to_char(fecha_orden, 'dd-MM-yyyy') ");
            Sql.Append("having sum(monto_pagado)>0 ");
            Sql.Append("order by to_char(fecha_orden, 'dd-MM-yyyy')");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable LossesByYear(int rolId, int year) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwMermas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable ResumeLossesByYear(int rolId, int year) {
            Sql.Clear();
            Sql.Append("select  id_rol, ");
            Sql.Append("fecha_orden as fecha_orden, ");
            Sql.Append("productor as productor,");
            Sql.Append("sum(precio_productos) as total_mermas ");
            Sql.Append("from fv_user.vwmermas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("group by id_rol, fecha_orden, productor ");
            Sql.Append("having sum(precio_productos)>0 ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable SalesByMonthAndYear(int rolId, int month, int year) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'MM')=:pMonth and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pMonth", month, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable  ResumeSalesByMonthAndYear(int rolId, int month, int year) {
            Sql.Clear();
            Sql.Append("select to_char(fecha_orden, 'dd-MM-yyyy') as fecha_compra, sum(monto_pagado) as monto ");
            Sql.Append("from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'MM')=:pMonth and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("group by to_char(fecha_orden, 'dd-MM-yyyy') ");
            Sql.Append("having sum(monto_pagado)>0 ");
            Sql.Append("order by to_char(fecha_orden, 'dd-MM-yyyy')");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pMonth", month, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable LossesByMonthAndYear(int rolId, int month, int year) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwMermas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'MM')=:pMonth and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pMonth", month, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable ResumeLossesByMonthAndYear(int rolId, int month, int year) {
            Sql.Clear();
            Sql.Append("select  id_rol, ");
            Sql.Append("fecha_orden as fecha_orden, ");
            Sql.Append("productor as productor,");
            Sql.Append("sum(precio_productos) as total_mermas ");
            Sql.Append("from fv_user.vwmermas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'MM')=:pMonth and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("group by id_rol, fecha_orden, productor ");
            Sql.Append("having sum(precio_productos)>0 ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pMonth", month, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable SalesBySemesterAndYear(int rolId, int semester, int year) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and trunc(((to_number(to_char(fecha_orden, 'MM'))-1)/6))=:pSemester and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pSemester", semester, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable  ResumeSalesBySemesterAndYear(int rolId, int semester, int year) {
            Sql.Clear();
            Sql.Append("select to_char(fecha_orden, 'dd-MM-yyyy') as fecha_compra, sum(monto_pagado) as monto ");
            Sql.Append("from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and trunc(((to_number(to_char(fecha_orden, 'MM'))-1)/6))=:pSemester and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("group by to_char(fecha_orden, 'dd-MM-yyyy') ");
            Sql.Append("having sum(monto_pagado)>0 ");
            Sql.Append("order by to_char(fecha_orden, 'dd-MM-yyyy')");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pSemester", semester, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable LossesBySemesterAndYear(int rolId, int semester, int year) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwMermas ");
            Sql.Append("where id_rol=:pIdRol and trunc(((to_number(to_char(fecha_orden, 'MM'))-1)/6))=:pSemester and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pSemester", semester, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable ResumeLossesBySemesterAndYear(int rolId, int semester, int year) {
            Sql.Clear();
            Sql.Append("select  id_rol, ");
            Sql.Append("fecha_orden as fecha_orden, ");
            Sql.Append("productor as productor,");
            Sql.Append("sum(precio_productos) as total_mermas ");
            Sql.Append("from fv_user.vwmermas ");
            Sql.Append("where id_rol=:pIdRol and trunc(((to_number(to_char(fecha_orden, 'MM'))-1)/6))=:pSemester and to_char(fecha_orden, 'yyyy')=:pYear ");
            Sql.Append("group by id_rol, fecha_orden, productor ");
            Sql.Append("having sum(precio_productos)>0 ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pSemester", semester, DbType.Int32);
            querySelect.AddParameter("pYear", year, DbType.Int32);
            return querySelect.ExecuteQuery();
        }

        public DataTable SalesByDate(int rolId, DateTime date) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'dd-MM-yyyy')=:pFecha ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFecha", date, DbType.Date);
            return querySelect.ExecuteQuery();
        }

        public DataTable  ResumeSalesByDate(int rolId, DateTime date) {
            Sql.Clear();
            Sql.Append("select to_char(fecha_orden, 'dd-MM-yyyy') as fecha_compra, sum(monto_pagado) as monto ");
            Sql.Append("from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'dd-MM-yyyy')=:pFecha ");
            Sql.Append("group by to_char(fecha_orden, 'dd-MM-yyyy') ");
            Sql.Append("having sum(monto_pagado)>0 ");
            Sql.Append("order by to_char(fecha_orden, 'dd-MM-yyyy')");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFecha", date, DbType.Date);
            return querySelect.ExecuteQuery();
        }

        public DataTable LossesByDate(int rolId, DateTime date) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwMermas ");
            Sql.Append("where id_rol=:pIdRol and fecha_orden=:pFecha ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFecha", date, DbType.Date);
            return querySelect.ExecuteQuery();
        }

        public DataTable ResumeLossesByDate(int rolId, DateTime date) {
            Sql.Clear();
            Sql.Append("select  id_rol, ");
            Sql.Append("fecha_orden as fecha_orden, ");
            Sql.Append("productor as productor,");
            Sql.Append("sum(precio_productos) as total_mermas ");
            Sql.Append("from fv_user.vwmermas ");
            Sql.Append("where id_rol=:pIdRol and fecha_orden=:pFecha ");
            Sql.Append("group by id_rol, fecha_orden, productor ");
            Sql.Append("having sum(precio_productos)>0 ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFecha", date, DbType.Date);
            return querySelect.ExecuteQuery();
        }

        public DataTable SalesByRange(int rolId, DateTime dateFrom, DateTime dateTo) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'dd-MM-yyyy') between :pFechaDesde and :pFechaHasta ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFechaDesde", dateFrom, DbType.Date);
            querySelect.AddParameter("pFechaHasta", dateTo, DbType.Date);
            return querySelect.ExecuteQuery();
        }

        public DataTable  ResumeSalesByRange(int rolId, DateTime dateFrom, DateTime dateTo) {
            Sql.Clear();
            Sql.Append("select to_char(fecha_orden, 'dd-MM-yyyy') as fecha_compra, sum(monto_pagado) as monto ");
            Sql.Append("from fv_user.vwVentas ");
            Sql.Append("where id_rol=:pIdRol and to_char(fecha_orden, 'dd-MM-yyyy') between :pFechaDesde and :pFechaHasta ");
            Sql.Append("group by to_char(fecha_orden, 'dd-MM-yyyy') ");
            Sql.Append("having sum(monto_pagado)>0 ");
            Sql.Append("order by to_char(fecha_orden, 'dd-MM-yyyy')");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFechaDesde", dateFrom, DbType.Date);
            querySelect.AddParameter("pFechaHasta", dateTo, DbType.Date);
            return querySelect.ExecuteQuery();
        }

        public DataTable LossesByRange(int rolId, DateTime dateFrom, DateTime dateTo) {
            Sql.Clear();
            Sql.Append("select * from fv_user.vwMermas ");
            Sql.Append("where id_rol=:pIdRol and fecha_orden between :pFechaDesde and :pFechaHasta ");
            Sql.Append("order by fecha_orden ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFechaDesde", dateFrom, DbType.Date);
            querySelect.AddParameter("pFechaHasta", dateTo, DbType.Date);
            return querySelect.ExecuteQuery();
        }

        public DataTable ResumeLossesByRange(int rolId, DateTime dateFrom, DateTime dateTo) {
            Sql.Clear();
            Sql.Append("select  id_rol, ");
            Sql.Append("fecha_orden as fecha_orden, ");
            Sql.Append("productor as productor,");
            Sql.Append("sum(precio_productos) as total_mermas ");
            Sql.Append("from fv_user.vwmermas ");
            Sql.Append("where id_rol=:pIdRol and fecha_orden between :pFechaDesde and :pFechaHasta ");
            Sql.Append("group by id_rol, fecha_orden, productor ");
            Sql.Append("having sum(precio_productos)>0 ");
            IQuerySelect querySelect = DefineQuerySelect(Sql.ToString());
            querySelect.AddParameter("pIdRol", rolId, DbType.Int32);
            querySelect.AddParameter("pFechaDesde", dateFrom, DbType.Date);
            querySelect.AddParameter("pFechahasta", dateTo, DbType.Date);
            return querySelect.ExecuteQuery();
        }


        public void NotifyReportByEmail(IList<ReportRecipientsDto> recipients){
            foreach (ReportRecipientsDto recipient in recipients){
                this.notifier.Notify(recipient);
            }
        }


    }
}