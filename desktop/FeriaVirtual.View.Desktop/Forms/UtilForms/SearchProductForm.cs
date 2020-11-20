using System;
using System.Data;
using FeriaVirtual.View.Desktop.Helpers;
using FeriaVirtual.Domain.Products;
using FeriaVirtual.Domain.Offers;
using FeriaVirtual.Business.Users;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.UtilForms {
    public partial class SearchProductForm:Form {

        private string idSelected;

        public Product ProductFound{get;set;}
        public bool IsFound{get;set;}

        public SearchProductForm() {
            InitializeComponent();
            this.IsFound= false;
        }

        private void SearchProductForm_Load(object sender,EventArgs e){
            this.Text = "Buscando productos.";
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadProducts(ListFilterComboBox.SelectedIndex);
        }

        private void ListFilterButton_Click(object sender,EventArgs e) {
            LoadProducts(ListFilterComboBox.SelectedIndex);
        }

        private void SearchAceptButton_Click(object sender,EventArgs e) {
            LoadProductInfo();
            IsFound = true;
            Close();
        }

        private void SearchCancelButton_Click(object sender,EventArgs e) {
            ProductFound = null;
            IsFound = false;
            Close();
        }

        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetRecordId();
        }

        private void ListDataGridView_DoubleClick(object sender,EventArgs e) {
            GetRecordId();
            LoadProductInfo();
            IsFound = true;
            Close();
        }

        private void LoadFilters(){
            FilterComboConfigurator configurator = FilterComboConfigurator.CreateConfigurator(this.ListFilterComboBox);
            IList<string> optionFilter = new List<string>(){ "Productos de exportación", "Productos de importación" };
            configurator.ClearFilters();
            configurator.LoadFilters(optionFilter);
        }

        private void LoadProducts(int filterType){
            try{
                var useCase = ProducerUseCase.CreateUseCase();
                ListDataGridView.DataSource = null;
                ListDataGridView.DataSource = useCase.SearchProductByCategory(filterType + 1);
                ConfigureGrid();
                DisplayCounts();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ConfigureGrid(){
            DataGridViewConfigurator  configurator = DataGridViewConfigurator.CreateConfigurator(this.ListDataGridView);
            IList<string> columns = new List<string>(){"id_producto", "id_cliente", "id_categoria", "Observacion" };
            configurator.HideColumns(columns);
        }

        private void DisplayCounts(){
            if (ListDataGridView.Rows.Count.Equals(0)){
                ListCountLabel.Text = $"No hay productos disponibles.";
                this.SearchAceptButton.Enabled= false;
            }
            else{
                this.SearchAceptButton.Enabled= true;
                ListCountLabel.Text = $"{ListDataGridView.Rows.Count.ToString()} productos encontrados.";
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }

        private void GetRecordId(){
            idSelected = string.Empty;
            if (ListDataGridView.Rows.Count.Equals(0)) return;
            var row = ListDataGridView.CurrentRow;
            if (row == null) return;
            row = ListDataGridView.CurrentRow;
            idSelected = row.Cells[0].Value.ToString();
        }

        private void LoadProductInfo(){
            if (this.ListDataGridView.Rows.Count.Equals(0)){
                this.ProductFound = null;
                return;
            }
            DataGridViewRow row = this.ListDataGridView.CurrentRow;
            ProductFound = Product.CreateProduct();
            ProductFound.ProductId = row.Cells["id_producto"].Value.ToString();
            ProductFound.ClientId = row.Cells["id_cliente"].Value.ToString();
            ProductFound.Category.CategoryId = int.Parse( row.Cells["id_categoria"].Value.ToString());
            ProductFound.Category.CategoryName = row.Cells["Categoria"].Value.ToString();
            ProductFound.ProductName = row.Cells["Producto"].Value.ToString();
            ProductFound.Observation = row.Cells["Observacion"].Value.ToString();
            ProductFound.ProductValue = float.Parse(row.Cells["Valor"].Value.ToString());
            ProductFound.ProductQuantity = float.Parse(row.Cells["Cantidad"].Value.ToString());
        }



    }
}
