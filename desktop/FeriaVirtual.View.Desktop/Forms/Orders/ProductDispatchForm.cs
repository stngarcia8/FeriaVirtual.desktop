using System;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Business.HelpersUseCases;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.View.Desktop.Helpers;
    using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Orders {
    public partial class ProductDispatchForm:Form {

        public string IdSelected { get; set; }
        public string ClientID { get; set; }
        public string CustomerName { get; set; }
        public bool IsNewRecord { get; set; }
        public Auction CurrentAuction { get; set; }
        public bool IsSaved { get; set; }

        public ProductDispatchForm() {
            InitializeComponent();
            this.IsSaved= false;
        }

        private void ProductDispatchForm_Load(object sender,EventArgs e) {
            LoadSafeData();
            this.LoadCarrierData();
            this.LoadCustomerData();
            this.LoadDispatchData();
            this.RemoveCarrierButton.Visible= this.IsNewRecord;
        }

        private void RemoveCarrierButton_Click(object sender,EventArgs e) {

        }

        private void NotifyButton_Click(object sender,EventArgs e) {
            if(!SaveOrderDispatch()) {
                return;
            }
            this.IsSaved= true;
            this.Close();
        }

        private void NotifyCloseButton_Click(object sender,EventArgs e) {
            this.Close();
        }

        private void LoadSafeData() {
            this.SafeComboBox.BeginUpdate();
            SafeUseCase uc = SafeUseCase.CreateUseCase();
            this.SafeComboBox.DataSource =  uc.FindAll();
            this.SafeComboBox.ValueMember = "id_seguro";
            this.SafeComboBox.DisplayMember="nombre_seguro";
            this.SafeComboBox.EndUpdate();
        }

        private void LoadCarrierData() {
            this.CarrierTextBox.Text = CurrentAuction.CarrierName;
            this.CarrierValueTextBox.Text = string.Format("${0}",CurrentAuction.BidValue.ToString());
            BindingList<AuctionProduct> products = new BindingList<AuctionProduct>(CurrentAuction.Products);
            this.ProductsDataGridView.DataSource = products;
            ConfigureProductGrid();
        }

        private void ConfigureProductGrid() {
            DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ProductsDataGridView);
            configurator.ChangeHeader("Product","Producto");
            configurator.CurrencyColumn("UnitValue","Valor");
            configurator.NumericIntegerColumn("Quantity","Cantidad");
            configurator.CurrencyColumn("TotalValue","Total");
        }


        private void LoadCustomerData() {
            this.CustomerTextBox.Text = this.CustomerName;
            this.CustomerCompanyTextBox.Text = CurrentAuction.CompanyName;
            this.CustomerAddressTextBox.Text= CurrentAuction.Destination;
            this.CustomerPhoneTextBox.Text= CurrentAuction.PhoneNumber;
        }

        private void LoadDispatchData() {
            this.DispatchPreparationDateTextBox.Text = DateTime.Now.Date.ToShortDateString();
            this.DispatchObservationTextBox.Text = CurrentAuction.DispachObservation;
            if(CurrentAuction.DispachDate != null) {
                this.DispatchOkDateTimePicker.MinDate= CurrentAuction.DispachDate.Value;
                this.DispatchOkDateTimePicker.Value = CurrentAuction.DispachDate.Value;
            } else {
                this.DispatchOkDateTimePicker.MinDate=DateTime.Now.Date.AddDays(1);
                this.DispatchOkDateTimePicker.Value = DateTime.Now.Date.AddDays(1);
            }
        }

        private bool SaveOrderDispatch() {
            bool result = false;
            string message = string.Empty;
            PutsDataControlsIntoAuctionObjects();
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                if(IsNewRecord) {
                    usecase.CreateOrderDispatch(CurrentAuction,this.IdSelected,this.ClientID,int.Parse( this.SafeComboBox.SelectedValue.ToString()));
                    message = string.Format( "La orden de despacho se completo correctamente y el correo electrónico de notificación fue enviado {0}.", this.CustomerName) ;
                }
                MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                result= true;
            } catch (Exception ex) {
                result= false;
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            return result;
        }

        private void  PutsDataControlsIntoAuctionObjects() {
            CurrentAuction.DispachObservation = this.DispatchObservationTextBox.Text;
            CurrentAuction.DispachDate= this.DispatchOkDateTimePicker.Value;
        }



    }
}
