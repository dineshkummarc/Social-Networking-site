Imports System.Data
Imports System.Data.SqlClient

Partial Class members_sendmsg
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim toemail As String = ""
        Dim strsql As String = ""
        Dim msg As String = ""

        strsql = "select email from profile where pid='" & Request.QueryString("pid") & "'"

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader

        While myreader.Read
            toemail = myreader.GetValue(0).ToString
        End While

        msg = "You have an Email From <br>"
        msg = msg & "http://" & cf.websitename & "/members/viewprofile.aspx?pid=" & Session("pid")
        msg = msg & "<br><br> Message Below <br><br>" & TextBox1.Text


        If Session("approved") <> "Y" Then
            Label1.ForeColor = Drawing.Color.Red
            Label1.Text = "Your Profile is not Approved Yet, Kindly Wait For Your Profile to be Approved and then you can send emails to other members"

        Else
            Try
                Label1.Text = cf.send25("contact", "Contact From " & Session("fname"), toemail, msg)
                Button1.Text = "Message Sent"
                Button1.Enabled = False

            Catch ex As Exception
                Label1.Text = ex.ToString
            End Try
        End If

        cn.Close()
    End Sub

   
End Class
