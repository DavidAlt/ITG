Imports System.Text

Public Class AmericoreEditor

    Private Prefix As List(Of String) ' Contains the beginning portion of the FormItems
    Private Suffix As List(Of String) ' Contains the ending portion of the FormItems (with tildes)
    Private Content As List(Of String) ' Contains the user-inputted content for each item

    Private TemplateName As String = "Template Name"
    Private AuthorName As String = "Author"

    Private Enum sel As Integer
        ' These correspond to the listbox items
        CC = 0
        HPI1 = 1
        HPI2 = 2
        ROS1 = 3
        ROS2 = 4
        ALL = 5
        MED = 6
        PMH = 7
        PSH = 8
        FAM = 9
        SOC = 10
        IMM = 11
        BIRTH = 12
        PM = 13
        AG = 14
        DIET = 15
        HABITS = 16
        HEADS = 17
        DEP = 18
        PE1 = 19
        PE2 = 20
    End Enum

#Region "Flag section"
    Private AmericoreFlag As String = _
        "1,366,0,914,37,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""3416754:0:0:1:""" & Environment.NewLine & _
        "1,366,37,914,74,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,366,74,914,111,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""3416754:0:0:1:""" & Environment.NewLine & _
        "1,366,111,914,148,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,366,148,914,185,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""3416754:0:0:1:""" & Environment.NewLine & _
        "1,366,185,914,222,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,366,222,914,259,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""3416754:0:0:1:""" & Environment.NewLine & _
        "1,0,259,914,296,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,0,296,914,333,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""3416754:0:0:1:""" & Environment.NewLine & _
        "1,0,333,914,370,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,0,370,914,407,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""3416754:0:0:1:""" & Environment.NewLine & _
        "1,0,407,914,444,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,0,444,914,481,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""3416754:0:0:1:""" & Environment.NewLine & _
        "1,0,0,366,258,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""7224124:0:0:1:""" & Environment.NewLine & _
        "1,23,19,37,33,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,83,19,97,33,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,143,19,157,33,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,203,19,217,33,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,263,19,277,33,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,323,19,337,33,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,53,45,67,59,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,113,45,127,59,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,173,45,187,59,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,233,45,247,59,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,293,45,307,59,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,23,71,37,85,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,83,71,97,85,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,143,71,157,85,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,203,71,217,85,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,263,71,277,85,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,323,71,337,85,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,53,97,67,111,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,113,97,127,111,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,173,97,187,111,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,233,97,247,111,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,293,97,307,111,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,23,123,37,137,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,83,123,97,137,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,143,123,157,137,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,203,123,217,137,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,263,123,277,137,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,323,123,337,137,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,53,149,67,163,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,113,149,127,163,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,173,149,187,163,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,233,149,247,163,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,293,149,307,163,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,23,175,37,189,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,83,175,97,189,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,143,175,157,189,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,203,175,217,189,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,263,175,277,189,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,323,175,337,189,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,53,201,67,215,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,113,201,127,215,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,173,201,187,215,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,233,201,247,215,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,293,201,307,215,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,23,227,37,241,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,83,227,97,241,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,143,227,157,241,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,203,227,217,241,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,263,227,277,241,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:""" & Environment.NewLine & _
        "1,323,227,337,241,0,2,""|||||||0|0||0|0|||0|||0|0|0|0|0||||"","""",""16777215:0:0:1:"""
#End Region

#Region "Links section"
    Private AmericoreLinks As String = _
        "1,-75,453,80,473,300082,262402,""|||||||19|80|YCR|1|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|B=T|Y=0|L="",""PCubed :""" & Environment.NewLine & _
        "1,-90,444,175,463,300082,262402,""|||||||19|80|YCR|2|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""H:\ :""" & Environment.NewLine & _
        "1,-90,463,175,481,300082,262402,""|||||||19|80|YCR|3|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""P:\ :""" & Environment.NewLine & _
        "1,-90,444,280,463,300082,262402,""|||||||19|80|YCR|4|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""Notepad :""" & Environment.NewLine & _
        "1,-90,463,280,481,300082,262402,""|||||||19|80|YCR|5|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""Calc :""" & Environment.NewLine & _
        "1,-90,444,415,463,300082,262402,""|||||||19|80|YCR|6|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""BP/Boys :""" & Environment.NewLine & _
        "1,-90,463,415,481,300082,262402,""|||||||19|80|YCR|7|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""BP/Girls :""" & Environment.NewLine & _
        "1,-90,444,520,463,300082,262402,""|||||||19|80|YCR|8|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""Growth Charts :""" & Environment.NewLine & _
        "1,-90,463,520,481,300082,262402,""|||||||19|80|YCR|9|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""Adjusted Age :""" & Environment.NewLine & _
        "1,-90,444,625,463,300082,262402,""|||||||19|80|YCR|10|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""MPHeight :""" & Environment.NewLine & _
        "1,-90,463,625,481,300082,262402,""|||||||19|80|YCR|11|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""BiliTool :""" & Environment.NewLine & _
        "1,-90,444,730,463,300082,262402,""|||||||19|80|YCR|12|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""Handouts :""" & Environment.NewLine & _
        "1,-90,463,730,481,300082,262402,""|||||||19|80|YCR|13|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|Y=0|L="",""Peds IR :""" & Environment.NewLine & _
        "1,-90,444,875,463,300082,262402,""|||||||19|80|YCR|14|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|B=T|Y=0|L="",""UpToDate :""" & Environment.NewLine & _
        "1,-90,463,875,481,300082,262402,""|||||||19|80|YCR|15|0|||0|||0|0|0|0|0||||"",""|K=16777215|T=T|B=T|Y=0|L="",""LexiComp :""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#1" & vbTab & "p:\pcubed\zzDatabase Info\index.html" & vbTab & "Patient reference"",""PCubed""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#2" & vbTab & "h:\" & vbTab & "Patient reference"",""H drive""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#3" & vbTab & "p:\" & vbTab & "Patient reference"",""P drive""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#4" & vbTab & "notepad.exe" & vbTab & "Patient reference"",""Notepad""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#5" & vbTab & "calc.exe" & vbTab & "Patient reference"",""Calculator""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#6" & vbTab & "http://www.uptodate.com/contents/calculator-blood-pressure-percentiles-for-boys-2-to-17-years?source=see_link&utdPopup=true" & vbTab & "Patient reference"",""BP - boys""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#7" & vbTab & "http://www.uptodate.com/contents/calculator-blood-pressure-percentiles-for-girls-2-to-17-years?source=see_link&utdPopup=true" & vbTab & "Patient reference"",""BP - girls""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#8" & vbTab & "http://www.cdc.gov/growthcharts/who_charts.htm" & vbTab & "Patient reference"",""Growth charts""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#9" & vbTab & "http://www.asqagecalculator.com/" & vbTab & "Patient reference"",""Adjusted age""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#10" & vbTab & "http://medcalc3000.com/HeightPotential.htm" & vbTab & "Patient reference"",""Mid-parental height""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#11" & vbTab & "http://bilitool.org/" & vbTab & "Patient reference"",""BiliTool""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#12" & vbTab & "http://dodmedicineandsurgery.exitcareoncall.com/" & vbTab & "Patient reference"",""Patient instructions""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#13" & vbTab & "http://pedsinreview.aappublications.org/" & vbTab & "Patient reference"",""Peds in Review""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#14" & vbTab & "http://www.uptodate.com/" & vbTab & "Patient reference"",""UpToDate""" & Environment.NewLine & _
        "0,0,0,0,0,0,262144,"""",""#15" & vbTab & "http://online.lexi.com/" & vbTab & "Patient reference"",""LexiComp"""
#End Region

    Private Sub AmericoreEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeAmericoreDefaults()
        listSelector.SelectedIndex = 0 ' Select the first item in the listbox
    End Sub

    Private Sub InitializeAmericoreDefaults()
        ' Initialize the Prefix list
        Prefix = New List(Of String) From { _
                "1,376,46,600,66,1718,33562881,""|||||||19|180|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""CC", _
                "1,630,37,720,55,115033,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""HPI", _
                "1,630,55,720,74,115033,8449,""AD|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""More HPI", _
                "1,750,37,860,55,112344,8449,""AL|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Complete ROS", _
                "1,750,55,860,74,112344,8449,""AO|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Focused ROS", _
                "1,376,111,480,130,122305,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Allergies", _
                "1,376,130,480,148,195087,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Medications", _
                "1,510,111,600,130,120054,8449,""H|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""PMHx", _
                "1,510,130,600,148,3406,8449,""H|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""PSHx", _
                "1,630,111,720,130,5098,8449,""F|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""FHx", _
                "1,630,130,720,148,122667,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Soc", _
                "1,750,111,860,130,195089,8449,""|||||||19|190|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Immunizations", _
                "1,750,130,860,148,123077,8449,""H|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Birth Hx", _
                "1,376,185,480,204,42435,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Tracking", _
                "1,376,204,480,222,115034,8449,""C|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Guidance", _
                "1,510,185,600,204,120052,8449,""H|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Diet", _
                "1,510,204,600,222,120044,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Lifestyle", _
                "1,630,185,720,204,115034,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""HEADSSS", _
                "1,630,204,720,222,220256,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""EPDS", _
                "1,750,185,860,204,208847,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Infant", _
                "1,750,204,860,222,208847,8449,""|||||||19|80|YCN|0|0|X|X|0|||0|0|0|0|0||||"",""|K=16777215|T=T|L="",""Child"
        }

        ' Initialize the Suffix list
        Suffix = New List(Of String) From { _
                "well-child visit", _
                ".~Here for well-child check. Overall has been healthy, with no recent illnesses (except occasional URIs), ED visits, or acute appointments. No parental concerns.~ ~Current diet includes _ . Making at least 6 wet diapers per day, and stooling at least once per day. Age-appropriate sleep pattern. New skills include _ .~.", _
                "", _
                "A complete review of systems was performed and was negative, except as detailed above (minimum 10 systems).~.", _
                "A focused review of systems was performed and was negative, except as detailed above (< 10 systems).~.", _
                "* No known drug allergies~* No known environmental allergies~* No known food allergies~.", _
                "Reviewed and reconciled, including OTC/CAM meds~* No regular medication use~.", _
                ".~* healthy~ ~* Birth: term birth, no chronic associated problems~* Development: reviewed; no history of delay~* Diet: reviewed; no special dietary measures~* Sleep: reviewed; appropriate for age~* Vaccinations: reviewed; on regular schedule~.", _
                ".~* denies ~.", _
                ".~POSITIVE FOR:~* none stated~ ~NEGATIVE FOR:~* sudden death~* genetic/metabolic disease~* birth defects~* kidney disease~* childhood deafness~.", _
                ".~* Lives with both parents~* Pets: none~* Smoke exposure: no~* DOES NOT attend daycare~* Contact: ~.", _
                "* Receiving all immunizations on schedule~.", _
                "_ g~* term birth (_ wga)~* newborn metabolic, hearing, and SpO2 screen were normal~* prenatal history: uncomplicated~* delivery: uncomplicated SVD~* postnatal events: routine newborn discharge~.", _
                "Last updated: ~* developmental screen: ~* newborn screen: normal~* hearing: passed newborn screen, no concerns~* vision: no concerns~* dental: NOT receiving periodic dental care~* screening for anemia, lead, and TB risk: screen at 12 mo~* BMI: not overweight or obese~* lipid screen: not assessed~.", _
                "Age-appropriate guidance discussed, including but not limited to: lifestyle (nutrition, sleep hygiene, physical activity), safety, behavior, and discipline. Signs of illness and symptom management reviewed as appropriate.~.", _
                ".~* age-appropriate diet with variety of foods ~* eats meals with family; not a picky eater and not skipping meals ~* fried/fatty/fast foods: ~* milk intake: ~* juice intake: ~* water intake: ~* caffeinated beverages: ~.", _
                ".~# SLEEP ~* quantity: _ hrs ~* quality: onset within _ minutes; minimal awakenings, feels refreshed afterward, not falling asleep at school, no recurrent headaches ~* routine: no significant difference in weekday vs weekend sleep schedule ~* stimulants: no afternoon/evening caffeine, energy drinks, or stimulant use ~* distractors: has electronic devices in bedroom with loosely monitored but unrestricted access ~  ~# EXERCISE / SCREENTIME ~* overall active / sedentary lifestyle ~* gets at least 1 hour of sustained active exercise daily ( ) ~* spends more than 2 leisure hours/day with electronic devices~.", _
                "# HEADSSS EXAM~H: Lives with _. No concerns with family interaction~E: _th grade, not failing any classes~A: Hangs out with friends, no parties. Plays _~D: Denies current or prior use of tobacco, alcohol, marijuana, or other drugs (both illicit and prescription)~S: Not dating and not sexually active~S: Denies SI/HI~S: Feels safe at home and school~.", _
                "Screening for maternal depression with EPDS; total score = _ and 0 points for question 10.~.", _
                "# VITAL SIGNS: Vital signs and growth parameters reviewed~ ~# GENERAL APPEARANCE: Awake and alert; well-nourished and well-developed~ ~# HEENT~* Anterior fontanelle open, soft, and flat~* PERRL. No conjunctival erythema or scleral icterus. Red reflex present bilaterally~* Normal canals. TMs pearly grey, normal light reflex/landmarks, not bulging~* No nasal drainage~* Mucous membranes moist. No oral lesions or thrush~ ~# HEART~* S1, S2, regular rate, no skipped/early beats, no murmurs, rubs, or gallops~* Distal extremity pulses symmetric, no femoral delay. Cap refill < 2 sec~ ~# LUNGS~* Breathing comfortably without tachypnea, nasal flaring, retractions, or accessory muscle use~* Lungs clear and symmetric on auscultation; no stridor, wheezing, rhonchi, or crackles~ ~# ABDOMEN~* Nondistended; normoactive bowel sounds. Soft, nontender~* No hepatomegaly, splenomegaly, or other palpable masses~ ~# MUSCULOSKELETAL~* Spine and paraspinal musculature are nontender with no obvious abnormalities~* Joints and limbs are non-edematous and nontender. Normal range of motion~* No subluxation/dislocation/relocation of the hips~ ~# NEURO: Moving all extremities spontaneously with normal tone and strength; no gross abnormalities~ ~# SKIN: No rashes, lesions, or petechiae~ ~# GENITOURINARY: normal male phenotype (Tanner stage 1) with bilaterally descended testicles~ ~# GENITOURINARY: normal female phenotype (Tanner stage 1) with no labial adhesions or hymenal obstruction~.~", _
                "# VITAL SIGNS: Vital signs and growth parameters reviewed~ ~# GENERAL APPEARANCE: Awake and alert; well-nourished and well-developed~ ~# HEENT~* Normocephalic, atraumatic~* PERRL, EOMI. No conjunctival erythema or scleral icterus~* Normal canals. TMs pearly grey, light reflex/landmarks visualized, not bulging~* No nasal drainage. Nasal mucosa is not pale or boggy~* Mucous membranes moist. No exudates, erythema, or tonsillar hypertrophy. Tongue and uvula are midline~ ~# HEART~* S1, S2, regular rate, no skipped/early beats, no murmurs, rubs, or gallops~* Distal extremity pulses symmetric, no femoral delay. Cap refill < 2 sec~ ~# LUNGS~* Breathing comfortably without tachypnea, nasal flaring, retractions, or accessory muscle use~* Lungs clear and symmetric on auscultation; no stridor, wheezing, rhonchi, or crackles~ ~# ABDOMEN~* Nondistended; normoactive bowel sounds. Soft, nontender~* No hepatomegaly, splenomegaly, or other palpable masses~ ~# MUSCULOSKELETAL~* Spine and paraspinal musculature are nontender with no obvious abnormalities~* Joints and limbs are non-edematous and nontender. Normal range of motion~ ~# NEURO~* CN 2-12 intact~* Strength 5/5 in proximal and distal musculature. Grips 2+/symmetric~* Sensation intact to light touch~* Normal gait and coordination with no ataxia~* Deep tendon reflexes 2+ in patellae~ ~# SKIN: No rashes, lesions, or petechiae~ ~# LYMPH NODES~* No palpable nodes in the occipital, pre/post-auricular, submandibular, submental, anterior/posterior cervical, or supra/infraclavicular chains ~ ~# GENITOURINARY/PUBERTAL~* Axillary: no hair or odor~* Genitals: normal male phenotype, Tanner stage 1; testicles descended bilaterally~* Genitals: normal female phenotype, Tanner stage 1~* Breasts: Tanner stage 1~.~"
        }

        ' Initialize the Content list
        Content = New List(Of String)(21)
        Content.Insert(sel.CC, TLR(Suffix.Item(sel.CC)))
        Content.Insert(sel.HPI1, TLR(Suffix.Item(sel.HPI1)))
        Content.Insert(sel.HPI2, TLR(Suffix.Item(sel.HPI2)))
        Content.Insert(sel.ROS1, TLR(Suffix.Item(sel.ROS1)))
        Content.Insert(sel.ROS2, TLR(Suffix.Item(sel.ROS2)))
        Content.Insert(sel.ALL, TLR(Suffix.Item(sel.ALL)))
        Content.Insert(sel.MED, TLR(Suffix.Item(sel.MED)))
        Content.Insert(sel.PMH, TLR(Suffix.Item(sel.PMH)))
        Content.Insert(sel.PSH, TLR(Suffix.Item(sel.PSH)))
        Content.Insert(sel.FAM, TLR(Suffix.Item(sel.FAM)))
        Content.Insert(sel.SOC, TLR(Suffix.Item(sel.SOC)))
        Content.Insert(sel.IMM, TLR(Suffix.Item(sel.IMM)))
        Content.Insert(sel.BIRTH, TLR(Suffix.Item(sel.BIRTH)))
        Content.Insert(sel.PM, TLR(Suffix.Item(sel.PM)))
        Content.Insert(sel.AG, TLR(Suffix.Item(sel.AG)))
        Content.Insert(sel.DIET, TLR(Suffix.Item(sel.DIET)))
        Content.Insert(sel.HABITS, TLR(Suffix.Item(sel.HABITS)))
        Content.Insert(sel.HEADS, TLR(Suffix.Item(sel.HEADS)))
        Content.Insert(sel.DEP, TLR(Suffix.Item(sel.DEP)))
        Content.Insert(sel.PE1, TLR(Suffix.Item(sel.PE1)))
        Content.Insert(sel.PE2, TLR(Suffix.Item(sel.PE2)))
    End Sub

    Private Function TLR(ByVal source As String) As String
        ' TLR = Toggle Line Return
        ' If source contains any ~, then all ~ are replaced with Environment.NewLine(== vbCrLf)
        ' Else replace all line returns with ~
        Dim result As String = ""
        If source.Contains("~") Then
            result = source.Replace("~", Environment.NewLine)
        Else
            result = source.Replace(Environment.NewLine, "~").Replace(vbCr, "~").Replace(vbLf, "~")
        End If
        Return result
    End Function

    Private Sub ClearStrings()
        Console.WriteLine("Called undefined subroutine ClearStrings()")
    End Sub

    Private Sub UpdatePreview()
        ' Displays the user's custom text as it will actually appear in the final AHLTA note

        ' Step 2: add and format the boilerplate text for that case
        ' Step 3: add the user's custom text

        ' Step 0: Clear the current contents
        txtPreview.Clear()
        ' Step 1: determine which item is selected
        Select Case listSelector.SelectedIndex
            Case sel.CC
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Chief complaint" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = "The Chief Complaint is: " & txtContent.Text
            Case sel.HPI1
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "History of present illness" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = vbTab & "The Patient is a <age> old <gender>." & Environment.NewLine & txtContent.Text
            Case sel.HPI2
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "History of present illness" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = vbTab & "The Patient is a <age> old <gender>." & Environment.NewLine & txtContent.Text
            Case sel.ROS1
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Review of systems" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case sel.ROS2
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Review of systems" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case sel.ALL
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Allergies" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case sel.MED
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Current medication" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case sel.PMH
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Past medical/surgical history" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold)
                txtPreview.SelectedText = "Reported:" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectionIndent = 40
                txtPreview.SelectedText = "Medical: Reported medical history " & txtContent.Text
            Case sel.PSH
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Past medical/surgical history" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold)
                txtPreview.SelectedText = "Reported:" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectionIndent = 40
                txtPreview.SelectedText = "Surgical / Procedural: Surgical / procedural history " & txtContent.Text
            Case sel.FAM
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Family history" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectionIndent = 40
                txtPreview.SelectedText = "Family medical history " & txtContent.Text
            Case sel.SOC
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Personal history" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = "Social history reviewed " & txtContent.Text
            Case sel.IMM
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Vaccinations" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case sel.BIRTH
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Past medical/surgical history" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold)
                txtPreview.SelectedText = "Reported:" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectionIndent = 40
                txtPreview.SelectedText = "Pediatric: Patient's birth weight " & txtContent.Text
            Case sel.PM
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Practice Management" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectionIndent = 40
                txtPreview.SelectedText = "Preventive medicine services " & txtContent.Text
            Case sel.AG
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "History of present illness" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = vbTab & "The Patient is a <age> old <gender>." & Environment.NewLine & Environment.NewLine & txtContent.Text
            Case sel.DIET
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Past medical/surgical history" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold)
                txtPreview.SelectedText = "Reported:" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectionIndent = 40
                txtPreview.SelectedText = "Dietary: Reported dietary history " & txtContent.Text
            Case sel.HABITS
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Personal history" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = "Habits: Habits " & txtContent.Text
            Case sel.HEADS
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "History of present illness" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = vbTab & "The Patient is a <age> old <gender>." & Environment.NewLine & Environment.NewLine & txtContent.Text
            Case sel.DEP
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Previous tests" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case sel.PE1
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Physical findings" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case sel.PE2
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Bold Or FontStyle.Underline)
                txtPreview.SelectedText = "Physical findings" & Environment.NewLine
                txtPreview.SelectionFont = New Font("Arial", 8, FontStyle.Regular)
                txtPreview.SelectedText = txtContent.Text
            Case Else
                txtPreview.Text = "Invalid case selected in subroutine UpdatePreview(); case must fit within the Enum ""sel"""
        End Select
    End Sub

    Private Function BuildAmericoreHeader() As String
        Dim sb As New StringBuilder("")
        sb.AppendLine("""MedcinForm-V1.0""")
        sb.AppendLine("""" & TemplateName & """" & "," & """CHCSII""" & "," & """" & AuthorName & """")
        sb.AppendLine("0,0,0,916,1200,0,1048576,,"""",""""")
        sb.AppendLine("1,5,377,295,395,0,32,|||||||0|0||0|0|||0|||0|0|0|0|0||||,""V=1:DF=1:PS=1:TP=0:MR=F:BS=1:TWS=0:PB=3:NB=3:ROS=1:PL=0:FB=0:EM=0:CB=2"","":-2147483633:Americore""")
        sb.Append("0,380,0,755,535,0,4,,""I=TS=TB=T"",""""")
        Return sb.ToString()
    End Function

    Private Sub ConvertContent()
        ' This should be called during Export, and take all the NewLine stuff and convert it to the tilde version
        For i As Integer = sel.CC To sel.PE2
            Suffix.Item(i) = TLR(Content.Item(i))
        Next
    End Sub

    Private Function BuildCustomText() As String
        Dim sb As New StringBuilder("")
        ConvertContent()
        For i As Integer = sel.CC To sel.PE2
            If i < sel.PE2 Then
                sb.AppendLine(Prefix.Item(i) & "~" & Suffix.Item(i) & """")
            Else : sb.Append(Prefix.Item(i) & "~" & Suffix.Item(i) & """")
            End If
        Next
        Return sb.ToString()
    End Function

    Private Function AssembleTemplate() As String
        If txtName.Text = "" Then
            TemplateName = "Custom Americore"
        Else
            TemplateName = txtName.Text
        End If

        If txtAuthor.Text = "" Then
            AuthorName = "Anonymous"
        Else
            AuthorName = txtAuthor.Text
        End If

        Dim sb As New StringBuilder("")
        sb.AppendLine(BuildAmericoreHeader())
        sb.AppendLine(AmericoreFlag)
        sb.AppendLine(BuildCustomText())
        sb.Append(AmericoreLinks)
        Return sb.ToString()
    End Function

    Private Sub listSelector_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listSelector.SelectedIndexChanged
        txtContent.Text = Content.Item(listSelector.SelectedIndex)
        UpdatePreview()
    End Sub

#Region "Menu items"
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If MessageBox.Show("This will erase ALL content without saving. Are you sure you want to do this?", "Warning!", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            ClearStrings()
            txtContent.Text = ""
            txtPreview.Text = ""
            TemplateName = "Template Name"
            AuthorName = "Author"
            txtName.Text = TemplateName
            txtAuthor.Text = AuthorName
            listSelector.SelectedIndex = sel.CC
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ' Opens a previously saved file

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        ' If previously saved, save to last used file
        ' Otherwise call SaveAs
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        ' Save current strings as new template
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' Exit the application
        End
    End Sub

    Private Sub WordwrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordwrapToolStripMenuItem.Click
        If WordwrapToolStripMenuItem.Checked Then
            txtContent.WordWrap = True
            txtPreview.WordWrap = True
        Else
            txtContent.WordWrap = False
            txtPreview.WordWrap = False
        End If
    End Sub

    Private Sub InstructionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstructionsToolStripMenuItem.Click

    End Sub

    Private Sub AboutAmericoreEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutAmericoreEditorToolStripMenuItem.Click

    End Sub
#End Region

    Private Sub txtContent_TextChanged(sender As Object, e As EventArgs) Handles txtContent.TextChanged
        Content.Item(listSelector.SelectedIndex) = txtContent.Text
        UpdatePreview()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' Exports everything to the final AHLTA FormTemplate
        Dim sfd As New SaveFileDialog()
        sfd.DefaultExt = "txt"
        sfd.Filter = "AHLTA FormTemplate (*.txt)|*.txt"
        sfd.RestoreDirectory = True

        If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Console.WriteLine("File name: " & sfd.FileName)
            Try
                Using sw As New System.IO.StreamWriter(sfd.FileName)
                    sw.Write(AssembleTemplate())
                End Using
            Catch ex As Exception
                Console.WriteLine("Exception caught while attempting to export the template: ")
                Console.WriteLine(ex.Message)
            End Try
        End If
    End Sub




End Class
        