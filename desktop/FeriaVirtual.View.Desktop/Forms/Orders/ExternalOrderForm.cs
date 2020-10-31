using System;
using System.Collections.Generic;
using FeriaVirtual.View.Desktop.Helpers;
using System.ComponentModel;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Orders {
    public partial class ExternalOrderForm:Form {

        private string idSelected;
        private int userRolID = 3;

        public ExternalOrderForm() {
            InitializeComponent();
            this.idSelected= string.Empty;
        }

        private void ExternalOrderForm_Load(object sender,EventArgs e) {
            this.ConfigureForm();
            
            this.ListDataGridView.Focus();
        }

        private void OptionRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadOrders(ListFilterComboBox.SelectedIndex);
        }

        private void OptionCloseToolStripMenuItem_Click(object sender,EventArgs e) {
            this.Close();
        }

        private void ListFilterButton_Click(object sender,EventArgs e) {
            LoadOrders(ListFilterComboBox.SelectedIndex);
        }

        private void ListDataGridView_SelectionChanged(object sender,EventArgs e) {
            GetRecordId();
        }

        private void ConfigureForm() {
            LoadFilters();
            ListFilterComboBox.SelectedIndex = 0;
            LoadOrders(0);
        }

        private void LoadFilters() {
            ListFilterComboBox.BeginUpdate();
            ListFilterComboBox.Items.Clear();
            ListFilterComboBox.Items.Add("Nuevas ordenes ingresadas");
            ListFilterComboBox.Items.Add("Ordenes de compras en proceso");
            ListFilterComboBox.Items.Add("Ordenes en proceso");
            ListFilterComboBox.Items.Add("Ordenes finalizadas");
            ListFilterComboBox.Items.Add("Ordenes anuladas");
            ListFilterComboBox.Items.Add("Ordenes rechazadas");
            ListFilterComboBox.EndUpdate();
        }

        private void LoadOrders(int filterType) {
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                ListDataGridView.DataSource = null;
                ListDataGridView.DataSource = usecase.GetOrderByStatus((filterType+1),userRolID);
                DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
                IList<string> columns = new List<string>() { "id_pedido", "id_cliente", "id_estado", "id_condicion", "id_rol" };
                configurator.HideColumns(columns);
                configurator.ChangeHeader("Observacion","Observación");
                configurator.NumericColumn("Descuento","Descuento solicitado");
                DisplayCounts();
            } catch(Exception ex) {
                ListDataGridView.DataSource=null;
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void DisplayCounts() {
            if(ListDataGridView.Rows.Count.Equals(0)) {
                ListCountLabel.Text = "No hay ordenes de compras disponibles.";
            } else {
                ListCountLabel.Text = string.Format("{0} ordenes de compras encontradas.",ListDataGridView.Rows.Count.ToString());
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Focus();
            }
        }

        private void GetRecordId() {
            idSelected = string.Empty;
            if(ListDataGridView.Rows.Count.Equals(0)) {
                return;
            }
            DataGridViewRow row = ListDataGridView.CurrentRow;
            if(row == null) {
                return;
            }
            idSelected=  row.Cells[0].Value.ToString();
            LoadProperties(row);
            LoadOrderDetail(idSelected);
        }

        private void LoadOrderDetail(string orderID) {
            try {
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                ProductDataGridView.DataSource = null;
                ProductDataGridView.DataSource = usecase.GetOrderDetailByID(orderID);
                DataGridViewConfigurator configurator = DataGridViewConfigurator.CreateConfigurator(ProductDataGridView);
                IList<string> columns = new List<string>() { "id", "id_pedido" };
                configurator.HideColumns(columns);
                configurator.NumericColumn("Cantidad","Cantidad solicitada");
            } catch(Exception ex) {
                ProductDataGridView.DataSource= null;
                MessageBox.Show(ex.Message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void LoadProperties(DataGridViewRow row) {
            PropertiesDataGridView.Rows.Clear();
            PropertiesDataGridView.Rows.Add("Cliente",row.Cells[7].Value);
            PropertiesDataGridView.Rows.Add("Fecha pedido",row.Cells[4].Value);
            PropertiesDataGridView.Rows.Add("Condición de pago",row.Cells[3].Value);
            PropertiesDataGridView.Rows.Add("Descuento solicitado",row.Cells[5].Value+"%");
            PropertiesDataGridView.Rows.Add("Observaciön",row.Cells[6].Value);
        }

        private void OrderContextMenuStrip_Opening(object sender,CancelEventArgs e) {
            bool thereAreRecords = !this.ListDataGridView.Rows.Count.Equals(0);
            this.OrderDistributeToolStripMenuItem.Enabled=thereAreRecords && this.ListFilterComboBox.SelectedIndex.Equals(0);
            this.OrderAuctionToolStripMenuItem.Enabled = thereAreRecords && this.ListFilterComboBox.SelectedIndex.Equals(1);
        }

        private void OrderRefreshToolStripMenuItem_Click(object sender,EventArgs e) {
            LoadOrders(ListFilterComboBox.SelectedIndex);
            this.ListDataGridView.Focus();
        }

        private void OrderDistributeToolStripMenuItem_Click(object sender,EventArgs e) {
            ProposeProductsForm form = new ProposeProductsForm();
            form.IdSelected= this.idSelected;
            form.ShowDialog();
            if(form.IsSaved) {
                this.LoadOrders(0);
            }
        }




    }
}
