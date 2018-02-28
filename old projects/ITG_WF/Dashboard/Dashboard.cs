using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dashboard.Views;

namespace Dashboard
{
    public partial class Dashboard : Form
    {
        private StateMachine sm;

        public Dashboard()
        {
            InitializeComponent();
            sm = new StateMachine();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (sm.HomeView == null)
            {
                sm.HomeView = new HomeView();
            }
            SwitchView(sm.HomeView);
        }

        private void SwitchView(Control view)
        {
            pnlRight.Controls.Clear();
            view.Dock = DockStyle.Fill;
            pnlRight.Controls.Add(view);
        }

        private void btnHomeView_Click(object sender, EventArgs e)
        {
            if (sm.HomeView == null)
            {
                sm.HomeView = new HomeView();
            }
            SwitchView(sm.HomeView);
        }

        private void btnColorConverterView_Click(object sender, EventArgs e)
        {
            if (sm.ColorConverterView == null)
            {
                sm.ColorConverterView = new ColorConverterView();
            }
            SwitchView(sm.ColorConverterView);
        }

        private void btnTextConverterView_Click(object sender, EventArgs e)
        {
            if (sm.TextConverterView == null)
            {
                sm.TextConverterView = new TextConverterView();
            }
            SwitchView(sm.TextConverterView);
        }

        private void btnTemplateView_Click(object sender, EventArgs e)
        {
            if (sm.TemplateView == null)
            {
                sm.TemplateView = new TemplateView();
            }
            SwitchView(sm.TemplateView);

        }
    }
}
