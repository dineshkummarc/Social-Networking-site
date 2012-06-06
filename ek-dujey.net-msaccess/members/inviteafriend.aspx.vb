
Partial Class members_inviteafriend
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Page.IsPostBack = False Then
            Label1.Text = ""
        End If
        Dim msg As String = ""
        msg = "hi there,<br>your friend " & Session("fname") & " " & Session("lname")
        msg = msg & "<br>wants you to join http://www." & cf.websitename
        msg = msg & "<br>its a free site, you can send email to other members free"
        msg = msg & "<br>here you can find your dream life partner<br>Join Here"
        msg = msg & "<br>All Educated Guys Registered Here <br>"
        msg = msg & "<br>Best Luck in Your Search"
        '  txtmsg.InnerHtml = msg
        dd.InnerHtml = msg
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = cf.send25("invite", "Hi " & Session("fname") & " Here ", txtemail.Text.ToString, dd.InnerHtml)
    End Sub

    
End Class
