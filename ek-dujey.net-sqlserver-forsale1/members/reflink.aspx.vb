
Partial Class members_reflink
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim msg As String = ""
        txtreflink.Text = "http://www." & cf.websitename & "/default.aspx?affid=" & Session("pid")

        msg = "hi there," & vbCrLf & "  join me here"
        msg = msg & vbCrLf & " http://www." & cf.websitename & "/default.aspx?affid=" & Session("pid")
        msg = msg & vbCrLf & vbCrLf & " its a free site, you can send email to other members free"
        msg = msg & vbCrLf & " Join with me here you can find your Buddy"
        msg = msg & vbCrLf & " All Cool People are Registered Here "
        msg = msg & vbCrLf & " Come Join have fun"

        TextBox1.Text = msg

        TD1.InnerText = "You can Point to Any Page just add ?affid=" & Session("pid")

    End Sub
End Class
