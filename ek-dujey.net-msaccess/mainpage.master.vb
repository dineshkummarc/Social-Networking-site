
Partial Class mainpage
    Inherits System.Web.UI.MasterPage

    Dim kkkkk As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            '  If getsessionid() <> "" Then
            'HyperLink5.Text = "Your Area"
            'Else
            'HyperLink5.Text = "Login"
            'End If
            TH1.InnerHtml = "<font size='5'>" & kkkkk.websitename & "</font> <br><font size='2'>" & kkkkk.subtitle & "</font>"

            HyperLink3.Text = "Dating Software From Websol"
            HyperLink3.NavigateUrl = "http://www.websol-dating-software.com"

        Catch ex As Exception

        End Try
    End Sub
    Function getsessionid() As String
        'Dim strpid As String = ""
        getsessionid = ""

        'Try
        'strpid = CType(Session("pid"), String)
        'Catch ex As Exception
        'strpid = ""
        'End Try

    End Function

    
End Class

