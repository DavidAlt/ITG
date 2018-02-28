using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ITG.Desktop.DesignerItems;
using ITG.Common;

namespace ITG.Desktop
{
    /// <summary>
    /// Interaction logic for ChooseMedcinTermDialog.xaml
    /// </summary>
    public partial class ChooseMedcinTermDialog : Window
    {

        public ChooseMedcinTermDialog(DesignerItemBaseVM item)
        {
            InitializeComponent();
            this.DataContext = item;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            // combobox.Focus();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public MedcinTerm Result
        { get; set; }

    
        
    }
}
