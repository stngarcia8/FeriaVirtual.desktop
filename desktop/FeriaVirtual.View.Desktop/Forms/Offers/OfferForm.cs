using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using FeriaVirtual.Business.Offers;
using FeriaVirtual.View.Desktop.Helpers;


namespace FeriaVirtual.View.Desktop.Forms.Offers{

    public partial class OfferForm : Form{

        private string idSelected;
        private int nodeIndex;


        public OfferForm(){
            InitializeComponent();
            idSelected = string.Empty;
        }


        private void OfferForm_Load(object sender, EventArgs e){
            ConfigureForm();
            ListDataGridView.Focus();
        }


        private void OptionRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadOffers(nodeIndex);
            ListDataGridView.Focus();
        }


        private void OptionCloseToolStripMenuItem_Click(object sender, EventArgs e){
            Close();
        }


        private void OptionsFilterTreeView_AfterSelect(object sender, TreeViewEventArgs e){
            if (e.Node.Level.Equals(0)) return;

            ListTitleLabel.Text = $"Lista de {e.Node.Text}";
            nodeIndex = e.Node.Index;
            LoadOffers(nodeIndex);
        }


        private void ListDataGridView_SelectionChanged(object sender, EventArgs e){
            GetRecordId();
        }


        private void OrderContextMenuStrip_Opening(object sender, CancelEventArgs e){
            var areThereRecords = !ListDataGridView.Rows.Count.Equals(0);
            OfferNewToolStripMenuItem.Enabled = nodeIndex.Equals(0);
            OfferEditToolStripMenuItem.Enabled = areThereRecords && (nodeIndex.Equals(0) || nodeIndex.Equals(1));
            OfferCloseToolStripMenuItem.Visible = areThereRecords && nodeIndex.Equals(0);
            OfferReopenToolStripMenuItem.Visible = areThereRecords && nodeIndex.Equals(1);
            OfferDeleteToolStripMenuItem.Enabled = areThereRecords && nodeIndex.Equals(1);
        }


        private void OfferRefreshToolStripMenuItem_Click(object sender, EventArgs e){
            LoadOffers(nodeIndex);
            ListDataGridView.Focus();
        }


        private void OfferNewToolStripMenuItem_Click(object sender, EventArgs e){
            OpenSimplyOfferForm(true);
        }


        private void OfferEditToolStripMenuItem_Click(object sender, EventArgs e){
            GetRecordId();
            OpenSimplyOfferForm(false);
        }


        private void OfferCloseToolStripMenuItem_Click(object sender, EventArgs e){
            if (CloseAnOffer(true)){
                LoadOffers(nodeIndex);
                ListDataGridView.Focus();
            }
        }


        private void OfferReopenToolStripMenuItem_Click(object sender, EventArgs e){
            if (CloseAnOffer(false)){
                LoadOffers(nodeIndex);
                ListDataGridView.Focus();
            }
        }


        private void OfferDeleteToolStripMenuItem_Click(object sender, EventArgs e){
            if (DeleteAnOffer()){
                LoadOffers(nodeIndex);
                ListDataGridView.Focus();
            }
        }


        private void ConfigureForm(){
            LoadFilters();
            LoadOffers(nodeIndex);
        }


        private void LoadFilters(){
            OptionsFilterTreeView.BeginUpdate();
            OptionsFilterTreeView.Nodes.Clear();
            IList<string> filterOptions = new List<string>{
                "Ofertas publicadas", "Ofertas cerradas"
            };
            var configurator =
                FilterNodeConfigurator.CreateConfigurator("Ofertas", filterOptions);
            OptionsFilterTreeView.Nodes.Add(configurator.GetNodes());
            OptionsFilterTreeView.ExpandAll();
            OptionsFilterTreeView.SelectedNode = OptionsFilterTreeView.Nodes[0];
            OptionsFilterTreeView.Select();
            OptionsFilterTreeView.Focus();
            OptionsFilterTreeView.EndUpdate();
        }


        private void LoadOffers(int filterType){
            try{
                var usecase = OfferUseCase.CreateUsecase();
                ListDataGridView.DataSource = null;
                ListDataGridView.DataSource = usecase.FindOffersByStatus(nodeIndex + 1);
                var configurator = DataGridViewConfigurator.CreateConfigurator(ListDataGridView);
                IList<string> columns = new List<string>{
                    "id_oferta", "estado_oferta", "tipo_oferta"
                };
                configurator.HideColumns(columns);
                configurator.ChangeHeader("Descripcion", "Descripción");
                configurator.ChangeHeader("Fecha publicacion", "Fecha publicación");
                configurator.NumericColumn("Descuento", "Descuento");
                DisplayCounts();
            }
            catch (Exception ex){
                ListDataGridView.DataSource = null;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void DisplayCounts(){
            if (ListDataGridView.Rows.Count.Equals(0)){
                ListCountLabel.Text = "No hay ofertas disponibles.";
                PropertiesDataGridView.Rows.Clear();
                ProductDataGridView.DataSource = null;
            }
            else{
                ListCountLabel.Text = $"{ListDataGridView.Rows.Count.ToString()} ofertas encontradas.";
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
            LoadBasicProperties(row);
            LoadOfferDetails(idSelected);
        }


        private void LoadBasicProperties(DataGridViewRow row){
            PropertiesDataGridView.Rows.Clear();
            PropertiesDataGridView.Rows.Add("Tipo publicación", row.Cells["Tipo"].Value);
            PropertiesDataGridView.Rows.Add("Publicada el", row.Cells["Fecha publicacion"].Value);
            PropertiesDataGridView.Rows.Add("Estado", row.Cells["Estado"].Value);
            PropertiesDataGridView.Rows.Add("Descuento", $"{row.Cells["Descuento"].Value}%");
            PropertiesDataGridView.Rows.Add("Descripción", row.Cells["Descripcion"].Value);
        }


        private void LoadOfferDetails(string idSelected){
            try{
                var usecase = OfferUseCase.CreateUsecase();
                ProductDataGridView.DataSource = null;
                ProductDataGridView.DataSource = usecase.FindOfferDetailByOffer(idSelected);
                ConfigureOrderDetailsGrid();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ConfigureOrderDetailsGrid(){
            var configurator = DataGridViewConfigurator.CreateConfigurator(ProductDataGridView);
            IList<string> columns = new List<string>{"id_detalle", "id_oferta", "id_producto", "Descuento aplicado"};
            configurator.HideColumns(columns);
            configurator.CurrencyColumn("valor_original", "Precio inicial");
            configurator.CurrencyColumn("Valor oferta", "Precio Oferta");
        }


        private void OpenSimplyOfferForm(bool isNew){
            var form = new SimplyOfferForm{IsNewRecord = isNew, IdSelected = idSelected};
            form.ShowDialog();
            if (form.IsSaved){
                LoadOffers(nodeIndex);
                ListDataGridView.Focus();
            }
        }


        private bool CloseAnOffer(bool closeOffer){
            string message;
            DialogResult result;
            var operationResult = false;
            message = "¿Esta seguro(a) de cerrar la oferta seleccionada?";
            result = MessageBox.Show(message, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.No)) return false;

            try{
                var usecase = OfferUseCase.CreateUsecase();
                if (closeOffer){
                    usecase.DisableOffer(idSelected);
                    message = "La oferta fue cerrada correctamente.";
                }
                else{
                    usecase.EnableOffer(idSelected);
                    message = "La oferta fue habilitada nuevamente.";
                }
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                operationResult = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                operationResult = false;
            }
            return operationResult;
        }


        private bool DeleteAnOffer(){
            string message;
            DialogResult result;
            var operationResult = false;
            message = "¿Esta seguro(a) de eliminar la oferta seleccionada?";
            result = MessageBox.Show(message, "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.No)) return false;

            try{
                var usecase = OfferUseCase.CreateUsecase();
                usecase.DeleteOffer(idSelected);
                message = "La oferta fue eliminada correctamente.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                operationResult = true;
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                operationResult = false;
            }
            return operationResult;
        }

    }

}