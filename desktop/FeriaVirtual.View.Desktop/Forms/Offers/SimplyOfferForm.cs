using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FeriaVirtual.Business.Offers;
using FeriaVirtual.Domain.Offers;
using FeriaVirtual.View.Desktop.Forms.UtilForms;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Offers{

    public partial class SimplyOfferForm : Form{

        private OfferDetail currentDetail;

        private Offer currentOffer;
        private BindingList<OfferDetail> source;


        public bool IsNewRecord{ get; set; }
        public bool IsSaved{ get; set; }
        public string IdSelected{ get; set; }
        public int OfferType{ get; set; }


        public SimplyOfferForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void SimplyOfferForm_Load(object sender, EventArgs e){
            ConfigureForm();
        }


        private void SaveOfferButton_Click(object sender, EventArgs e){
            if (!SaveOfferData()) return;

            IsSaved = true;
            Close();
        }


        private void CancelOfferButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void ProductDataGridView_SelectionChanged(object sender, EventArgs e){
            GetCurrentDetail();
        }


        private void ProductListContextMenuStrip_Opening(object sender, CancelEventArgs e){
            var thereAreRecords = ProductDataGridView.Rows.Count.Equals(0);
            ListRemoveToolStripMenuItem.Enabled = !thereAreRecords;
        }


        private void ListRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            ConfigureProductsList();
            ProductDataGridView.Focus();
        }


        private void ListAddToolStripMenuItem_Click(object sender, EventArgs e){
            OpenSearchProductsForm();
        }


        private void ListRemoveToolStripMenuItem_Click(object sender, EventArgs e){
            if (ProductDataGridView.Rows.Count.Equals(0)) return;

            if (ProductDataGridView.SelectedRows.Count.Equals(0)) return;

            ProductDataGridView.Rows.Remove(ProductDataGridView.SelectedRows[0]);
        }


        private void ConfigureForm(){
            LoadOffersType();
            if (IsNewRecord){
                currentOffer = Offer.CreateOffer();
                currentDetail = OfferDetail.CreateDetail();
                CleanControls();
            }
            else{
                LoadOffer();
                CalculateProductsDiscount();
            }
            ConfigureBindingList();
            ConfigureProductsList();
        }


        private void LoadOffersType(){
            FilterComboConfigurator configurator = FilterComboConfigurator.CreateConfigurator(this.OfferTypeComboBox);
            IList<string> filterOptions = new List<string>(){"Oferta", "Venta de saldos"};
            configurator.ClearFilters();
            configurator.LoadFilters(filterOptions);
        }


        private void CleanControls(){
            PublishDateTextBox.Text = DateTime.Now.ToShortDateString();
            DiscountNumericUpDown.Value = 0;
            DescriptionTextBox.Text = string.Empty;
            OfferTypeComboBox.SelectedIndex = 0;
            ProductDataGridView.DataSource = null;
        }


        private void ConfigureBindingList(){
            source = new BindingList<OfferDetail>(currentOffer.Details){
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };
        }


        private void OpenSearchProductsForm(){
            var form = new SearchProductForm();
            form.ShowDialog();
            if (form.IsFound){
                currentDetail = OfferDetail.CreateDetail();
                currentDetail.ProductId = form.ProductFound.ProductId;
                currentDetail.ProductName = form.ProductFound.ProductName;
                currentDetail.ActualValue = form.ProductFound.ProductValue;
                currentDetail.Percent = $"{DiscountNumericUpDown.Value.ToString()}%";
                currentDetail.OfferValue = form.ProductFound.ProductValue - form.ProductFound.ProductValue *
                    float.Parse(DiscountNumericUpDown.Value.ToString()) / 100;
                currentOffer.Details.Add(currentDetail);
            }
            ConfigureBindingList();
            ConfigureProductsList();
        }


        private void ConfigureProductsList(){
            ProductDataGridView.SelectionChanged -= ProductDataGridView_SelectionChanged;
            ProductDataGridView.DataSource = null;
            ProductDataGridView.DataSource = source;
            ProductDataGridView.Refresh();
            ConfigureGrid();
            ProductDataGridView.SelectionChanged += ProductDataGridView_SelectionChanged;
        }


        private void ConfigureGrid(){
            var configurator =
                DataGridViewConfigurator.CreateConfigurator(ProductDataGridView);
            IList<string> columns = new List<string>{"OfferDetailId", "ProductId"};
            configurator.HideColumns(columns);
            configurator.ChangeHeader("ProductName", "Producto");
            configurator.ChangeHeader("Percent", "Porcentaje descuento");
            configurator.CurrencyColumn("ActualValue", "Precio actual");
            configurator.CurrencyColumn("OfferValue", "Precio oferta");
        }


        private void GetCurrentDetail(){
            if (currentOffer.Details.Count.Equals(0)){
                currentDetail = OfferDetail.CreateDetail();
                return;
            }
            var row = ProductDataGridView.CurrentRow;
            if (row != null) currentDetail = row.DataBoundItem as OfferDetail;
        }


        private void PutInfoControlsToOffer(){
            currentOffer.PublishDate = DateTime.Parse(PublishDateTextBox.Text);
            currentOffer.Description = DescriptionTextBox.Text;
            currentOffer.OfferType = ( this.OfferTypeComboBox.SelectedIndex+1);
            currentOffer.Discount = float.Parse(DiscountNumericUpDown.Value.ToString());
        }


        private bool SaveOfferData(){
            bool result;
            PutInfoControlsToOffer();
            try{
                string message;
                var usecase = OfferUseCase.CreateUsecase();
                if (IsNewRecord){
                    usecase.NewOffer(currentOffer);
                    message = "La oferta fue creada correctamente";
                }
                else{
                    usecase.EditOffer(currentOffer);
                    message = "La oferta fue actualizada correctamente.";
                }
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                result = false;
            }
            return result;
        }


        private void DiscountNumericUpDown_ValueChanged(object sender, EventArgs e){
            CalculateProductsDiscount();
            ConfigureBindingList();
        }


        private void CalculateProductsDiscount(){
            if (currentOffer.Details.Count.Equals(0)) return;

            foreach (var d in currentOffer.Details){
                var percent = d.ActualValue * float.Parse(DiscountNumericUpDown.Value.ToString()) / 100;
                d.OfferValue = d.ActualValue - percent;
                d.Percent = $"{DiscountNumericUpDown.Value}%";
            }
        }


        private void LoadOffer(){
            try{
                var usecase = OfferUseCase.CreateUsecase();
                var offer = usecase.GetOfferById(IdSelected);
                PutOfferDataIntoControls(offer);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void PutOfferDataIntoControls(OfferDto offer){
            currentOffer = Offer.CreateOffer();
            currentOffer.OfferId = offer.OfferId;
            currentOffer.PublishDate = DateTime.Parse(offer.PublishDate);
            currentOffer.Discount = offer.Discount;
            currentOffer.Description = offer.Description;
            currentOffer.Details = offer.Details;
            PublishDateTextBox.Text = currentOffer.PublishDate.ToShortDateString();
            DescriptionTextBox.Text = currentOffer.Description;
            OfferTypeComboBox.SelectedIndex = (currentOffer.OfferType - 1);
            DiscountNumericUpDown.Value = decimal.Parse(currentOffer.Discount.ToString());
        }

    }

}