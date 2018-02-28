Imports ITG.Utility
Public Class ITGColorChooser

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If clr.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtColor.Text = ITGColorConverter.ConvertColorToAhlta(clr.Color)
            pnlColor.BackColor = clr.Color
            lblHex.Text = "Hex: " & ITGColorConverter.ConvertColorToHex(clr.Color, False)
        End If
    End Sub
End Class
