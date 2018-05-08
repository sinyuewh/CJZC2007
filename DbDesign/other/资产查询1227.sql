 use cjzc2007
 
 /*---------------------调整资产审批中的数据-1--------------------*/
 update u_zc2 set zeren=u_zc.zeren, depart=u_zc.depart 
from u_zc2 inner join u_zc on u_zc2.zcid=u_zc.id 
Go

/*---------------------调整资产审批中的数据-2--------------------*/
update u_zc2 set zcid=1180 where zcid=1511
update u_zcsp set zcid=1180 where zcid =1511
delete from u_zc where id=1511
Go
 
/*------------创建审批的函数---------------------*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'FN' AND name = 'getSpStatus')
	BEGIN
		DROP  function getSpStatus
	END
GO

CREATE FUNCTION getSpStatus
	(
	    @kind nvarchar(50),
		@ps nvarchar(50)
	)
RETURNS nvarchar(50)
AS
	BEGIN
		declare @temp nvarchar(50)
		set @temp='-1'
		if @kind='13' 
			begin
				if @ps='同意'
					set @temp='1'
				else
					set @temp='0'
			end
		else
			if @kind='15'
				begin
					if @ps='同意'
						set @temp='2'
					else
						set @temp='0'
				end
			else
				if @kind='11'
					set @temp='0'
		RETURN @temp
	END
GO
 
 /*  资产审批流程视图  */
 /*  找到最近的一个资产审批流程处理 */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZCSPSearchView1')
	BEGIN
		DROP  View U_ZCSPSearchView1
	END
GO

CREATE View U_ZCSPSearchView1 AS

	select zcid,dbo.getSpStatus(kind,ps) spstatus from u_zcsp where id in(
select max(id) id from u_zcsp where zcid is not null and (zx='1' and (kind='13'or kind='15')) or kind='11'
group by zcid )

GO
 
 
/* 方案审批表（单条资产） */
/* 找到资产最近的一条方案审批表 */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2SearchView1')
	BEGIN
		DROP  View U_ZC2SearchView1
	END
GO

CREATE View U_ZC2SearchView1 AS

	select U_ZC2.id,U_ZC2.zcid,
	xmmc,danwei,hysj1,hysj2,U_ZCSPSearchView1.spstatus spstatus,status1,status2,spresult,spdotime
from u_zc2 left outer join U_ZCSPSearchView1
on U_ZC2.zcid=U_ZCSPSearchView1.zcid 
where U_ZC2.zcid is not null

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2SearchView11')
	BEGIN
		DROP  View U_ZC2SearchView11
	END
GO

CREATE View U_ZC2SearchView11 AS

	select zcid,max(id) id from U_ZC2SearchView1 group by zcid
GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2SearchView2')
	BEGIN
		DROP  View U_ZC2SearchView2
	END
GO

CREATE View U_ZC2SearchView2 AS

	select * from U_ZC2SearchView1 where exists ( select * from U_ZC2SearchView11 where id=U_ZC2SearchView1.id) 
GO


/* 方案审批表（资产包） */
/* 找到资产包最近的一条方案审批表 */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2BaoSearchView1')
	BEGIN
		DROP  View U_ZC2BaoSearchView1
	END
GO

CREATE View U_ZC2BaoSearchView1 AS

	select id,zcbid,xmmc,danwei,hysj1,hysj2,spstatus,status1,status2,spresult,spdotime
from u_zc2  where zcbid is not null

GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2BaoSearchView2')
	BEGIN
		DROP  View U_ZC2BaoSearchView2
	END
GO

CREATE View U_ZC2BaoSearchView2 AS

	select * from U_ZC2BaoSearchView1 where id in (select max(id) id from U_ZC2BaoSearchView1 group by zcbid) 
GO
