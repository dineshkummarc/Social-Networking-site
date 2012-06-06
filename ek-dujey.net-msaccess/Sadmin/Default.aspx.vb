
Partial Class Sadmin_Default
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions

    

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim kk As String = ""
        Try




            kk = cf.update("update profile set isonlinenow='N'")
            If kk = "True" Then
                Button1.Text = "Users Online Reseted"
            End If
        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub


    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try



            If checklogin() = False Then
                Response.Redirect("~/adminlogin.aspx")
                Exit Sub
            End If

            

            lblRegtoday.Text = cf.CountRs("select count(*) as cnt from profile where profiledate=date()")
            lblUnApproved.Text = cf.CountRs("select count(*) as cnt from profile where approved='N'")
            lblunApprovedPhotos.Text = cf.CountRs("select count(*) as cnt from photo where active='N'")
            lblTotMem.Text = cf.CountRs("select count(*) as cnt from profile")

          

        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
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
