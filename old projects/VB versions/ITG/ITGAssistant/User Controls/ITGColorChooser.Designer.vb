<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ITGColorChooser
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlColor = New System.Windows.Forms.Panel()
        Me.lblHex = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.clr = New System.Windows.Forms.ColorDialog()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlColor)
        Me.GroupBox2.Controls.Add(Me.lblHex)
        Me.GroupBox2.Controls.Add(Me.txtColor)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 80)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COLOR CODES"
        '
        'pnlColor
        '
        Me.pnlColor.Location = New System.Drawing.Point(102, 45)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.Size = New System.Drawing.Size(126, 22)
        Me.pnlColor.TabIndex = 4
        '
        'lblHex
        '
        Me.lblHex.AutoSize = True
        Me.lblHex.Location = New System.Drawing.Point(267, 24)
        Me.lblHex.Name = "lblHex"
        Me.lblHex.Size = New System.Drawing.Size(62, 13)
        Me.lblHex.TabIndex = 2
        Me.lblHex.Text = "RGB (hex): "
        '
        'txtColor
        '
        Me.txtColor.Location = New System.Drawing.Point(102, 19)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(126, 20)
        Me.txtColor.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(10, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 48)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Choose Color"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ITGColorChooser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ITGColorChooser"
        Me.Size = New System.Drawing.Size(493, 92)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlColor As System.Windows.Forms.Panel
    Friend WithEvents lblHex As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents clr As System.Windows.Forms.ColorDialog

End Class
