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
        Me.lblColor = New System.Windows.Forms.Label()
        Me.txtColorValue = New System.Windows.Forms.TextBox()
        Me.btnCToInt = New System.Windows.Forms.Button()
        Me.btnCToHex = New System.Windows.Forms.Button()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.pnlColor = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(13, 13)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(63, 13)
        Me.lblColor.TabIndex = 0
        Me.lblColor.Text = "Color value:"
        '
        'txtColorValue
        '
        Me.txtColorValue.Location = New System.Drawing.Point(79, 11)
        Me.txtColorValue.Name = "txtColorValue"
        Me.txtColorValue.Size = New System.Drawing.Size(100, 20)
        Me.txtColorValue.TabIndex = 1
        '
        'btnCToInt
        '
        Me.btnCToInt.Location = New System.Drawing.Point(186, 9)
        Me.btnCToInt.Name = "btnCToInt"
        Me.btnCToInt.Size = New System.Drawing.Size(50, 24)
        Me.btnCToInt.TabIndex = 2
        Me.btnCToInt.Text = "To Int"
        Me.btnCToInt.UseVisualStyleBackColor = True
        '
        'btnCToHex
        '
        Me.btnCToHex.Location = New System.Drawing.Point(243, 9)
        Me.btnCToHex.Name = "btnCToHex"
        Me.btnCToHex.Size = New System.Drawing.Size(50, 24)
        Me.btnCToHex.TabIndex = 3
        Me.btnCToHex.Text = "To Hex"
        Me.btnCToHex.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtResult.Location = New System.Drawing.Point(79, 38)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.Size = New System.Drawing.Size(100, 20)
        Me.txtResult.TabIndex = 5
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(13, 40)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(40, 13)
        Me.lblResult.TabIndex = 4
        Me.lblResult.Text = "Result:"
        '
        'pnlColor
        '
        Me.pnlColor.BackColor = System.Drawing.SystemColors.Control
        Me.pnlColor.Location = New System.Drawing.Point(186, 38)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.Size = New System.Drawing.Size(107, 20)
        Me.pnlColor.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(266, 52)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "This tool has no error checking! You are forewarned." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enter the color value EITHE" & _
    "R as the int found in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "an AHLTA template, OR as an RRGGBB value (no #), " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and h" & _
    "it the appropriate button."
        '
        'fMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 138)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlColor)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.btnCToHex)
        Me.Controls.Add(Me.btnCToInt)
        Me.Controls.Add(Me.txtColorValue)
        Me.Controls.Add(Me.lblColor)
        Me.Name = "fMain"
        Me.Text = "AHLTA Color Converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtColorValue As System.Windows.Forms.TextBox
    Friend WithEvents btnCToInt As System.Windows.Forms.Button
    Friend WithEvents btnCToHex As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents pnlColor As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
