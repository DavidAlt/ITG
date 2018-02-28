Public Class fMain

    Private Sub btnCToHex_Click(sender As Object, e As EventArgs) Handles btnCToHex.Click

        ' Needs error checking

        ' Convert the AHLTA int to reversed hex
        Dim BBGGRR As String = Conversion.Hex(CInt(txtColorValue.Text))

        ' Parse the reversed hex value
        Dim BB, GG, RR As String
        BB = Mid(BBGGRR, 1, 2)
        GG = Mid(BBGGRR, 3, 2)
        RR = Mid(BBGGRR, 5, 2)

        Dim iRR, iGG, iBB As Integer
        iRR = Val("&H" & RR)
        iGG = Val("&H" & GG)
        iBB = Val("&H" & BB)

        ' Reverse from BGR to RGB
        Dim RRGGBB As String = RR & GG & BB

        ' Display the RGB hex value
        txtResult.Text = RRGGBB

        ' Display the color represented by the original AHLTA int
        pnlColor.BackColor = System.Drawing.Color.FromArgb(iRR, iGG, iBB)

    End Sub

    Private Sub btnCToInt_Click(sender As Object, e As EventArgs) Handles btnCToInt.Click

        ' Needs error checking

        ' Reverse the hex to BBGGRR
        Dim RRGGBB, BBGGRR, RR, GG, BB As String
        RRGGBB = txtColorValue.Text
        RR = Mid(RRGGBB, 1, 2)
        GG = Mid(RRGGBB, 3, 2)
        BB = Mid(RRGGBB, 5, 2)
        BBGGRR = BB & GG & RR

        ' Convert the BBGGRR hex to int
        Dim iColor As Integer = Convert.ToInt32(BBGGRR, 16)

        Dim iRR, iGG, iBB As Integer
        iRR = Val("&H" & RR)
        iGG = Val("&H" & GG)
        iBB = Val("&H" & BB)

        ' Display the int color value
        txtResult.Text = iColor

        ' Display the color on the panel
        pnlColor.BackColor = System.Drawing.Color.FromArgb(IRR, iGG, iBB)

    End Sub
End Class
