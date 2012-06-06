
Partial Class members_privacysettings
    Inherits System.Web.UI.Page

    Protected Sub chkphotpassword_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkphotpassword.CheckedChanged
        If chkphotpassword.Checked = True Then
            txtphotopassword.Visible = True
            txtphotopassword.ReadOnly = False
        Else
            txtphotopassword.Visible = False
            txtphotopassword.ReadOnly = True
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim cmd2 As New System.Data.OleDb.OleDbCommand

        Dim visibleall As String = ""
        Dim photopassw As String = ""
        Dim strsql As String = ""
        Dim k1 As String = ""
        Dim k2 As String = ""

        cn.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
        cn.Open()

        If chkvisibleall.Checked = True Then
            visibleall = "Y"
        Else
            visibleall = "N"
        End If

        If chkphotpassword.Checked = True Then
            photopassw = txtphotopassword.Text
        Else
            photopassw = ""
        End If



        strsql = " update profile set visibletoall=@visibletoall where pid='" & Session("pid") & "'"

        cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.Parameters.AddWithValue("@visibletoall", visibleall.ToString)

        k1 = cmd.ExecuteNonQuery

        If k1 > 0 Then
            Label1.Text = " Your Profile Settings Updated"
        End If

        'If chkphotpassword.Checked = True Then
        strsql = " update photo set passw=@passw where pid='" & Session("pid") & "'"
        cmd2.Connection = cn
        cmd2.CommandText = strsql
        cmd2.Parameters.AddWithValue("@passw", photopassw)

        k2 = cmd2.ExecuteNonQuery

        If k2 > 0 Then
            Label2.Text = "Photo Password Updated"
        Else
            Label2.Text = "No Photo Found to Update with Password"
        End If
        'End If

        cn.Close()


    End Sub

    

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            Dim myreader As System.Data.OleDb.OleDbDataReader
            Dim cn As New System.Data.OleDb.OleDbConnection
            Dim cmd As New System.Data.OleDb.OleDbCommand

            Dim cf As New comonfunctions
            Dim visibleall As String = ""
            Dim photopass As String = ""
            Dim strsql As String = ""

            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            strsql = "select visibletoall,photo.passw from profile left join photo on profile.pid=photo.pid where profile.pid='" & Session("pid") & "'"

            cmd.Connection = cn
            cmd.CommandText = strsql
            myreader = cmd.ExecuteReader


            If myreader.HasRows Then
                While myreader.Read
                    visibleall = myreader.GetValue(0).ToString
                    photopass = myreader.GetValue(1).ToString


                End While
            End If

            If visibleall = "Y" Then
                'chkphotpassword.Checked = True
                chkvisibleall.Checked = True
            End If
            If photopass <> "" Then
                chkphotpassword.Checked = True
                txtphotopassword.Text = photopass
            End If

            cn.Close()
        End If
    End Sub
End Class
