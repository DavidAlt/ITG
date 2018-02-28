<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tester
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
        Me.b1 = New System.Windows.Forms.Button()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'b1
        '
        Me.b1.Location = New System.Drawing.Point(221, 10)
        Me.b1.Name = "b1"
        Me.b1.Size = New System.Drawing.Size(75, 23)
        Me.b1.TabIndex = 0
        Me.b1.Text = "Button1"
        Me.b1.UseVisualStyleBackColor = True
        '
        't1
        '
        Me.t1.Location = New System.Drawing.Point(12, 12)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(192, 20)
        Me.t1.TabIndex = 1
        '
        't2
        '
        Me.t2.Location = New System.Drawing.Point(12, 47)
        Me.t2.Multiline = True
        Me.t2.Name = "t2"
        Me.t2.ReadOnly = True
        Me.t2.Size = New System.Drawing.Size(535, 211)
        Me.t2.TabIndex = 2
        '
        'Tester
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 288)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.b1)
        Me.Name = "Tester"
        Me.Text = "Tester"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b1 As System.Windows.Forms.Button
    Friend WithEvents t1 As System.Windows.Forms.TextBox
    Friend WithEvents t2 As System.Windows.Forms.TextBox

End Class
