using System;
using System.Collections.Generic;
using FeriaVirtual.View.Desktop.Helpers;
using FeriaVirtual.View.Desktop.Commands;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.Business.Orders;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Payments {

    public partial class PaymentDetailsForm:Form {

        public bool IsSaved{get;set;}
        public string IdSelected{get;set;}
        public string IdOrderSelected{get;set;}
        public bool IsNew{get;set;}

        
        
        public PaymentDetailsForm() {
            InitializeComponent();
            this.IsSaved= false;
        }

        private void PaymentDetailsForm_Load(object sender,EventArgs e){
            this.NotifyButton.Visible = this.IsNew;
            LoadPaymentData();
            LoadProducerIntoPaymentData();
        }

        private void RefreshButton_Click(object sender,EventArgs e){
            this.LoadPaymentData();
            this.LoadProducerIntoPaymentData();
            this.ProductDataGridView.Focus();
        }



        private void NotifyButton_Click(object sender,EventArgs e){
            if (!NotifyToProducer()) return;
            this.IsSaved = true;
            this.Close();
        }

        private void CloseShowButton_Click(object sender,EventArgs e){
            this.IsSaved= false;
            this.Close();
        }


        private void LoadPaymentData(){
            try{
                PaymentUsecase usecase = PaymentUsecase.CreateUsecase();
                PutsPaymentDataIntoControls(usecase.GetPaymentById(this.IdSelected));
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.IsSaved= false;
                this.Close();
            }
        }


        private void PutsPaymentDataIntoControls(DataTable data){
            if (data.Rows.Count.Equals(0)){
                MessageBox.Show("No se encontro información de pago.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.IsSaved= false;
                this.Close();
            }
            ExtractPaymentDataFromDataRow(data.Rows[0]);
        }


        private void ExtractPaymentDataFromDataRow(DataRow r){
            this.CustomerNameTextBox.Text = r["Cliente"].ToString();
            this.CustomerEmailTextBox.Text = r["email"].ToString();
            this.CustomerTypeTextBox.Text = r["tipo usuario"].ToString();
            this.PaymentDateTextBox.Text= $"{r["Fecha pago"].ToString()} {r["Hora pago"].ToString()}";
            this.PaymentConditionTextBox.Text = r["Condicion pago"].ToString();
            this.PaymentMethodTextBox.Text = r["desc_metpago"].ToString();
            this.AmountTextBox.Text = $"${r["Total a pagar"].ToString()}";
            this.ObservationTextBox.Text = r["Observacion"].ToString();
        }

        private void LoadProducerIntoPaymentData(){
            try{
                PaymentUsecase usecase = PaymentUsecase.CreateUsecase();
                this.ProductDataGridView.DataSource = null;
                this.ProductDataGridView.DataSource =usecase.GetProducerIntoPayment(this.IdOrderSelected);
                this.ConfigureProductGrid();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.IsSaved= false;
                this.Close();
            }
        }


        private void ConfigureProductGrid(){
            DataGridViewConfigurator configurator =
                DataGridViewConfigurator.CreateConfigurator(this.ProductDataGridView);
            IList<string> columns = new List<string>(){ "id_pago", "id_pedido", "id_cliente", "email" };
            configurator.HideColumns(columns);
            configurator.NumericIntegerColumn("Cantidad", "Cantidad");
            configurator.CurrencyColumn("Valor unitario", "Precio unitario");
            configurator.CurrencyColumn("Valor productos", "Precio total");
        }


        private bool NotifyToProducer(){
            string message;
            DialogResult messageResult;
            bool result = false;
            try{
                PaymentUsecase usecase = PaymentUsecase.CreateUsecase();
                usecase.NotifyProducer(GetResultFromDataGrid());
                message = "Los productores han sido notificados de sus ventas.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message.ToString(), "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }




        private IList<PaymentResult> GetResultFromDataGrid(){
            if (this.ProductDataGridView.Rows.Count.Equals(0)) return null;
            IList<PaymentResult> resultsList = new List<PaymentResult>();
            foreach (DataGridViewRow r in this.ProductDataGridView.Rows){
                PaymentResult result = PaymentResult.CreateResult();
                result.PaymentId = r.Cells["id_pago"].Value.ToString();
                result.SalesDate = DateTime.Parse(r.Cells["Fecha venta"].Value.ToString());
                result.Quantity = int.Parse(r.Cells["Cantidad"].Value.ToString());
                result.ProductName = r.Cells["Producto"].Value.ToString();
                result.UnitPrice = float.Parse(r.Cells["Valor unitario"].Value.ToString());
                result.ProductPrice = float.Parse(r.Cells["Valor productos"].Value.ToString());
                result.ClientId = r.Cells["id_cliente"].Value.ToString();
                result.ProducerName = r.Cells["Productor"].Value.ToString();
                result.ProducerEmail = r.Cells["email"].Value.ToString();

                resultsList.Add(result);
            }
            return resultsList;
        }


    }
}
