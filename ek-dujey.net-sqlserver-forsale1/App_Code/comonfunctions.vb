Imports System.Net.Mail
Imports System.Net
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient





Public Class comonfunctions
    Dim doubtfulprofile As String = ""

    Public Function send25(ByVal fromemail As String, ByVal subject As String, ByVal toas As String, ByVal tmsg As String) As String
        Dim msg As New System.Net.Mail.MailMessage
        Dim websitename As String = ""
        Dim emailserver As String = ""
        Dim emailport As String = ""


        websitename = ConfigurationManager.AppSettings("websitename").ToString
        emailserver = ConfigurationManager.AppSettings("emailserver").ToString
        emailport = ConfigurationManager.AppSettings("emailport").ToString
        Try
            With msg
                .From = New MailAddress(fromemail & "@" & websitename)
                .To.Add(toas)
                .Subject = subject
                .IsBodyHtml = True
                .Body = tmsg

            End With



            ' Dim objSMTPClient As New System.Net.Mail.SmtpClient(emailserver, emailport)
            'objSMTPClient.Credentials = CredentialCache.DefaultNetworkCredentials
            ' objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network
            ' objSMTPClient.Send(msg)

            Dim mailserver As New SmtpClient()
            mailserver.Host = emailserver
            mailserver.Port = emailport
            mailserver.Send(msg)

            send25 = "Message Sent"


        Catch ex As Exception
            send25 = ex.ToString
        End Try

      


    End Function

    Sub logoffuser(ByVal pid As String)

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
      
        Try

            cn.ConnectionString = friendshipdb()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "update profile set isonlinenow='N' where pid='" & pid & "'"


            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception

        End Try


    End Sub
    Function generateid() As String
        generateid = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Millisecond
    End Function

    Function checkblocked(ByVal pidiftheuserblockedtheContactor As String, ByVal sessionpid As String) As Boolean
        Dim strsql As String = ""
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader

        Dim kk As String = ""

        cn.ConnectionString = friendshipdb()
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = "select * from blacklisted where pid='" & pidiftheuserblockedtheContactor & "' and memberidblocked='" & sessionpid & "'"
        myreader = cmd.ExecuteReader

        If myreader.HasRows = True Then
            cn.Close()
            Return True

        Else
            cn.Close()
            Return False
        End If

    End Function
    Function websitename() As String
        websitename = ConfigurationManager.AppSettings("websitename").ToString
    End Function

    Function friendshipdb() As String
        friendshipdb = ConfigurationManager.ConnectionStrings("sqlcon").ConnectionString
    End Function
  
    Function delrecordset(ByVal strsql As String) As Boolean
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim cnstring As String = ""


        cn.ConnectionString = friendshipdb()
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            cn.Close()
            Return True
        Else
            cn.Close()
            Return False
        End If


    End Function

    Function update(ByVal strsql As String) As Boolean
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim kk As String = ""
        Dim cnstring As String = ""


        cn.ConnectionString = friendshipdb()
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        kk = cmd.ExecuteNonQuery()

        If kk > 0 Then
            cn.Close()
            Return True
        Else
            cn.Close()
            Return False
        End If


    End Function

    Function CountRs(ByVal strsql As String) As String

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim kk As String = ""
        Try

            cn.ConnectionString = friendshipdb()
            cn.Open()

            cmd.Connection = cn
            cmd.CommandText = strsql
            myreader = cmd.ExecuteReader

            If myreader.HasRows = True Then
                While myreader.Read
                    kk = myreader.GetValue(0)
                End While
                cn.Close()
                CountRs = kk
            Else
                cn.Close()
                CountRs = "0"

            End If

        Catch ex As Exception
            CountRs = "0"
            cn.Close()
        End Try

    End Function

    Function adminemail() As String
        adminemail = ConfigurationManager.AppSettings("adminemail").ToString
    End Function



    Public Function BreakWordForWrap(ByVal StringToBreak As String) As String
        If String.IsNullOrEmpty(StringToBreak) Then
            Return (String.Empty)
        End If
        Dim pattern As String = "(\S{20})(\S)"
        Dim regex As New Regex(pattern, RegexOptions.IgnoreCase)
        'return regex.Replace(StringToBreak, @"$1 $2"); //for space...or use "$1<wbr>$2"
        Return (regex.Replace(StringToBreak, "$1<br/>$2"))
    End Function

    Public Function totalmembersonline() As String
        Try
            totalmembersonline = CountRs("select count(*) from profile where isonlinenow='Y' and approved='Y'")
        Catch ex As Exception
            totalmembersonline = "0"

        End Try
    End Function
    Sub Writeerrlog(ByVal pth As String, ByVal mm As String)

        Dim fp As StreamWriter

        Try
            fp = File.CreateText(pth)
            fp.WriteLine(mm)

            fp.Close()
        Catch err As Exception




        End Try

    End Sub
    Function dtformat() As String
        Dim vl As String = ""
        'adminemail = ConfigurationManager.GetSection("culture").ToString
        vl = ConfigurationManager.AppSettings("dtformat").ToString
        If vl = "he-IL" Then
            dtformat = "dd/mm/yyyy"
        Else
            dtformat = "mm/dd/yyyy"
        End If

    End Function
    Function subtitle() As String
        Try
            subtitle = ConfigurationManager.AppSettings("subtitle").ToString
        Catch ex As Exception
            subtitle = ""
        End Try
    End Function
    Function firealert() As String
        Try
            firealert = ConfigurationManager.AppSettings("emailalerts").ToString
        Catch ex As Exception
            firealert = "5"
        End Try
    End Function

    

    
    Function autoapprove() As String
        autoapprove = ConfigurationManager.AppSettings("autoapprove").ToString
    End Function
    
    Sub sendemailtouser(ByVal userid As String, ByVal subj As String, ByVal emmsg As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim strSql As String = ""
        Dim kk As String = ""

        Try


            strSql = "select email from profile where pid='" & userid & "'"
            cn.ConnectionString = friendshipdb()
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = strSql

            myreader = cmd.ExecuteReader
            While myreader.Read
                kk = send25("admin", subj, myreader.GetValue(0).ToString, emmsg)
            End While

            cn.Close()

        Catch ex As Exception

        End Try

    End Sub
    Function convertdateforsql(ByVal st As String) As String
        If dtformat() = "dd/mm/yyyy" Then
            st = Mid(st, 7, 4) & "/" & Mid(st, 4, 2) & "/" & Mid(st, 1, 2)
        End If

        If dtformat() = "mm/dd/yyyy" Then
            st = Mid(st, 7, 4) & "/" & Mid(st, 1, 2) & "/" & Mid(st, 4, 2)
        End If

        convertdateforsql = st
    End Function
    Sub addviewentry(ByVal viewdby As String, ByVal viewdof As String, ByVal ipofviewer As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim sql As String = ""
        Dim cnt As Integer = 0
        
        If checkviewentry(viewdby, viewdof) > 0 Then
            sql = "update profileviews set vieweddate=getdate() where viewedbyid='" & viewdby & "' and  pidof='" & ipofviewer & "'"
        Else
            sql = "insert into profileviews(viewedbyid,pidof,ipaddress) values('" & viewdby & "','" & viewdof & "','" & ipofviewer & "')"
        End If
        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        cn.Close()

    End Sub
    Function checkviewentry(ByVal viewbyid As String, ByVal viewdofid As String) As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Integer = 0
        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "select count(*) from profileviews  where viewedbyid='" & viewbyid & "' and pidof='" & viewdofid & "'"
        myreader = cmd.ExecuteReader

        While myreader.Read
            cnt = myreader.GetValue(0)
        End While
        cn.Close()

        checkviewentry = cnt
    End Function
    
    Function ref1val() As Decimal
        ref1val = ConfigurationManager.AppSettings("ref1val").ToString
    End Function
    Function ref2val() As Decimal
        ref2val = ConfigurationManager.AppSettings("ref2val").ToString
    End Function

    Function directmemref(ByVal ref1 As String) As Integer
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Integer = 0
        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "select count(*) from profile  where ref1='" & ref1 & "'"
        myreader = cmd.ExecuteReader

        While myreader.Read
            cnt = myreader.GetValue(0)
        End While
        cn.Close()

        directmemref = cnt
    End Function


   

    Function unpaidmoneydirect(ByVal pid As String) As Decimal
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Decimal = 0

        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "select sum(ref1val) from profile  where ref1='" & pid & "'"
        myreader = cmd.ExecuteReader

        While myreader.Read
            If IsDBNull(myreader.GetValue(0)) Then
                cnt = 0
            Else
                cnt = myreader.GetValue(0)
            End If
        End While
        cn.Close()

        unpaidmoneydirect = cnt

    End Function
    
    Function affprogram() As String
        affprogram = ConfigurationManager.AppSettings("affprogram").ToString
    End Function

    Function ForAdminunpaidmoneydirect() As Decimal
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim myreader As SqlDataReader
        Dim cnt As Decimal = 0

        cn.ConnectionString = friendshipdb()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = "select sum(ref1val) from profile where paid='N' "
        myreader = cmd.ExecuteReader

        While myreader.Read
            If IsDBNull(myreader.GetValue(0)) Then
                cnt = 0
            Else
                cnt = myreader.GetValue(0)
            End If
        End While
        cn.Close()

        ForAdminunpaidmoneydirect = cnt

    End Function

    Function gethiscountrybyip(ByVal ipadd As String) As String
        Dim dottedip As String
        Dim Dot2LongIP As Double
        Dim PrevPos As Double
        Dim pos As Double
        Dim num As Double
        Dim i As Integer = 0



        dottedip = ipadd

        For i = 1 To 4
            pos = InStr(PrevPos + 1, dottedip, ".", 1)
            If i = 4 Then
                pos = Len(dottedip) + 1
            End If
            num = Int(Mid(dottedip, PrevPos + 1, pos - PrevPos - 1))
            PrevPos = pos
            Dot2LongIP = ((num Mod 256) * (256 ^ (4 - i))) + Dot2LongIP
        Next

        ipadd = Dot2LongIP
        Try


            Dim cn As New System.Data.OleDb.OleDbConnection
            Dim cmd As New System.Data.OleDb.OleDbCommand
            Dim myreader As System.Data.OleDb.OleDbDataReader
            Dim constring As String = ""
            Dim countryname As String = ""

            constring = ConfigurationManager.ConnectionStrings("iptocountry").ConnectionString
            cn.ConnectionString = constring
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "SELECT countryname,isdoubtful from [ip-to-country] WHERE (([BeginingIP] <= " & ipadd & ") AND ([EndingIP] >=" & ipadd & " )) "

            myreader = cmd.ExecuteReader
            While myreader.Read
                countryname = myreader.GetValue(0)
                doubtfulprofile = myreader.GetValue(1)
            End While

            gethiscountrybyip = countryname
            myreader.Close()
            cn.Close()

        Catch ex As Exception
            gethiscountrybyip = ""
        End Try

    End Function

    Public ReadOnly Property isdoubtful() As String
        Get
            Return doubtfulprofile
        End Get
    End Property

    Function Conipcountry() As String
        Conipcountry = ConfigurationManager.ConnectionStrings("iptocountry").ConnectionString
    End Function
End Class
