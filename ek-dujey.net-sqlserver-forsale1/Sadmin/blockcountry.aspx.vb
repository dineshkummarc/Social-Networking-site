
Partial Class Sadmin_blockcountry
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim strsql As String = ""
        Dim rtn As Integer = 0

        strsql = "update [ip-to-country] set isdoubtful='Y' where countryname like '%" & Request.QueryString("id") & "%'"
        cn.ConnectionString = cf.Conipcountry
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql

        rtn = cmd.ExecuteNonQuery
        Label1.Text = Request.QueryString("id")

    End Sub
End Class
