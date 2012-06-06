
Partial Class Sadmin_approveprofile
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim msg As String = ""
        Dim kk As Boolean
        kk = cf.update("update profile set Approved='Y', isdoubtful='N', susp='N' where pid='" & Request.QueryString("pid") & "'")


        If kk = True Then
            msg = "Congrats<br>Your Profile  has been Approved <br> Happy Hunting <br><br> http://www." & cf.websitename
            cf.sendemailtouser(Request.QueryString("pid"), "Profile Approved", msg)
            msgaa.InnerHtml = "Profile Approved"
        End If

        If Request.QueryString("photo") = "Y" Then
            kk = cf.update("update photo set active='Y' where pid='" & Request.QueryString("pid") & "'")
            msgaa.InnerHtml = "Profile Approved With Photo"
        End If

    End Sub

End Class
