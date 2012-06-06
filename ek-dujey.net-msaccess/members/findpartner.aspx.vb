Imports System.Data
Imports System.Data.OleDb

Partial Class members_findpartner
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Dim queryforentry As String = ""

    Private Sub PopulatePublishersGridView()

        Dim connectionString As String = AccessConnectionString()

        Dim accessConnection As OleDbConnection = New OleDbConnection(connectionString)


        Dim email As String = ""
        Dim sqlQuery As String = ""
        Dim Jointype As String = ""

        Try
            If chkphoto.Checked = True Then
                Jointype = " inner join"
            Else
                Jointype = " Left join"

            End If

            sqlQuery = "select distinct profile.pid,profile.profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active='Y') as photoname,photo.passw  from profile " & Jointype & " photo on  profile.pid=photo.pid where approved='Y' and " & makequery()


            queryforentry = sqlQuery





            sqlQuery = sqlQuery & " order by Profiledate desc"

            '        Response.Write(sqlQuery)

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

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try


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



    
    Function makequery() As String
        'Dim country, sqlcountry, state, sqlstate, city, sqlcity As String
        Dim sqlcountry As String = ""
        Dim sqlstate As String = ""
        Dim sqlcity As String = ""
        Dim sqlpincode As String = ""
        Dim sqlgender As String = ""
        Dim sqlrace As String = ""
        Dim sqlreligion As String = ""
        Dim sqlstarsign As String = ""
        Dim sqlmaritalstatus As String = ""
        Dim sqlheight As String = ""
        Dim sqlage As String = ""
        Dim sqlmarital As String = ""
        Dim sqlonline As String = ""
        Dim sqlchkphoto As String = ""

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

        If dpmaritalstatus.SelectedValue <> "" Then
            sqlmarital = " and profile.maritalstatus='" & dpmaritalstatus.SelectedValue & "'"
        End If

        If dpstarsign.Text <> "" Then
            sqlstarsign = " and profile.starsign='" & dpstarsign.Text & "'"
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
        '  sqlchkphoto = " and (photo.passw='' or photo.passw is null) "
        'End If

        makequery = sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonline & sqlchkphoto & sqlcity

    End Function
    Function addalertentry(ByVal query, ByVal em) As String

        Dim cnstring As String = ""
        
        Dim cc As New comonfunctions
        Dim rzlt As String = ""
        Dim regmsg As String = ""
        Dim uid As String = ""
        Dim strfield As String = ""
        Dim strvalues As String = ""
        Dim StrSql As String = ""

        Dim con As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand



        cnstring = ConfigurationManager.ConnectionStrings("foralerts").ConnectionString
        con.ConnectionString = cnstring
        con.Open()

        uid = Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Millisecond

        strfield = " insert into alert(searchno,candiid,query,queryname,email) values("
        strvalues = " @searchno,@candiid,@query,@queryname,@email)"

        StrSql = strfield & strvalues
        

        If checkingnoofentryies() >= 10 Then
            con.Close()
            addalertentry = "you can only save 10 enteries "
        Else

            cmd.Parameters.AddWithValue("@searchno", uid)
            cmd.Parameters.AddWithValue("@candiid", Session("pid"))
            cmd.Parameters.AddWithValue("@query", query & "  ")
            cmd.Parameters.AddWithValue("@queryname", txtqueryname.Text.ToString)
            cmd.Parameters.AddWithValue("@email", txtemail.Text.ToString)

            cmd.Connection = con
            cmd.CommandText = StrSql
            cmd.ExecuteNonQuery()

            regmsg = "Alert Verification Required <br>"
            regmsg = regmsg & "http://www." & ConfigurationManager.AppSettings("websitename").ToString & "/members/verifyalert.aspx?alertid=" & uid & "&b=" & Session("pid").ToString
            regmsg = regmsg & "<br>You have got this email because you have created Partner alert"

            If txtemail.Text.ToString <> "" Then
                rzlt = cc.send25("alert", "Alert Query Verification", em.ToString, regmsg)
            End If
            con.Close()
            addalertentry = "Alert Entry added " & rzlt
        End If


    End Function

    Function checkingnoofentryies() As Integer
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim numbofrows As Integer = 0

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "select count(*) from alert where candiid='" & Session("pid") & "'"


        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                numbofrows = myreader.GetValue(0).ToString
            End While
            cn.Close()
            Return numbofrows
        Else
            cn.Close()
            Return numbofrows
        End If
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

    
    
   
   
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        PopulatePublishersGridView()
        If txtqueryname.Text <> "" Then
            label1.Text = addalertentry(queryforentry, txtemail.Text)
        End If
    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Page.IsPostBack = True Then
            label1.Text = ""
            searchresults.Visible = True
            searchform.Visible = False
        Else
            label1.Text = ""
            searchresults.Visible = False
            searchform.Visible = True
        End If
    End Sub
End Class
