<%@ Application Language="VB" %>
 
<script runat="server">
    Dim Gf As New comonfunctions
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        Try
            Application("noofusers") = 1
            
        Catch ex As Exception
            '    Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
        End Try
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
        Try
            
        Catch ex As Exception

        End Try
        
    
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        '   Dim ex As Exception = Server.GetLastError.GetBaseException
        
        '    Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
        
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Try
            Session("pid") = ""
            Application.Lock()
            Application("noofusers") = CInt(Application("noofusers")) + 1
            Application.UnLock()
            
        Catch ex As Exception
            ' cf.send25("err", "err occured", "aminnagpure@gmail.com", ex.Message)
            '  Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
        End Try

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Try
            Dim strpid As String = CType(Session("pid"), String)
            
            If strpid <> "" Then
                Gf.logoffuser(strpid)
            End If
            
            Application.Lock()
            Application("noofusers") = CInt(Application("noofusers") - 1)
            Application.UnLock()
            
        Catch ex As Exception
            '   CF.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
            'logof.send25("err", "err occured", "aminnagpure@gmail.com", ex.Message)
            ' Gf.Writeerrlog(Server.MapPath("err.txt"), ex.Message)
        End Try

    End Sub
       
</script>