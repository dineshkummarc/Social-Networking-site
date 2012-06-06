Imports System.Data
Imports System.Data.SqlClient

Partial Class Sadmin_payhim
    Inherits System.Web.UI.Page
    Dim cf As New comonfunctions
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sqlinsert As String
        sqlinsert = "update paymentApproved set paymentdate=getdate(),paymentnumber='" & txtpaymentnumber.Text & "',amtpaid=" & txtamtpaid.Text & " where payid='" & txtapproveid.Text.ToString & "'"

        cf.update(sqlinsert)
    End Sub

   

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim pid As String = ""
        Dim sql As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader

        pid = Request.QueryString("pid")
        sql = "select amtapproved,pid,payid from paymentApproved where payid='" & pid & "'"

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = sql
        myreader = cmd.ExecuteReader

        While myreader.Read
            txtamt.Text = myreader.GetValue(0)
            txtpid.Text = myreader.GetValue(1).ToString
            txtapproveid.Text = myreader.GetValue(2).ToString

        End While

        cn.Close()

    End Sub
End Class
