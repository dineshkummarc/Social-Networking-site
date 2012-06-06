Imports System.Data
Imports System.Data.SqlClient
Partial Class searchresults
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim err As String = ((("<b>Error Caught in Page_Error event</b><hr><br>" & "<br><b>Error in: </b>") + Request.Url.ToString() & "<br><b>Error Message: </b>") + objErr.Message.ToString() & "<br> jointype is " & txtjointype.Text & "--<br>" & TextBox1.Text & "  <b>Stack Trace:</b><br>") + objErr.StackTrace.ToString()
        ' Response.Write(err.ToString())

        Server.ClearError()


      

        cf.send25("err", "searchresults.aspx", cf.adminemail, err)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Page.IsPostBack = True Then

        If Not Page.PreviousPage Is Nothing Then

            '   TextBox1.Text = PreviousPage.CurrentCity
            'dcountry.Value = PreviousPage.c
            hdcountry.Value = PreviousPage.Country
            hdage1.Value = PreviousPage.ag1
            hdage2.Value = PreviousPage.ag2
            hdgender.Value = PreviousPage.gender
            hdwithphoto.Value = PreviousPage.withphoto

            If PreviousPage.withphoto = True Then
                hdwithphoto.Value = "Y"
                txtjointype.Text = " inner join"
            Else
                hdwithphoto.Value = "N"
                txtjointype.Text = " Left join"
            End If


            If PreviousPage.onlinenow = True Then
                hdonlinenow.Value = "Y"
            Else
                hdonlinenow.Value = "N"
            End If


            makequery()
        End If

        ' 
        ' End If


        'If Page. Then

        'End If

    End Sub


    Protected Sub gridview1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridview1.RowDataBound
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

            If (url <> "" Or url IsNot Nothing) And (pasw <> "") Then
                Dim img As Image = DirectCast(e.Row.FindControl("img"), Image)
                If img IsNot Nothing Then
                    img.ImageUrl = "App_Themes/request-photo-large-1.gif"
                End If
            End If


        End If
    End Sub

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
            sqlage = " and DateDiff(yyyy,profile.bdate,getdate())>=" & hdage1.Value
        End If

        If hdage2.Value <> "" Then
            sqlage = sqlage & " and DateDiff(yyyy,profile.bdate,getdate())<=" & hdage2.Value
        End If

        If hdgender.Value.ToString <> "" Then
            sqlgender = " and profile.gender='" & hdgender.Value.ToString & "'"
        End If

        If hdonlinenow.Value.ToString <> "" Then
            sqlonlinenow = " and profile.isonlinenow='" & hdonlinenow.Value.ToString & "'"
        End If

        makequery = sqlcountry & sqlstate & sqlpincode & sqlgender & sqlrace & sqlreligion & sqlmarital & sqlstarsign & sqlheight & sqlage & sqlonlinenow

        TextBox1.Text = " hid='N' " & makequery
    End Function

   
End Class
