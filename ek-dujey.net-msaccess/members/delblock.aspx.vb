
Partial Class members_delblock
    Inherits System.Web.UI.Page

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        cnstring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        cn.ConnectionString = cnstring
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "delete from blacklisted where memberidblocked='" & Request.QueryString("pid") & "' and pid='" & Session("pid") & "'"
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            Label1.Text = "Block Removed Succesfully"
        Else
            Label1.Text = " Block not Found"
        End If

        cn.Close()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LinkButton1.Text = "Are You Sure You Want To Remove Your Blocked Profile?"
        Else
            LinkButton1.Text = ""
        End If
    End Sub
End Class
