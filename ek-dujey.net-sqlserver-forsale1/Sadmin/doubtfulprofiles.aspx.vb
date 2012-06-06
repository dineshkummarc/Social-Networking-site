Imports System.Data
Imports System.Data.SqlClient

Partial Class Sadmin_doubtfulprofiles
    Inherits System.Web.UI.Page

    Public cf As New comonfunctions



    Dim sqlquery As String = ""

    




    Function makequery() As String
        makequery = " isdoubtful='Y' and  susp='N' "

        TextBox1.Text = makequery

    End Function

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        If Page.IsPostBack = False Then
            makequery()
        End If

    End Sub


End Class
