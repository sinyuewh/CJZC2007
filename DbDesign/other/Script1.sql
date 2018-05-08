use cjzc2007

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2SearchView1')
	BEGIN
		DROP  View U_ZC2SearchView1
	END
GO

CREATE View U_ZC2SearchView1 AS

	select id,zcid,xmmc,danwei,hysj1,hysj2,spstatus,status1,status2,spresult,spdotime
from u_zc2  where exists(select * from u_zcsp where u_zcsp.czid=u_zc2.id) and zcid is not null

GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2SearchView2')
	BEGIN
		DROP  View U_ZC2SearchView2
	END
GO

CREATE View U_ZC2SearchView2 AS

	select * from U_ZC2SearchView1 where id in (select max(id) id from U_ZC2SearchView1 group by zcid) 
GO


/*2)资产包--------------------------------------------------------*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2BaoSearchView1')
	BEGIN
		DROP  View U_ZC2BaoSearchView1
	END
GO

CREATE View U_ZC2BaoSearchView1 AS

	select id,zcbid,xmmc,danwei,hysj1,hysj2,spstatus,status1,status2,spresult,spdotime
from u_zc2  where exists(select * from u_zcsp where u_zcsp.czid=u_zc2.id) and zcbid is not null

GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'U_ZC2BaoSearchView2')
	BEGIN
		DROP  View U_ZC2BaoSearchView2
	END
GO

/*------------最新的资产项目申报表-------------------------*/
CREATE View U_ZC2BaoSearchView2 AS

	select * from U_ZC2BaoSearchView1 where id in (select max(id) id from U_ZC2BaoSearchView1 group by zcbid) 
GO
