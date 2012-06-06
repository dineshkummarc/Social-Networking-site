Imports System.Data
Imports System.Data.SqlClient

Partial Class firealerts
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Dim alerFirDays As Integer = 5
    

    Function getcandirecords(ByVal searchno As String, ByVal candiid As String, ByVal Qn As String, ByVal email As String, ByVal queryname As String) As String
        Dim msg As String = ""
        Dim myreader As SqlDataReader
        Dim kk As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand


        Qn = Replace(Qn, "distinct", "top 5 ")

        Qn = Qn & " and (DateDiff('d',profile.profiledate,date())<=" & alerFirDays & ") " & " order by profiledate desc  "


        cn.ConnectionString = cf.friendshipdb()
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = Qn



        myreader = cmd.ExecuteReader

        'Label2.Text = Qn
        msg = ""

        If myreader.HasRows = True Then
            msg = "<table>"
            While myreader.Read

                msg = msg & "<tr><td> <A href='http://www." & cf.websitename & "/viewprofile.aspx?pid=" & myreader.GetString(0).ToString & "'> View Profile </a></td></tr>"
                msg = msg & "<tr></td> " & myreader.GetString(2).ToString & " " & myreader.GetString(3).ToString & "</td></tr>"
                msg = msg & "<tr><td>Age " & DateDiff(DateInterval.Year, myreader.GetValue(4), Now.Date) & " </td></tr>"
                msg = msg & "<tr><td>Ethnic " & myreader.GetString(7).ToString & " " & myreader.GetString(8).ToString & " " & myreader.GetString(9).ToString & "</td></tr>"
                msg = msg & "<tr><td>Location " & myreader.GetString(10).ToString & " " & myreader.GetString(12).ToString & " " & myreader.GetString(13).ToString & "</td></tr>"

            End While

            msg = msg & "</table><br>"
            msg = msg & "<a href='http://www." & cf.websitename & "/members/delalert.aspx?pid=" & searchno & "&candiid=" & candiid & "'> Disable Alert </a>"

            'msgcontent.InnerHtml = msg

            kk = cf.send25("alerts", "Your Alert " & queryname, email, msg)
        End If

        cn.Close()
        getcandirecords = kk

    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim sqlalerts As String = ""

        Dim sql As String = ""
        Dim kk As String = ""
        Dim k1 As Boolean
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""

        Dim myreader As SqlDataReader

        alerFirDays = "117" 'cf.firealert

        strsql = "select top 5 searchno,candiid,query,email,queryname,fireddate from alert where verified='Y' and (DateDiff('d',alert.fireddate,date())>=" & alerFirDays & ")"

        cn.ConnectionString = cf.friendshipdb
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = strsql



        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            '  Label1.Text = "Records Found"
            While myreader.Read
                k1 = cf.update("update alert set fireddate=date() where searchno='" & myreader.GetValue(0).ToString & "'")
                kk = getcandirecords(myreader.GetValue(0).ToString, myreader.GetValue(1).ToString, myreader.GetValue(2).ToString, myreader.GetValue(3).ToString, myreader.GetValue(4).ToString)
            End While
        Else
            '   Label1.Text = "no Records found"
        End If
        cn.Close()
    End Sub
End Class
