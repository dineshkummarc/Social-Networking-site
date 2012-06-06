Imports System.Web
Imports System.Web.Security

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

            '/// not to remove this link
            '// copy right requirment
            HyperLink3.Text = "Dating Software From Websol"
            HyperLink3.NavigateUrl = "http://www.websol-dating-software.com"

            '// if you want to remove this link
            '// you got to pay us $10 for link removal
            '//thank you

            If Request.QueryString("affid") <> "" Then

                Response.Cookies("referby").Value = Request.QueryString("affid")
                Response.Cookies("referby").Expires = DateTime.Now.AddDays(60)

            End If

            'Dim kuki As HttpCookie
            'kuki.Value = Request.QueryString("affid")

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

