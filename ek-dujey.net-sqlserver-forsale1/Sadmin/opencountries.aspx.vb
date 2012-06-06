Imports system.Data
Imports System.Data.OleDb
Partial Class Sadmin_opencountries
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = AccessConnectionString()

        Dim accessConnection As OleDbConnection = New OleDbConnection(connectionString)



        Dim sqlQuery As String = ""




        sqlQuery = makequery()



        Dim accessCommand As New OleDbCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New OleDbDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataTable.Clear()
        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable
            gridViewPublishers.DataBind()

        Else

            '  label1.Text = "No Favourite Members Found"

        End If


        accessConnection.Close()

    End Sub



    Private Function AccessConnectionString() As String

        AccessConnectionString = cf.Conipcountry

        'Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", accessDatabasePath)

    End Function




    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        'gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), True)

        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
        'gridViewPublishers.DataBind()

    End Sub

    Function makequery() As String
        makequery = " select distinct countryname from [ip-to-country] where isdoubtful='N' "
    End Function

    


    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PopulatePublishersGridView()
        End If
    End Sub


End Class
