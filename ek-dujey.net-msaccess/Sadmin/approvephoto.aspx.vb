
Partial Class Sadmin_approvephoto
    Inherits System.Web.UI.Page

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        
        

        Dim cf As New comonfunctions
        Dim kk As Boolean

        If checklogin() = False Then
            Response.Redirect("~/adminlogin.aspx")
            Exit Sub
        End If

        If Request.QueryString("pid") <> "" Then
            kk = cf.update("update photo set active='Y' where photoid='" & Request.QueryString("pid") & "'")
        End If

        If kk = True Then
            Label1.Text = "Photo Approved"
        Else
            Label1.Text = "Photo Not Found"
        End If

        If Session("username").ToString = "" Then
            Response.Redirect("~/adminlogin.aspx")
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

End Class
