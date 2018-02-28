Public Class fMain

    Private Sub btnColorChooser_Click(sender As Object, e As EventArgs) Handles btnColorChooser.Click
        pnlUC.Controls.Clear()
        pnlUC.Controls.Add(New ITGColorChooser())
        statusLoaded.Text = "ITG Color Chooser"
    End Sub

    Private Sub btnDefaultTextFormatter_Click(sender As Object, e As EventArgs) Handles btnDefaultTextFormatter.Click
        pnlUC.Controls.Clear()
        pnlUC.Controls.Add(New ITGDefaultTextFormatter())
        statusLoaded.Text = "ITG Default Text Formatter"
    End Sub

    Private Sub btnControlDecoder_Click(sender As Object, e As EventArgs) Handles btnControlDecoder.Click
        pnlUC.Controls.Clear()
        pnlUC.Controls.Add(New ITGControlDecoder())
        statusLoaded.Text = "ITG Control Decoder"
        ' pnlUC.Controls.Item(0).Dock = DockStyle.Fill
    End Sub

    Private Sub btnTabSorter_Click(sender As Object, e As EventArgs) Handles btnTabSorter.Click
        pnlUC.Controls.Clear()
        pnlUC.Controls.Add(New ITGTabSorter())
        statusLoaded.Text = "ITG Tab Sorter"
    End Sub

    Private Sub btnDataGridView_Click(sender As Object, e As EventArgs) Handles btnDataGridView.Click
        pnlUC.Controls.Clear()
        pnlUC.Controls.Add(New ITGDataGridView())
        statusLoaded.Text = "ITG Data Grid View"
    End Sub
End Class
