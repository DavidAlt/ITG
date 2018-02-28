Imports ITG.Utility

Public Class ITGDefaultTextFormatter

    Private Sub UpdateOutput(send As Object, e As EventArgs) Handles txtContent.TextChanged, txtCaption.TextChanged
        txtOutput.Text = """" & txtCaption.Text & "~" & ITGTextConverter.ToggleLineReturn(txtContent.Text) & """"
    End Sub


End Class
