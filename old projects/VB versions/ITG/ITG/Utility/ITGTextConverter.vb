Namespace Utility

    Public Class ITGTextConverter

        Public Shared Function ToggleLineReturn(ByVal source As String) As String
            ' Function TLR = ToggleLineReturn
            ' If source contains any ~, then all ~ are replaced with Environment.NewLine(== vbCrLf)
            ' Else replace all line returns with ~
            ' User must ensure that Caption/Content splitting is taken care of elsewhere!
            Dim result As String = ""
            If source.Contains("~") Then
                result = source.Replace("~", Environment.NewLine)
            Else
                result = source.Replace(Environment.NewLine, "~").Replace(vbCr, "~").Replace(vbLf, "~")
            End If
            Debug.WriteLine("Function ToggleLineReturn(String) returns: " & result)
            Return result
        End Function

        Public Shared Function ExtractCaption(ByVal source As String) As String
            Dim parts As String() = Split(source, "~", 2)
            Debug.WriteLine("Function ExtractCaption(String) returns: " & parts(0))
            Return parts(0)
        End Function

        Public Shared Function ExtractContent(ByVal source As String) As String
            Dim parts As String() = Split(source, "~", 2)
            Debug.WriteLine("Function ExtractCaption(String) returns: " & parts(1))
            Return parts(1)
        End Function

    End Class
End Namespace