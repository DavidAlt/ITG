Imports System.Text

Namespace ITG

    Public Class ITGTab
        ' This class is probably unnecessary as long as ITGFormItem is properly implemented
        ' But it may be useful as a conceptual abstraction

        Public Items As List(Of ITGFormItem)

        Sub New(ByVal itemlist As List(Of ITGFormItem))
            Items = itemlist
        End Sub

        Sub New()
            Items = New List(Of ITGFormItem)
        End Sub

        Public Overrides Function ToString() As String
            Dim sb As New StringBuilder("")
            For Each item As ITGFormItem In Me.Items
                sb.AppendLine(item.ToString())
            Next
            Return sb.ToString()
        End Function
    End Class

End Namespace
