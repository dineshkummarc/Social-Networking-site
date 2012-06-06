Imports System.IO

Partial Class Sadmin_delpic
    Inherits System.Web.UI.Page

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        Dim cf As New comonfunctions
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim strsql As String = ""
        Dim cc As Boolean
        strsql = "select photoname from photo where photoid='" & Request.QueryString("pid") & "'"

        cn.ConnectionString = cf.friendshipdb()
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = strsql

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                kk = deletephoto(myreader.GetString(0).ToString)
            End While
        End If

        cn.Close()


        cc = cf.delrecordset("delete from photo where photoid='" & Request.QueryString("pid") & "'")

        If cc = True Then
            Label1.Text = "Photo Deleted"
        End If
    End Sub

    Function deletephoto(ByVal photo As String) As String
        Dim imgfolder As String = ""
        imgfolder = Server.MapPath("..\App_Themes") & "\" & photo
        If File.Exists(imgfolder) Then
            File.Delete(imgfolder)
            Return "photo Deleted"
        Else
            Return "photo not Found"
        End If
    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
       
        If checklogin() = False Then
            Response.Redirect("~/adminlogin.aspx")
            Exit Sub
        End If

        If Page.IsPostBack = False Then
            LinkButton1.Text = "Are You Sure You Want To Remove Your Photo?"
        Else
            LinkButton1.Text = ""
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
