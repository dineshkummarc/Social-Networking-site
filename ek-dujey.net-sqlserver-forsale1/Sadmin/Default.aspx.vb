
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



           

            

            lblRegtoday.Text = cf.CountRs("select count(*) as cnt from profile where convert(varchar(10),profiledate,103)=convert(varchar(10),getdate(),103)")
            lblUnApproved.Text = cf.CountRs("select count(*) as cnt from profile where approved='N' and susp='N'")
            lblunApprovedPhotos.Text = cf.CountRs("select count(*) as cnt from photo where active='N'")
            lblTotMem.Text = cf.CountRs("select count(*) as cnt from profile")
            lblsuspendedcount.Text = cf.CountRs("select count(*) as cnt from profile where susp='Y'")
            lblDoubtfulprofile.Text = cf.CountRs("select count(*) as cnt from profile where  isdoubtful='Y' and  susp='N'")

        Catch ex As Exception
            Response.Write(ex.Message)

        End Try
    End Sub

    

End Class
