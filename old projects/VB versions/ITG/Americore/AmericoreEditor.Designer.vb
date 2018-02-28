<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AmericoreEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoformatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstructionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutAmericoreEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.splitter = New System.Windows.Forms.SplitContainer()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.txtPreview = New System.Windows.Forms.RichTextBox()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.listSelector = New System.Windows.Forms.ListBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.WordwrapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.splitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitter.Panel1.SuspendLayout()
        Me.splitter.Panel2.SuspendLayout()
        Me.splitter.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1061, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem1, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Enabled = False
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.OpenToolStripMenuItem.Text = "Open..."
        Me.OpenToolStripMenuItem.ToolTipText = "Feature not implemented"
        '
        'SaveToolStripMenuItem1
        '
        Me.SaveToolStripMenuItem1.Enabled = False
        Me.SaveToolStripMenuItem1.Name = "SaveToolStripMenuItem1"
        Me.SaveToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+S"
        Me.SaveToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.SaveToolStripMenuItem1.Text = "Save"
        Me.SaveToolStripMenuItem1.ToolTipText = "Feature not implemented"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Enabled = False
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        Me.SaveAsToolStripMenuItem.ToolTipText = "Feature not implemented"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoformatToolStripMenuItem, Me.WordwrapToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'AutoformatToolStripMenuItem
        '
        Me.AutoformatToolStripMenuItem.CheckOnClick = True
        Me.AutoformatToolStripMenuItem.Enabled = False
        Me.AutoformatToolStripMenuItem.Name = "AutoformatToolStripMenuItem"
        Me.AutoformatToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AutoformatToolStripMenuItem.Text = "Autoformat"
        Me.AutoformatToolStripMenuItem.ToolTipText = "Feature not implemented"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstructionsToolStripMenuItem, Me.ToolStripSeparator3, Me.AboutAmericoreEditorToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'InstructionsToolStripMenuItem
        '
        Me.InstructionsToolStripMenuItem.Enabled = False
        Me.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem"
        Me.InstructionsToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.InstructionsToolStripMenuItem.Text = "Instructions"
        Me.InstructionsToolStripMenuItem.ToolTipText = "Feature not implemented"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(196, 6)
        '
        'AboutAmericoreEditorToolStripMenuItem
        '
        Me.AboutAmericoreEditorToolStripMenuItem.Enabled = False
        Me.AboutAmericoreEditorToolStripMenuItem.Name = "AboutAmericoreEditorToolStripMenuItem"
        Me.AboutAmericoreEditorToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AboutAmericoreEditorToolStripMenuItem.Text = "About Americore Editor"
        Me.AboutAmericoreEditorToolStripMenuItem.ToolTipText = "Feature not implemented"
        '
        'splitter
        '
        Me.splitter.BackColor = System.Drawing.SystemColors.Control
        Me.splitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitter.Location = New System.Drawing.Point(158, 24)
        Me.splitter.Name = "splitter"
        '
        'splitter.Panel1
        '
        Me.splitter.Panel1.Controls.Add(Me.txtContent)
        Me.splitter.Panel1MinSize = 180
        '
        'splitter.Panel2
        '
        Me.splitter.Panel2.Controls.Add(Me.txtPreview)
        Me.splitter.Panel2MinSize = 5
        Me.splitter.Size = New System.Drawing.Size(903, 393)
        Me.splitter.SplitterDistance = 452
        Me.splitter.TabIndex = 3
        '
        'txtContent
        '
        Me.txtContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtContent.Location = New System.Drawing.Point(0, 0)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtContent.Size = New System.Drawing.Size(452, 393)
        Me.txtContent.TabIndex = 2
        '
        'txtPreview
        '
        Me.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPreview.Location = New System.Drawing.Point(0, 0)
        Me.txtPreview.Name = "txtPreview"
        Me.txtPreview.ReadOnly = True
        Me.txtPreview.Size = New System.Drawing.Size(447, 393)
        Me.txtPreview.TabIndex = 0
        Me.txtPreview.Text = ""
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.txtAuthor)
        Me.pnlLeft.Controls.Add(Me.txtName)
        Me.pnlLeft.Controls.Add(Me.btnExport)
        Me.pnlLeft.Controls.Add(Me.listSelector)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 24)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(158, 393)
        Me.pnlLeft.TabIndex = 2
        '
        'listSelector
        '
        Me.listSelector.FormattingEnabled = True
        Me.listSelector.Items.AddRange(New Object() {"Chief complaint", "History of present illness", "Additional HPI", "Complete ROS", "Focused ROS", "Allergies", "Medications", "Medical history", "Surgical history", "Family history", "Social history", "Immunizations", "Birth history", "Practice management", "Anticipatory guidance", "Diet", "Lifestyle", "HEADSSS", "Depression screening", "Physical exam - infant", "Physical exam - child"})
        Me.listSelector.Location = New System.Drawing.Point(12, 64)
        Me.listSelector.Name = "listSelector"
        Me.listSelector.Size = New System.Drawing.Size(133, 290)
        Me.listSelector.TabIndex = 0
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(24, 360)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(104, 23)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "Export Template"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(13, 10)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(132, 20)
        Me.txtName.TabIndex = 2
        Me.txtName.Text = "Template Name"
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAuthor
        '
        Me.txtAuthor.Location = New System.Drawing.Point(12, 36)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(133, 20)
        Me.txtAuthor.TabIndex = 3
        Me.txtAuthor.Text = "Author"
        Me.txtAuthor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WordwrapToolStripMenuItem
        '
        Me.WordwrapToolStripMenuItem.Checked = True
        Me.WordwrapToolStripMenuItem.CheckOnClick = True
        Me.WordwrapToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.WordwrapToolStripMenuItem.Name = "WordwrapToolStripMenuItem"
        Me.WordwrapToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WordwrapToolStripMenuItem.Text = "Word Wrap"
        '
        'AmericoreEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 417)
        Me.Controls.Add(Me.splitter)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(640, 455)
        Me.Name = "AmericoreEditor"
        Me.Text = "Americore Editor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.splitter.Panel1.ResumeLayout(False)
        Me.splitter.Panel1.PerformLayout()
        Me.splitter.Panel2.ResumeLayout(False)
        CType(Me.splitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitter.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeft.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents splitter As System.Windows.Forms.SplitContainer
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents txtPreview As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents listSelector As System.Windows.Forms.ListBox
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoformatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstructionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutAmericoreEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents WordwrapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
