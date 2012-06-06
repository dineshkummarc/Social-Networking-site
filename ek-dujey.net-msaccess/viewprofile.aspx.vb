
Partial Class viewprofile
    Inherits System.Web.UI.Page
    Dim pid As String = ""
    Dim cf As New comonfunctions

   

    Sub loaddata(ByVal pid As String)
        Dim constring As String
        Dim rzlt As String = ""
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim strsql As String = ""

        constring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader




        cn.ConnectionString = constring
        cn.Open()

        str1 = "select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityname,whoami,"
        str2 = " lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,"
        str3 = "highestdegree,profession,htname,castename,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,"
        str4 = "Drink,Drugs,religion,zipcode,isonlinenow,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active='Y') as photoname,photo.passw from profile left join photo on profile.pid=photo.pid where profile.pid='" & pid & "' "

        strsql = str1 & str2 & str3 & str4
        cmd.Connection = cn
        cmd.CommandText = strsql
        cmd.Parameters.Add("@pid", Data.OleDb.OleDbType.VarChar).Value = pid


        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then

            While myreader.Read
                tdpid.InnerText = myreader.GetValue(0).ToString
                tdheadline.InnerText = myreader.GetValue(1).ToString
                tdname.InnerText = myreader.GetString(2).ToString & "  " & myreader.GetString(3).ToString
                Page.Title = myreader.GetString(2).ToString & "  " & myreader.GetString(3).ToString
                tdage.InnerText = DateDiff(DateInterval.Year, myreader.GetValue(4), Now.Date)
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


                'tdaboutme.NoWrap = False

                If (myreader.GetValue(36).ToString <> "" And myreader.GetValue(35).ToString <> "") Then
                    tdimage.InnerHtml = "<a href='members/requestphotopassw.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' width='339' height='435'></a>"
                    Button1.Visible = True
                    photopassw.Visible = True

                ElseIf (myreader.GetValue(35).ToString = "") Then
                    tdimage.InnerHtml = "<img src='App_Themes/no_avatar.gif'>"
                Else
                    tdimage.InnerHtml = "<a href='members/photogallery.aspx?pid=" & pid & "'><img width='339' height='435' src='App_Themes/" & myreader.GetValue(35).ToString & "'></a>"
                End If

            End While

        Else

        End If

       
        cn.Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim kk As String = ""
        Dim constring As String



        kk = photopassw.Text.ToString
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand

        Dim myreader As System.Data.OleDb.OleDbDataReader

        constring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString


        cn.ConnectionString = constring
        cn.Open()


        cmd.Connection = cn
        cmd.CommandText = "select photoname from photo where passw=@passw and pid=@pid"
        cmd.Parameters.Add("@passw", Data.OleDb.OleDbType.VarChar).Value = kk
        cmd.Parameters.Add("@pid", Data.OleDb.OleDbType.VarChar).Value = Request.QueryString("pid")

        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            While myreader.Read
                tdimage.InnerHtml = "<a href='members/photogallery.aspx?pid=" & Request.QueryString("pid") & "'><img width='339' height='435' src='App_Themes/" & myreader.GetValue(0).ToString & "'></a>"
                Button1.Visible = False
                photopassw.Visible = False

            End While
        Else
            tdimage.InnerHtml = "Wrong Password"
            photopassw.Text = "Type Correct Password"
            Button1.Visible = True
            photopassw.Visible = True
        End If
        cn.Close()

    End Sub

    Protected Sub btnContact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContact.Click

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack = True Then
            Button1.Visible = False
            photopassw.Visible = False
            pid = Request.QueryString("pid")
            loaddata(pid)
            btnContact.PostBackUrl = "members/sendmsg.aspx?pid=" & pid

        End If
    End Sub
End Class
