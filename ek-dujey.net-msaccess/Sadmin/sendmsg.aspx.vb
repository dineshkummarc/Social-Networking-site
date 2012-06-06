
Partial Class Sadmin_sendmsg
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim strsql As String = ""
        Dim toemail As String = ""

        cn.ConnectionString = cf.friendshipdb()
        cn.Open()

        Dim msg As String = ""
        strsql = "select email from profile where pid='" & Request.QueryString("pid") & "'"

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader


        While myreader.Read
            toemail = myreader.GetValue(0).ToString
        End While

        msg = "You have an Email From Website Admin <br>"
        msg = msg & "Message Below <br><br>" & TextBox1.Text

        Label1.Text = cf.send25("contact", "Contact From " & Session("fname"), toemail, msg)
        cn.Close()

    End Sub

    

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If checklogin() = False Then
            Response.Redirect("~/adminlogin.aspx")
            Exit Sub
        End If

    End Sub
    Function checklogin() As Boolean
        If Session("username") IsNot Nothing Then

            If Session("username") = "" Then
                '  Response.Redirect("~/adminlogin.aspx")
                Return False
            Else
                Return True
            End If

        Else
            ' Response.Redirect("~/adminlogin.aspx")
            Return False
        End If
    End Function

End Class
