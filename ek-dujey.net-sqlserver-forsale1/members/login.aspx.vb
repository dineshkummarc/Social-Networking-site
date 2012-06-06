Imports System.Data
Imports System.Data.SqlClient

Partial Class members_login
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        Dim u, p As String
        Dim rslt As Boolean

        u = Login1.UserName
        p = Login1.Password

        rslt = checkit(u, p)
        If rslt = True And Session("susp") = "Y" Then
            Response.Cookies("scammer").Value = "yes"
            Response.Cookies("scammer").Expires = DateTime.Now.AddDays(30)
            Response.Redirect("../usedbyscammers.aspx")
        End If

        If rslt = True Then

            e.Authenticated = True


        Else
            e.Authenticated = False
        End If

    End Sub

    Private Function checkit(ByVal us As String, ByVal pas As String) As Boolean

        Dim cn As New SqlConnection

        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As String = ""



        cn.ConnectionString = cf.friendshipdb
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select pid,fname,approved,lname,susp from profile where email=@email and passw=@passw"
        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = us
        cmd.Parameters.Add("@passw", SqlDbType.VarChar).Value = pas

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                Session("pid") = myreader.GetString(0).ToString
                Session("fname") = myreader.GetString(1).ToString
                Session("approved") = myreader.GetString(2).ToString
                Session("lname") = myreader.GetString(3).ToString
                Session("susp") = myreader.GetString(4).ToString
            End While

            myreader.Close()
            cmd2.Connection = cn
            cmd2.CommandText = "update profile set lastvisited=getdate(),isonlinenow='Y' where pid=@pid "
            cmd2.Parameters.AddWithValue("@pid", Session("pid"))
            cmd2.CommandTimeout = 200
            kk = cmd2.ExecuteNonQuery()
            cn.Close()
            Return True
        Else
            cn.Close()
            Return False
        End If



    End Function

    
End Class
