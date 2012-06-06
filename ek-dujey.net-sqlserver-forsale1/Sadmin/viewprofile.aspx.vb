Imports System.Data
Imports System.Data.SqlClient
Partial Class Sadmin_viewprofile
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Dim kk As Boolean
    Dim pid As String = ""
    Dim Susp As String = ""
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim msg As String = ""
        kk = cf.update("update profile set Approved='Y' where pid='" & Request.QueryString("pid") & "'")


        If kk = True Then
            Button1.Text = "Profile Approved"
            msg = "Congrats<br>Your Profile  has been Approved <br> Happy Hunting <br><br> http://www." & cf.websitename
            cf.sendemailtouser(Request.QueryString("pid"), "Profile Approved", msg)
            Button1.Enabled = False
            Button2.Enabled = False
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim k2 As Boolean
        Dim msg As String = ""
        kk = cf.update("update profile set Approved='Y' where pid='" & Request.QueryString("pid") & "'")
        k2 = cf.update("update photo set active='Y' where pid='" & Request.QueryString("pid") & "'")

        msg = "Congrats<br>Your Profile  has been Approved <br> Happy Hunting <br><br> http://www." & cf.websitename

        If kk = True Then
            Button1.Enabled = False
            Button2.Enabled = False
            Button2.Text = "Profile Approved"
            cf.sendemailtouser(Request.QueryString("pid"), "Profile Approved", msg)
        End If
        If k2 = True Then
            Button2.Text = Button2.Text & " " & "with photo"
        End If
    End Sub
    

    Sub loaddata(ByVal pid As String)

        Dim rzlt As String = ""
        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim str3 As String = ""
        Dim str4 As String = ""
        Dim strsql As String = ""



        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim isdoubtful As String = ""
        Dim ipcountry As String = ""



        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        str1 = "select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityname,whoami,"
        str2 = " lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,"
        str3 = "education,profession,htname,castename,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,"
        str4 = "Drink,Drugs,religion,zipcode,isonlinenow,photoname,profile.passw,approved,email,ipaddress from profile left join photo on profile.pid=photo.pid where profile.pid='" & pid & "'"

        strsql = str1 & str2 & str3 & str4
        strsql = "viewprofileforadmin '" & pid & "'"
        cmd.Connection = cn
        cmd.CommandText = strsql
        'cmd.Parameters.Add("@pid", SqlDbType.VarChar).Value = pid



        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then

            While myreader.Read
                tdpid.InnerText = myreader.GetValue(0).ToString
                tdheadline.InnerText = myreader.GetValue(1).ToString
                tdname.InnerText = myreader.GetString(2).ToString & myreader.GetString(3).ToString
                Page.Title = tdname.InnerText

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


                If (myreader.GetValue(35).ToString = "") Then
                    tdimage.InnerHtml = "<img src='../App_Themes/no_avatar.gif'>"
                Else
                    tdimage.InnerHtml = "<a href='photogallery.aspx?pid=" & pid & "'><img width='339' height='435' src='../App_Themes/" & myreader.GetValue(35).ToString & "'></a>"
                End If

                tdpassword.InnerHtml = myreader.GetValue(36).ToString

                If (myreader.GetValue(37).ToString = "Y") Then
                    Button1.Enabled = False
                    Button2.Enabled = False
                End If

                tdusername.InnerHtml = myreader.GetValue(38).ToString
                tdipaddress.InnerText = "Ip Address " & myreader.GetValue(39).ToString
                Susp = myreader.GetValue(40).ToString
                isdoubtful = myreader.GetValue(41).ToString
                ipcountry = myreader.GetValue(42).ToString
                Button3.PostBackUrl = "editreg.aspx?pid=" & myreader.GetValue(0).ToString

            End While

        Else

        End If

        If isdoubtful = "Y" Then
            lbldoubtful.Text = "This Profile looks Doubtful"
        Else
            lbldoubtful.Text = ""
        End If
        lblipcountry.Text = ipcountry

        cn.Close()
    End Sub

   

    
    
    
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
       


        pid = Request.QueryString("pid").ToString
        loaddata(pid)

        HyperLink1.NavigateUrl = "approveprofile.aspx?pid=" & pid
        HyperLink2.NavigateUrl = "approveprofile.aspx?pid=" & pid & "&photo=Y"
        If Susp = "N" Then
            HyperLink3.NavigateUrl = "suspend.aspx?pid=" & pid
        Else
            HyperLink3.NavigateUrl = "unsuspend.aspx?pid=" & pid
            HyperLink3.Text = "Profile is Suspended, click here to unsuspend"
        End If

        removeprofile.NavigateUrl = "removeprofile.aspx?pid=" & pid
        hyperlinksengmsg.NavigateUrl = "sendmsg.aspx?pid=" & pid

    End Sub


    

  
   
End Class
