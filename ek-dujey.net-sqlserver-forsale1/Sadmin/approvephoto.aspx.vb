
Partial Class Sadmin_approvephoto
    Inherits System.Web.UI.Page

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        
        

        Dim cf As New comonfunctions
        Dim kk As Boolean



        If Request.QueryString("pid") <> "" Then
            kk = cf.update("approvephoto '" & Request.QueryString("pid") & "'")
        End If

        If kk = True Then
            Label1.Text = "Photo Approved"
        Else
            Label1.Text = "Photo Not Found"
        End If

      

    End Sub

   

End Class
