using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using FeriaVirtual.Business.HelpersUseCases;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Orders{

    public partial class ProductDispatchForm : Form{

        public string IdSelected{ get; set; }
        public string ClientId{ get; set; }
        public string CustomerName{ get; set; }
        public bool IsNewRecord{ get; set; }
        public Auction CurrentAuction{ get; set; }
        public OrderDispatch CurrentDispatch{ get; set; }
        public bool IsSaved{ get; set; }
        public bool IsRemoveBidValue{ get; set; }


        public ProductDispatchForm(){
            InitializeComponent();
            IsSaved = false;
            IsRemoveBidValue = false;
        }


        private void ProductDispatchForm_Load(object sender, EventArgs e){
            LoadSafeData();
            if (IsNewRecord) ConvertAuctionIntoOrderDispatch();

            LoadCarrierData();
            LoadCustomerData();
            LoadDispatchData();
            RemoveCarrierButton.Visible = IsNewRecord;
            NotifyButton.Visible = IsNewRecord;
        }


        private void RemoveCarrierButton_Click(object sender, EventArgs e){
            if (!RemoveBidValue()) return;

            IsRemoveBidValue = true;
            Close();
        }


        private void NotifyButton_Click(object sender, EventArgs e){
            if (!SaveOrderDispatch()) return;

            IsSaved = true;
            Close();
        }


        private void NotifyCloseButton_Click(object sender, EventArgs e){
            Close();
        }


        private void LoadSafeData(){
            SafeComboBox.BeginUpdate();
            var uc = SafeUseCase.CreateUseCase();
            SafeComboBox.DataSource = uc.FindAll();
            SafeComboBox.ValueMember = "id_seguro";
            SafeComboBox.DisplayMember = "nombre_seguro";
            SafeComboBox.EndUpdate();
        }


        private void ConvertAuctionIntoOrderDispatch(){
            CurrentDispatch = OrderDispatch.CreateOrder();
            CurrentDispatch.OrderId = IdSelected;
            CurrentDispatch.ClientId = ClientId;
            CurrentDispatch.ClientName = CustomerName;
            CurrentDispatch.CarrierId = CurrentAuction.CarrierId;
            CurrentDispatch.CarrierName = CurrentAuction.CarrierName;
            CurrentDispatch.DispatchDate = DateTime.Now.Date.ToShortDateString();
            CurrentDispatch.DispatchValue = CurrentAuction.BidValue;
            CurrentDispatch.DispatchWeight = CurrentAuction.Weight;
            CurrentDispatch.Observation = CurrentAuction.DispachObservation;
            CurrentDispatch.CompanyName = CurrentAuction.CompanyName;
            CurrentDispatch.Destination = CurrentAuction.Destination;
            CurrentDispatch.CarrierEmail = CurrentAuction.Email;
            CurrentDispatch.PhoneNumber = CurrentAuction.PhoneNumber;
            CurrentDispatch.Status = 1;
            GetProductList();
        }


        private void GetProductList(){
            foreach (var p in CurrentAuction.Products){
                var odd = OrderDispatchDetail.CreateDetail();
                odd.Product = p.Product;
                odd.UnitValue = p.UnitValue;
                odd.Quantity = p.Quantity;
                odd.TotalValue = p.TotalValue;
                CurrentDispatch.Products.Add(odd);
            }
        }


        private void LoadCarrierData(){
            CarrierTextBox.Text = CurrentDispatch.CarrierName;
            CarrierValueTextBox.Text = $"${CurrentDispatch.DispatchValue.ToString(CultureInfo.CurrentCulture)}";
            var products = new BindingList<OrderDispatchDetail>(CurrentDispatch.Products);
            ProductsDataGridView.DataSource = products;
            ConfigureProductGrid();
        }


        private void ConfigureProductGrid(){
            var configurator = DataGridViewConfigurator.CreateConfigurator(ProductsDataGridView);
            IList<string> columns = new List<string>{"DetailId"};
            configurator.HideColumns(columns);
            configurator.ChangeHeader("Product", "Producto");
            configurator.CurrencyColumn("UnitValue", "Valor");
            configurator.NumericIntegerColumn("Quantity", "Cantidad");
            configurator.CurrencyColumn("TotalValue", "Total");
        }


        private void LoadCustomerData(){
            CustomerTextBox.Text = CustomerName;
            CustomerCompanyTextBox.Text = CurrentDispatch.CompanyName;
            CustomerAddressTextBox.Text = CurrentDispatch.Destination;
            CustomerPhoneTextBox.Text = CurrentDispatch.PhoneNumber;
        }


        private void LoadDispatchData(){
            DispatchPreparationDateTextBox.Text = CurrentDispatch.PreparationDate.ToShortDateString();
            DispatchObservationTextBox.Text = CurrentDispatch.Observation;
            if (CurrentAuction.DispachDate != null){
                DispatchOkDateTimePicker.MinDate = DateTime.Parse(CurrentDispatch.DispatchDate);
                DispatchOkDateTimePicker.Value = DateTime.Parse(CurrentDispatch.DispatchDate);
            }
            else{
                DispatchOkDateTimePicker.MinDate = DateTime.Now.Date.AddDays(1);
                DispatchOkDateTimePicker.Value = DateTime.Now.Date.AddDays(1);
            }
        }


        private bool SaveOrderDispatch(){
            bool result;
            var message = string.Empty;
            PutsDataControlsIntoOrderDispatchObjects();
            try{
                var usecase = OrderDispatchUseCase.CreateUseCase();
                if (IsNewRecord){
                    usecase.CreateOrderDispatch(CurrentDispatch);
                    message =
                        $"La orden de despacho se completo correctamente y el correo electrónico de notificación fue enviado {CustomerName}.";
                }

                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }
            catch (Exception ex){
                result = false;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }


        private void PutsDataControlsIntoOrderDispatchObjects(){
            CurrentDispatch.Observation = DispatchObservationTextBox.Text;
            CurrentDispatch.DispatchDate = DispatchOkDateTimePicker.Value.ToShortDateString();
            CurrentDispatch.Safe.SafeId = int.Parse(SafeComboBox.SelectedValue.ToString());
            CurrentDispatch.Safe.SafeName = SafeComboBox.Text;
        }


        private bool RemoveBidValue(){
            var message =
                $"¿Esta seguro(a) de quitar la puja del transportista {CurrentAuction.CarrierName}?, esto eliminará los datos de la subasta y el estado de la orden de compra estará disponible para generar una nueva subasta.";
            var result = MessageBox.Show(message, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.No)) return false;

            try{
                var usecase = AuctionUseCase.CreateUseCase();
                usecase.RemoveBidValue(CurrentAuction.AuctionId, IdSelected);
                message =
                    "Los datos de la puja de la subasta han sido removidos correctamente, recuerde que esta subasta quedará en las ordenes con subastas publicadas.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

    }

}