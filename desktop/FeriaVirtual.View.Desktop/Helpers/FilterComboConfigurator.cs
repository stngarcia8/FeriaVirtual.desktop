using System.Collections.Generic;
using System.Windows.Forms;


namespace FeriaVirtual.View.Desktop.Helpers{

    public class FilterComboConfigurator{

        private readonly ComboBox comboBox;


        private FilterComboConfigurator(ComboBox comboBox){
            this.comboBox = comboBox;
        }


        public static FilterComboConfigurator CreateConfigurator(ComboBox comboBox){
            return new FilterComboConfigurator(comboBox);
        }


        public void ClearFilters(){
            comboBox.Items.Clear();
        }


        public void LoadFilters(IList<string> filterList){
            comboBox.BeginUpdate();
            foreach (var filterOption in filterList) comboBox.Items.Add(filterOption);
            comboBox.EndUpdate();
        }

    }

}