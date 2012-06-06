SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[topearner]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[topearner]
as
select pr.pid,pr.fname,pr.lname,pr.email,pr.gender,pr.countryname,pr.state,pr.cityid,pr.whoami,pr.purpose,pr.ethnic,pr.religion,pr.caste,sum(r1.ref1val) as sum1,photoname,ph.passw,pr.ipaddress,pr.ipcountry
from profile pr join profile r1 on pr.pid=r1.ref1
left join singlephoto ph on pr.pid=ph.pid
and pr.paid=''N'' 
group by pr.pid,pr.fname,pr.lname,pr.email,pr.gender,pr.passw,pr.countryname,pr.state,pr.cityid, pr.whoami,pr.purpose,pr.ethnic,pr.religion,pr.caste,photoname,ph.passw,pr.ipaddress,pr.ipcountry order by sum1 desc
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[blacklisted]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[blacklisted](
	[pid] [varchar](60) NOT NULL,
	[memberidblocked] [varchar](60) NOT NULL CONSTRAINT [blacklistedmemberidblockedDefault]  DEFAULT (''),
	[fname] [varchar](250) NOT NULL CONSTRAINT [blacklistedfnameDefault]  DEFAULT (''),
	[lname] [varchar](250) NOT NULL CONSTRAINT [blacklistedlnameDefault]  DEFAULT (''),
	[upddate] [smalldatetime] NOT NULL CONSTRAINT [blacklistedupddateDefault]  DEFAULT (getdate()),
 CONSTRAINT [pkblacklisted] PRIMARY KEY CLUSTERED 
(
	[pid] ASC,
	[memberidblocked] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[topearnercount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[topearnercount]
as
select count(*)
from profile pr join profile r1 on pr.pid=r1.ref1
left join singlephoto ph on pr.pid=ph.pid
and pr.paid=''N'' 


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[favorities]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[favorities](
	[pid] [varchar](60) NOT NULL,
	[memberidfav] [varchar](60) NOT NULL CONSTRAINT [favoritiesmemberidfavDefault]  DEFAULT (''),
	[fname] [varchar](250) NOT NULL CONSTRAINT [favoritiesfnameDefault]  DEFAULT (''),
 CONSTRAINT [pkfavorities] PRIMARY KEY CLUSTERED 
(
	[pid] ASC,
	[memberidfav] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[passwordrequests]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[passwordrequests](
	[requestid] [varchar](50) NOT NULL,
	[frompid] [varchar](60) NOT NULL CONSTRAINT [passwordrequestsfrompidDefault]  DEFAULT (''),
	[topid] [varchar](60) NOT NULL CONSTRAINT [passwordrequeststopidDefault]  DEFAULT (''),
	[fromemail] [varchar](250) NOT NULL CONSTRAINT [passwordrequestsfromemailDefault]  DEFAULT (''),
	[fname] [varchar](250) NOT NULL CONSTRAINT [passwordrequestsfnameDefault]  DEFAULT (''),
	[lname] [varchar](250) NOT NULL CONSTRAINT [passwordrequestslnameDefault]  DEFAULT (''),
 CONSTRAINT [pkpasswordrequest] PRIMARY KEY CLUSTERED 
(
	[requestid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pendingfriendshipRequestCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[pendingfriendshipRequestCount]
@mid as varchar(60)
as
select count(*) from friendshiprequest where tomid=@mid and isapproved=''N''
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[paymentApproved]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[paymentApproved](
	[pid] [varchar](60) NOT NULL CONSTRAINT [[dbo]].[paymentApproved]]pidDefault]  DEFAULT (''),
	[amtapproved] [money] NOT NULL CONSTRAINT [[dbo]].[paymentApproved]]amtapprovedDefault]  DEFAULT ((0)),
	[approvaldate] [smalldatetime] NOT NULL CONSTRAINT [paymentApprovedapprovaldateDefault]  DEFAULT (getdate()),
	[paymentnumber] [varchar](60) NOT NULL CONSTRAINT [paymentApprovedpaymentnumberDefault]  DEFAULT (''),
	[paymentdate] [smalldatetime] NOT NULL CONSTRAINT [[dbo]].[paymentApproved]]paymentdateDefault]  DEFAULT (getdate()),
	[payid] [varchar](60) NOT NULL CONSTRAINT [[dbo]].[paymentApproved]]payidDefault]  DEFAULT (''),
	[amtpaid] [money] NOT NULL CONSTRAINT [[dbo]].[paymentApproved]]amtpaidDefault]  DEFAULT ((0)),
	[actualpaymentdate] [varchar](150) NOT NULL CONSTRAINT [[dbo]].[paymentApproved]]actualpaymentdateDefault]  DEFAULT (''),
 CONSTRAINT [pkpaymentapproved] PRIMARY KEY CLUSTERED 
(
	[payid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[friendshiprequest]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[friendshiprequest](
	[fidreq] [varchar](50) NOT NULL,
	[frommid] [varchar](50) NOT NULL,
	[tomid] [varchar](50) NOT NULL,
	[isapproved] [varchar](1) NOT NULL CONSTRAINT [DF_friendshiprequest_isapproved]  DEFAULT ('N')
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[photo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[photo](
	[photoid] [varchar](60) NOT NULL,
	[photoname] [varchar](250) NOT NULL CONSTRAINT [photophotonameDefault]  DEFAULT (''),
	[photopath] [varchar](250) NOT NULL CONSTRAINT [photophotopathDefault]  DEFAULT (''),
	[pid] [varchar](60) NOT NULL CONSTRAINT [photopidDefault]  DEFAULT (''),
	[active] [varchar](1) NOT NULL CONSTRAINT [photoactiveDefault]  DEFAULT ('N'),
	[datasize] [varchar](50) NOT NULL CONSTRAINT [photodatasizeDefault]  DEFAULT (''),
	[passw] [varchar](50) NOT NULL CONSTRAINT [photopasswDefault]  DEFAULT (''),
	[uploaddate] [smalldatetime] NOT NULL CONSTRAINT [photouploaddateDefault]  DEFAULT (getdate()),
 CONSTRAINT [photo_PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[photoid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Profile](
	[pid] [varchar](60) NOT NULL,
	[headline] [varchar](250) NOT NULL CONSTRAINT [ProfileheadlineDefault]  DEFAULT (''),
	[fname] [varchar](250) NOT NULL CONSTRAINT [ProfilefnameDefault]  DEFAULT (''),
	[lname] [varchar](250) NOT NULL CONSTRAINT [ProfilelnameDefault]  DEFAULT (''),
	[bdate] [smalldatetime] NOT NULL CONSTRAINT [[dbo]].[Profile]]bdateDefault]  DEFAULT (getdate()),
	[purpose] [varchar](250) NOT NULL CONSTRAINT [ProfilepurposeDefault]  DEFAULT (''),
	[gender] [varchar](1) NOT NULL CONSTRAINT [ProfilegenderDefault]  DEFAULT ('M'),
	[email] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]emailDefault]  DEFAULT (''),
	[countryid] [int] NOT NULL CONSTRAINT [[dbo]].[Profile]]countryidDefault]  DEFAULT ((1)),
	[countryname] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]countrynameDefault]  DEFAULT (''),
	[state] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]stateDefault]  DEFAULT (''),
	[cityname] [varchar](250) NOT NULL CONSTRAINT [ProfilecitynameDefault]  DEFAULT (''),
	[whoami] [varchar](max) NOT NULL CONSTRAINT [ProfilewhoamiDefault]  DEFAULT (''),
	[lookingfor] [varchar](max) NOT NULL CONSTRAINT [ProfilelookingforDefault]  DEFAULT (''),
	[profiledate] [smalldatetime] NOT NULL CONSTRAINT [[dbo]].[Profile]]profiledateDefault]  DEFAULT (getdate()),
	[LastVisited] [smalldatetime] NOT NULL CONSTRAINT [[dbo]].[Profile]]LastVisitedDefault]  DEFAULT (getdate()),
	[lastupdated] [smalldatetime] NOT NULL CONSTRAINT [[dbo]].[Profile]]lastupdatedDefault]  DEFAULT (getdate()),
	[banned] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]bannedDefault]  DEFAULT ('N'),
	[ipaddress] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]ipaddressDefault]  DEFAULT (''),
	[maritalstatus] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]maritalstatusDefault]  DEFAULT (''),
	[mothertounge] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]mothertoungeDefault]  DEFAULT (''),
	[height] [int] NOT NULL CONSTRAINT [[dbo]].[Profile]]heightDefault]  DEFAULT ((0)),
	[annualincome] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]annualincomeDefault]  DEFAULT (''),
	[familydetails] [varchar](max) NOT NULL CONSTRAINT [[dbo]].[Profile]]familydetailsDefault]  DEFAULT (''),
	[profession] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]professionDefault]  DEFAULT (''),
	[passw] [varchar](50) NOT NULL CONSTRAINT [[dbo]].[Profile]]passwDefault]  DEFAULT (''),
	[htname] [varchar](50) NOT NULL CONSTRAINT [[dbo]].[Profile]]htnameDefault]  DEFAULT (''),
	[castename] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]castenameDefault]  DEFAULT (''),
	[eyesight] [varchar](150) NOT NULL CONSTRAINT [[dbo]].[Profile]]eyesightDefault]  DEFAULT (''),
	[wt] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]wtDefault]  DEFAULT (''),
	[complexion] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]complexionDefault]  DEFAULT (''),
	[caste] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]casteDefault]  DEFAULT (''),
	[cityid] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]cityidDefault]  DEFAULT (''),
	[verifiedemail] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]verifiedemailDefault]  DEFAULT ('Y'),
	[religion] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]religionDefault]  DEFAULT ('Y'),
	[zipcode] [varchar](150) NOT NULL CONSTRAINT [[dbo]].[Profile]]zipcodeDefault]  DEFAULT (''),
	[ref1] [varchar](60) NOT NULL CONSTRAINT [[dbo]].[Profile]]ref1Default]  DEFAULT (''),
	[approved] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]approvedDefault]  DEFAULT ('N'),
	[hid] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]hidDefault]  DEFAULT ('N'),
	[isonlinenow] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]isonlinenowDefault]  DEFAULT ('N'),
	[ethnic] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]ethnicDefault]  DEFAULT (''),
	[starsign] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]starsignDefault]  DEFAULT (''),
	[haircolor] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]haircolorDefault]  DEFAULT (''),
	[education] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]educationDefault]  DEFAULT (''),
	[nature] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]natureDefault]  DEFAULT (''),
	[smoke] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]smokeDefault]  DEFAULT (''),
	[Drink] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]DrinkDefault]  DEFAULT (''),
	[diet] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]dietDefault]  DEFAULT (''),
	[drugs] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]drugsDefault]  DEFAULT (''),
	[children] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]childrenDefault]  DEFAULT (''),
	[thoughtsofmarriage] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]thoughtsofmarriageDefault]  DEFAULT (''),
	[political] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]politicalDefault]  DEFAULT (''),
	[visibletoall] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]visibletoallDefault]  DEFAULT ('Y'),
	[ref2] [varchar](60) NOT NULL CONSTRAINT [[dbo]].[Profile]]ref2Default]  DEFAULT (''),
	[ref1val] [numeric](19, 2) NOT NULL CONSTRAINT [[dbo]].[Profile]]ref1valDefault]  DEFAULT ((0)),
	[ref2val] [numeric](19, 2) NOT NULL CONSTRAINT [[dbo]].[Profile]]ref2valDefault]  DEFAULT ((0)),
	[paid] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]paidDefault]  DEFAULT ('N'),
	[Susp] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]SuspDefault]  DEFAULT ('N'),
	[isdoubtful] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]isdoubtfulDefault]  DEFAULT ('N'),
	[ipcountry] [varchar](250) NOT NULL CONSTRAINT [[dbo]].[Profile]]ipcountryDefault]  DEFAULT (''),
	[newoffers] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]newoffersDefault]  DEFAULT ('Y'),
	[msgcycle] [int] NOT NULL CONSTRAINT [[dbo]].[Profile]]msgcycleDefault]  DEFAULT ((0)),
	[adminemail] [varchar](1) NOT NULL CONSTRAINT [[dbo]].[Profile]]adminemailDefault]  DEFAULT ('Y'),
	[photo] [varchar](150) NOT NULL CONSTRAINT [DF_Profile_photo]  DEFAULT (''),
 CONSTRAINT [profilepk] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[topearners]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[topearners](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[mid] [varchar](60) NOT NULL,
	[earnedamt] [decimal](18, 2) NOT NULL CONSTRAINT [DF_topearners_earnedamt]  DEFAULT ((0)),
	[earndate] [smalldatetime] NOT NULL CONSTRAINT [DF_topearners_earndate]  DEFAULT (getdate()),
	[source] [varchar](50) NOT NULL,
	[pstatus] [varchar](50) NOT NULL CONSTRAINT [DF_topearners_pstatus]  DEFAULT ('pending'),
	[referd] [varchar](60) NOT NULL CONSTRAINT [DF_topearners_referd]  DEFAULT (''),
	[regdatetp] [datetime] NOT NULL CONSTRAINT [DF_topearners_regdate]  DEFAULT (getdate()),
 CONSTRAINT [PK_topearners] PRIMARY KEY CLUSTERED 
(
	[eid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[profileviews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[profileviews](
	[viewedbyid] [varchar](60) NOT NULL,
	[pidof] [varchar](60) NOT NULL CONSTRAINT [profileviewspidofDefault]  DEFAULT (''),
	[ipaddress] [varchar](150) NOT NULL CONSTRAINT [profileviewsipaddressDefault]  DEFAULT (''),
	[vieweddate] [smalldatetime] NOT NULL CONSTRAINT [profileviewsvieweddateDefault]  DEFAULT (getdate()),
 CONSTRAINT [pkprofileviews] PRIMARY KEY CLUSTERED 
(
	[viewedbyid] ASC,
	[pidof] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Referals]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Referals](
	[Pid] [varchar](60) NOT NULL,
	[referdby] [varchar](60) NOT NULL CONSTRAINT [ReferalsreferdbyDefault]  DEFAULT (''),
	[refer2] [varchar](60) NOT NULL CONSTRAINT [Referalsrefer2Default]  DEFAULT (''),
	[ref1val] [money] NOT NULL CONSTRAINT [Referalsref1valDefault]  DEFAULT ((0)),
	[ref2val] [money] NOT NULL CONSTRAINT [Referalsref2valDefault]  DEFAULT ((0)),
	[ipaddress] [varchar](150) NOT NULL CONSTRAINT [ReferalsipaddressDefault]  DEFAULT (''),
	[paid] [varchar](1) NOT NULL CONSTRAINT [ReferalspaidDefault]  DEFAULT ('Y'),
	[refdate] [smalldatetime] NOT NULL CONSTRAINT [ReferalsrefdateDefault]  DEFAULT (getdate())
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[users](
	[userid] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](250) NOT NULL CONSTRAINT [usersusernameDefault]  DEFAULT (''),
	[passw] [varchar](250) NOT NULL CONSTRAINT [userspasswDefault]  DEFAULT (''),
	[role] [varchar](50) NOT NULL CONSTRAINT [usersroleDefault]  DEFAULT (''),
 CONSTRAINT [pkusers] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[citytable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[citytable](
	[cityid] [varchar](60) NOT NULL,
	[stateid] [varchar](60) NULL,
	[cityname] [varchar](250) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Country](
	[COUNTRYID] [int] NOT NULL,
	[countryname] [varchar](255) NULL,
	[countrygroupid] [int] NULL,
	[countrygroupname] [varchar](max) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[states]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[states](
	[countryid] [int] NOT NULL,
	[stateid] [varchar](50) NOT NULL,
	[statename] [varchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[alert]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[alert](
	[searchno] [varchar](60) NOT NULL,
	[candiid] [varchar](60) NOT NULL,
	[query] [varchar](max) NOT NULL CONSTRAINT [alertqueryDefault]  DEFAULT (''),
	[queryname] [varchar](250) NOT NULL CONSTRAINT [alertquerynameDefault]  DEFAULT (''),
	[email] [varchar](250) NOT NULL CONSTRAINT [alertemailDefault]  DEFAULT (''),
	[verified] [varchar](1) NOT NULL CONSTRAINT [alertverifiedDefault]  DEFAULT ('N'),
	[fireddate] [smalldatetime] NOT NULL CONSTRAINT [alertfireddateDefault]  DEFAULT (getdate()),
	[jointype] [varchar](60) NOT NULL CONSTRAINT [[dbo]].[alert]]jointypeDefault]  DEFAULT ('Left Join'),
 CONSTRAINT [alert_PrimaryKey] PRIMARY KEY CLUSTERED 
(
	[searchno] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[partnersearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[partnersearch]
@startRowIndex int,
@maximumRows int,
@jointype varchar(60),
@criteria varchar(max)
as
Declare @sqlst as varchar(max)
select @sqlst=''select * from (
select   ROW_NUMBER() OVER(ORDER BY profiledate DESC) AS rowid ,profile.pid,profile.profiledate, fname,lname,bdate,purpose,gender,ethnic,religion,caste,profile.countryname,whoami, profile.state, profile.cityid, singlephoto.photoname,singlephoto.passw,ipaddress,ipcountry from profile '' + @jointype  +  '' singlephoto on  profile.pid=singlephoto.pid  where  '' + @criteria + '' ) as kk''
EXEC(@sqlst + '' where rowid > ''+@startRowIndex+'' AND rowid <= (''+ @startRowIndex + @maximumRows + '')'')

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[partnersearchcount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[partnersearchcount]
@jointype varchar(60),
@criteria varchar(max)
as
Declare @sqlst as varchar(max)
select @sqlst=''select  count(*)  from profile '' + @jointype  +  '' photo on  profile.pid=photo.pid  where  '' + @criteria

EXEC(@sqlst)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[myfriends]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[myfriends]
@startRowIndex int,
@maximumRows int,
@criteria varchar(60)
as

SELECT   * from
(select fidreq,profiledate,mm.pid,fname,lname, photo,
ROW_NUMBER() OVER(ORDER BY profiledate DESC) AS rowid from [profile] mm
inner join friendshiprequest fp
on mm.pid=fp.tomid
where frommid=@criteria and isapproved=''Y''
group by fidreq,profiledate,mm.pid,fname,lname,photo )as kk
union
SELECT   * from
(select fidreq,profiledate,mm.pid,fname,lname,photo, 
ROW_NUMBER() OVER(ORDER BY profiledate DESC) AS rowid from [profile] mm
inner join friendshiprequest fp
on mm.pid=fp.frommid
where tomid=@criteria and isapproved=''Y''
group by fidreq,profiledate,mm.pid,fname,lname,photo) as kk
where rowid >@startRowIndex AND rowid <= (@startRowIndex + @maximumRows)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pendingfriendshipRequest]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[pendingfriendshipRequest]
@startRowIndex int,
@maximumRows int,
@criteria varchar(60)
as

SELECT   * from
(
select fidreq,profiledate,mm.pid as frommid,fname,lname,photo, ROW_NUMBER() OVER(ORDER BY profiledate DESC)
 AS rowid 
from [profile] mm
inner join friendshiprequest fp
on mm.pid=fp.frommid
where tomid=@criteria and isapproved=''N'' group by fidreq,profiledate,mm.pid,fname,lname,photo) as kk
where rowid >@startRowIndex AND rowid <= (@startRowIndex + @maximumRows)


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[myfriendsCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[myfriendsCount]
@criteria as varchar(50)
as


select count(*) from profile,friendshiprequest 
where (frommid=@criteria or tomid=@criteria) and isapproved=''Y''

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[approvephoto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[approvephoto]
@photoid varchar(60)
as
update photo set active=''Y'' where photoid=@photoid' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[approvephotoall]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[approvephotoall]
@pid varchar(60)
as
update photo set active=''Y'' where pid=@pid' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[viewprofileforadmin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[viewprofileforadmin]
@pid varchar(60)
as
select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityid,whoami,
lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,
education,profession,htname,caste,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,
Drink,Drugs,religion,zipcode,isonlinenow,photoname,profile.passw,approved,email,ipaddress,susp,isdoubtful,ipcountry from profile left join photo on profile.pid=photo.pid where profile.pid=@pid


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[singlephoto]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[singlephoto]  AS select distinct  profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid)as photoname,photo.passw from profile inner join  photo
on profile.pid=photo.pid
 where photo.active=''Y''
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[viewprofile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  procedure [dbo].[viewprofile]
 @pid as varchar(60)
as

select top 1 profile.pid,headline,fname,lname,bdate,purpose,gender,countryname,state,cityid,whoami,
lookingfor,profiledate,lastvisited,lastupdated,maritalstatus,mothertounge,annualincome,
education,profession,htname,caste,eyesight,haircolor,ethnic,WT,complexion,starsign,smoke,diet,
Drink,Drugs,religion,zipcode,isonlinenow,(select top 1 photoname from  photo where photo.pid=profile.pid and photo.active=''Y'') as photoname,photo.passw,susp from profile left join photo on profile.pid=photo.pid where profile.pid=@pid

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[onlinemem]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[onlinemem]
as
select distinct top 7 profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid and photo.active=''Y'')as photoname ,photo.passw,fname,profiledate  from profile left  join photo on  profile.pid=photo.pid where visibletoall=''Y'' and approved=''Y'' and isonlinenow=''Y'' ' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[newlyreg]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure  [dbo].[newlyreg]
as
select distinct top 7 profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid and photo.active=''Y'')as photoname ,photo.passw,fname,profiledate  from profile inner join photo on  profile.pid=photo.pid where visibletoall=''Y'' and approved=''Y''  order by profiledate desc
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mostviewdmaleprofiles]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[mostviewdmaleprofiles]
as
select distinct top 7 profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid and photo.active=''Y'')as photoname ,photo.passw,fname,profiledate,count(pidof)
 from profile 
inner join photo on  profile.pid=photo.pid 
inner join profileviews on profileviews.pidof=profile.pid
where visibletoall=''Y'' and approved=''Y'' and gender=''M''
group by profile.pid,photoname,photo.passw,fname,profiledate
order by count(pidof) desc
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[delphoto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[delphoto]
@photoid varchar(60)
as
delete from photo where photoid=@photoid' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mostviewdFemaleprofiles]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[mostviewdFemaleprofiles]
as
select distinct top 7 profile.pid,(select top 1 photoname from photo where photo.pid=profile.pid and photo.active=''Y'')as photoname ,photo.passw,fname,profiledate,count(pidof)
 from profile 
inner join photo on  profile.pid=photo.pid 
inner join profileviews on profileviews.pidof=profile.pid
where visibletoall=''Y'' and approved=''Y'' and gender=''F''
group by profile.pid,photoname,photo.passw,fname,profiledate
order by count(pidof) desc' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[resetuser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[resetuser]
@pid varchar(60)
as
update profile set isonlinenow=''N'' where pid=@pid

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[suspendprofile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[suspendprofile]
@pid varchar(60)
as
update profile set susp=''Y'',approved=''N'' where pid=@pid' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[unsuspendprofile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[unsuspendprofile]
@pid varchar(60)
as
update profile set susp=''N'',approved=''Y'' where pid=@pid' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[updatedate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[updatedate]
as
update profile set bdate=''1985-10-10''  where datediff(yy,bdate,getdate())<18
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[adminemailall]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE procedure [dbo].[adminemailall]
as
select email,fname,passw,pid from profile where adminemail=''Y''

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offeralerts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [dbo].[offeralerts]
as
select email,fname,passw from profile
where newoffers=''Y'' and
datediff(day,profiledate,getdate())<=7
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offeralertsall]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[offeralertsall]
as
select email,fname,passw from profile
where newoffers=''Y'' ' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[approveprofile]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[approveprofile]
@pid varchar(60)
as
update profile set Approved=''Y'' where pid=@pid' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vemail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [dbo].[vemail]
 @email as varchar(250)
as
select count(*) from profile where email=@email' 
END
