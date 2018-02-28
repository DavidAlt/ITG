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
    public partial class MedcinBuilderView : UserControl, IView
    {
        #region PROPERTIES
        private string _name = "MedcinBuilder";
        string IView.Name
        {
            get { return _name; }
        }
        #endregion

        #region MEMBERS
        private MedcinViewModel vm;
        #endregion

        #region CONSTRUCTOR
        public MedcinBuilderView()
        {
            InitializeComponent();
            
            // Initialize the ViewModel and bind it to the lists
            vm = new MedcinViewModel();
            //binding = new BindingSource();
            //binding.DataSource = vm.MedcinObjects;
            MedcinList.DataSource = vm.MedcinObjects;
            MedcinList.DisplayMember = "Name";
            MedcinList.ValueMember = "Name";
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
        }

        private bool ValidateInput()
        {
            return true;
        }

        private void ResetFields()
        {
            // Empty all the fields and set the focus back on txtName
        }
        #endregion

        #region EVENT HANDLERS
        private void MedcinBuilderView_Load(object sender, EventArgs e)
        {
            cboTreeDepth.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Generates: A first chance exception of type 'System.ArgumentOutOfRangeException' occurred in System.Windows.Forms.dll

            // validate user input
            if(ValidateInput())
            {
                // create the MedcinObject from the fields
                MedcinObject m = new MedcinObject();
                m.Name = txtName.Text;
                m.Category = cboCategory.Text;
                m.TreeDepth = int.Parse(cboTreeDepth.Text);
                m.MedcinID = int.Parse(txtMedcinID.Text);
                m.Prefix = txtPrefix.Text;
                m.StateOneText = txtStateOne.Text;
                m.StateTwoText = txtStateTwo.Text;
                m.StateOneIsAbnormal = chkPositiveFinding.Checked;
                m.CustomTextReplacesDefault = chkUserTextOverrides.Checked;

                // pass it to the ViewModel
                vm.MedcinObjects.Add(m);

                // get ready to enter another item
                ResetFields();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MedcinList.SelectedItem != null)
            {
                vm.MedcinObjects.Remove(MedcinList.SelectedItem as MedcinObject);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            vm.MedcinObjects.Clear();
        }

        private void TextBoxSelectAll_Enter(object sender, EventArgs e)
        {
            // Kick off SelectAll asyncronously so that it occurs after Click
            BeginInvoke((Action)delegate
            {
                TextBox senderTextBox = sender as TextBox;
                senderTextBox.SelectAll();
            });
        }
        #endregion

    }
}
