<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fMain
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
        Me.pnlDashboard = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnColorChooser = New System.Windows.Forms.Button()
        Me.btnDefaultTextFormatter = New System.Windows.Forms.Button()
        Me.btnControlDecoder = New System.Windows.Forms.Button()
        Me.pnlUC = New System.Windows.Forms.Panel()
        Me.btnTabSorter = New System.Windows.Forms.Button()
        Me.btnDataGridView = New System.Windows.Forms.Button()
        Me.status = New System.Windows.Forms.StatusStrip()
        Me.statusLoaded = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlDashboard.SuspendLayout()
        Me.status.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDashboard
        '
        Me.pnlDashboard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlDashboard.Controls.Add(Me.btnColorChooser)
        Me.pnlDashboard.Controls.Add(Me.btnDefaultTextFormatter)
        Me.pnlDashboard.Controls.Add(Me.btnControlDecoder)
        Me.pnlDashboard.Controls.Add(Me.btnTabSorter)
        Me.pnlDashboard.Controls.Add(Me.btnDataGridView)
        Me.pnlDashboard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlDashboard.Location = New System.Drawing.Point(0, 0)
        Me.pnlDashboard.Name = "pnlDashboard"
        Me.pnlDashboard.Size = New System.Drawing.Size(128, 450)
        Me.pnlDashboard.TabIndex = 0
        '
        'btnColorChooser
        '
        Me.btnColorChooser.AutoSize = True
        Me.btnColorChooser.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnColorChooser.Location = New System.Drawing.Point(3, 3)
        Me.btnColorChooser.Name = "btnColorChooser"
        Me.btnColorChooser.Size = New System.Drawing.Size(122, 23)
        Me.btnColorChooser.TabIndex = 0
        Me.btnColorChooser.Text = "Color Chooser"
        Me.btnColorChooser.UseVisualStyleBackColor = True
        '
        'btnDefaultTextFormatter
        '
        Me.btnDefaultTextFormatter.AutoSize = True
        Me.btnDefaultTextFormatter.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDefaultTextFormatter.Location = New System.Drawing.Point(3, 32)
        Me.btnDefaultTextFormatter.Name = "btnDefaultTextFormatter"
        Me.btnDefaultTextFormatter.Size = New System.Drawing.Size(122, 23)
        Me.btnDefaultTextFormatter.TabIndex = 1
        Me.btnDefaultTextFormatter.Text = "Default Text Formatter"
        Me.btnDefaultTextFormatter.UseVisualStyleBackColor = True
        '
        'btnControlDecoder
        '
        Me.btnControlDecoder.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnControlDecoder.Location = New System.Drawing.Point(3, 61)
        Me.btnControlDecoder.Name = "btnControlDecoder"
        Me.btnControlDecoder.Size = New System.Drawing.Size(122, 23)
        Me.btnControlDecoder.TabIndex = 2
        Me.btnControlDecoder.Text = "Control Decoder"
        Me.btnControlDecoder.UseVisualStyleBackColor = True
        '
        'pnlUC
        '
        Me.pnlUC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlUC.Location = New System.Drawing.Point(128, 0)
        Me.pnlUC.Name = "pnlUC"
        Me.pnlUC.Size = New System.Drawing.Size(771, 450)
        Me.pnlUC.TabIndex = 1
        '
        'btnTabSorter
        '
        Me.btnTabSorter.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnTabSorter.Location = New System.Drawing.Point(3, 90)
        Me.btnTabSorter.Name = "btnTabSorter"
        Me.btnTabSorter.Size = New System.Drawing.Size(122, 23)
        Me.btnTabSorter.TabIndex = 3
        Me.btnTabSorter.Text = "Tab Sorter"
        Me.btnTabSorter.UseVisualStyleBackColor = True
        '
        'btnDataGridView
        '
        Me.btnDataGridView.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDataGridView.Location = New System.Drawing.Point(3, 119)
        Me.btnDataGridView.Name = "btnDataGridView"
        Me.btnDataGridView.Size = New System.Drawing.Size(122, 23)
        Me.btnDataGridView.TabIndex = 4
        Me.btnDataGridView.Text = "Data Grid View"
        Me.btnDataGridView.UseVisualStyleBackColor = True
        '
        'status
        '
        Me.status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLoaded})
        Me.status.Location = New System.Drawing.Point(0, 453)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(889, 22)
        Me.status.TabIndex = 2
        Me.status.Text = "StatusStrip1"
        '
        'statusLoaded
        '
        Me.statusLoaded.Name = "statusLoaded"
        Me.statusLoaded.Size = New System.Drawing.Size(237, 17)
        Me.statusLoaded.Text = "Select a button from the left to load a utility"
        '
        'fMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 475)
        Me.Controls.Add(Me.pnlDashboard)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.pnlUC)
        Me.Name = "fMain"
        Me.Text = "ITG Assistant"
        Me.pnlDashboard.ResumeLayout(False)
        Me.pnlDashboard.PerformLayout()
        Me.status.ResumeLayout(False)
        Me.status.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlDashboard As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnColorChooser As System.Windows.Forms.Button
    Friend WithEvents pnlUC As System.Windows.Forms.Panel
    Friend WithEvents btnDefaultTextFormatter As System.Windows.Forms.Button
    Friend WithEvents btnControlDecoder As System.Windows.Forms.Button
    Friend WithEvents btnTabSorter As System.Windows.Forms.Button
    Friend WithEvents btnDataGridView As System.Windows.Forms.Button
    Friend WithEvents status As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLoaded As System.Windows.Forms.ToolStripStatusLabel

End Class
