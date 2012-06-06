
Partial Class members_login
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        Dim u, p As String
        Dim rslt As Boolean

        u = Login1.UserName
        p = Login1.Password

        rslt = checkit(u, p)

        If rslt = True Then

            e.Authenticated = True


        Else
            e.Authenticated = False
        End If

    End Sub

    Private Function checkit(ByVal us As String, ByVal pas As String) As Boolean
        Dim constring As String


        constring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        Dim cn As New System.Data.OleDb.OleDbConnection

        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim cmd2 As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim kk As String = ""



        cn.ConnectionString = constring
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select pid,fname,approved,lname from profile where email=@email and passw=@passw"
        cmd.Parameters.Add("@email", Data.OleDb.OleDbType.VarChar).Value = us
        cmd.Parameters.Add("@passw", Data.OleDb.OleDbType.VarChar).Value = pas

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                Session("pid") = myreader.GetString(0).ToString
                Session("fname") = myreader.GetString(1).ToString
                Session("approved") = myreader.GetString(2).ToString
                Session("lname") = myreader.GetString(3).ToString
            End While

            updatelogin()

           
            Return True
        Else
            cn.Close()
            Return False
        End If



    End Function

    Sub updatelogin()
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim kk As String = ""

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "update profile set lastvisited=date(),isonlinenow='Y' where pid=@pid "
        cmd.Parameters.AddWithValue("@pid", Session("pid"))
        kk = cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
End Class
