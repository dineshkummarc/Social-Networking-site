
Partial Class members_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim kkkkkkk As New comonfunctions

    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus1.LoggingOut
        Dim strsession As String = Session("pid").ToString


        kkkkkkk.logoffuser(strsession)
        Session("pid") = ""
        
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TH1.InnerHtml = "<font size='5'>" & kkkkkkk.websitename & "</font> <br><font size='2'>" & kkkkkkk.subtitle & "</font>"
    End Sub
End Class

