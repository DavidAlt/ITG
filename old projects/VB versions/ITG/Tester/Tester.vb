Imports ITG, ITG.Utility
Imports System.Collections.Generic
Imports System.Text 'StringBuilder

Public Class Tester

    Private Sub Tester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim test As String = "This is my caption~And this is my content,~with multiple lines of text!"
        ' Debug.WriteLine(f.ToString())
        ' Me.Close()
    End Sub

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        Dim l As List(Of StringBuilder) = New List(Of StringBuilder)
        For i As Integer = 0 To 2
            l.Add(New StringBuilder())
        Next
        l.Item(0).AppendLine("First append to SB@0")
        l.Item(1).AppendLine("First append to SB@1")
        l.Item(2).AppendLine("First append to SB@2")
        l.Item(0).AppendLine("Second append to SB@0")
        l.Item(2).AppendLine("Second append to SB@2")
        t2.Text = l.Item(0).ToString() & l.Item(1).ToString() & l.Item(2).ToString()

    End Sub
End Class
