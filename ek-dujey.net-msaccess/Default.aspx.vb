Imports System.Data
Imports System.Data.OleDb

Partial Class _Default
    Inherits System.Web.UI.Page
    Public cf As New comonfunctions
    Private Function AccessConnectionString() As String

        AccessConnectionString = ConfigurationManager.ConnectionStrings("accessconstr").ConnectionString

        'Return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", accessDatabasePath)

    End Function
    Public ReadOnly Property Country() As String
        Get
            Return dpcountry.SelectedValue
        End Get
    End Property

    Public ReadOnly Property ag1() As String
        Get
            Return dpage1.Text
        End Get
    End Property

    Public ReadOnly Property ag2() As String
        Get
            Return dpage2.Text
        End Get
    End Property

    Public ReadOnly Property withphoto() As String
        Get
            Return chkphoto.Checked
        End Get
    End Property

    Public ReadOnly Property gender() As String
        Get
            Return dpgender.SelectedValue
        End Get
    End Property
    Public ReadOnly Property onlinenow() As String
        Get
            Return chkonlinenow.Checked
        End Get
    End Property

    Sub fillonlinemembers()
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim strsql As String = ""

        cn.ConnectionString = cf.friendshipdb()
        cn.Open()

        Dim i As Integer = 0
        strsql = "select top 7 profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid and photo.active='Y')as photoname ,photo.passw,fname,profiledate  from profile left  join photo on  profile.pid=photo.pid where visibletoall='Y' and approved='Y' and isonlinenow='Y' "
        cmd.Connection = cn
        cmd.CommandText = strsql

        myreader = cmd.ExecuteReader

        While myreader.Read
            i = i + 1


            If i = 1 Then
                If myreader.GetValue(1).ToString = "" Then
                    TD8.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                Else
                    TD8.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                End If

                If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                    TD8.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                End If
            End If

            If i = 2 Then
                If myreader.GetValue(1).ToString = "" Then
                    TD9.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                Else
                    TD9.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                End If

                If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                    TD9.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                End If
            End If

            If i = 3 Then
                If myreader.GetValue(1).ToString = "" Then
                    TD10.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                Else
                    TD10.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                End If

                If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                    TD10.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                End If
            End If

            If i = 4 Then
                If myreader.GetValue(1).ToString = "" Then
                    TD11.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                Else
                    TD11.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                End If

                If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                    TD11.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                End If
            End If

            If i = 5 Then
                If myreader.GetValue(1).ToString = "" Then
                    TD12.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                Else
                    TD12.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                End If

                If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                    TD12.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                End If
            End If

            If i = 6 Then
                If myreader.GetValue(1).ToString = "" Then
                    TD13.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                Else
                    TD13.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                End If

                If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                    TD13.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                End If
            End If

            If i = 7 Then
                If myreader.GetValue(1).ToString = "" Then
                    TD14.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                Else
                    TD14.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                End If

                If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                    TD14.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                End If
            End If



        End While
        cn.Close()

    End Sub



    
    Sub newreg()
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim sqlQuery As String = ""









        sqlQuery = "select top 7 profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid and photo.active='Y')as photoname ,photo.passw,fname,profiledate  from profile left  join photo on  profile.pid=photo.pid where visibletoall='Y' and approved='Y'  "

        sqlQuery = sqlQuery & "order by profiledate desc"



        
        cn.ConnectionString = cf.friendshipdb
        cn.Open()



        cmd.Connection = cn
        cmd.CommandText = sqlQuery

        myreader = cmd.ExecuteReader
        Dim i As Integer = 0

        Try






            While myreader.Read
                i = i + 1
                If i = 1 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD15.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/no_avatar.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD15.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/" & myreader.GetValue(1).ToString & " style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD15.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/request-photo-large-1.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 2 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD16.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD16.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD16.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 3 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD17.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD17.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD17.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 4 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD18.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD18.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD18.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 5 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD19.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD19.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD19.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 6 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD20.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/no_avatar.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD20.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/" & myreader.GetValue(1).ToString & " style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD20.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/request-photo-large-1.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 7 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD21.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD21.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD21.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

            End While


           

            cn.Close()
        Catch ex As Exception
            cn.Close()
            Response.Write(ex.Message)
        End Try
    End Sub

    Function totalonline() As String
        If Application("noofusers") IsNot Nothing Then
            totalonline = CType(Application("noofusers"), String)
        Else
            totalonline = "0"
        End If
        

    End Function

    


    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim strsql As String = ""

        If Not Page.IsPostBack Then
            loadcountry()
            newreg()
        End If

        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        strsql = "select  top 7 profile.pid,(select photoname from photo where photo.pid=profile.pid and photo.active='Y')as photoname ,photo.passw,fname,profiledate  from profile left  join photo on  profile.pid=photo.pid where visibletoall='Y' and approved='Y' order by photoname desc ,profiledate desc"

        cmd.Connection = cn
        cmd.CommandText = strsql

        myreader = cmd.ExecuteReader
        Dim i As Integer = 0

        Try


            Label1.Text = cf.websitename



            While myreader.Read
                i = i + 1
                If i = 1 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD1.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/no_avatar.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD1.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/" & myreader.GetValue(1).ToString & " style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD1.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/request-photo-large-1.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 2 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD2.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD2.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD2.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 3 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD3.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD3.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD3.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 4 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD4.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD4.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD4.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 5 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD5.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD5.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD5.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 6 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD6.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/no_avatar.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD6.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/" & myreader.GetValue(1).ToString & " style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD6.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src=App_Themes/request-photo-large-1.gif style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

                If i = 7 Then
                    If myreader.GetValue(1).ToString = "" Then
                        TD7.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/no_avatar.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    Else
                        TD7.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/" & myreader.GetValue(1).ToString & "' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If

                    If (myreader.GetValue(1).ToString <> "" And myreader.GetValue(2).ToString <> "") Then
                        TD7.InnerHtml = myreader.GetValue(3).ToString & "<br><a href='viewprofile.aspx?pid=" & myreader.GetValue(0).ToString & "'><img src='App_Themes/request-photo-large-1.gif' style='height:80px;width:100px;border-width:0px;'></a>"
                    End If
                End If

            End While
            fillonlinemembers()

            Label2.Text = totalonline()

            HyperLink2.Text = "Members Online " & cf.totalmembersonline

            cn.Close()
        Catch ex As Exception
            cn.Close()
            ' Response.Write(ex.Message)
        End Try

    End Sub
    Sub loadcountry()
        Dim myreader As System.Data.OleDb.OleDbDataReader
        Dim cn As New System.Data.OleDb.OleDbConnection
        Dim cmd As New System.Data.OleDb.OleDbCommand
        Dim strsql As String = ""

        strsql = "select countryid,countryname from country"
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = strsql
        myreader = cmd.ExecuteReader


        dpcountry.DataSource = myreader
        dpcountry.DataValueField = "countryid"
        dpcountry.DataTextField = "countryname"
        dpcountry.DataBind()

        cn.Close()
    End Sub

  
End Class
