Imports System.Data
Imports System.Data.OleDb

Partial Class onlinemem
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridViewPublishers.PageIndexChanging
        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
    End Sub

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = AccessConnectionString()

        Dim accessConnection As OleDbConnection = New OleDbConnection(connectionString)


        '      Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim jointype As String = ""

        

        sqlQuery = "select distinct profile.pid,profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active='Y') as photoname,photo.passw  from profile left join photo on  profile.pid=photo.pid where visibletoall='Y' and isonlinenow='Y' and approved='Y'  "

        sqlQuery = sqlQuery & "order by profiledate desc"


        Dim accessCommand As New OleDbCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New OleDbDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()
        Else

            label1.Text = "No Members Online"

        End If

        accessConnection.Close()


    End Sub

    Private Function AccessConnectionString() As String

        AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        'Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", accessDatabasePath)

    End Function

    

   

    Protected Sub gridViewPublishers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridViewPublishers.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim pasw As String = TryCast(DataBinder.Eval(e.Row.DataItem, "passw"), String)
            Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photoname"), String)

            If (url <> "" Or url IsNot Nothing) And (pasw = "" Or pasw Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "App_Themes/" & url
                End If
            End If

            If (url = "" Or url Is Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "App_Themes/no_avatar.gif"
                End If
            End If

            If (url <> "" Or url IsNot Nothing) And (pasw <> "" Or pasw IsNot Nothing) Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "App_Themes/request-photo-large-1.gif"
                End If
            End If


        End If
    End Sub

   
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Page.IsPostBack = False Then
            PopulatePublishersGridView()
        End If
    End Sub
End Class
