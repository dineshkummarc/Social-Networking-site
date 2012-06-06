Imports System.Data
Imports System.Data.SqlClient

Partial Class Sadmin_paymentapproved
    Inherits System.Web.UI.Page

    Public cf As New comonfunctions

    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridViewPublishers.PageIndexChanging
        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
    End Sub

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = cf.friendshipdb()

        Dim accessConnection As SqlConnection = New SqlConnection(connectionString)


        '      Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim jointype As String = ""



        sqlQuery = "select * from paymentApproved where paymentnumber=''"




        Dim accessCommand As New SqlCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New SqlDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()
        Else

            label1.Text = "No Payments Pending"

        End If

        accessConnection.Close()


    End Sub











    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Page.IsPostBack = False Then
            PopulatePublishersGridView()
        End If
    End Sub
End Class
