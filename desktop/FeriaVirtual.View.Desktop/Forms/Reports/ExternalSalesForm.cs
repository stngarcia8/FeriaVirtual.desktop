using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FeriaVirtual.Business.Stats;
using FeriaVirtual.Domain.Dto;
using FeriaVirtual.View.Desktop.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = iTextSharp.text.Image;


namespace FeriaVirtual.View.Desktop.Forms.Reports {

    public partial class ExternalSalesForm:Form {

        private readonly int rolId;
        private string pdfFileName;
        private IList<ReportRecipientsDto> recipients;
        private string reportTitle;


        public ExternalSalesForm(int rolId) {
            InitializeComponent();
            this.rolId = rolId;
        }


        private void ExternalSalesForm_Load(object sender,EventArgs e) {
            ConfigureForm();
            pdfFileName = string.Empty;
            recipients = new List<ReportRecipientsDto>();
            reportTitle = "Informe de ventas";
        }


        private void YearRadioButton_CheckedChanged(object sender,EventArgs e) {
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


        private void RangeFromDateTimePicker_ValueChanged(object sender,EventArgs e) {
            RangeToDateTimePicker.MinDate = RangeFromDateTimePicker.Value.AddDays(1);
        }


        private void OptionExecuteToolStripMenuItem_Click(object sender,EventArgs e) {
            ExecuteReport();
        }


        private void OptionSendMailToolStripMenuItem_Click(object sender,EventArgs e) {
            GeneratePDF();
            OpenRecipientForm();
            //SendReport();
        }


        private void OptionCleanToolStripMenuItem_Click(object sender,EventArgs e) {
            pdfFileName = string.Empty;
            ClearResults();
            ConfigureForm();
            YearComboBox.Focus();
        }


        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e) {
            Close();
        }


        private void ConfigureForm() {
            Text = rolId == 3 ? "Informe de ventas clientes externos" : "Informe de ";
            FilterGroupBox.Width = Width;
            YearComboBox.SelectedIndex = 0;
            YearRadioButton.Checked = true;
            MonthComboBox.SelectedIndex = DateTime.Now.Month - 1;
            SemesterComboBox.SelectedIndex = DateTime.Now.Month > 6 ? 1 : 0;
            DateDateTimePicker.Value = DateTime.Now.Date;
            RangeFromDateTimePicker.Value = DateTime.Now.Date;
            RangeToDateTimePicker.Value = DateTime.Now.Date.AddDays(1);
            EnableOrDisableControls(0);
            ClearResults();
            YearComboBox.Focus();
        }


        private void EnableOrDisableControls(int optionSelected) {
            MonthComboBox.Enabled = optionSelected.Equals(1);
            SemesterComboBox.Enabled = optionSelected.Equals(2);
            DateDateTimePicker.Enabled = optionSelected.Equals(3);
            RangeFromDateTimePicker.Enabled = optionSelected.Equals(4);
            RangeToDateTimePicker.Enabled = optionSelected.Equals(4);
        }


        private void ClearResults() {
            recipients = new List<ReportRecipientsDto>();
            SalesDataGridView.DataSource = null;
            ResumeSalesDataGridView.DataSource = null;
            LossesDataGridView.DataSource = null;
            ResumeLossesDataGridView.DataSource = null;
            pdfFileName = string.Empty;
            LossesChart.Visible = false;
            OptionSendMailToolStripMenuItem.Enabled = false;
        }


        private void ExecuteReport() {
            try {
                ReportUsecase usecase = ReportUsecase.CreateUsecase();
                DataSet results = new DataSet();
                if(YearRadioButton.Checked) {
                    usecase.GetReportByYear(rolId,int.Parse(YearComboBox.Text));
                    reportTitle = $"Reporte de ventas año {YearComboBox.Text}";
                }

                if(MonthRadioButton.Checked) {
                    usecase.GetReportByMonthAndYear(rolId,MonthComboBox.SelectedIndex + 1,
                        int.Parse(YearComboBox.Text));
                    reportTitle = $"Reporte de ventas de {MonthComboBox.Text} de {YearComboBox.Text}";
                }

                if(SemesterRadioButton.Checked) {
                    usecase.GetReportBySemesterAndYear(rolId,SemesterComboBox.SelectedIndex,
                        int.Parse(YearComboBox.Text));
                    reportTitle = $"Reporte de ventas {SemesterComboBox.Text} año {YearComboBox.Text}";
                }

                if(DateRadioButton.Checked) {
                    usecase.GetReportByDate(rolId,DateDateTimePicker.Value);
                    reportTitle = $"Reporte de ventas del {DateDateTimePicker.Value.ToLongDateString()}";
                }

                if(RangeRadioButton.Checked) {
                    usecase.GetReportByRange(rolId,RangeFromDateTimePicker.Value,RangeToDateTimePicker.Value);
                    reportTitle =
                        $"Reporte de ventas entre {RangeFromDateTimePicker.Value.ToShortDateString()} y {RangeToDateTimePicker.Value.ToShortDateString()}";
                }

                results = usecase.SourceDataSet;
                ConfigureResumeSalesGrid(results.Tables["ResumeSales"]);
                ConfigureSalesGrid(results.Tables["Sales"]);
                ConfigureResumeLossesGrid(results.Tables["ResumeLosses"]);
                ConfigureLossesSalesGrid(results.Tables["Losses"]);
                VerifySendEmail();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }


        private void VerifySendEmail() {
            if(SalesDataGridView.Rows.Count > 0) {
                OptionSendMailToolStripMenuItem.Enabled = true;
                return;
            }
            if(ResumeSalesDataGridView.Rows.Count > 0) {
                OptionSendMailToolStripMenuItem.Enabled = true;
                return;
            }
            if(LossesDataGridView.Rows.Count > 0) {
                OptionSendMailToolStripMenuItem.Enabled = true;
                return;
            }
            if(ResumeLossesDataGridView.Rows.Count > 0) {
                OptionSendMailToolStripMenuItem.Enabled = true;
                return;
            }
            OptionSendMailToolStripMenuItem.Enabled = false;
        }


        private void ConfigureResumeSalesGrid(DataTable data) {
            if(data.Rows.Count.Equals(0)) {
                ResumeSalesLabel.Text = "No hay ventas registradas en el periodo.";
                ResumeSalesDataGridView.Height = 50;
                ResumeSalesDataGridView.DataSource = null;
                return;
            }
            ResumeSalesLabel.Text = "Resumen de ventas";
            ResumeSalesDataGridView.DataSource = data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ResumeSalesDataGridView);
            configurator.ChangeHeader("fecha_compra","Fecha");
            configurator.CurrencyColumn("monto","Venta diaria");
            configurator.AdjustHeight();
        }


        private void ConfigureSalesGrid(DataTable data) {
            if(data.Rows.Count.Equals(0)) {
                SalesDataGridView.Height = 50;
                SalesDataGridView.DataSource = null;
                SalesTitleLabel.Text = string.Empty;
                return;
            }
            SalesTitleLabel.Location = new Point(0,
                ResumeSalesDataGridView.Height + ResumeSalesDataGridView.Location.Y + 25);
            SalesDataGridView.Location = new Point(0,SalesTitleLabel.Location.Y + 25);
            SalesTitleLabel.Text = "Detalle de ventas.";
            SalesDataGridView.DataSource = data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(SalesDataGridView);
            IList<string> columns = new List<string> { "id_rol","estado_orden" };
            configurator.HideColumns(columns);
            configurator.ChangeHeader("fecha_orden","Fecha de compra");
            configurator.ChangeHeader("fecha_pago","Fecha de pago");
            configurator.ChangeHeader("condicion_pago","Condición de pago");
            configurator.ChangeHeader("metodo_pago","Metodo pago");
            configurator.CurrencyColumn("monto_pagado","Monto");
            configurator.AdjustHeight();
        }


        private void ConfigureResumeLossesGrid(DataTable data) {
            if(data.Rows.Count.Equals(0)) {
                ResumeLossesDataGridView.Height = 50;
                ResumeLossesDataGridView.DataSource = null;
                ResumeLossesLabel.Text = "No se registran mermas en el periodo seleccionado.";
                return;
            }
            ResumeLossesLabel.Text = "Resumen de mermas";
            ResumeLossesDataGridView.DataSource = data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ResumeLossesDataGridView);
            IList<string> columns = new List<string> { "id_rol" };
            configurator.HideColumns(columns);
            configurator.ChangeHeader("fecha_orden","Fecha");
            configurator.ChangeHeader("productor","Productor");
            configurator.CurrencyColumn("total_mermas","Total mermas");
            configurator.AdjustHeight();
        }


        private void ConfigureLossesSalesGrid(DataTable data) {
            if(data.Rows.Count.Equals(0)) {
                LossesDataGridView.Height = 50;
                LossesChart.Visible = false;
                LossesDataGridView.DataSource = null;
                LossesLabel.Text = string.Empty;
                return;
            }
            LossesLabel.Location = new Point(675,
                ResumeLossesDataGridView.Height + ResumeLossesDataGridView.Location.Y + 25);
            LossesDataGridView.Location = new Point(675,LossesLabel.Location.Y + 25);
            LossesLabel.Text = "Detalle de mermas registradas.";
            LossesDataGridView.DataSource = data;
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(LossesDataGridView);
            IList<string> columns = new List<string> { "id_rol" };
            configurator.HideColumns(columns);
            configurator.ChangeHeader("fecha_orden","Fecha");
            configurator.ChangeHeader("producto","Producto");
            configurator.NumericIntegerColumn("cantidad_merma","Cantidad");
            configurator.CurrencyColumn("precio_kg","Precio (KG)");
            configurator.CurrencyColumn("precio_productos","Total");
            configurator.ChangeHeader("productor","Productor");
            configurator.AdjustHeight();
            LossesChart.Location = new Point(675,
                LossesDataGridView.Height + LossesDataGridView.Location.Y + 25);
            LossesChart.DataSource = data;
            LossesChart.Series[0].XValueMember = "producto";
            LossesChart.Series[0].YValueMembers = "cantidad_merma";
            LossesChart.Series[0]["PieLabelStyle"] = "Disabled";
            LossesChart.Titles.Clear();
            LossesChart.Titles.Add("Distribución de mermas por producto vs cantidad");
            LossesChart.Visible = true;
        }


        private void GeneratePDF() {
            string filename =
                $"ventas_clientes{(rolId.Equals(3) ? "externos" : "internos")}_{DateTime.Now.ToFileTimeUtc()}.pdf";
            string filePath = $"{Environment.CurrentDirectory}\\reportes";
            pdfFileName = Path.Combine(filePath,filename);
            try {
                using(FileStream stream = new FileStream(pdfFileName,FileMode.Create)) {
                    Document doc = new Document(PageSize.LETTER,10,10,10,10);
                    PdfWriter.GetInstance(doc,stream);
                    doc.Open();
                    GenerateTable(doc,SalesDataGridView,SalesTitleLabel);
                    GenerateTable(doc,LossesDataGridView,LossesLabel);
                    GenerateTable(doc,ResumeSalesDataGridView,ResumeSalesLabel);
                    GenerateTable(doc,ResumeLossesDataGridView,ResumeLossesLabel);
                    doc.Close();
                }
            } catch(Exception ex) {
                pdfFileName = string.Empty;
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }


        private void GenerateTitle(Document doc) {
            doc.NewPage();
            Image img = Image.GetInstance(Path.Combine(Environment.CurrentDirectory,"mg-logo.png"));
            img.ScaleToFit(125f,60F);
            doc.Add(img);
            iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.COURIER_BOLD,14);
            Paragraph p = new Paragraph(reportTitle,font) {
                SpacingBefore = -35,
                SpacingAfter = 0,
                Alignment = 1
            };
            doc.Add(p);
            doc.Add(Chunk.NEWLINE);

            iTextSharp.text.Font font1 = FontFactory.GetFont(FontFactory.COURIER_BOLD,12);
            Paragraph p1 = new Paragraph(rolId.Equals(3) ? "Clientes externos" : "Clientes internos",font1) {
                SpacingBefore = -25,
                SpacingAfter = 3,
                Alignment = 1
            };
            doc.Add(p1);
            doc.Add(Chunk.NEWLINE);
        }


        private void GenerateTable(Document document,DataGridView dgv,Label lbl) {
            if(dgv.Rows.Count.Equals(0)) {
                return;
            }

            GenerateTitle(document);
            int cols = 0;
            foreach(DataGridViewColumn column in dgv.Columns) {
                if(column.Visible) {
                    cols++;
                }
            }

            PdfPTable pdfTable = new PdfPTable(cols);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.DefaultCell.BorderWidth = 1;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BackgroundColor = new BaseColor(0,150,0);
            PdfPCell cell = new PdfPCell(new Phrase(lbl.Text)) {
                Colspan = cols,
                HorizontalAlignment = 1,
                BackgroundColor = new BaseColor(0,155,0)
            };
            pdfTable.AddCell(cell);
            foreach(DataGridViewColumn column in dgv.Columns) {
                if(column.Visible) {
                    PdfPCell cell1 = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell1);
                }
            }

            pdfTable.HeaderRows = 1;
            pdfTable.DefaultCell.BackgroundColor = new BaseColor(255,255,255);
            pdfTable.DefaultCell.BorderWidth = 1;
            foreach(DataGridViewRow row in dgv.Rows) {
                foreach(DataGridViewCell cell2 in row.Cells) {
                    if(cell2.Visible) {
                        pdfTable.AddCell(cell2.Value.ToString());
                    }
                }

                pdfTable.CompleteRow();
            }
            document.Add(pdfTable);
        }


        private void OpenRecipientForm() {
            if(string.IsNullOrEmpty(pdfFileName)) {
                return;
            }

            RecipientForm form = new RecipientForm {
                FileName = pdfFileName,
                ReportName = reportTitle
            };
            form.ShowDialog();
            if(form.IsSendit) {
                ClearResults();
            }
        }

    }

}