
Partial Class Sadmin_editprofile
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        Dim strsql As String = ""


        cn.ConnectionString = cf.apconstring
        cn.Open()

        strsql = "update users set username=@username,passw=@passw"

        cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.Parameters.AddWithValue("@username", txtusername.Text.ToString)
        cmd.Parameters.AddWithValue("@passw", txtpassword.Text.ToString)
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            Label1.Text = "Updated Sucessfully"
        End If
        

        cn.Close()
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        If checklogin() = False Then
            Response.Redirect("~/adminlogin.aspx")
            Exit Sub
        End If

        If Page.IsPostBack = False Then
            Try
                Dim myreader As System.Data.OleDb.OleDbDataReader
                Dim cn As New System.Data.OleDb.OleDbConnection
                Dim cmd As New System.Data.OleDb.OleDbCommand

                Dim strsql As String = ""
                strsql = "select username,passw from users"


                cn.ConnectionString = cf.apconstring
                cn.Open()


                cmd.Connection = cn
                cmd.CommandText = strsql

                myreader = cmd.ExecuteReader
                If myreader.HasRows Then
                    While myreader.Read
                        txtusername.Text = myreader.GetValue(0).ToString
                        txtpassword.Text = myreader.GetValue(1).ToString
                    End While
                End If

                If txtusername.Text = "admin" Then
                    Label1.Text = "Kindly Change Your Username and Password For Security"
                End If

                cn.Close()
            Catch ex As Exception
                Response.Write(ex.Message)

            End Try


        End If

        ' Button1.Enabled = False
        ' Label1.Text = "Username and Password Disabled in Demo mode, Click on Menu Option and Carry on"

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
