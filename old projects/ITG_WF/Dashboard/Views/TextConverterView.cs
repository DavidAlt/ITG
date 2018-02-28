using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextOps = ITG.Utilities.TextOps;

namespace Dashboard.Views
{
    public partial class TextConverterView : UserControl
    {
        public TextConverterView()
        {
            InitializeComponent();
        }

        private void chkWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            txtContent.WordWrap = chkWordWrap.Checked;
            txtOutput.WordWrap = chkWordWrap.Checked;
        }

        private void UpdateOutput(object sender, EventArgs e)
        {
            if (txtContent.Text == "")
            {
                txtOutput.Text = "\"" + txtCaption.Text + "\"";
            }
            else
            {
                txtOutput.Text = "\"" + txtCaption.Text + "~" + TextOps.ToggleLineReturn(txtContent.Text) + "\"";
            }
        }

    }
}
