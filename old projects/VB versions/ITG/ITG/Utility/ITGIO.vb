Imports System.IO, System.Collections.Generic, System.Text

Namespace ITG.Utility

    Public Module ITGIO
        ' Contains conversion and processing functions

        Public Function SortByTab(ByVal filename As String) As String
            Dim Header, Template As String
            Dim sb As New StringBuilder()
            Dim NumTabs As Integer
            Dim Tabs As List(Of StringBuilder) = New List(Of StringBuilder)

            Try
                Using sr As New StreamReader(filename)

                    Dim line As String
                    For i As Integer = 0 To 4   ' store the header
                        line = sr.ReadLine()
                        If i = 3 Then           ' on line 4 of the template, extract the number of tabs
                            NumTabs = GetTabCount(line)
                        End If
                        sb.AppendLine(line)
                        line = ""
                    Next
                    Header = sb.ToString()
                    sb.Clear()                  ' clear the StringBuilder of header data

                    ' Now that we have the number of tabs, populate the list with StringBuilders
                    For i As Integer = 0 To (NumTabs - 1)
                        Tabs.Add(New StringBuilder())
                    Next

                    ' sr should now be ready to read line 6 - the first "real" FormItem
                    Do While sr.Peek() >= 0
                        line = sr.ReadLine()
                        Tabs(GetTab(line)).AppendLine(line) ' Add line to the list, where the tab matches the index
                    Loop
                End Using

                ' The entire template should be processed; now it needs to be reconstituted
                sb.Clear()

                ' Add the header
                sb.Append(Header)

                ' Rebuild the body
                For i As Integer = 1 To (NumTabs - 1)
                    sb.Append(Tabs(i).ToString())
                Next
                ' Add tab "0"
                sb.Append(Tabs(0).ToString())

                ' Return the template
                Template = sb.ToString()
                Return Template
            Catch ex As Exception
                Return "exception"
            End Try
        End Function

        Public Function GetTabCount(ByVal Line4 As String) As Integer
            ' Line 4 of a template has the template's tab count in the first position
            Return GetTab(Line4)
        End Function

        Public Function GetTab(ByVal line As String) As Integer
            ' Returns the first number in a FormItem line
            Dim tokens As String() = Split(line, ",", 1)
            Return CInt(tokens(0))
        End Function

        Private Sub ImportTabs(ByVal numberOfTabs As Integer)
            ' Dim sb As New StringBuilder("")
            ' Dim items As New List(Of ITGFormItem)()
            ' Dim tab As Integer = Find the number of tabs in _header
            ' For index As Integer From 1 To tabcount
            '   Loop through _body
            '     If tab == index
            '     Add line to List(Of ITGFOrmItem)
            '   Tabs(index).AddListOfITGFormItems  
            '   Increment index, repeat
            ' You *should* end up with a List(Of ITGFormItem) for each index (=tab number),
            ' which is then added to the dictionary
        End Sub



    End Module

End Namespace
