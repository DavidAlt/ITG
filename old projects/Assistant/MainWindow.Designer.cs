namespace GlacialSystems.ITG
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Shell = new System.Windows.Forms.SplitContainer();
            this.ViewSelector = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Shell)).BeginInit();
            this.Shell.Panel1.SuspendLayout();
            this.Shell.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(602, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel1.Text = "Some text here";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(602, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Shell
            // 
            this.Shell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Shell.IsSplitterFixed = true;
            this.Shell.Location = new System.Drawing.Point(0, 24);
            this.Shell.Name = "Shell";
            // 
            // Shell.Panel1
            // 
            this.Shell.Panel1.Controls.Add(this.ViewSelector);
            this.Shell.Panel1MinSize = 100;
            this.Shell.Size = new System.Drawing.Size(602, 410);
            this.Shell.SplitterDistance = 100;
            this.Shell.TabIndex = 2;
            this.Shell.TabStop = false;
            // 
            // ViewSelector
            // 
            this.ViewSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewSelector.FormattingEnabled = true;
            this.ViewSelector.Location = new System.Drawing.Point(0, 0);
            this.ViewSelector.Name = "ViewSelector";
            this.ViewSelector.Size = new System.Drawing.Size(100, 410);
            this.ViewSelector.TabIndex = 2;
            this.ViewSelector.TabStop = false;
            this.ViewSelector.SelectedIndexChanged += new System.EventHandler(this.ViewSelector_SelectionChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(602, 456);
            this.Controls.Add(this.Shell);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "ITG Assistant";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Shell.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Shell)).EndInit();
            this.Shell.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer Shell;
        private System.Windows.Forms.ListBox ViewSelector;


    }
}

