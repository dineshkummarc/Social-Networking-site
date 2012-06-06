Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class setup
    Inherits System.Web.UI.Page
    Dim strstring As String = ""
    Dim countryid As String = ""
    Dim countryname As String = ""
    Dim ConSql As SqlConnection

    Dim cf As New comonfunctions


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'createtables()
        'insertcountry()
        '//now procedures
        createprocedures()
        singlephoto()
    End Sub

    Sub createtables()
        Dim sw As New StreamReader(MapPath("generatetables.txt"))
        Dim tbls As String = ""
        tbls = sw.ReadToEnd

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = tbls
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub
    Sub createprocedures()
        approvephoto()
        approvephotoall()
        approveprofile()
        mostviewdfemales()
        mostviewdmaleprofiles()
        newlyreg()
        onlinemem()
        partnersearch()
        partnersearchcount()
        resetuser()
        suspendprofile()
        unsuspendprofile()
        updatedate()
        viewprofile()
        insertcountry()

    End Sub

    Sub singlephoto()
        
        Dim s1 As String = ""
        s1 = " CREATE VIEW singlephoto  AS select distinct  profile.pid, "
        s1 = s1 & " (select top 1 photoname from photo where photo.pid=profile.pid)as photoname,photo.passw from profile inner join  photo "
        s1 = s1 & " on profile.pid=photo.pid "
        s1 = s1 & " where photo.active='Y'"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub

    Sub approvephoto()
        Dim s1 As String = ""
        s1 = "   create procedure approvephoto"
        s1 = s1 & " @photoid varchar(60)"
        s1 = s1 & " as "
        s1 = s1 & "update photo set active='Y' where photoid=@photoid "

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub

    Sub approvephotoall()
        Dim s1 As String = ""
        s1 = " create procedure approvephotoall"
        s1 = s1 & " @pid varchar(60)"
        s1 = s1 & " as "
        s1 = s1 & "update photo set active='Y' where pid=@pid"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub

    Sub approveprofile()
        Dim s1 As String = ""
        s1 = "create procedure approveprofile "
        s1 = s1 & " @pid varchar(60)"
        s1 = s1 & " as "
        s1 = s1 & "update profile set Approved='Y',isdoubtful='N',susp='N' where pid=@pid"
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub

    Sub mostviewdfemales()
        Dim s1 As String = ""
        s1 = "create procedure mostviewdFemaleprofiles "
        s1 = s1 & " as "
        s1 = s1 & " select distinct top 7 profile.pid,photoname ,singlephoto.passw,fname,profiledate,count(pidof)"
        s1 = s1 & " from Profile "
        s1 = s1 & " inner join singlephoto on  profile.pid=singlephoto.pid "
        s1 = s1 & " inner join profileviews on profileviews.pidof=profile.pid"
        s1 = s1 & " where visibletoall='Y' and approved='Y' and gender='F' and singlephoto.passw<>''"
        s1 = s1 & " group by profile.pid,photoname,singlephoto.passw,fname,profiledate"
        s1 = s1 & " order by count(pidof) desc"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        Response.Write(s1)

        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()


    End Sub

    Sub mostviewdmaleprofiles()
        Dim s1 As String = ""
        s1 = "create procedure mostviewdmaleprofiles"
        s1 = s1 & " as "
        s1 = s1 & " select distinct top 7 profile.pid,photoname ,singlephoto.passw,fname,profiledate,count(pidof)"
        s1 = s1 & " from Profile"
        s1 = s1 & " inner join singlephoto on  profile.pid=singlephoto.pid "
        s1 = s1 & " inner join profileviews on profileviews.pidof=profile.pid "
        s1 = s1 & " where visibletoall='Y' and approved='Y' and gender='M' and singlephoto.passw<>'' "
        s1 = s1 & " group by profile.pid,photoname,fname,profiledate "
        s1 = s1 & " order by count(pidof) desc"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub

    Sub newlyreg()
        Dim s1 As String = ""
        s1 = " create procedure newlyreg"
        s1 = s1 & " as "
        s1 = s1 & " select distinct top 7 profile.pid,photoname ,photo.passw,fname,profiledate  from profile left  join singlephoto on  profile.pid=singlephoto.pid where visibletoall='Y' and approved='Y'  order by profiledate desc"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()


    End Sub

    Sub onlinemem()
        Dim s1 As String = ""
        s1 = "create procedure onlinemem"
        s1 = s1 & " as "
        s1 = s1 & " select distinct top 7 profile.pid,photoname ,singlephoto.passw,fname,profiledate  from profile left  join singlephoto on  profile.pid=singlephoto.pid where visibletoall='Y' and approved='Y' and isonlinenow='Y' "

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()


    End Sub
    Sub partnersearch()
        Dim s1 As String = ""
        s1 = " CREATE procedure partnersearch "
        s1 = s1 & " @startRowIndex int,"
        s1 = s1 & " @maximumRows int,"
        s1 = s1 & " @jointype varchar(60),"
        s1 = s1 & " @criteria varchar(max)"
        s1 = s1 & " as "
        s1 = s1 & " Declare @sqlst as varchar(max)"
        s1 = s1 & " select @sqlst='select * from ("
        s1 = s1 & " select   ROW_NUMBER() OVER(ORDER BY profiledate DESC) AS rowid ,profile.pid,profile.profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid, singlephoto.photoname,singlephoto.passw from profile ' + @jointype  +  ' singlephoto on  profile.pid=singlephoto.pid  where  ' + @criteria + ' ) as kk'"
        s1 = s1 & " EXEC(@sqlst + ' where rowid > '+@startRowIndex+' AND rowid <= ('+ @startRowIndex + @maximumRows + ')')"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()


    End Sub

    Sub partnersearchcount()
        Dim s1 As String = ""
        s1 = "create procedure partnersearchcount"
        s1 = s1 & " @jointype varchar(60),"
        s1 = s1 & " @criteria varchar(max) "
        s1 = s1 & " as "
        s1 = s1 & " Declare @sqlst as varchar(max)"
        s1 = s1 & " select @sqlst='select  count(*)  from profile ' + @jointype  +  ' photo on  profile.pid=photo.pid  where  ' + @criteria "
        s1 = s1 & " EXEC(@sqlst)"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()


    End Sub

    Sub resetuser()
        Dim s1 As String = ""
        s1 = " create procedure resetuser"
        s1 = s1 & " @pid varchar(60) "
        s1 = s1 & " as "
        s1 = s1 & " update profile set isonlinenow='N' where pid=@pid"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()


    End Sub

    Sub suspendprofile()
        Dim s1 As String = ""
        s1 = "    create procedure suspendprofile"
        s1 = s1 & " @pid varchar(60) "
        s1 = s1 & " as "
        s1 = s1 & " update profile set susp='Y',approved='N',isdoubtful='Y' where pid=@pid"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()


    End Sub
    Sub unsuspendprofile()
        Dim s1 As String = ""
        s1 = " create procedure unsuspendprofile"
        s1 = s1 & " @pid varchar(60) "
        s1 = s1 & " as "
        s1 = s1 & " update profile set susp='N',approved='Y',isdoubtful='N' where pid=@pid"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()



    End Sub
    Sub updatedate()
        Dim s1 As String = ""
        s1 = "        create procedure updatedate "
        s1 = s1 & " as "
        s1 = s1 & " update profile set bdate='1988-10-10'  where datediff(yy,bdate,getdate())<18 "

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub
    Sub viewprofile()
        Dim s1 As String = ""
        s1 = " CREATE  procedure viewprofile"
        s1 = s1 & " @pid as varchar(60) "
        s1 = s1 & " as "
        s1 = s1 & " select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityid,whoami,"
        s1 = s1 & " lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,"
        s1 = s1 & " education,profession,htname,caste,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,"
        s1 = s1 & " Drink,Drugs,religion,zipcode,isonlinenow, photoname,singlephoto.passw,susp,ipaddress,ipcountry from profile left join singlephoto on profile.pid=singlephoto.pid where profile.pid=@pid"

        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = s1
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()



    End Sub
    Sub insertcountry()
        Dim sw As New StreamReader(MapPath("insertintocountry.txt"))
        Dim tbls As String = ""
        tbls = sw.ReadToEnd
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand

        cn.ConnectionString = cf.friendshipdb
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = tbls
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()

    End Sub
    Sub executefordb(ByVal sql As String)
        Dim cn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim rtn As Integer = 0
        cn.ConnectionString = cf.friendshipdb
        cn.Open()

        cmd.Connection = cn
        cmd.CommandText = sql
        rtn = cmd.ExecuteNonQuery
    End Sub
End Class
