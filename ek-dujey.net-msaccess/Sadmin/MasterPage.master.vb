
Partial Class Sadmin_MasterPage
    Inherits System.Web.UI.MasterPage
    Dim kkkkk As New comonfunctions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        'Session("username") = myreader.GetString(1).ToString
        'Session("role") = myreader.GetString(2).ToString
        TH1.InnerHtml = "<font size='5'>" & kkkkk.websitename.ToString & "</font> <br><font size='2'>" & kkkkk.subtitle.ToString & "</font>"
    End Sub
End Class

