Imports System.Data
Imports System.Data.SqlClient

Partial Class regi
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Public dtformat As String = ""
    
    Protected Sub reg_FinishButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs) Handles reg.FinishButtonClick

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim pid As String = ""
        Dim regmsg As String = ""
        Dim rzlt As String = ""

        Dim refer1 As String = ""
        Dim refer2 As String = ""

        Dim strsql As String = ""
        Dim strfield As String = ""
        Dim strvalues As String = ""

        Dim ref1val As Decimal = 0
        Dim ref2val As Decimal = 0
        Dim ipadd As String = ""
        Dim isdoubtful As String = ""
        Dim ipcountry As String = ""
        Dim autoapprove As String = ""
        cn.ConnectionString = cf.friendshipdb
        cn.Open()


       


        If checkfirst() = False Then


            Try


                pid = cf.generateid
                ipadd = getip()
                ipcountry = cf.gethiscountrybyip(ipadd)
                isdoubtful = cf.isdoubtful
                autoapprove = cf.autoapprove

                If isdoubtful = "Y" Then
                    autoapprove = "N"
                End If

                Dim st1 As String = ""
                Dim st2 As String = ""
                Dim st3 As String = ""
                Dim st4 As String = ""
                Dim st5 As String = ""

                refer1 = referby.Value

                If refer1 Is Nothing Then
                    refer1 = ""
                End If

                If refer1 <> "" Then
                    ref1val = cf.ref1val
                End If







                st1 = "insert into profile(pid,headline,fname,lname,bdate,purpose,gender,email,countryid,countryname,"
                st2 = "state,cityid,whoami,lookingfor,ipaddress,maritalstatus,mothertounge,height,annualincome,profession,passw,htname,caste,eyesight,wt,complexion,religion,zipcode,approved,ethnic,"
                st3 = "starsign,haircolor,education,smoke,Drink,diet,drugs,isonlinenow,visibletoall,ref1,ref1val,isdoubtful,ipcountry)"

                st4 = " values(@pid,@headline,@fname,@lname,@bdate,@purpose,@gender,@email,@countryid,@countryname,@state,@cityid,@whoami,"
                st5 = "@lookingfor,@ipaddress,@maritalstatus,@mothertounge,@height,@annualincome,@profession,@passw,@htname,@caste,@eyesight,@wt,@complexion,@religion,@zipcode,@approved,@ethnic,@starsign,@haircolor,@education,@smoke,@Drink,@diet,@drugs,@isonlinenow,@visibletoall,@ref1,@ref1val,@isdoubtful,@ipcountry)"

                strsql = st1 & st2 & st3 & st4 & st5

                cmd.Parameters.AddWithValue("@pid", pid)
                cmd.Parameters.AddWithValue("@headline", txtheadline.Text.ToString)
                cmd.Parameters.AddWithValue("@fname", txtfname.Text.ToString)
                cmd.Parameters.AddWithValue("@lname", txtlastname.Text.ToString)
                cmd.Parameters.AddWithValue("@bdate", cf.convertdateforsql(txtbirthdate.Text))
                cmd.Parameters.AddWithValue("@purpose", dppurpose.Text)

                cmd.Parameters.AddWithValue("@gender", gender.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("email", txtemail.Text.ToString)

                cmd.Parameters.AddWithValue("@countryid", dpcountry.SelectedValue)
                cmd.Parameters.AddWithValue("@countryname", dpcountry.SelectedItem.Text.ToString)

                cmd.Parameters.AddWithValue("@state", txtstate.Text.ToString)

                cmd.Parameters.AddWithValue("@cityid", txtcity.Text.ToString)

                cmd.Parameters.AddWithValue("@whoami", Mid(aboutme.Value.ToString, 1, 700))
                cmd.Parameters.AddWithValue("@lookingfor", Mid(lookingfor.Value.ToString, 1, 500))

                cmd.Parameters.AddWithValue("@ipaddress", ipadd)

                cmd.Parameters.AddWithValue("@maritalstatus", dpmaritalstatus.Text.ToString)
                cmd.Parameters.AddWithValue("@mothertounge", txtmothertounge.Text.ToString)
                cmd.Parameters.AddWithValue("@height", dpheight.SelectedValue)
                cmd.Parameters.AddWithValue("@annualincome", txtanualincome.Text.ToString)

                cmd.Parameters.AddWithValue("@profession", txtprofession.Text.ToString)
                cmd.Parameters.AddWithValue("@passw", txtpassword.Text.ToString)
                cmd.Parameters.AddWithValue("@htname", dpheight.SelectedItem.Text.ToString)

                cmd.Parameters.AddWithValue("@caste", txtcaste.Text.ToString)
                cmd.Parameters.AddWithValue("@eyesight", dpeyesight.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@wt", dpbodytype.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@complexion", dpskincolor.SelectedItem.Text.ToString)

                cmd.Parameters.AddWithValue("@religion", dpreligion.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@zipcode", txtpincode.Text.ToString)

                cmd.Parameters.AddWithValue("@approved", autoapprove)
                cmd.Parameters.AddWithValue("@ethnic", dpRace.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@starsign", dpstarsign.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@haircolor", dphaircolor.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@education", dpeducation.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@smoke", dpSmoke.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@Drink", dpDrinks.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@Diet", dpDiet.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@drugs", dpDrugs.SelectedItem.Text.ToString)
                cmd.Parameters.AddWithValue("@isonlinenow", "Y")
                cmd.Parameters.AddWithValue("@visibletoall", "Y")
                cmd.Parameters.AddWithValue("@ref1", refer1)
                cmd.Parameters.AddWithValue("@ref1val", ref1val)
                cmd.Parameters.AddWithValue("@isdoubtful", isdoubtful)
                cmd.Parameters.AddWithValue("@ipcountry", ipcountry)


                cmd.Connection = cn
                cmd.CommandText = strsql
                cmd.ExecuteNonQuery()




                '// send email
                regmsg = regmsg & "<tr>"
                regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Dear " & txtfname.Text.ToString & " &nbsp;" & txtlastname.Text.ToString & "</td>"
                regmsg = regmsg & "  </tr>"
                regmsg = regmsg & "<tr>"
                regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Thank you for Registering with us,</td>"
                regmsg = regmsg & "</tr>"
                regmsg = regmsg & "<tr>"

                regmsg = regmsg & "<tr>"
                regmsg = regmsg & "<td width='20%'>Username :</td>"
                regmsg = regmsg & "<td width='80%'><font color='#FF0000'>" & txtemail.Text.ToString & "</font></td>"
                regmsg = regmsg & "</tr>"
                regmsg = regmsg & "      <tr>"
                regmsg = regmsg & "        <td align=left>Password :</td>"
                regmsg = regmsg & "        <td align=left><font color='#FF0000'>" & txtpassword.Text.ToString & "</font></td>"
                regmsg = regmsg & "</tr>"


                regmsg = regmsg & "   <tr> <td width='100%' height='19' colspan='2' align='center'>&nbsp;</td>"
                regmsg = regmsg & "</tr>"
                regmsg = regmsg & "<tr>"
                regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Best Luck in Your Search"
                regmsg = regmsg & " </td>"
                regmsg = regmsg & "</tr>"
                regmsg = regmsg & "<tr>"

                regmsg = regmsg & "    <td width='100%' height='19' colspan='2' align='center'>&nbsp;</td>"
                regmsg = regmsg & "</tr>"
                regmsg = regmsg & "<tr>"
                regmsg = regmsg & "<td width='100%' height='19' colspan='2'>Welcome To " & cf.websitename & " <br>"
                regmsg = regmsg & " http://www." & cf.websitename & " </td>"
                regmsg = regmsg & "</tr>"


                rzlt = cf.send25("reg", "Thakyou For Registration", txtemail.Text.ToString, regmsg.ToString)


                FormsAuthentication.SetAuthCookie(txtemail.Text, False)
                Session("pid") = pid.ToString
                Session("fname") = txtfname.Text.ToString
                Session("lname") = txtlastname.Text.ToString
                Session("approved") = cf.autoapprove

                Response.Redirect("members/uploadphoto.aspx")

                cn.Close()
            Catch ex As Exception
                ' = ex.ToString
                cn.Close()
                Response.Write(ex.ToString)


            End Try


        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myreader As System.Data.SqlClient.SqlDataReader
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand

        Dim passw As String = ""
        Dim regmsg As String = ""

        Try
            cn.ConnectionString = cf.friendshipdb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandText = "select passw from profile where email='" & txtemail.Text.ToString & "'"
            myreader = cmd.ExecuteReader



            If myreader.HasRows = True Then
                While myreader.Read
                    passw = myreader.GetValue(0).ToString
                End While
            End If

            regmsg = "Your Password is <br><br>"
            regmsg = regmsg & "Your Login is:=" & txtemail.Text.ToString
            regmsg = regmsg & " and password is " & passw
            regmsg = regmsg & "<br><br>" & cf.websitename

            Button1.Text = cf.send25("forgotpass", "Your Password", txtemail.Text.ToString, regmsg)
            Button1.Enabled = False
            tdmessage.InnerHtml = "Password Sent Check Your Mail Box"
            cn.Close()

        Catch ex As Exception
            ' = ex.ToString
            Response.Write(ex.ToString)
        End Try
    End Sub

   
   
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Page.IsPostBack Then
            Dim myreader As System.Data.SqlClient.SqlDataReader
            Dim cn As New System.Data.SqlClient.SqlConnection
            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim strsql As String = ""
            Try

                If Request.Cookies("referby") Is Nothing Then
                    referby.Value = ""
                Else
                    referby.Value = Request.Cookies("referby").Value
                End If

                strsql = "select countryid,countryname from country"
                cn.ConnectionString = cf.friendshipdb
                cn.Open()

                cmd.Connection = cn
                cmd.CommandText = strsql
                myreader = cmd.ExecuteReader


                dpcountry.DataSource = myreader
                dpcountry.DataValueField = "countryid"
                dpcountry.DataTextField = "countryname"
                dpcountry.SelectedValue = "217"
                dpcountry.DataBind()

                cn.Close()

            Catch ex As Exception
                cn.Close()

            End Try


            ' tdgetpassword.Visible = False
        End If
    End Sub
    Function checkfirst() As Boolean
        Dim myreader As SqlDataReader
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        Try
            cmd.CommandTimeout = "200"
            cmd.Connection = cn
            cmd.CommandText = "select pid from profile where email='" & txtemail.Text.ToString & "'"

            myreader = cmd.ExecuteReader

            If myreader.HasRows = True Then
                tdmessage.InnerHtml = "Your Alc Already Exists"
                tdgetpassword.Visible = True
                checkfirst = True
            Else
                checkfirst = False
            End If

            cn.Close()

        Catch ex As Exception
            cn.Close()

        End Try

    End Function

    Function getip() As String
        Dim ip As String = ""
        ip = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If Not String.IsNullOrEmpty(ip) Then
            Dim ipRange As String() = ip.Split(","c)
            Dim le As Integer = ipRange.Length - 1
            Dim trueIP As String = ipRange(le)
        Else
            ip = Request.ServerVariables("REMOTE_ADDR")
        End If
        getip = ip

    End Function
End Class
