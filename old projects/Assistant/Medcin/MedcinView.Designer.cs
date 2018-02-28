namespace GlacialSystems.ITG
{
    partial class MedcinBuilderView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAdd = new System.Windows.Forms.Button();
            this.MedcinPanel = new System.Windows.Forms.Panel();
            this.lblUID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkUserTextOverrides = new System.Windows.Forms.CheckBox();
            this.chkPositiveFinding = new System.Windows.Forms.CheckBox();
            this.txtStateTwo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStateOne = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTreeDepth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtMedcinID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ListPanel = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.MedcinList = new System.Windows.Forms.ListBox();
            this.MedcinTreeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MedcinListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemove = new System.Windows.Forms.Button();
            this.medcinViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MedcinPanel.SuspendLayout();
            this.ListPanel.SuspendLayout();
            this.MedcinTreeContext.SuspendLayout();
            this.MedcinListContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medcinViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(264, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MedcinPanel
            // 
            this.MedcinPanel.Controls.Add(this.btnAdd);
            this.MedcinPanel.Controls.Add(this.lblUID);
            this.MedcinPanel.Controls.Add(this.label8);
            this.MedcinPanel.Controls.Add(this.chkUserTextOverrides);
            this.MedcinPanel.Controls.Add(this.chkPositiveFinding);
            this.MedcinPanel.Controls.Add(this.txtStateTwo);
            this.MedcinPanel.Controls.Add(this.label7);
            this.MedcinPanel.Controls.Add(this.txtStateOne);
            this.MedcinPanel.Controls.Add(this.label6);
            this.MedcinPanel.Controls.Add(this.cboTreeDepth);
            this.MedcinPanel.Controls.Add(this.label5);
            this.MedcinPanel.Controls.Add(this.label4);
            this.MedcinPanel.Controls.Add(this.txtPrefix);
            this.MedcinPanel.Controls.Add(this.label3);
            this.MedcinPanel.Controls.Add(this.cboCategory);
            this.MedcinPanel.Controls.Add(this.txtMedcinID);
            this.MedcinPanel.Controls.Add(this.label2);
            this.MedcinPanel.Controls.Add(this.txtName);
            this.MedcinPanel.Controls.Add(this.label1);
            this.MedcinPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MedcinPanel.Location = new System.Drawing.Point(0, 0);
            this.MedcinPanel.Name = "MedcinPanel";
            this.MedcinPanel.Size = new System.Drawing.Size(355, 275);
            this.MedcinPanel.TabIndex = 1;
            // 
            // lblUID
            // 
            this.lblUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUID.BackColor = System.Drawing.SystemColors.Control;
            this.lblUID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUID.Location = new System.Drawing.Point(247, 12);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(88, 23);
            this.lblUID.TabIndex = 30;
            this.lblUID.Text = "<UID>";
            this.lblUID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(219, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "UID:  ";
            // 
            // chkUserTextOverrides
            // 
            this.chkUserTextOverrides.AutoSize = true;
            this.chkUserTextOverrides.Location = new System.Drawing.Point(15, 220);
            this.chkUserTextOverrides.Name = "chkUserTextOverrides";
            this.chkUserTextOverrides.Size = new System.Drawing.Size(169, 17);
            this.chkUserTextOverrides.TabIndex = 9;
            this.chkUserTextOverrides.Text = "User text overrides default text";
            this.chkUserTextOverrides.UseVisualStyleBackColor = true;
            // 
            // chkPositiveFinding
            // 
            this.chkPositiveFinding.AutoSize = true;
            this.chkPositiveFinding.Checked = true;
            this.chkPositiveFinding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPositiveFinding.Location = new System.Drawing.Point(15, 196);
            this.chkPositiveFinding.Name = "chkPositiveFinding";
            this.chkPositiveFinding.Size = new System.Drawing.Size(308, 17);
            this.chkPositiveFinding.TabIndex = 8;
            this.chkPositiveFinding.Text = "State one represents a positive finding or the abnormal state";
            this.chkPositiveFinding.UseVisualStyleBackColor = true;
            // 
            // txtStateTwo
            // 
            this.txtStateTwo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStateTwo.Location = new System.Drawing.Point(154, 156);
            this.txtStateTwo.Name = "txtStateTwo";
            this.txtStateTwo.Size = new System.Drawing.Size(181, 20);
            this.txtStateTwo.TabIndex = 7;
            this.txtStateTwo.Enter += new System.EventHandler(this.TextBoxSelectAll_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Text when state two active";
            // 
            // txtStateOne
            // 
            this.txtStateOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStateOne.Location = new System.Drawing.Point(154, 124);
            this.txtStateOne.Name = "txtStateOne";
            this.txtStateOne.Size = new System.Drawing.Size(181, 20);
            this.txtStateOne.TabIndex = 6;
            this.txtStateOne.Enter += new System.EventHandler(this.TextBoxSelectAll_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Text when state one active";
            // 
            // cboTreeDepth
            // 
            this.cboTreeDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTreeDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTreeDepth.FormattingEnabled = true;
            this.cboTreeDepth.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboTreeDepth.Location = new System.Drawing.Point(289, 39);
            this.cboTreeDepth.MaxLength = 1;
            this.cboTreeDepth.Name = "cboTreeDepth";
            this.cboTreeDepth.Size = new System.Drawing.Size(46, 21);
            this.cboTreeDepth.Sorted = true;
            this.cboTreeDepth.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tree Depth";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Prefix";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrefix.Location = new System.Drawing.Point(289, 73);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(46, 20);
            this.txtPrefix.TabIndex = 5;
            this.txtPrefix.Enter += new System.EventHandler(this.TextBoxSelectAll_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Medcin ID";
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(91, 39);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(103, 21);
            this.cboCategory.TabIndex = 2;
            // 
            // txtMedcinID
            // 
            this.txtMedcinID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedcinID.Location = new System.Drawing.Point(91, 73);
            this.txtMedcinID.Name = "txtMedcinID";
            this.txtMedcinID.Size = new System.Drawing.Size(103, 20);
            this.txtMedcinID.TabIndex = 4;
            this.txtMedcinID.Text = "0";
            this.txtMedcinID.Enter += new System.EventHandler(this.TextBoxSelectAll_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Category";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(91, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(103, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Enter += new System.EventHandler(this.TextBoxSelectAll_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name";
            // 
            // ListPanel
            // 
            this.ListPanel.Controls.Add(this.btnRemove);
            this.ListPanel.Controls.Add(this.btnClear);
            this.ListPanel.Controls.Add(this.btnImport);
            this.ListPanel.Controls.Add(this.btnExport);
            this.ListPanel.Controls.Add(this.MedcinList);
            this.ListPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ListPanel.Location = new System.Drawing.Point(355, 0);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(200, 275);
            this.ListPanel.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(118, 242);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear list";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(6, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.TabStop = false;
            this.btnImport.Text = "Import list";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(118, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Export list";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // MedcinList
            // 
            this.MedcinList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MedcinList.FormattingEnabled = true;
            this.MedcinList.Location = new System.Drawing.Point(3, 39);
            this.MedcinList.Name = "MedcinList";
            this.MedcinList.Size = new System.Drawing.Size(190, 186);
            this.MedcinList.TabIndex = 1;
            this.MedcinList.TabStop = false;
            // 
            // MedcinTreeContext
            // 
            this.MedcinTreeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemToolStripMenuItem1});
            this.MedcinTreeContext.Name = "MedcinTreeContext";
            this.MedcinTreeContext.Size = new System.Drawing.Size(135, 26);
            // 
            // deleteItemToolStripMenuItem1
            // 
            this.deleteItemToolStripMenuItem1.Name = "deleteItemToolStripMenuItem1";
            this.deleteItemToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.deleteItemToolStripMenuItem1.Text = "Delete item";
            // 
            // MedcinListContext
            // 
            this.MedcinListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemToolStripMenuItem});
            this.MedcinListContext.Name = "MedcinListContext";
            this.MedcinListContext.Size = new System.Drawing.Size(135, 26);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete item";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.AutoSize = true;
            this.btnRemove.Location = new System.Drawing.Point(6, 242);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(79, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Remove item";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // medcinViewModelBindingSource
            // 
            this.medcinViewModelBindingSource.DataSource = typeof(GlacialSystems.ITG.MedcinViewModel);
            // 
            // MedcinBuilderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MedcinPanel);
            this.Controls.Add(this.ListPanel);
            this.MinimumSize = new System.Drawing.Size(555, 275);
            this.Name = "MedcinBuilderView";
            this.Size = new System.Drawing.Size(555, 275);
            this.Load += new System.EventHandler(this.MedcinBuilderView_Load);
            this.MedcinPanel.ResumeLayout(false);
            this.MedcinPanel.PerformLayout();
            this.ListPanel.ResumeLayout(false);
            this.ListPanel.PerformLayout();
            this.MedcinTreeContext.ResumeLayout(false);
            this.MedcinListContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.medcinViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MedcinPanel;
        private System.Windows.Forms.CheckBox chkUserTextOverrides;
        private System.Windows.Forms.CheckBox chkPositiveFinding;
        private System.Windows.Forms.TextBox txtStateTwo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStateOne;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTreeDepth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtMedcinID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ListPanel;
        private System.Windows.Forms.ListBox MedcinList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip MedcinTreeContext;
        private System.Windows.Forms.ContextMenuStrip MedcinListContext;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.BindingSource medcinViewModelBindingSource;
        private System.Windows.Forms.Button btnRemove;

    }
}
