using System;
using FeriaVirtual.Domain.Offers;
using FeriaVirtual.View.Desktop.Forms.UtilForms;
using FeriaVirtual.Business.Offers;
using FeriaVirtual.View.Desktop.Helpers;
using FeriaVirtual.View.Desktop.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Offers {
    public partial class SimplyOfferForm:Form {

        private Offer currentOffer;
        private OfferDetail currentDetail;
        private BindingList<OfferDetail> source;


        public bool IsNewRecord{get;set;}
        public bool IsSaved{get;set;}
        public string IdSelected{get;set;}
        public int OfferType{get;set;}
        
        public SimplyOfferForm() {
            InitializeComponent();
            this.IsSaved= false;
        }

        private void SimplyOfferForm_Load(object sender,EventArgs e) {
            if (this.IsNewRecord){
                this.currentOffer = Offer.CreateOffer();
                this.currentDetail = OfferDetail.CreateDetail();
                this.CloseOfferButton.Visible= false;
            }
            this.CloseOfferButton.Visible = !this.IsNewRecord;
            ConfigureForm();
        }

        private void CloseOfferButton_Click(object sender,EventArgs e) {

        }

        private void SaveOfferButton_Click(object sender,EventArgs e) {
            if (!SaveOfferData()) return;
            IsSaved = true;
            Close();
        }

        private void CancelOfferButton_Click(object sender,EventArgs e){
            this.IsSaved= false;
            this.Close();
        }

        private void ProductDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetCurrentDetail();
        }

        private void ProductListContextMenuStrip_Opening(object sender,CancelEventArgs e){
            bool thereAreRecords = this.ProductDataGridView.Rows.Count.Equals(0);
            this.ListRemoveToolStripMenuItem.Enabled = !thereAreRecords;
        }

        private void ListRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            ConfigureProductsList();
            ProductDataGridView.Focus();
        }

        private void ListAddToolStripMenuItem_Click(object sender,EventArgs e) {
            OpenSearchProductsForm();
        }

        private void ListRemoveToolStripMenuItem_Click(object sender,EventArgs e) {
            if (this.ProductDataGridView.Rows.Count.Equals(0)) return;
            if (ProductDataGridView.SelectedRows.Count.Equals(0)) return;
            ProductDataGridView.Rows.Remove(ProductDataGridView.SelectedRows[0]);
        }


        private void ConfigureForm(){
            this.CloseOfferButton.Visible = !this.IsNewRecord;
            this.CleanControls();
            ConfigureBindingList();
            ConfigureProductsList();
        }


        private void CleanControls(){
            this.PublishDateTextBox.Text = DateTime.Now.ToShortDateString();
            this.DiscountNumericUpDown.Value = 0;
            this.DescriptionTextBox.Text = string.Empty;
            this.ProductDataGridView.DataSource = null;
        }

        private void ConfigureBindingList(){
            source = new BindingList<OfferDetail>(this.currentOffer.Details){
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
                currentDetail.Percent = $"{this.DiscountNumericUpDown.Value.ToString()}%";
                currentDetail.OfferValue = form.ProductFound.ProductValue - ((form.ProductFound.ProductValue * float.Parse(this.DiscountNumericUpDown.Value.ToString()))/100);
                this.currentOffer.Details.Add(currentDetail);
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
            DataGridViewConfigurator configurator =
                DataGridViewConfigurator.CreateConfigurator(this.ProductDataGridView);
            IList<string> columns = new List<string>(){"OfferDetailId", "ProductId"};
            configurator.HideColumns(columns);
            configurator.ChangeHeader("ProductName", "Producto");
            configurator.CurrencyColumn("ActualValue", "Valor actual");
            configurator.CurrencyColumn("OfferValue", "Valor con descuento");
        }

        private void GetCurrentDetail(){
            if (currentOffer.Details.Count.Equals(0)){
                currentDetail= OfferDetail.CreateDetail();
                return;
            }
            var row = ProductDataGridView.CurrentRow;
            if (row != null) currentDetail = row.DataBoundItem as OfferDetail;
        }

        private void PutInfoControlsToOffer(){
            currentOffer.PublishDate = DateTime.Parse(this.PublishDateTextBox.Text);
            currentOffer.Description = this.DescriptionTextBox.Text;
            currentOffer.Discount = float.Parse(this.DiscountNumericUpDown.Value.ToString());
        }


        private bool SaveOfferData(){
            bool result;
            PutInfoControlsToOffer();
            try{
                string message;
                OfferUseCase usecase = OfferUseCase.CreateUsecase();
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

        private void DiscountNumericUpDown_ValueChanged(object sender,EventArgs e) {
            foreach (OfferDetail d in currentOffer.Details){
                float percent = ((d.ActualValue * float.Parse(this.DiscountNumericUpDown.Value.ToString())) / 100);
                d.OfferValue = d.ActualValue - percent;
                d.Percent = $"{this.DiscountNumericUpDown.Value}%";
            }
            ConfigureBindingList();
        }
    }
}
