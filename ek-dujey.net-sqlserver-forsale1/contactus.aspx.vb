
Partial Class contactus
    Inherits System.Web.UI.Page

    

    
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cf As New comonfunctions


        Dim content As String = ""

        Try
            content = "mail from " & txtname.Text & "<br>email " & txtemail.Text & "<br><br>" & txtcomments.Value

            lblstatus.Text = cf.send25("contactus", "Email from " & cf.websitename, cf.adminemail, content)

        Catch ex As Exception
            lblstatus.Text = ex.ToString
        End Try

    End Sub
End Class
