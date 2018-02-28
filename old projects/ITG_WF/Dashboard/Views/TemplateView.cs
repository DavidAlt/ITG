using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard.Views
{
    public partial class TemplateView : UserControl
    {
        public TemplateView()
        {
            InitializeComponent();
        }

        public void AssignTemplate(ITG.DataLayer.FormTemplate template)
        {
            pgrid.SelectedObject = template;
        }
    }
}
