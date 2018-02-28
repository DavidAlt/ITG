<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fColorConverter
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
        Me.clrDialog = New System.Windows.Forms.ColorDialog()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.pnlColor = New System.Windows.Forms.Panel()
        Me.pnlVerify = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(12, 12)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(75, 54)
        Me.btnColor.TabIndex = 0
        Me.btnColor.Text = "Choose color"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'txtColor
        '
        Me.txtColor.Location = New System.Drawing.Point(95, 40)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(145, 20)
        Me.txtColor.TabIndex = 1
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(93, 19)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(151, 13)
        Me.lblColor.TabIndex = 2
        Me.lblColor.Text = "Equivalent AHLTA color code:"
        '
        'pnlColor
        '
        Me.pnlColor.Location = New System.Drawing.Point(250, 12)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.Size = New System.Drawing.Size(76, 54)
        Me.pnlColor.TabIndex = 3
        '
        'pnlVerify
        '
        Me.pnlVerify.Location = New System.Drawing.Point(252, 88)
        Me.pnlVerify.Name = "pnlVerify"
        Me.pnlVerify.Size = New System.Drawing.Size(76, 54)
        Me.pnlVerify.TabIndex = 4
        '
        'fColorConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 154)
        Me.Controls.Add(Me.pnlVerify)
        Me.Controls.Add(Me.pnlColor)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.btnColor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "fColorConverter"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "AHLTA Color Converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents clrDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents pnlColor As System.Windows.Forms.Panel
    Friend WithEvents pnlVerify As System.Windows.Forms.Panel
End Class
