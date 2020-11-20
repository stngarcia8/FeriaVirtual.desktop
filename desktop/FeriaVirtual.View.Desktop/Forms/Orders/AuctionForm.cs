using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FeriaVirtual.Business.Orders;
using FeriaVirtual.Domain.Orders;
using FeriaVirtual.View.Desktop.Commands;


namespace FeriaVirtual.View.Desktop.Forms.Orders{

    public partial class AuctionForm : Form{

        // Properties
        public string IdSelected{ get; set; }
        public bool IsSaved{ get; set; }
        public bool IsNewRecord{ get; set; }
        public Auction CurrentAuction{ get; set; }


        public AuctionForm(){
            InitializeComponent();
            IsSaved = false;
        }


        private void AuctionForm_Load(object sender, EventArgs e){
            if (IsNewRecord)
                ConfigureFormForNewAuction();
            else
                ConfigureFormFromEditAuction();
        }


        private void ProposeValueNumericUpDown_ValueChanged(object sender, EventArgs e){
            CalculateTransportPercentValue();
        }


        private void AuctionSaveButton_Click(object sender, EventArgs e){
            if (!SaveAuction()) return;
            IsSaved = true;
            Close();
        }


        private void AuctionCancelButton_Click(object sender, EventArgs e){
            IsSaved = false;
            Close();
        }


        private void ConfigureFormForNewAuction(){
            ProposeValueNumericUpDown.Value = 10;
            LimitDateDateTimePicker.MinDate = DateTime.Now.Date;
            LimitDateDateTimePicker.Value = DateTime.Now.Date;
            FillInitialControls();
            ProductWeightTextBox.Text = CalculateTotals("Cantidad solicitada").ToString();
            ProductValueTextBox.Text = CalculateTotals("Total").ToString();
            CalculateTransportPercentValue();
        }


        private void FillInitialControls(){
            var propose = LoadProposeProduct.OpenPropose(ProductDataGridView, IdSelected, true);
            propose.Execute();
        }


        private int CalculateTotals(string field){
            return ProductDataGridView.Rows.Cast<DataGridViewRow>()
                .Sum(t => Convert.ToInt32(t.Cells[field].Value));
        }


        private void ConfigureFormFromEditAuction(){
            AuctionSaveButton.Text = "Editar publicación";
            LimitDateDateTimePicker.MinDate = CurrentAuction.LimitDate;
            LimitDateDateTimePicker.Value = CurrentAuction.LimitDate;
            FillInitialControls();
            ProposeValueNumericUpDown.Value = decimal.Parse(CurrentAuction.Percent.ToString("n2"));
            ProductWeightTextBox.Text = CurrentAuction.Weight.ToString("N");
            ProductValueTextBox.Text = CurrentAuction.Value.ToString("N");
            ObservationTextBox.Text = CurrentAuction.Observation;
            CalculateTransportPercentValue();
        }


        private void CalculateTransportPercentValue(){
            try{
                float productValue = float.Parse(ProductValueTextBox.Text);
                float percent = float.Parse(ProposeValueNumericUpDown.Value.ToString());
                ProposeValueTextBox.Text = ((productValue * percent)/100 ).ToString();
            }
            catch{
                ProposeValueTextBox.Text = "0";
            }
        }


        private bool SaveAuction(){
            bool result;
            try{
                CurrentAuction = PutsControlsDataIntoAuctionObject();
                var usecase = AuctionUseCase.CreateUseCase();
                if (IsNewRecord)
                    usecase.NewAuction(CurrentAuction, IdSelected);
                else
                    usecase.EditAuction(CurrentAuction, IdSelected);
                var message = $"La subasta fue {(IsNewRecord ? "creada" : "actualizada")} correctamente.";
                MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = true;
            }
            catch (Exception ex){
                result = false;
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }


        private Auction PutsControlsDataIntoAuctionObject(){
            var a = Auction.CreateAuction();
            a.AuctionDate = DateTime.Now.Date;
            a.LimitDate = LimitDateDateTimePicker.Value;
            a.Status = 0;
            a.Percent = float.Parse(ProposeValueNumericUpDown.Value.ToString(CultureInfo.CurrentCulture));
            a.Value = float.Parse(ProposeValueTextBox.Text);
            a.Weight = float.Parse(ProductWeightTextBox.Text);
            a.Observation = ObservationTextBox.Text;
            return a;
        }

    }

}