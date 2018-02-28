Imports ITG.Utility

Public Class fColorConverter
    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim argb, ahlta As Integer
        Dim hex, hexA As String

        If clrDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            pnlColor.BackColor = clrDialog.Color

            ' ahlta = ITG.Utility.ITGColorConverter.ConvertColorToAhlta(clrDialog.Color)
            ' argb = ITG.Utility.ITGColorConverter.ConvertColorToArgb(clrDialog.Color)
            ' hex = ITG.Utility.ITGColorConverter.ConvertColorToHex(clrDialog.Color, False)
            ' hexA = ITG.Utility.ITGColorConverter.ConvertColorToHex(clrDialog.Color, True)
        End If

        argb = -128
        ahlta = 8454143
        hex = "FFFF80"
        hexA = "FFFFFF80"

        ' pnlVerify.BackColor = ITG.Utility.ITGColorConverter.ConvertArgbToColor(argb)
        ' pnlVerify.BackColor = ITG.Utility.ITGColorConverter.ConvertAhltaToColor(ahlta)
        ' pnlVerify.BackColor = ITG.Utility.ITGColorConverter.ConvertHexToColor(hex, False)
        ' pnlVerify.BackColor = ITG.Utility.ITGColorConverter.ConvertHexToColor(hexA, True)

        Console.WriteLine("ConvertArgbToAhlta: " & ITG.Utility.ITGColorConverter.ConvertArgbToAhlta(argb).ToString())
        Console.WriteLine("ConvertAhltaToArgb: " & ITG.Utility.ITGColorConverter.ConvertAhltaToArgb(ahlta).ToString())

        ' pnlVerify.BackColor = ITG.Utility.ITGColorConverter.ConvertIntToColor(ITG.Utility.ITGColorConverter.ConvertColorToInt(clrDialog.Color))


    End Sub
End Class