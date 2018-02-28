Namespace Utility

    Public Class ITGColorConverter
        ' For the purposes of this class,
        ' ... Color represents a System.Drawing.Color object
        ' ... Argb represents a 32-bit signed Integer, with the 4 bytes representing Alpha, Red, Green, Blue
        ' ... Ahlta represents an unsigned Integer, as AHLTA will not correctly interpret negative integers into colors
        ' ... Hex represents either a 6-character string (RRGGBB) or an 8-character string (AARRGGBB)
        ' For conversions requiring multiple steps, Hex is used as the intermediary

        ' Convert COLOR objects
        Public Shared Function ConvertColorToAhlta(ByVal c As System.Drawing.Color) As Integer
            Dim hex As String = ConvertColorToHex(c, False)
            Dim i As Integer = ConvertHexToAhlta(hex, False)
            Debug.WriteLine("Function ConvertColorToAhlta(Color) returns: " & i.ToString())
            Return i
        End Function 'done

        Public Shared Function ConvertColorToArgb(ByVal c As System.Drawing.Color) As Integer
            ' Acts as a wrapper for the built-in function
            Debug.WriteLine("Function ConvertColorToArgb(Color) returns: " & c.ToArgb())
            Return c.ToArgb()
        End Function 'done

        Public Shared Function ConvertColorToHex(ByVal c As System.Drawing.Color, ByVal IncludeAlpha As Boolean) As String
            Dim A, R, G, B As String
            A = Conversion.Hex(CInt(c.A))
            R = Conversion.Hex(CInt(c.R))
            G = Conversion.Hex(CInt(c.G))
            B = Conversion.Hex(CInt(c.B))
            If IncludeAlpha Then
                Dim ARGB = A & R & G & B
                Debug.WriteLine("Function ConvertColorToHex(Color, IncludeAlpha) returns: " & ARGB)
                Return ARGB
            Else
                Dim RGB = R & G & B
                Debug.WriteLine("Function ConvertColorToHex(Color, NotIncludeAlpha) returns: " & RGB)
                Return RGB
            End If
        End Function 'done

        ' Convert ARGB integers
        Public Shared Function ConvertArgbToAhlta(ByVal argb As Integer) As Integer
            Dim hex As String = ConvertArgbToHex(argb, False)
            Dim i As Integer = ConvertHexToAhlta(hex, False)
            Debug.WriteLine("Function ConvertArgbToAhlta(Integer) returns: " & i.ToString())
            Return i
        End Function 'done

        Public Shared Function ConvertArgbToColor(ByVal argb As Integer) As System.Drawing.Color
            ' Acts as a wrapper for the built-in function
            Dim c As System.Drawing.Color = System.Drawing.Color.FromArgb(argb)
            Debug.WriteLine("Function ConvertArgbToColor(Integer) returns: " & c.ToString())
            Return c
        End Function 'done

        Public Shared Function ConvertArgbToHex(ByVal argb As Integer, ByVal IncludeAlpha As Boolean) As String
            Dim Bytes As Byte() = BitConverter.GetBytes(argb)
            Dim A, R, G, B, hex As String
            A = Conversion.Hex(Bytes(3))
            R = Conversion.Hex(Bytes(2))
            G = Conversion.Hex(Bytes(1))
            B = Conversion.Hex(Bytes(0))

            If IncludeAlpha Then
                hex = A & R & G & B
                Debug.WriteLine("Function ConvertArgbToHex(Integer, IncludeAlpha) returns: " & hex)
            Else
                hex = R & G & B
                Debug.WriteLine("Function ConvertArgbToHex(Integer, NotIncludeAlpha) returns: " & hex)
            End If
            Return hex
        End Function 'done

        ' Convert hex strings
        Public Shared Function ConvertHexToAhlta(ByVal hex As String, ByVal HasAlpha As Boolean) As Integer
            ' This does not have error checking to ensure it receives only a 6 or 8 character string!
            Dim BGR, R, G, B As String
            If HasAlpha Then
                ' Ignore the initial alpha component
                ' Dim A As String = Mid(hex, 1, 2)
                R = Mid(hex, 3, 2)
                G = Mid(hex, 5, 2)
                B = Mid(hex, 7, 2)
            Else
                R = Mid(hex, 1, 2)
                G = Mid(hex, 3, 2)
                B = Mid(hex, 5, 2)
            End If

            ' Reverse the hex to BGR
            BGR = B & G & R

            ' Convert BGR to Integer
            Dim iBGR As Integer = Convert.ToInt32(BGR, 16)
            Debug.WriteLine("Function ConvertHexToAhlta(String) returns: " & iBGR.ToString())
            Return iBGR
        End Function 'done

        Public Shared Function ConvertHexToArgb(ByVal hex As String, ByVal HasAlpha As Boolean) As Integer
            Dim hA, hR, hG, hB As String
            If HasAlpha Then
                hA = Mid(hex, 1, 2)
                hR = Mid(hex, 3, 2)
                hG = Mid(hex, 5, 2)
                hB = Mid(hex, 7, 2)
            Else
                hA = "FF"
                hR = Mid(hex, 1, 2)
                hG = Mid(hex, 3, 2)
                hB = Mid(hex, 5, 2)
            End If

            ' Dim ARGB As Byte()
            ' ARGB(3) = Convert.ToInt32(hA, 16) ' object ref not set to an instance
            ' ARGB(2) = Convert.ToInt32(hR, 16)
            ' ARGB(1) = Convert.ToInt32(hG, 16)
            ' ARGB(0) = Convert.ToInt32(hB, 16)

            ' Dim i As Integer = BitConverter.ToInt32(ARGB, 0)
            Dim ARGB As String = hA & hR & hG & hB
            Dim i As Integer = Convert.ToInt32(ARGB, 16)
            Debug.WriteLine("Function ConvertHexToArgb(String, Boolean) returns: " & i.ToString())
            Return i
        End Function 'broken

        Public Shared Function ConvertHexToColor(ByVal hex As String, ByVal HasAlpha As Boolean) As System.Drawing.Color
            Dim i As Integer = ConvertHexToArgb(hex, HasAlpha)
            Dim c As System.Drawing.Color = System.Drawing.Color.FromArgb(i)
            Debug.WriteLine("Function ConvertHexToColor(String, Boolean) returns: " & c.ToString())
            Return c
        End Function 'done

        ' Convert Ahlta integers
        Public Shared Function ConvertAhltaToArgb(ByVal ahlta As Integer) As Integer
            Dim hex As String = ConvertAhltaToHex(ahlta, False)
            Dim i As Integer = ConvertHexToArgb(hex, False)
            Debug.WriteLine("Function ConvertAhltaToArgb(Integer) returns: " & i.ToString())
            Return i
        End Function 'done

        Public Shared Function ConvertAhltaToColor(ByVal ahlta As Integer) As System.Drawing.Color
            Dim hex As String = ConvertAhltaToHex(ahlta, False)
            Dim c As System.Drawing.Color = ConvertHexToColor(hex, False)
            Debug.WriteLine("Function ConvertAhltaToColor(Integer) returns: " & c.ToString())
            Return c
        End Function 'done

        Public Shared Function ConvertAhltaToHex(ByVal ahlta As Integer, ByVal IncludeAlpha As Boolean) As String
            Dim BGR As String = Conversion.Hex(ahlta)

            ' Parse the reversed hex value
            Dim B, G, R As String
            B = Mid(BGR, 1, 2)
            G = Mid(BGR, 3, 2)
            R = Mid(BGR, 5, 2)

            If IncludeAlpha Then
                ' Reverse from BGR to RGB and include alpha component
                Dim ARGB As String = "FF" & R & G & B
                Debug.WriteLine("Function ConvertAhltaToHex(Integer, IncludeAlpha) returns: " & ARGB)
                Return ARGB
            Else
                ' Reverse from BGR to RGB without the alpha component
                Dim RGB As String = R & G & B
                Debug.WriteLine("Function ConvertAhltaToHex(Integer, NotIncludeAlpha) returns: " & RGB)
                Return RGB
            End If
        End Function 'done


    End Class
End Namespace