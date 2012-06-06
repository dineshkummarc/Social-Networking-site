Imports System.Data
Imports System.Data.SqlClient

Partial Class Sadmin_searchprofile
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

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
        Dim sqlemail As String = ""

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
            sqlage = " and DateDiff(yyyy,profile.bdate,getdate())>=" & dpage1.Text
        End If

        If dpage2.Text <> "" Then
            sqlage = sqlage & " and DateDiff(yyyy,profile.bdate,getdate())<=" & dpage2.Text
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

        If txtemail.Text <> "" Then
            sqlemail = " and profile.email like '%" & txtemail.Text.ToString & "%'"
        End If

        makequery = sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlCaste & sqldescription & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonline & sqlchkphoto & sqlcity & sqlprofileid & sqlemail
        TextBox1.Text = makequery
    End Function



    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete


        If Page.IsPostBack = True Then
            searchresults.Visible = True
            searchform.Visible = False
        Else
            searchresults.Visible = False
            searchform.Visible = True
            loadcountry()
        End If



    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        makequery()
    End Sub

    Sub loadcountry()
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim strsql As String = ""

        strsql = "select countryid,countryname from country"
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader


        dpcountry.DataSource = myreader
        dpcountry.DataValueField = "countryid"
        dpcountry.DataTextField = "countryname"
        dpcountry.DataBind()

        cn.Close()
    End Sub
    Protected Sub gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridview1.RowDataBound
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

            If (url <> "" Or url IsNot Nothing) And (pasw <> "") Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "../App_Themes/request-photo-large-1.gif"
                End If
            End If


        End If
    End Sub


End Class
