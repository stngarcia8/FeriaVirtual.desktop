using System;
using FeriaVirtual.View.Desktop.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeriaVirtual.View.Desktop.Forms.Orders {

    public partial class AuctionForm:Form {


        // Properties
        public string IdSelected { get; set; }
        public bool IsSaved { get; set; }
        public bool IsNewRecord { get; set; }
        public Auction CurrentAuction { get; set; }

        public AuctionForm() {
            InitializeComponent();
            this.IsSaved= false;
        }

        private void AuctionForm_Load(object sender,EventArgs e) {
            if(IsNewRecord) {
                ConfigureFormForNewAuction();
            } else {
                ConfigureFormFromEditAuction();
            }
        }

        private void ProposeValueNumericUpDown_ValueChanged(object sender,EventArgs e) {
            CalculateTransportPercentValue();
        }

        private void AuctionSaveButton_Click(object sender,EventArgs e) {
if(!this.SaveAuction()) {
                return;
            }
            this.IsSaved= true;
            this.Close();
        }

        private void AuctionCancelButton_Click(object sender,EventArgs e) {
            this.IsSaved=false;
            this.Close();
        }

        private void ConfigureFormForNewAuction() {
            this.ProposeValueNumericUpDown.Value=10;
            this.LimitDateDateTimePicker.MinDate= DateTime.Now.Date;
            this.LimitDateDateTimePicker.Value= DateTime.Now.Date;
            FillInitialControls();
            this.ProductWeightTextBox.Text = CalculateTotals("Cantidad solicitada").ToString();
            this.ProductValueTextBox.Text = CalculateTotals("Total").ToString();
            this.CalculateTransportPercentValue();
        }


        private void FillInitialControls() {
            LoadProposeProduct propose = LoadProposeProduct.OpenPropose(this.ProductDataGridView, this.IdSelected);
            propose.Execute();
        }

        private int CalculateTotals(string field) {
            return this.ProductDataGridView.Rows.Cast<DataGridViewRow>()
                                   .Sum(t => Convert.ToInt32(t.Cells[field].Value));
        }

        private void ConfigureFormFromEditAuction() {
            this.AuctionSaveButton.Text= "Editar publicación";
            this.LimitDateDateTimePicker.MinDate= CurrentAuction.LimitDate;
            this.LimitDateDateTimePicker.Value= CurrentAuction.LimitDate;
            FillInitialControls();
            this.ProposeValueNumericUpDown.Value = Decimal.Parse(CurrentAuction.Percent.ToString());
            this.ProductWeightTextBox.Text = CurrentAuction.Weight.ToString();
            this.ProductValueTextBox.Text = CurrentAuction.Value.ToString();
            this.ObservationTextBox.Text = CurrentAuction.Observation;
            this.CalculateTransportPercentValue();
        }

        private void CalculateTransportPercentValue() {
            this.ProposeValueTextBox.Text= ((int.Parse(this.ProductValueTextBox.Text) * this.ProposeValueNumericUpDown.Value)/100).ToString();
        }

        private bool SaveAuction() {
            bool result = false;
            try {
                CurrentAuction = PutsControlsDataIntoAuctionObject();
                OrderUseCase usecase = OrderUseCase.CreateUseCase();
                if(IsNewRecord) {
                    usecase.NewAuction(CurrentAuction,this.IdSelected);
                } else {
                    usecase.EditAuction(CurrentAuction,this.IdSelected);
                }
                string message = string.Format("La subasta fue {0} correctamente.", (IsNewRecord?"creada":"actualizada"));
                MessageBox.Show(message,"Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
                result= true;
            } catch (Exception ex) {
                result= false;
                MessageBox.Show(ex.Message.ToString(),"Atención",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            return result;
        }

        private Auction PutsControlsDataIntoAuctionObject() {
            Auction a = Auction.CreateAuction();
            a.AuctionDate = DateTime.Now.Date;
            a.LimitDate = this.LimitDateDateTimePicker.Value;
            a.Status = 0;
            a.Percent =float.Parse(this.ProposeValueNumericUpDown.Value.ToString());
            a.Value = float.Parse(this.ProposeValueTextBox.Text);
            a.Weight=float.Parse(this.ProductWeightTextBox.Text);
            a.Observation = this.ObservationTextBox.Text;
            return a;
        }


    }
}
