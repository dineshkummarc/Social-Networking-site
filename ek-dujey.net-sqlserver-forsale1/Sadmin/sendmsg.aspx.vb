Imports System.Data
Imports System.Data.SqlClient

Partial Class Sadmin_sendmsg
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""
        Dim toemail As String = ""

        cn.ConnectionString = cf.friendshipdb()
        cn.Open()

        Dim msg As String = ""
        strsql = "select email from profile where pid='" & Request.QueryString("pid") & "'"

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                toemail = myreader.GetValue(0).ToString
            End While

            msg = "You have an Email From Website Admin <br>"
            msg = msg & "Message Below <br><br>" & TextBox1.Text
            msg = msg & "<br><br> You are Getting this message becoz your are registered member of " & cf.websitename
            Label1.Text = cf.send25("admin", txtsubject.Text.ToString, toemail, msg)
        Else
            Label1.Text = "No Eamil Found"
        End If
        cn.Close()

    End Sub

    

    

End Class
