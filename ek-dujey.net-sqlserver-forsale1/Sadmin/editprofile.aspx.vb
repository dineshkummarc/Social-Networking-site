Imports System.Data.SqlClient
Imports System.Data

Partial Class Sadmin_editprofile
    Inherits System.Web.UI.Page
    
    Dim cf As New comonfunctions
    
    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        Dim strsql As String = ""


        cn.ConnectionString = cf.friendshipdb
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

       

        If Page.IsPostBack = False Then
            Try
                Dim myreader As SqlDataReader
                Dim cn As New SqlConnection
                Dim cmd As New SqlCommand

                Dim strsql As String = ""
                strsql = "select username,passw from users"


                cn.ConnectionString = cf.friendshipdb
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

        'Button1.Enabled = False
        'Label1.Text = "Username and Password Disabled in Demo mode, Click on Menu Option and Carry on"

    End Sub


  
End Class
