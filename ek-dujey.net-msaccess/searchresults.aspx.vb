Imports System.Data
Imports System.Data.OleDb
Partial Class searchresults
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Page.IsPostBack = True Then

        If Not Page.PreviousPage Is Nothing Then

            'TextBox1.Text = PreviousPage.CurrentCity
            'dcountry.Value = PreviousPage.c
            hdcountry.Value = PreviousPage.Country
            hdage1.Value = PreviousPage.ag1
            hdage2.Value = PreviousPage.ag2
            hdgender.Value = PreviousPage.gender
            hdwithphoto.Value = PreviousPage.withphoto

            If PreviousPage.withphoto = True Then
                hdwithphoto.Value = "Y"
            Else
                hdwithphoto.Value = "N"
            End If


            If PreviousPage.onlinenow = True Then
                hdonlinenow.Value = "Y"
            Else
                hdonlinenow.Value = "N"
            End If


            PopulatePublishersGridView()
        End If

        ' 
        ' End If


        'If Page. Then

        'End If

    End Sub

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

        If hdwithphoto.Value = "Y" Then
            jointype = " inner join"
        Else
            jointype = " Left join"

        End If

        sqlQuery = "select distinct profile.pid,profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active='Y') as photoname,photo.passw  from profile" & jointype & " photo on  profile.pid=photo.pid where visibletoall='Y' and approved='Y'   " & makequery()

        sqlQuery = sqlQuery & "order by profiledate desc"

        'Response.Write(sqlQuery)

        Dim accessCommand As New OleDbCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New OleDbDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")



        publishersDataAdapter.Fill(publishersDataTable)

        'publishersDataTable.DataSet.Tables.Item("photoname").Select(  

        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count





        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()
        Else

            label1.Text = "No Members Found"

        End If
        

        accessConnection.Close()

    End Sub

    Private Function AccessConnectionString() As String

        AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        'Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", accessDatabasePath)

    End Function

    Function makequery() As String
        'Dim country, sqlcountry, state, sqlstate, city, sqlcity As String
        Dim sqlcountry As String = ""
        Dim sqlstate As String = ""
        Dim sqlpincode As String = ""
        Dim sqlgender As String = ""
        Dim sqlrace As String = ""
        Dim sqlreligion As String = ""
        Dim sqlstarsign As String = ""
        Dim sqlmaritalstatus As String = ""
        Dim sqlheight As String = ""
        Dim sqlage As String = ""
        Dim sqlmarital As String = ""
        Dim sqlonlinenow As String = ""



        If hdcountry.Value <> "" Then
            sqlcountry = "  and countryid=" & hdcountry.Value
        End If

        If hdage1.Value <> "" Then
            sqlage = " and DateDiff('yyyy',profile.bdate,date())>=" & hdage1.Value
        End If

        If hdage2.Value <> "" Then
            sqlage = sqlage & " and DateDiff('yyyy',profile.bdate,date())<=" & hdage2.Value
        End If

        If hdgender.Value.ToString <> "" Then
            sqlgender = " and profile.gender='" & hdgender.Value.ToString & "'"
        End If

        If hdonlinenow.Value.ToString <> "" Then
            sqlonlinenow = " and profile.isonlinenow='" & hdonlinenow.Value.ToString & "'"
        End If

        makequery = sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonlinenow

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
   
   
End Class
