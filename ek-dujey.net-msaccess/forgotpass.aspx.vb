
Partial Class forgotpass
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim passw As String = ""
        Dim regmsg As String = ""
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim strsql As String = ""

        Try
            strsql = "select passw from profile where email='" & TextBox1.Text.ToString & "'"

            cn.ConnectionString = cf.friendshipdb()
            cn.Open()


            cmd.Connection = cn
            cmd.CommandText = strsql


            myreader = cmd.ExecuteReader

            If myreader.HasRows = True Then
                While myreader.Read
                    passw = myreader.GetValue(0).ToString
                End While
            Else
                Label1.Text = "no alc found"
            End If

            regmsg = "Your Password is <br><br>"
            regmsg = regmsg & "Your Login is:=" & TextBox1.Text.ToString
            regmsg = regmsg & " and password is " & passw
            regmsg = regmsg & "<br><br>" & cf.websitename
            cn.Close()



            Label1.Text = cf.send25("forgotpass", "Your Password", TextBox1.Text.ToString, regmsg)


        Catch ex As Exception

            Label1.Text = ex.ToString
        End Try
    End Sub
End Class
