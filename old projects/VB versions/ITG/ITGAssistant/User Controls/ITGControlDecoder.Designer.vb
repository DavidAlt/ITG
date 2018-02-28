<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ITGControlDecoder
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFlagOutput = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtFlags = New System.Windows.Forms.TextBox()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.list = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.list)
        Me.GroupBox1.Controls.Add(Me.txtFlagOutput)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 550)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Generate code"
        '
        'txtFlagOutput
        '
        Me.txtFlagOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlagOutput.Location = New System.Drawing.Point(7, 518)
        Me.txtFlagOutput.Name = "txtFlagOutput"
        Me.txtFlagOutput.ReadOnly = True
        Me.txtFlagOutput.Size = New System.Drawing.Size(190, 20)
        Me.txtFlagOutput.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Controls.Add(Me.txtFlags)
        Me.GroupBox2.Controls.Add(Me.txtValue)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Location = New System.Drawing.Point(206, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 550)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Generate flags"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(164, 37)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(46, 20)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtFlags
        '
        Me.txtFlags.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFlags.Location = New System.Drawing.Point(10, 63)
        Me.txtFlags.Multiline = True
        Me.txtFlags.Name = "txtFlags"
        Me.txtFlags.ReadOnly = True
        Me.txtFlags.Size = New System.Drawing.Size(200, 474)
        Me.txtFlags.TabIndex = 2
        '
        'txtValue
        '
        Me.txtValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtValue.Location = New System.Drawing.Point(10, 37)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(147, 20)
        Me.txtValue.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter the integer representing the controls"
        '
        'list
        '
        Me.list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.list.FormattingEnabled = True
        Me.list.Location = New System.Drawing.Point(7, 20)
        Me.list.Name = "list"
        Me.list.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.list.Size = New System.Drawing.Size(190, 485)
        Me.list.TabIndex = 2
        '
        'ITGControlDecoder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MinimumSize = New System.Drawing.Size(430, 100)
        Me.Name = "ITGControlDecoder"
        Me.Size = New System.Drawing.Size(432, 550)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFlagOutput As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtFlags As System.Windows.Forms.TextBox
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents list As System.Windows.Forms.ListBox

End Class
