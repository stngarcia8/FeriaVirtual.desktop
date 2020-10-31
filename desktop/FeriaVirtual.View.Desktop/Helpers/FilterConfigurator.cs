using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.View.Desktop.Helpers {

    public class FilterConfigurator {

        private ComboBox comboBox;

        private FilterConfigurator(ComboBox comboBox) {
            this.comboBox = comboBox;
        }

        public static FilterConfigurator CreateConfigurator(ComboBox comboBox) {
            return new FilterConfigurator(comboBox);
        }

        public void ClearFilters() {
            this.comboBox.Items.Clear();
        }

        public void LoadFilters(IList<String> filterList) {
            this.comboBox.BeginUpdate();
            foreach(string filterOption in filterList) {
                this.comboBox.Items.Add(filterOption);
            }
            this.comboBox.EndUpdate();
        }


    }

}
