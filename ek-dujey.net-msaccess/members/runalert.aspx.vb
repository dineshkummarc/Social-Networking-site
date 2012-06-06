Imports System.Data
Imports System.Data.OleDb


Partial Class members_runalert
    Inherits System.Web.UI.Page

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = AccessConnectionString()

        Dim accessConnection As OleDbConnection = New OleDbConnection(connectionString)


        Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim Jointype As String = ""

        

        sqlQuery = makequery() & " order by profiledate desc "

        'sqlQuery = sqlQuery '& '"order by Profiledate desc"

        

        Dim accessCommand As New OleDbCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New OleDbDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()

        Else
            Label1.Text = "No Members Found"
        End If


        accessConnection.Close()

    End Sub



    Private Function AccessConnectionString() As String

        AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        'Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", accessDatabasePath)

    End Function



    Private Property GridViewSortDirection() As String

        Get

            Return IIf(ViewState("SortDirection") = Nothing, "ASC", ViewState("SortDirection"))

        End Get

        Set(ByVal value As String)

            ViewState("SortDirection") = value

        End Set

    End Property



    Private Property GridViewSortExpression() As String

        Get

            Return IIf(ViewState("SortExpression") = Nothing, String.Empty, ViewState("SortExpression"))

        End Get

        Set(ByVal value As String)

            ViewState("SortExpression") = value

        End Set

    End Property



    Private Function GetSortDirection() As String

        Select Case GridViewSortDirection

            Case "ASC"

                GridViewSortDirection = "DESC"



            Case "DESC"

                GridViewSortDirection = "ASC"

        End Select



        Return GridViewSortDirection

    End Function



    Protected Sub gridViewPublishers_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)

        'gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), True)

        gridViewPublishers.PageIndex = e.NewPageIndex
        PopulatePublishersGridView()
        'gridViewPublishers.DataBind()

    End Sub



    Protected Function SortDataTable(ByVal pdataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView

        If Not pdataTable Is Nothing Then

            Dim pdataView As New DataView(pdataTable)

            If GridViewSortExpression <> String.Empty Then

                If isPageIndexChanging Then

                    pdataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)

                Else

                    pdataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())

                End If

            End If

            Return pdataView

        Else

            Return New DataView()

        End If

    End Function



    Protected Sub gridViewPublishers_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression

        Dim pageIndex As Integer = gridViewPublishers.PageIndex

        gridViewPublishers.DataSource = SortDataTable(CType(gridViewPublishers.DataSource, DataTable), False)

        gridViewPublishers.DataBind()

        gridViewPublishers.PageIndex = pageIndex

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'If Page.IsPostBack = True Then
        ' searchresults.Visible = True
        ' searchform.Visible = False
        If Request.QueryString("alid") <> "" Then
            If Page.IsPostBack = False Then
                PopulatePublishersGridView()
            End If
        Else
            Label1.Text = "Alert id not found"
        End If
        'Else

        ' searchresults.Visible = False
        ' searchform.Visible = True
        ' End If


    End Sub
    Function makequery() As String
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim kk As String = ""

        cn.ConnectionString = ConfigurationManager.ConnectionStrings("foralerts").ConnectionString
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select query from alert where candiid=@pid and searchno=@searchno"
        cmd.Parameters.Add("@pid", Data.OleDb.OleDbType.VarChar).Value = Session("pid")
        cmd.Parameters.Add("@searchno", Data.OleDb.OleDbType.VarChar).Value = Request.QueryString("alid").ToString

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                kk = myreader.GetString(0).ToString
            End While

            
            Return kk
        Else
            Return "no such alert found"
        End If

        
        cn.Close()

    End Function

    Protected Sub gridViewPublishers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridViewPublishers.RowDataBound
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
    End Sub

    
End Class
