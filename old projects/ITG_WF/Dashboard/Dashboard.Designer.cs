namespace Dashboard
{
    partial class Dashboard
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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHomeView = new System.Windows.Forms.Button();
            this.btnColorConverterView = new System.Windows.Forms.Button();
            this.btnTextConverterView = new System.Windows.Forms.Button();
            this.btnTemplateView = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(798, 24);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.StatusBar.Location = new System.Drawing.Point(0, 434);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(798, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(798, 410);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(96, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(702, 410);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnHomeView);
            this.pnlLeft.Controls.Add(this.btnColorConverterView);
            this.pnlLeft.Controls.Add(this.btnTextConverterView);
            this.pnlLeft.Controls.Add(this.btnTemplateView);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(96, 410);
            this.pnlLeft.TabIndex = 0;
            // 
            // btnHomeView
            // 
            this.btnHomeView.AutoSize = true;
            this.btnHomeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHomeView.Location = new System.Drawing.Point(3, 3);
            this.btnHomeView.Name = "btnHomeView";
            this.btnHomeView.Size = new System.Drawing.Size(90, 23);
            this.btnHomeView.TabIndex = 0;
            this.btnHomeView.Text = "HomeView";
            this.btnHomeView.UseVisualStyleBackColor = true;
            this.btnHomeView.Click += new System.EventHandler(this.btnHomeView_Click);
            // 
            // btnColorConverterView
            // 
            this.btnColorConverterView.AutoSize = true;
            this.btnColorConverterView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnColorConverterView.Location = new System.Drawing.Point(3, 32);
            this.btnColorConverterView.Name = "btnColorConverterView";
            this.btnColorConverterView.Size = new System.Drawing.Size(90, 23);
            this.btnColorConverterView.TabIndex = 1;
            this.btnColorConverterView.Text = "Color Converter";
            this.btnColorConverterView.UseVisualStyleBackColor = true;
            this.btnColorConverterView.Click += new System.EventHandler(this.btnColorConverterView_Click);
            // 
            // btnTextConverterView
            // 
            this.btnTextConverterView.AutoSize = true;
            this.btnTextConverterView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTextConverterView.Location = new System.Drawing.Point(3, 61);
            this.btnTextConverterView.Name = "btnTextConverterView";
            this.btnTextConverterView.Size = new System.Drawing.Size(90, 23);
            this.btnTextConverterView.TabIndex = 2;
            this.btnTextConverterView.Text = "Text Converter";
            this.btnTextConverterView.UseVisualStyleBackColor = true;
            this.btnTextConverterView.Click += new System.EventHandler(this.btnTextConverterView_Click);
            // 
            // btnTemplateView
            // 
            this.btnTemplateView.AutoSize = true;
            this.btnTemplateView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTemplateView.Location = new System.Drawing.Point(3, 90);
            this.btnTemplateView.Name = "btnTemplateView";
            this.btnTemplateView.Size = new System.Drawing.Size(90, 23);
            this.btnTemplateView.TabIndex = 3;
            this.btnTemplateView.Text = "View Template";
            this.btnTemplateView.UseVisualStyleBackColor = true;
            this.btnTemplateView.Click += new System.EventHandler(this.btnTemplateView_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 456);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Dashboard";
            this.Text = "ITG Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnHomeView;
        private System.Windows.Forms.Button btnColorConverterView;
        private System.Windows.Forms.Button btnTextConverterView;
        private System.Windows.Forms.Button btnTemplateView;

    }
}

