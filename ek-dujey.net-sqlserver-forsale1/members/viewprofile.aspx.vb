Imports System.Data
Imports System.Data.SqlClient

Partial Class members_viewprofile
    Inherits System.Web.UI.Page

    Dim pid As String = ""
    Public cf As New comonfunctions
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       
    End Sub

    Sub loaddata(ByVal pid As String)

        Dim rzlt As String = ""
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim strsql As String = ""
        Dim photocount As Integer = 0




        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim myreader As SqlDataReader




        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        str1 = "select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityid,whoami,"
        str2 = " lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,"
        str3 = "education,profession,htname,castename,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,"
        str4 = "Drink,Drugs,religion,zipcode,isonlinenow,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active='Y' order by uploaddate desc) as photoname,photo.passw from profile left join photo on profile.pid=photo.pid where profile.pid=@pid"

        strsql = str1 & str2 & str3 & str4
        strsql = "viewprofile '" & pid & "'"
        cmd.Connection = cn
        cmd.CommandText = strsql
        ' cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = pid


        myreader = cmd.ExecuteReader
       
        photocount = getphotocount()

        '        Response.Write(cmd.CommandText)



        If myreader.HasRows = True Then

            While myreader.Read

                

                tdpid.InnerText = myreader.GetValue(0).ToString
                tdheadline.InnerText = myreader.GetValue(1).ToString
                tdname.InnerText = myreader.GetString(2).ToString '& " " & myreader.GetString(3).ToString

                Page.Title = myreader.GetString(2).ToString & " " & myreader.GetString(3).ToString

                tdage.InnerText = "(" & DateDiff(DateInterval.Year, myreader.GetValue(4), Now.Date) & ") Date of Birth " & myreader.GetValue(4)
                tdpurpose.InnerText = myreader.GetValue(5).ToString
                tdsex.InnerText = myreader.GetValue(6).ToString
                tdlocation.InnerHtml = myreader.GetValue(7).ToString & "<br>" & myreader.GetValue(8).ToString & "<br>" & myreader.GetValue(9).ToString

                tdaboutme.InnerHtml = cf.BreakWordForWrap(myreader.GetValue(10).ToString)
                tdlookingfor.InnerHtml = cf.BreakWordForWrap(myreader.GetValue(11).ToString)
                tdregdate.InnerText = myreader.GetValue(12)
                tdlastvisited.InnerText = myreader.GetValue(13)
                tdlastupdate.InnerText = myreader.GetValue(14)
                tdmaritalstatus.InnerText = myreader.GetValue(15).ToString
                tdmothertounge.InnerText = myreader.GetValue(16).ToString
                tdincome.InnerText = myreader.GetValue(17).ToString
                tdeducation.InnerText = myreader.GetValue(18).ToString
                tdprofession.InnerText = myreader.GetValue(19).ToString
                tdheight.InnerText = myreader.GetValue(20).ToString
                tdcaste.InnerText = myreader.GetValue(21).ToString
                tdeyesight.InnerText = myreader.GetValue(22).ToString
                tdhaircolor.InnerText = myreader.GetValue(23).ToString
                tdrace.InnerText = myreader.GetValue(24).ToString
                tdbodytype.InnerText = myreader.GetValue(25).ToString
                tdcomplexion.InnerText = myreader.GetValue(26).ToString
                tdstarsign.InnerText = myreader.GetValue(27).ToString
                tdsmoke.InnerText = myreader.GetValue(28).ToString
                tddiet.InnerText = myreader.GetValue(29).ToString
                tddrinking.InnerText = myreader.GetValue(30).ToString
                tddrugs.InnerText = myreader.GetValue(31).ToString
                tdreligion.InnerText = myreader.GetValue(32).ToString
                tdpincode.InnerText = myreader.GetValue(33).ToString
                tdonline.InnerText = myreader.GetValue(34).ToString



                If (myreader.GetValue(36).ToString <> "" And myreader.GetValue(35).ToString <> "") Then
                    tdimage.InnerHtml = "<a href='requestphotopassw.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='../App_Themes/request-photo-large-1.gif' width='339' height='435'></a>"
                    Button1.Visible = True
                    photopassw.Visible = True


                ElseIf (myreader.GetValue(35).ToString = "") Then
                    tdimage.InnerHtml = "<img src='../App_Themes/no_avatar.gif'>"
                Else
                    tdimage.InnerHtml = "<a href='photogallery.aspx?pid=" & pid & "'><img width='339' height='435' src='../App_Themes/" & myreader.GetValue(35).ToString & "'></a>"
                    If photocount > 1 Then
                        totalphoto.Text = " This User has " & photocount - 1 & " More Photos"
                    End If
                End If

            End While

        Else

        End If

        
        cn.Close()
    End Sub

    Protected Sub addtofav_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addtofav.Click

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd2 As New SqlCommand
        Dim kk As String



        cn.ConnectionString = cf.friendshipdb
        cn.Open()
       


        If checkfirst() > 0 Then

            favcell.InnerText = "Profile Already Exist in Favorities"



        Else
            cmd2.Connection = cn
            cmd2.CommandText = "insert into favorities(pid,memberidfav,fname) values(@pid,@memberidfav,@fname) "
            cmd2.Parameters.AddWithValue("@pid", Session("pid"))
            cmd2.Parameters.AddWithValue("@memberidfav", tdpid.InnerText)
            cmd2.Parameters.AddWithValue("@fname", tdname.InnerText)

            kk = cmd2.ExecuteNonQuery
            If kk > 0 Then
                favcell.InnerHtml = "<font color='red'>Profile Added To Favorities</font>"
            End If

        End If

        cn.Close()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click


        Dim cn As New SqlConnection

        Dim cmd2 As New SqlCommand
        Dim kk As String



       
        cn.ConnectionString = cf.friendshipdb
        cn.Open()



        If checkblock() > 0 Then

            tdblocked.InnerText = "Profile Already Blocked"



        Else
            cmd2.Connection = cn
            cmd2.CommandText = "insert into blacklisted(pid,memberidblocked,fname) values(@pid,@memberidblocked,@fname) "
            cmd2.Parameters.AddWithValue("@pid", Session("pid"))
            cmd2.Parameters.AddWithValue("@memberidblocked", tdpid.InnerText)
            cmd2.Parameters.AddWithValue("@fname", tdname.InnerText)

            kk = cmd2.ExecuteNonQuery
            If kk > 0 Then
                tdblocked.InnerHtml = "<font color='red'>Profile Blocked</font>"
            End If

        End If

        cn.Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim kk As String = ""

        Dim photocount As Integer = 0


        kk = photopassw.Text.ToString

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader





        cn.ConnectionString = cf.friendshipdb
        cn.Open()


        

        cmd.Connection = cn
        cmd.CommandText = "select photoname from photo where passw='" & kk & "' and pid='" & Request.QueryString("pid") & "'"




        photocount = getphotocount()

        myreader = cmd.ExecuteReader



        If myreader.HasRows = True Then
            While myreader.Read
                tdimage.InnerHtml = "<a href='photogallery.aspx?pid=" & Request.QueryString("pid") & "'><img width='339' height='435' src='../App_Themes/" & myreader.GetValue(0).ToString & "'></a>"
                Button1.Visible = False
                photopassw.Visible = False
            End While

            If photocount > 1 Then
                totalphoto.Text = " This User has " & photocount - 1 & " More Photos"
            End If
        Else
            tdimage.InnerHtml = "Wrong Password"
            photopassw.Text = "Type Correct Password"
            Button1.Visible = True
            photopassw.Visible = True
        End If

        cn.Close()
    End Sub
    Function getphotocount() As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim photoreader As SqlDataReader
        Dim photocount As Integer = 0
        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "select count(*) from photo where pid='" & Request.QueryString("pid") & "'"

        photoreader = cmd.ExecuteReader
        While photoreader.Read
            photocount = photoreader.GetValue(0)
        End While

        getphotocount = photocount
        cn.Close()
    End Function
    Function checkfirst() As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As Integer = 0


        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn

        cmd.CommandText = "select count(*) from favorities where pid=@pid and memberidfav=@memberidfav"
        cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = Session("pid").ToString
        cmd.Parameters.Add("@memberidfav", SqlDbType.VarChar).Value = Request.QueryString("pid").ToString
        myreader = cmd.ExecuteReader

        While myreader.Read
            kk = myreader.GetValue(0)
        End While

        checkfirst = kk
        cn.Close()

    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack = True Then
            Button1.Visible = False
            photopassw.Visible = False
            pid = Request.QueryString("pid").ToString
            loaddata(pid)
            btnContact.PostBackUrl = "sendmsg.aspx?pid=" & pid
            cf.addviewentry(Session("pid"), pid, Request.ServerVariables("REMOTE_ADDR"))
        End If
    End Sub

    Function checkblock() As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As Integer = 0


        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn

        cmd.CommandText = "select count(*) from blacklisted where pid=@pid and memberidblocked=@memberidfav"
        cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = Session("pid").ToString
        cmd.Parameters.Add("@memberidfav", SqlDbType.VarChar).Value = Request.QueryString("pid").ToString
        myreader = cmd.ExecuteReader

        While myreader.Read
            kk = myreader.GetValue(0)
        End While

        checkblock = kk
        cn.Close()
    End Function
End Class
