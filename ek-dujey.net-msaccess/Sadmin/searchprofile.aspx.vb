Imports System.Data
Imports System.Data.OleDb

Partial Class Sadmin_searchprofile
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = AccessConnectionString()

        Dim accessConnection As OleDbConnection = New OleDbConnection(connectionString)


        Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim Jointype As String = ""

        If chkphoto.Checked = True Then
            jointype = " inner join"
        Else
            jointype = " Left join"

        End If

        sqlQuery = "select distinct profile.pid,profile.profiledate,email,profile.passw, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,(select top 1 photoname from photo where photo.pid=profile.pid)as photoname  from profile " & Jointype & " photo on  profile.pid=photo.pid where   " & makequery()

        

        sqlQuery = sqlQuery & " order by Profiledate desc"



        Dim accessCommand As New OleDbCommand(sqlQuery, accessConnection)



        Dim publishersDataAdapter As New OleDbDataAdapter(accessCommand)

        Dim publishersDataTable As New DataTable("profile")

        publishersDataAdapter.Fill(publishersDataTable)



        Dim dataTableRowCount As Integer = publishersDataTable.Rows.Count



        If dataTableRowCount > 0 Then

            gridViewPublishers.DataSource = publishersDataTable

            gridViewPublishers.DataBind()
        Else
            label1.Text = "No Profile Found, Kindly Expand Your Search Criteria"

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

    Protected Sub Page_InitComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.InitComplete

    End Sub



    
    Function makequery() As String
        'Dim country, sqlcountry, state, sqlstate, city, sqlcity As String
        Dim sqlcountry As String = ""
        Dim sqlstate As String = ""
        Dim sqlcity As String = ""
        Dim sqlpincode As String = ""
        Dim sqlgender As String = ""
        Dim sqlrace As String = ""
        Dim sqlreligion As String = ""
        Dim sqlCaste As String = ""
        Dim sqlstarsign As String = ""
        Dim sqlmaritalstatus As String = ""
        Dim sqlheight As String = ""
        Dim sqlage As String = ""
        Dim sqlmarital As String = ""
        Dim sqlonline As String = ""
        Dim sqlchkphoto As String = ""
        Dim sqlprofileid As String = ""
        Dim sqldescription As String = ""

        If dpcountry.Text <> "" Then
            sqlcountry = " profile.countryid=" & dpcountry.SelectedValue & " "

        End If
        If txtstate.Text <> "" Then
            sqlstate = " and profile.state like '%" & txtstate.Text & "%'"
        End If

        If txtCity.Text <> "" Then
            sqlcity = " and profile.cityid like '%" & txtCity.Text & "%'"
        End If

        If txtpincode.Text <> "" Then
            sqlpincode = " and profile.pincode like '%" & txtpincode.Text & "%'"
        End If

        If gender.SelectedValue.ToString <> "" Then
            sqlgender = " and profile.gender='" & gender.SelectedValue.ToString & "'"
        End If

        If dpRace.Text <> "" Then
            sqlrace = " and profile.ethnic='" & dpRace.SelectedValue.ToString & "'"
        End If

        If dpreligion.Text <> "" Then
            sqlreligion = " and profile.religion='" & dpreligion.Text & "'"
        End If

        If txtCaste.Text <> "" Then
            sqlCaste = " and profile.caste like '%" & txtCaste.Text.ToString & "%'"
        End If

        If dpstarsign.Text <> "" Then
            sqlstarsign = " and profile.starsign='" & dpstarsign.Text & "'"
        End If

        If txtDescription.Text <> "" Then
            sqldescription = " and profile.whoami like '%" & txtDescription.Text.ToString & "%'"
        End If


        If dpmaritalstatus.SelectedValue <> "" Then
            sqlmarital = " and profile.maritalstatus='" & dpmaritalstatus.SelectedValue & "'"
        End If

        
        If dpheight1.SelectedValue <> "" Then
            sqlheight = " and height>=" & dpheight1.SelectedValue & ""
        End If

        If dpheight2.SelectedValue <> "" Then
            sqlheight = sqlheight & " and height<=" & dpheight2.SelectedValue & ""
        End If

        If dpage1.Text <> "" Then
            sqlage = " and DateDiff('yyyy',profile.bdate,date())>=" & dpage1.Text
        End If

        If dpage2.Text <> "" Then
            sqlage = sqlage & " and DateDiff('yyyy',profile.bdate,date())<=" & dpage2.Text
        End If

        If chkonlinenow.Checked = True Then
            sqlonline = " and isonlinenow='Y'"
        End If

        'If chkphoto.Checked = True Then
        sqlchkphoto = " " ' and (photo.passw='' or photo.passw is null) "
        'End If
        If txtprofileid.Text <> "" Then
            sqlprofileid = " and profile.pid like '%" & txtprofileid.Text.ToString & "%'"
        End If

        makequery = sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlCaste & sqldescription & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonline & sqlchkphoto & sqlcity & sqlprofileid

    End Function
 
    
    
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If checklogin() = False Then
            Response.Redirect("~/adminlogin.aspx")
            Exit Sub
        End If

        If Page.IsPostBack = True Then
            searchresults.Visible = True
            searchform.Visible = False
        Else
            searchresults.Visible = False
            searchform.Visible = True
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

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        PopulatePublishersGridView()
    End Sub
End Class
