Imports System.Data
Imports System.Data.OleDb


Partial Class members_blockedmem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub
    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = AccessConnectionString()

        Dim accessConnection As OleDbConnection = New OleDbConnection(connectionString)

        Try


            Dim sqlQuery As String = ""




            sqlQuery = makequery()



            Dim accessCommand As New OleDbCommand(sqlQuery, accessConnection)



            Dim publishersDataAdapter As New OleDbDataAdapter(accessCommand)

            Dim publishersDataTable As New DataTable("profile")

            publishersDataAdapter.Fill(publishersDataTable)



            Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



            If dataTableRowCount > 0 Then

                gridViewPublishers.DataSource = publishersDataTable

                gridViewPublishers.DataBind()
            Else
                label1.Text = "No Blocked Members Found"

            End If

            accessConnection.Close()

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try


    End Sub



    Private Function AccessConnectionString() As String

        AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        'Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", accessDatabasePath)

    End Function



   



    


    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        'gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), True)
        Try
            gridViewPublishers.PageIndex = e.NewPageIndex
            PopulatePublishersGridView()
            'gridViewPublishers.DataBind()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub



    Function makequery() As String
        makequery = " select distinct memberidblocked,fname,(select top 1 photoname from  photo where photo.pid=f.memberidblocked and p.active='Y') as photoname,p.passw from blacklisted f left join photo p on f.memberidblocked=p.pid  where f.pid='" & Session("pid") & "'"
    End Function

    Protected Sub gridViewPublishers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridViewPublishers.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim pasw As String = TryCast(DataBinder.Eval(e.Row.DataItem, "passw"), String)
                Dim url As String = TryCast(DataBinder.Eval(e.Row.DataItem, "photoname"), String)

                If (url <> "" Or url IsNot Nothing) And (pasw = "" Or pasw Is Nothing) Then
                    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                    If img IsNot Nothing Then
                        img.ImageUrl = "../App_Themes/" & url
                    End If
                End If

                If (url = "" Or url Is Nothing) Then
                    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                    If img IsNot Nothing Then
                        img.ImageUrl = "../App_Themes/no_avatar.gif"
                    End If
                End If

                If (url <> "" Or url IsNot Nothing) And (pasw <> "" Or pasw IsNot Nothing) Then
                    Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                    If img IsNot Nothing Then
                        img.ImageUrl = "../App_Themes/request-photo-large-1.gif"
                    End If
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    
    
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Not Page.IsPostBack Then
                PopulatePublishersGridView()
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class
