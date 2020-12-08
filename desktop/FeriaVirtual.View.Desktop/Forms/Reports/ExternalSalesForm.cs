using System;
using System.Data;
using System.Collections.Generic;
using FeriaVirtual.View.Desktop.Helpers;
using FeriaVirtual.Business.Stats;
using System.Windows.Forms;


namespace FeriaVirtual.View.Desktop.Forms.Reports{

    public partial class ExternalSalesForm : Form{

        private readonly int rolId;


        public ExternalSalesForm(int rolId){
            InitializeComponent();
            this.rolId = rolId;
        }

        private void ExternalSalesForm_Load(object sender,System.EventArgs e){
            ConfigureForm();
        }


        private void YearRadioButton_CheckedChanged(object sender,EventArgs e){
            EnableOrDisableControls(0);
        }

        private void MonthRadioButton_CheckedChanged(object sender,EventArgs e) {
            EnableOrDisableControls(1);
        }

        private void SemesterRadioButton_CheckedChanged(object sender,EventArgs e) {
            EnableOrDisableControls(2);
        }

        private void DateRadioButton_CheckedChanged(object sender,EventArgs e) {
            EnableOrDisableControls(3);
        }

        private void RangeRadioButton_CheckedChanged(object sender,EventArgs e) {
            EnableOrDisableControls(4);
        }

        private void OptionExecuteToolStripMenuItem_Click(object sender,EventArgs e){
            this.ExecuteReport();
        }

        private void OptionSendMailToolStripMenuItem_Click(object sender,EventArgs e) {

        }

        private void OptionCleanToolStripMenuItem_Click(object sender,EventArgs e){
            this.ClearResults();
            this.ConfigureForm();
            this.YearComboBox.Focus();
        }

        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e){
            this.Close();
        }




        private void ConfigureForm(){
            this.Text = (rolId == 3 ? "Informe de ventas clientes externos" : "Informe de ");
            this.FilterGroupBox.Width = this.Width;
            this.YearComboBox.SelectedIndex = 0;
            this.YearRadioButton.Checked = true;
            this.MonthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            this.SemesterComboBox.SelectedIndex = (DateTime.Now.Month > 6 ? 1 : 0);
            this.DateDateTimePicker.Value = DateTime.Now.Date;
            this.RangeFromDateTimePicker.Value = DateTime.Now.Date;
            this.RangeToDateTimePicker.Value = DateTime.Now.Date.AddDays(1);
            EnableOrDisableControls(0);
            ClearResults();
            this.YearComboBox.Focus();
        }


        private void EnableOrDisableControls(int optionSelected){
            this.MonthComboBox.Enabled = optionSelected.Equals(1);
            this.SemesterComboBox.Enabled = optionSelected.Equals(2);
            this.DateDateTimePicker.Enabled = optionSelected.Equals(3);
            this.RangeFromDateTimePicker.Enabled = optionSelected.Equals(4);
            this.RangeToDateTimePicker.Enabled = optionSelected.Equals(4);
        }


        private void ClearResults(){
            this.SalesDataGridView.DataSource= null;
            this.ResumeSalesDataGridView.DataSource= null;
            this.LossesDataGridView.DataSource=null;
            this.ResumeLossesDataGridView.DataSource= null;
        }


        private void ExecuteReport(){
            try{
                ReportUsecase usecase = ReportUsecase.CreateUsecase();
                DataSet results = new DataSet();
                if (this.YearRadioButton.Checked)usecase.GetReportByYear(rolId, int.Parse(this.YearComboBox.Text));
                if (this.MonthRadioButton.Checked)usecase.GetReportByMonthAndYear(rolId, this.MonthComboBox.SelectedIndex+1,   int.Parse(this.YearComboBox.Text));
                if (this.SemesterRadioButton.Checked)usecase.GetReportBySemesterAndYear(rolId, this.SemesterComboBox.SelectedIndex,   int.Parse(this.YearComboBox.Text));
                if (this.DateRadioButton.Checked)usecase.GetReportByDate(rolId, this.DateDateTimePicker.Value);
                if (this.RangeRadioButton.Checked)usecase.GetReportByRange(rolId, this.RangeFromDateTimePicker.Value, this.RangeToDateTimePicker.Value);
                results = usecase.SourceDataSet;
                ConfigureResumeSalesGrid(results.Tables["ResumeSales"]);
                ConfigureSalesGrid(results.Tables["Sales"]);
                ConfigureResumeLossesGrid(results.Tables["ResumeLosses"]);
                ConfigureLossesSalesGrid(results.Tables["Losses"]);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message.ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfigureResumeSalesGrid(DataTable data){
            if (data.Rows.Count.Equals(0)){
                this.ResumeSalesLabel.Text = "No hay ventas registradas en el periodo.";
                this.ResumeSalesDataGridView.Height = 50;
                this.ResumeSalesDataGridView.DataSource=null;
                return;
            }
            this.ResumeSalesLabel.Text = "Resumen de ventas";
            this.ResumeSalesDataGridView.DataSource=data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(this.ResumeSalesDataGridView);
            configurator.ChangeHeader("fecha_compra", "Fecha");
            configurator.CurrencyColumn("monto", "Venta diaria");
            configurator.AdjustHeight();
        }

        private void ConfigureSalesGrid(DataTable data){
            if (data.Rows.Count.Equals(0)){
                this.SalesDataGridView.Height = 50;
                this.SalesDataGridView.DataSource=null;
                this.SalesTitleLabel.Text = string.Empty;
                return;
            }
            this.SalesTitleLabel.Location = new System.Drawing.Point(0,
                this.ResumeSalesDataGridView.Height + this.ResumeSalesDataGridView.Location.Y + 25);
            this.SalesDataGridView.Location = new System.Drawing.Point(0, this.SalesTitleLabel.Location.Y + 25);
            this.SalesTitleLabel.Text = "Detalle de ventas.";
            this.SalesDataGridView.DataSource=data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(this.SalesDataGridView);
            IList<string> columns = new List<string>(){"id_rol", "estado_orden"};
            configurator.HideColumns(columns);
            configurator.ChangeHeader("fecha_orden", "Fecha de compra");
            configurator.ChangeHeader("fecha_pago", "Fecha de pago");
            configurator.ChangeHeader("condicion_pago", "Condición de pago");
            configurator.ChangeHeader("metodo_pago", "Metodo pago");
            configurator.CurrencyColumn("monto_pagado", "Monto");
            configurator.AdjustHeight();
        }

        private void ConfigureResumeLossesGrid(DataTable data){
            if (data.Rows.Count.Equals(0)){
                this.ResumeLossesDataGridView.Height = 50;
                this.ResumeLossesDataGridView.DataSource=null;
                this.ResumeLossesLabel.Text = "No se registran mermas en el periodo seleccionado.";
                return;
            }
            this.ResumeLossesLabel.Text = "Resumen de mermas";
            this.ResumeLossesDataGridView.DataSource=data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(this.ResumeLossesDataGridView);
            IList<string> columns = new List<string>(){"id_rol"};
            configurator.HideColumns(columns);
            configurator.ChangeHeader("fecha_orden", "Fecha");
            configurator.ChangeHeader("productor", "Productor");
            configurator.CurrencyColumn("total_mermas", "Total mermas");
            configurator.AdjustHeight();
        }

        private void ConfigureLossesSalesGrid(DataTable data){
            if (data.Rows.Count.Equals(0)){
                this.LossesDataGridView.Height = 50;
                this.LossesChart.Visible = false;
                this.LossesDataGridView.DataSource=null;
                this.LossesLabel.Text = string.Empty;
                return;
            }
            this.LossesLabel.Location = new System.Drawing.Point(675,
                this.ResumeLossesDataGridView.Height + this.ResumeLossesDataGridView.Location.Y + 25);
            this.LossesDataGridView.Location = new System.Drawing.Point(675, this.LossesLabel.Location.Y + 25);
            this.LossesLabel.Text = "Detalle de mermas registradas.";
            this.LossesDataGridView.DataSource = data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(this.LossesDataGridView);
            IList<string> columns = new List<string>(){"id_rol"};
            configurator.HideColumns(columns);
            configurator.ChangeHeader("fecha_orden", "Fecha");
            configurator.ChangeHeader("producto", "Producto");
            configurator.NumericIntegerColumn("cantidad_merma", "Cantidad");
            configurator.CurrencyColumn("precio_kg", "Precio (KG)");
            configurator.CurrencyColumn("precio_productos", "Total");
            configurator.ChangeHeader("productor", "Productor");
            configurator.AdjustHeight();
            this.LossesChart.Location = new System.Drawing.Point(675,
                this.LossesDataGridView.Height + this.LossesDataGridView.Location.Y + 25);
            this.LossesChart.DataSource= data;
            this.LossesChart.Series[0].XValueMember = "producto";
            this.LossesChart.Series[0].YValueMembers = "cantidad_merma";
            this.LossesChart.Series[0]["PieLabelStyle"] = "Disabled";
            this.LossesChart.Titles.Clear();
            this.LossesChart.Titles.Add("Distribución de mermas por producto vs cantidad");
            this.LossesChart.Visible = true;
        }

        private void RangeFromDateTimePicker_ValueChanged(object sender,EventArgs e){
            this.RangeToDateTimePicker.MinDate = this.RangeFromDateTimePicker.Value.AddDays(1);
        }
    }

}