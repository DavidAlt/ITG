using System;
using System.Windows.Forms;

namespace GlacialSystems.ITG
{
    public partial class MainWindow : Form
    {
        private StateMachine sm;
        
        public MainWindow()
        {
            InitializeComponent();
            InitializeStateMachine();

            // Setup the ViewSelector combobox and display the HomeView
            ViewSelector.DataSource = sm.Views;
            ViewSelector.DisplayMember = "Name";
            ViewSelector.SelectedIndex = 0;
        }

        private void InitializeStateMachine()
        {
            sm = new StateMachine();
            sm.Views.Add(new HomeView());
            sm.Views.Add(new MedcinBuilderView());
        }

        private void SwitchView(UserControl view)
        {
            // Ensure the main window stays the appropriate size
            System.Drawing.Size ItFits = new System.Drawing.Size((Shell.Panel1MinSize + 30 + view.MinimumSize.Width), (menuStrip1.Height + statusStrip1.Height + view.MinimumSize.Height));
            this.MinimumSize = ItFits;
            Shell.Panel2.Controls.Clear();
            view.Dock = DockStyle.Fill;
            Shell.Panel2.Controls.Add(view);
        }

        private void ViewSelector_SelectionChanged(object sender, EventArgs e)
        {
            UserControl SelectedView = ViewSelector.SelectedItem as UserControl;
            SwitchView(SelectedView);
        }
    }
}
