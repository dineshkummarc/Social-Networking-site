Imports System.Data
Imports System.Data.OleDb

Partial Class Sadmin_totalmem
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        

    End Sub

    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridViewPublishers.PageIndexChanging
        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
    End Sub

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = AccessConnectionString()

        Dim accessConnection As OleDbConnection = New OleDbConnection(connectionString)


        Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim jointype As String = ""


        jointype = " Left join"



        sqlQuery = "select distinct profile.pid,profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,photoname,email,profile.passw  from profile" & jointype & " photo on  profile.pid=photo.pid where visibletoall='Y'   " & makequery()

        sqlQuery = sqlQuery & "order by profiledate desc"


        Dim accessCommand As New OleDbCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New OleDbDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()

        End If


        accessConnection.Close()

    End Sub

    Private Function AccessConnectionString() As String

        AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        'Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", accessDatabasePath)

    End Function

    Function makequery() As String
        
        makequery = "" ' sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonlinenow

    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If checklogin() = False Then
            Response.Redirect("~/adminlogin.aspx")
            Exit Sub
        End If

        If Page.IsPostBack = False Then
            PopulatePublishersGridView()
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
