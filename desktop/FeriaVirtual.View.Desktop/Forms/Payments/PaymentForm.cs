using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Payments{

    public partial class PaymentForm : Form{

        private string IdOrderSelected;

        private string idSelected;
        private int nodeIndex;


        public PaymentForm(){
            InitializeComponent();
            idSelected = string.Empty;
            IdOrderSelected = string.Empty;
        }


        private void PaymentForm_Load(object sender, EventArgs e){
            ConfigureForm();
            ListDataGridView.Focus();
        }


        private void OptionRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadPayments(nodeIndex);
            ListDataGridView.Focus();
        }


        private void OptionCloseToolStripMenuItem_Click(object sender, EventArgs e){
            Close();
        }


        private void OptionsFilterTreeView_AfterSelect(object sender, TreeViewEventArgs e){
            if (e.Node.Level.Equals(0)) return;

            ListTitleLabel.Text = $"Lista de {e.Node.Text}";
            nodeIndex = e.Node.Index;
            LoadPayments(nodeIndex);
        }


        private void ListDataGridView_SelectionChanged(object sender, EventArgs e){
            GetRecordId();
        }


        private void PaymentContextMenuStrip_Opening(object sender, CancelEventArgs e){
            var areThereRecords = !ListDataGridView.Rows.Count.Equals(0);
            PaymentShowDetailsToolStripMenuItem.Visible = areThereRecords;
        }


        private void PaymentRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadPayments(nodeIndex);
            ListDataGridView.Focus();
        }


        private void PaymentShowDetailsToolStripMenuItem_Click(object sender, EventArgs e){
            OpenPaymentShowDetail(nodeIndex.Equals(0) || nodeIndex.Equals(1));
        }


        private void ConfigureForm(){
            LoadFilters();
            LoadPayments(nodeIndex);
        }


        private void LoadFilters(){
            OptionsFilterTreeView.BeginUpdate();
            OptionsFilterTreeView.Nodes.Clear();
            IList<string> filterOptions = new List<string>{
                "Pagos clientes externos", "Pagos clientes internos",
                "Pagos notificados clientes externos", "Pagos notificados clientes internos"
            };
            var configurator =
                FilterNodeConfigurator.CreateConfigurator("Pagos", filterOptions);
            OptionsFilterTreeView.Nodes.Add(configurator.GetNodes());
            OptionsFilterTreeView.ExpandAll();
            OptionsFilterTreeView.SelectedNode = OptionsFilterTreeView.Nodes[0];
            OptionsFilterTreeView.Select();
            OptionsFilterTreeView.Focus();
            OptionsFilterTreeView.EndUpdate();
        }


        private void LoadPayments(int filterType){
            try{
                var usecase = PaymentUsecase.CreateUsecase();
                ListDataGridView.DataSource = null;
                ListDataGridView.DataSource = usecase.GetPaymentByEstatus(nodeIndex);
                ConfigurePaymentGrid();
            }
            catch (Exception ex){
                ListDataGridView.DataSource = null;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ConfigurePaymentGrid(){
            var configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
            IList<string> columns = new List<string>{
                "id_pago", "id_pedido", "id_cliente", "id_rol", "id_condicion", "id_metpago",
                "pago_notificado", "Notificacion", "tipo usuario", "Condicion pago",
                "desc_metpago", "Neto", "IVA", "Porcentaje descuento", "Descuento", "email"
            };
            configurator.HideColumns(columns);
            configurator.ChangeHeader("Observacion", "Observación");
            configurator.CurrencyColumn("Total a pagar", "Pago");
            DisplayCounts();
        }


        private void DisplayCounts(){
            if (ListDataGridView.Rows.Count.Equals(0)){
                ListCountLabel.Text = "No hay pagos disponibles.";
                PropertiesDataGridView.Rows.Clear();
            }
            else{
                ListCountLabel.Text = $"{ListDataGridView.Rows.Count.ToString()} pagos encontrados.";
                ListDataGridView.Rows[0].Selected = true;
                ListDataGridView.Rows[0].Cells[3].Selected = true;
                ListDataGridView.Focus();
            }
        }


        private void GetRecordId(){
            idSelected = string.Empty;
            if (ListDataGridView.Rows.Count.Equals(0)) return;

            var row = ListDataGridView.CurrentRow;
            if (row == null) return;

            idSelected = row.Cells[0].Value.ToString();
            IdOrderSelected = row.Cells[1].Value.ToString();
            LoadBasicProperties(row);
        }


        private void LoadBasicProperties(DataGridViewRow row){
            PropertiesDataGridView.Rows.Clear();
            PropertiesDataGridView.Rows.Add("Cliente", row.Cells["Cliente"].Value);
            PropertiesDataGridView.Rows.Add("Email", row.Cells["email"].Value);
            PropertiesDataGridView.Rows.Add("Tipo cliente", row.Cells["tipo usuario"].Value);
            PropertiesDataGridView.Rows.Add("Fecha de pago", row.Cells["Fecha pago"].Value);
            PropertiesDataGridView.Rows.Add("Hora", row.Cells["Hora pago"].Value);
            PropertiesDataGridView.Rows.Add("Condición de pago", row.Cells["Condicion pago"].Value);
            PropertiesDataGridView.Rows.Add("Metodo de pago", row.Cells["desc_metpago"].Value);
            PropertiesDataGridView.Rows.Add("Valor neto", row.Cells["Neto"].Value);
            PropertiesDataGridView.Rows.Add("IVA", row.Cells["IVA"].Value);
            if (int.Parse(row.Cells["Porcentaje descuento"].Value.ToString()) > 0){
                PropertiesDataGridView.Rows.Add("Descuento aplicado", row.Cells["Porcentaje descuento"].Value);
                PropertiesDataGridView.Rows.Add("Valor descuento", row.Cells["Descuento"].Value);
            }
            PropertiesDataGridView.Rows.Add("Total pagado", row.Cells["Total a pagar"].Value);
            PropertiesDataGridView.Rows.Add("Observación", row.Cells["Observacion"].Value);
        }


        private void OpenPaymentShowDetail(bool isNew){
            var form = new PaymentDetailsForm{
                IsNew = isNew,
                IdSelected = idSelected,
                IdOrderSelected = IdOrderSelected
            };
            form.ShowDialog();
            if (form.IsSaved){
                LoadPayments(nodeIndex);
                ListDataGridView.Focus();
            }
        }

    }

}