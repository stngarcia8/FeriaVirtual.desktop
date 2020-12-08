using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Payments{

    public partial class PaymentDetailsForm : Form{

        public bool IsSaved{ get; set; }
        public string IdSelected{ get; set; }
        public string IdOrderSelected{ get; set; }
        public bool IsNew{ get; set; }


        public PaymentDetailsForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void PaymentDetailsForm_Load(object sender, EventArgs e){
            NotifyButton.Visible = IsNew;
            LoadPaymentData();
            LoadProductsIntoPaymentData();
        }


        private void RefreshButton_Click(object sender, EventArgs e){
            LoadPaymentData();
            LoadProductsIntoPaymentData();
            ProductDataGridView.Focus();
        }


        private void NotifyButton_Click(object sender, EventArgs e){
            if (!NotifyToProducer()) return;

            IsSaved = true;
            Close();
        }


        private void CloseShowButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void LoadPaymentData(){
            try{
                var usecase = PaymentUsecase.CreateUsecase();
                PutsPaymentDataIntoControls(usecase.GetPaymentById(IdSelected));
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsSaved = false;
                Close();
            }
        }


        private void PutsPaymentDataIntoControls(DataTable data){
            if (data.Rows.Count.Equals(0)){
                MessageBox.Show("No se encontro información de pago.", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                IsSaved = false;
                Close();
            }
            ExtractPaymentDataFromDataRow(data.Rows[0]);
        }


        private void ExtractPaymentDataFromDataRow(DataRow r){
            CustomerNameTextBox.Text = r["Cliente"].ToString();
            CustomerEmailTextBox.Text = r["email"].ToString();
            CustomerTypeTextBox.Text = r["tipo usuario"].ToString();
            PaymentDateTextBox.Text = $"{r["Fecha pago"]} {r["Hora pago"]}";
            PaymentConditionTextBox.Text = r["Condicion pago"].ToString();
            PaymentMethodTextBox.Text = r["desc_metpago"].ToString();
            AmountTextBox.Text = $"${r["Total a pagar"]}";
            ObservationTextBox.Text = r["Observacion"].ToString();
        }


        private void LoadProductsIntoPaymentData(){
            try{
                var usecase = PaymentUsecase.CreateUsecase();
                ProductDataGridView.DataSource = null;
                ProductDataGridView.DataSource = usecase.GetProducerIntoPayment(IdOrderSelected);
                ConfigureProductGrid();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IsSaved = false;
                Close();
            }
        }


        private void ConfigureProductGrid(){
            var configurator =
                DataGridViewConfigurator.CreateConfigurator(ProductDataGridView);
            IList<string> columns = new List<string>{"id_pago", "id_pedido", "id_cliente", "email"};
            configurator.HideColumns(columns);
            configurator.NumericIntegerColumn("Cantidad", "Cantidad");
            configurator.CurrencyColumn("Valor unitario", "Precio unitario");
            configurator.CurrencyColumn("Valor productos", "Precio total");
        }


        private bool NotifyToProducer(){
            var result = false;
            try{
                string message;
                var usecase = PaymentUsecase.CreateUsecase();
                usecase.NotifyProducer(GetResultFromDataGrid());
                message = "Los productores han sido notificados de sus ventas.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }


        private IList<PaymentResult> GetResultFromDataGrid(){
            if (ProductDataGridView.Rows.Count.Equals(0)) return null;

            IList<PaymentResult> resultsList = new List<PaymentResult>();
            foreach (DataGridViewRow r in ProductDataGridView.Rows){
                var result = PaymentResult.CreateResult();
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