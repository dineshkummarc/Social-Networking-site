
Partial Class members_requestphotopassw
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dorequest()
    End Sub
    Sub dorequest()
        Dim constring As String = ""
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim cmd2 As New System.Data.OleDb.OleDbCommand
        Dim kk As String
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim cmdprofiledetails As New System.Data.OleDb.OleDbCommand
        Dim myreaderprofile As System.Data.OleDb.OleDbDataReader
        Dim rid As String = ""
        Dim fname As String = ""
        Dim lname As String = ""
        Dim email As String = ""
        Dim cf As New comonfunctions
        Dim passwreqmsg As String = ""

        rid = cf.generateid

        If cf.checkblocked(Request.QueryString("pid"), Session("pid")) = True Then
            Label1.Text = "You Cannot Contact This Person, You are Blocked"
            Exit Sub
        End If


        cn.ConnectionString = cf.friendshipdb
        cn.Open()




        cmd.Connection = cn
        cmd.CommandText = "select pid from passwordrequests where frompid=@pid and topid=@pid"
        cmd.Parameters.Add("@pid", Data.OleDb.OleDbType.VarChar).Value = Session("pid").ToString
        cmd.Parameters.Add("@topid", Data.OleDb.OleDbType.VarChar).Value = Request.QueryString("pid").ToString

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            tdblocked.InnerText = "Photo Request Made Is In Process"

           

        Else
            cmdprofiledetails.Connection = cn
            cmdprofiledetails.CommandText = "select email from profile where pid='" & Request.QueryString("pid").ToString & "'"
            myreaderprofile = cmdprofiledetails.ExecuteReader

            If myreaderprofile.HasRows = True Then
                While myreaderprofile.Read
                    email = myreaderprofile.GetString(0).ToString
                End While
            End If


            cmd2.Connection = cn
            cmd2.CommandText = "insert into passwordrequests(requestid,frompid,topid,fname,lname) values(@requestid,@frompid,@topid,@fname,@lname) "
            cmd2.Parameters.AddWithValue("@requestid", rid)
            cmd2.Parameters.AddWithValue("@frompid", Session("pid").ToString)
            cmd2.Parameters.AddWithValue("@topid", Request.QueryString("pid").ToString)
            cmd2.Parameters.AddWithValue("@fname", fname.ToString)
            cmd2.Parameters.AddWithValue("@lname", lname.ToString)


            kk = cmd2.ExecuteNonQuery
            If kk > 0 Then
                tdblocked.InnerText = "Photo Request Made"

                passwreqmsg = "<tr><td> "
                passwreqmsg = passwreqmsg & " Password Request has been made by http://www." & cf.websitename & "/viewprofile.aspx?pid=" & Session("pid") & "<br><br>"
                passwreqmsg = passwreqmsg & " you can see the entire list here http://www." & cf.websitename & "/members/reqpasswordlist.aspx <br> <br> You Can Grant and Deny Password Requests</td></tr>"

                If email <> "" Then
                    kk = cf.send25("passwordrequest", Session("fname") & " Wants To see your photo", email, passwreqmsg)

                    Label1.Text = kk.ToString

                End If
            End If

        End If

        cn.Close()

    End Sub
End Class
