using System.Collections.Generic;
using System.Windows.Forms;


namespace FeriaVirtual.View.Desktop.Helpers {

    public class FilterNodeConfigurator {

        private TreeNode rootNode;


        private FilterNodeConfigurator(string rootText,IEnumerable<string> optionList) {
            ConfigureRootNode(rootText);
            ConfigureChildNodes(optionList);
        }


        private void ConfigureRootNode(string rootText) {
            rootNode = new TreeNode {
                Text = rootText,
                Tag = 0
            };
            rootNode.Expand();
        }


        private void ConfigureChildNodes(IEnumerable<string> optionList) {
            foreach(var option in optionList) {
                var childNode = new TreeNode { Text = option };
                rootNode.Nodes.Add(childNode);
            }
        }


        public static FilterNodeConfigurator CreateConfigurator(string rootText,IList<string> optionList) {
            return new FilterNodeConfigurator(rootText,optionList);
        }


        public TreeNode GetNodes() {
            return rootNode;
        }

    }

}