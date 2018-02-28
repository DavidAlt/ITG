Imports ITG

Public Class ITGControlDecoder

    Private Sub ITGControlDecoder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'chklist.Items.AddRange([Enum].GetValues(GetType(ITGComponent).ToString()))
        For Each i In [Enum].GetValues(GetType(ITGComponent))
            list.Items.Add(i)
        Next
        ' txtFlagOutput.Text = "None"
    End Sub



    Private Sub list_MouseDown(sender As Object, e As MouseEventArgs) Handles list.MouseDown
        Dim result As ITGComponent = 0
        If list.SelectedItems.Count <> 0 Then
            For i As Integer = 0 To (list.SelectedItems.Count - 1)
                result = result Or list.SelectedItems.Item(i)
            Next
        End If
        txtFlagOutput.Text = Conversion.Int(result).ToString()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim result As New ITGComponent()
        result = Convert.ToInt32(txtValue.Text)
        txtFlags.Text = result.ToString()
    End Sub
End Class
