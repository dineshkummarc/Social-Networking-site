Imports System.IO

Partial Class Sadmin_websitesettings
    Inherits System.Web.UI.Page

    
    Dim filepath As String = ""




    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        Dim myConfiguration As Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")

        'myConfiguration.ConnectionStrings.ConnectionStrings("myDatabaseName").ConnectionString = txtConnectionString.Text

        myConfiguration.AppSettings.Settings.Item("websitename").Value = txtWebsiteName.Text.ToString
        myConfiguration.AppSettings.Settings.Item("emailserver").Value = txtemailserver.Text.ToString
        myConfiguration.AppSettings.Settings.Item("emailport").Value = txtemailport.Text.ToString
        myConfiguration.AppSettings.Settings.Item("autoapprove").Value = dpautoaprove.SelectedValue.ToString

        myConfiguration.Save()

        filepath = Server.MapPath("../members") & "/adcode1.txt"

        Try
            If File.Exists(filepath) Then
            Else
                File.CreateText(filepath)
            End If

            Dim fw As New StreamWriter(File.Open(filepath, FileMode.Open))
            fw.Write(txtadcode1.Text)
            fw.Close()

            lblstatus.Text = "File Succesfully created!"

            filepath = Server.MapPath("../members") & "/adcode2.txt"

            If File.Exists(filepath) Then
            Else
                File.CreateText(filepath)
            End If

            Dim fw2 As New StreamWriter(File.Open(filepath, FileMode.Open))
            fw2.Write(txtadcode2.Text)
            fw2.Close()


        Catch err As Exception
            lblstatus.Text = "File Creation failed. Reason is as follows" & err.ToString()
        Finally
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       

    End Sub

   
    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        If checklogin() = False Then
            Response.Redirect("~/adminlogin.aspx")
            Exit Sub
        End If

        Dim myConfiguration As Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
        If Page.IsPostBack = False Then
            filepath = Server.MapPath("../members") & "/adcode1.txt"
            If File.Exists(filepath) Then
            Else
                File.CreateText(filepath)
            End If

            Dim f1 As New StreamReader(File.Open(filepath, FileMode.Open))
            txtadcode1.Text = f1.ReadToEnd
            f1.Close()



            filepath = Server.MapPath("../members") & "/adcode2.txt"

            If File.Exists(filepath) Then
            Else
                File.CreateText(filepath)
            End If

            Dim f2 As New StreamReader(File.Open(filepath, FileMode.Open))
            txtadcode2.Text = f2.ReadToEnd
            f2.Close()

            'FileName = "123.XML"

            'xDoc.Save(path)

            'txtWebsiteName.Text = ConfigurationManager.GetSection("system.web/globalization/culture").ToString

            'Dim xmldoc As New XmlDataDocument


        End If



    End Sub
    Function checklogin() As Boolean
        If Session("username") IsNot Nothing Then

            If Session("username") = "" Then
                '  Response.Redirect("~/adminlogin.aspx")
                Return False
            Else
                Return True
            End If

        Else
            ' Response.Redirect("~/adminlogin.aspx")
            Return False
        End If
    End Function

End Class
