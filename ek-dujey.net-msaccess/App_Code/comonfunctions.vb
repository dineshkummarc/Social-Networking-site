Imports System.Net.Mail
Imports System.Net
Imports Microsoft.VisualBasic
Imports System.IO




Public Class comonfunctions


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
        Dim constring As String
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
      
        Try
            constring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
            cn.ConnectionString = constring
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
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader

        Dim kk As String = ""

        cn.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
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
        friendshipdb = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
    End Function
  
    Function delrecordset(ByVal strsql As String) As Boolean
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        cnstring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        cn.ConnectionString = cnstring
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
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        cnstring = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        cn.ConnectionString = cnstring
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

        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim kk As String = ""
        Try

            cn.ConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString
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
        'much faster way is
        'SELECT rows FROM sysindexes WHERE id = OBJECT_ID('TableName')
        Try
            totalmembersonline = CountRs("select count(*) from profile where isonlinenow='Y' and approved='Y'")
        Catch ex As Exception
            totalmembersonline = "0"

        End Try
    End Function
    Function apconstring() As String
        apconstring = ConfigurationManager.ConnectionStrings("appsettings").ConnectionString
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

    

    Function updatealerts(ByVal strsql As String) As Boolean
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim kk As String = ""
        Dim cnstring As String = ""
        cnstring = ConfigurationManager.ConnectionStrings("foralerts").ConnectionString

        cn.ConnectionString = cnstring
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

        'cn.Close()
    End Function
    Function autoapprove() As String
        autoapprove = ConfigurationManager.AppSettings("autoapprove").ToString
    End Function
    Function foralertscontstring() As String
        foralertscontstring = ConfigurationManager.ConnectionStrings("foralerts").ConnectionString
    End Function
    Sub sendemailtouser(ByVal userid As String, ByVal subj As String, ByVal emmsg As String)
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim myreader As System.Data.OleDb.OleDbDataReader
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
End Class
