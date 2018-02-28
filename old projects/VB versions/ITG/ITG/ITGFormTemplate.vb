Imports System.IO, System.Text

Namespace ITG

    Public Class ITGFormTemplate
        Private _template As List(Of String)
        Private _dummyHeader As String() = { _
            """MedcinForm-V1.1""", _
            """New Template"", ""AHLTA"", ""System""", _
            "0,0,0,1080,2180,0,1048576,"""","""",""""", _
            "1,5,377,295,395,0,32,""|||||||0|0||0|0|||0|||0|0|0|0|0|0|||"",""N=1|L=V=13:DF=1:PS=1:TP=0:MR=T:BS=0:TWS=0:PB=2:NB=0:ROS=1:PL=0:FB=0:EM=0:CB=2:HHL=F"","":-2147483633:Tab 1""", _
            "0,555,10,1065,610,0,4,"""",""N=2|I=F|S=F|B=T"","""""
        }

        ' TemplateSignature
        ' Public Property Signature As String = "MedcinForm-v1.1"

        ' TemplateIdentification
        ' Public Property Name As String = "New Template"
        ' Public Property Environment As String = "AHLTA"
        ' Public Property Author As String = "System"

        Sub New(ByVal filename As String)
            Try
                Using sr As New System.IO.StreamReader(filename)
                    Do While sr.Peek() >= 0
                        _template.Add(sr.ReadLine())
                    Loop
                End Using
            Catch ex As Exception
            End Try
        End Sub

        Sub New()
            For i As Integer = 0 To 4
                _template.Add(_dummyHeader(i))
            Next
        End Sub

        Public Sub ExportTemplate(ByVal filename As String)
            Try
                Using sw As New StreamWriter(filename)
                    sw.Write(_template.ToString())
                End Using
            Catch ex As Exception
                Console.WriteLine("Exception thrown: ")
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Public Function GetTabCount() As Integer
            ' should be made into a property
            Dim s As String = _template(3)
            Dim tokens As String() = Split(s, ",", 1)
            Console.Out.WriteLine("Number of tabs: " & tokens(0).ToString())
            Return CInt(tokens(0).ToString())
        End Function

        Public Overrides Function ToString() As String
            Dim sb As New StringBuilder()
            For Each s As String In _template
                sb.AppendLine(s)
            Next
            Debug.WriteLine("ITGFormTemplate.ToString() returns: " & sb.ToString())
            Return sb.ToString()
        End Function

    End Class

End Namespace