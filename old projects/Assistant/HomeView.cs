using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlacialSystems.ITG
{
    public partial class HomeView : UserControl, IView
    {
        private string _name = "Home";
        
        public HomeView()
        {
            InitializeComponent();
        }

        string IView.Name
        {
            get
            {
                return _name;
            }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
