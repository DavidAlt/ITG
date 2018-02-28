namespace Dashboard.Views
{
    partial class TemplateView
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
            this.pgrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pgrid
            // 
            this.pgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgrid.Location = new System.Drawing.Point(0, 0);
            this.pgrid.Name = "pgrid";
            this.pgrid.Size = new System.Drawing.Size(602, 367);
            this.pgrid.TabIndex = 0;
            // 
            // TemplateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pgrid);
            this.Name = "TemplateView";
            this.Size = new System.Drawing.Size(602, 367);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgrid;
    }
}
