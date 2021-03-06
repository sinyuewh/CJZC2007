use cjzc2007

/*------------更新数据库表--------------*/
if Not EXISTS (select *  from syscolumns where name='bzeren1' and id=(select id from sysobjects where name='U_ZCBAO'))
	begin 
		alter table U_ZCBAO add bzeren1 nvarchar(50)
	end
Go
/*----------------12月16日---------------*/
if Not EXISTS (select *  from syscolumns where name='zeren1' and id=(select id from sysobjects where name='U_OLDZC'))
	begin 
		alter table U_OLDZC add zeren1 nvarchar(50)
	end
Go

if Not EXISTS (select *  from syscolumns where name='status1' and id=(select id from sysobjects where name='U_OLDZC'))
	begin 
		alter table U_OLDZC add status1 nvarchar(50)
	end
Go

if Not EXISTS (select *  from syscolumns where name='spstatus' and id=(select id from sysobjects where name='U_OLDZC'))
	begin 
		alter table U_OLDZC add spstatus nvarchar(50)
	end
Go

if Not EXISTS (select *  from syscolumns where name='status2' and id=(select id from sysobjects where name='U_OLDZC'))
	begin 
		alter table U_OLDZC add status2 nvarchar(50)
	end
Go

if Not EXISTS (select *  from syscolumns where name='spdotime' and id=(select id from sysobjects where name='U_OLDZC'))
	begin 
		alter table U_OLDZC add spdotime datetime
	end
Go

if Not EXISTS (select *  from syscolumns where name='spresult' and id=(select id from sysobjects where name='U_OLDZC'))
	begin 
		alter table U_OLDZC add spresult nvarchar(50)
	end
Go


/*--------长江资产视图文件--------------*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DA_FileCopyBillView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[DA_FileCopyBillView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCMyDepartZc]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCMyDepartZc]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcNoShenPIINFO]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcNoShenPIINFO]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcShenPIINFO]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcShenPIINFO]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_InStockView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_InStockView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_OutStockView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_OutStockView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_Pay1View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_Pay1View]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_PayView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_PayView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_ShouKuan1View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_ShouKuan1View]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_ShouKuanView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_ShouKuanView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_StockBillView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_StockBillView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DA_AnJuanFileView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[DA_AnJuanFileView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCTCBUView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[U_ZCTCBUView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCDepartTimeView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCDepartTimeView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCSPStatView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCSPStatView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Zc2View1]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[Zc2View1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Zc2View2]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[Zc2View2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBNoShenPI]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBNoShenPI]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBShenPI]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBShenPI]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBaoView3]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBaoView3]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcNoShengPI]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcNoShengPI]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcShengPI]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcShengPI]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcView2010]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcView2010]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DA_AnJuanView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[DA_AnJuanView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_UserAndDepartVIEW]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[U_UserAndDepartVIEW]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCBAOFileView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCBAOFileView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCBAOView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCBAOView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCBStateView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCBStateView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCFileView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCFileView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCFileView1]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCFileView1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCNoShenPIView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCNoShenPIView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCSP1View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCSP1View]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCSPView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCSPView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCShenBaoView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCShenBaoView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCShenPIView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCShenPIView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCStateView1]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCStateView1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCTimeView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCTimeView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZX_InfoView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZX_InfoView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZX_InfoView1]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZX_InfoView1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBNOShenPIView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBNOShenPIView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBShenPIView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBShenPIView]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBaoView2]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBaoView2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcTcView1]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcTcView1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcTcView2]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcTcView2]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.DA_AnJuanView
AS
SELECT ID, ajnum, ajname, time0, ljren, ajkind, remark, ajstatus
FROM dbo.DA_AnJuan



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




/*---------------------------------*/
CREATE VIEW dbo.U_UserAndDepartVIEW
AS
SELECT dbo.U_UserName.*, dbo.U_Depart.num AS Dnum
FROM dbo.U_UserName INNER JOIN
      dbo.U_Depart ON dbo.U_UserName.depart = dbo.U_Depart.depart



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE VIEW dbo.ZCBAOFileView
AS
SELECT dbo.U_ZCTC.zeren AS djren, dbo.U_ZCStatus.statusText, dbo.U_ZCTC.kind, 
      dbo.U_ZCFiles.*, dbo.U_ZCBAO.Bname AS bname, 
      dbo.U_ZCBAO.Bzeren AS bzeren
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_ZCFiles ON dbo.U_ZCTC.ID = dbo.U_ZCFiles.TCID INNER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCTC.kind = dbo.U_ZCStatus.statusValue INNER JOIN
      dbo.U_ZCBAO ON dbo.U_ZCTC.ZcID = dbo.U_ZCBAO.ID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCBAOView
AS
SELECT dbo.U_UserName.depart, dbo.U_ZCStatus.statusText, dbo.U_ZCBAO.ID, 
      dbo.U_ZCBAO.Bname, dbo.U_ZCBAO.Btime, dbo.U_ZCBAO.Bren, dbo.U_ZCBAO.Bjsf, 
      dbo.U_ZCBAO.Bljsk, dbo.U_ZCBAO.Bljzc, dbo.U_ZCBAO.Bremark, 
      dbo.U_ZCBAO.Bzeren, dbo.U_ZCBAO.Bstatus
FROM dbo.U_ZCBAO LEFT OUTER JOIN
      dbo.U_UserName ON 
      dbo.U_ZCBAO.Bzeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCBAO.Bstatus = dbo.U_ZCStatus.statusValue



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCBStateView
AS
SELECT dbo.U_ZCBAO.*, dbo.U_ZCStatus.statusText AS statusText, 
      dbo.U_UserName.depart AS depart
FROM dbo.U_ZCBAO INNER JOIN
      dbo.U_UserName ON 
      dbo.U_ZCBAO.Bzeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCBAO.Bstatus = dbo.U_ZCStatus.statusValue



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCFileView
AS
SELECT dbo.U_ZCTC.zeren AS djren, dbo.U_ZCStatus.statusText, dbo.U_ZCTC.kind, 
      dbo.U_ZC.danwei, dbo.U_ZC.zeren, dbo.U_ZC.depart, dbo.U_ZCFiles.*
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_ZCFiles ON dbo.U_ZCTC.ID = dbo.U_ZCFiles.TCID INNER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCTC.kind = dbo.U_ZCStatus.statusValue INNER JOIN
      dbo.U_ZC ON dbo.U_ZCTC.ZcID = dbo.U_ZC.ID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCFileView1
AS
SELECT TCID, COUNT(*) AS Fcount
FROM dbo.U_ZCFiles
GROUP BY TCID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE VIEW dbo.ZCNoShenPIView
AS
SELECT ZCID, zeren, MAX(ID) AS id
FROM dbo.U_ZCSP
WHERE (time1 IS NULL)
GROUP BY ZCID, zeren



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCSP1View
AS
SELECT dbo.U_UserName.depart, dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.U_UserName ON dbo.U_ZCBSP.zeren = dbo.U_UserName.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCSPView
AS
SELECT dbo.U_ZCSP.*, dbo.U_UserName.depart AS depart
FROM dbo.U_ZCSP INNER JOIN
      dbo.U_UserName ON dbo.U_ZCSP.zeren = dbo.U_UserName.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCShenBaoView
AS
SELECT dbo.U_ZC.depart AS cbdepart, dbo.U_ZC.zeren AS cbzeren, dbo.U_ZC2.*, 
      dbo.U_ZC.danwei AS danwei1, dbo.U_ZC.bj AS bj, dbo.U_ZC.lx1 AS lx1, 
      dbo.U_ZC.lx2 AS lx2, dbo.U_ZC.lx3 AS lx3, ISNULL(dbo.U_ZC.bj, 0) 
      + ISNULL(dbo.U_ZC.lx1, 0) + ISNULL(dbo.U_ZC.lx2, 0) + ISNULL(dbo.U_ZC.lx3, 0) 
      AS zqze, ISNULL(dbo.U_ZC.lx1, 0) + ISNULL(dbo.U_ZC.lx2, 0) 
      + ISNULL(dbo.U_ZC.lx3, 0) AS lx, dbo.U_ZC.num2 AS num21
FROM dbo.U_ZC2 INNER JOIN
      dbo.U_ZC ON dbo.U_ZC2.ZCID = dbo.U_ZC.ID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCShenPIView
AS
SELECT ZCID, zeren, MAX(ID) AS id
FROM dbo.U_ZCSP
WHERE (time1 IS NOT NULL)
GROUP BY ZCID, zeren



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCStateView1
AS
SELECT dbo.U_ZC.danwei, dbo.U_ZC.bj, dbo.U_ZC.lx1, dbo.U_ZC.lx2, dbo.U_ZC.lx3, 
      dbo.U_ZC.depart, dbo.U_ZC.zeren, dbo.U_ZC.ID, dbo.U_ZC.status, 
      dbo.U_ZCStatus.statusText, dbo.U_ZC.userkind, dbo.U_ZC3.pbj, dbo.U_ZC3.plx, 
      dbo.U_ZC3.fee1, dbo.U_ZC3.fee2, dbo.U_ZC3.fee3, dbo.U_ZC3.fee4, dbo.U_ZC3.fee5, 
      dbo.U_ZC3.fee6, dbo.U_ZC3.fee7, dbo.U_ZC3.fee8, dbo.U_ZC3.fee9, 
      dbo.U_ZC3.fee10, dbo.U_ZC3.fee11, dbo.U_ZC3.fee12, dbo.U_ZC3.fee13, 
      dbo.U_ZC3.fee14, dbo.U_ZC3.fee15, dbo.U_ZC3.fee16, dbo.U_ZC3.fee17, 
      dbo.U_ZC3.fee18, dbo.U_ZC3.fee19, dbo.U_ZC3.fee20, ISNULL(dbo.U_ZC3.fee1, 0) 
      + ISNULL(dbo.U_ZC3.fee2, 0) + ISNULL(dbo.U_ZC3.fee3, 0) 
      + ISNULL(dbo.U_ZC3.fee4, 0) + ISNULL(dbo.U_ZC3.fee5, 0) 
      + ISNULL(dbo.U_ZC3.fee6, 0) + ISNULL(dbo.U_ZC3.fee7, 0) 
      + ISNULL(dbo.U_ZC3.fee8, 0) + ISNULL(dbo.U_ZC3.fee9, 0) 
      + ISNULL(dbo.U_ZC3.fee10, 0) + ISNULL(dbo.U_ZC3.fee11, 0) 
      + ISNULL(dbo.U_ZC3.fee12, 0) + ISNULL(dbo.U_ZC3.fee13, 0) 
      + ISNULL(dbo.U_ZC3.fee14, 0) + ISNULL(dbo.U_ZC3.fee15, 0) 
      + ISNULL(dbo.U_ZC3.fee16, 0) + ISNULL(dbo.U_ZC3.fee17, 0) 
      + ISNULL(dbo.U_ZC3.fee18, 0) + ISNULL(dbo.U_ZC3.fee19, 0) 
      + ISNULL(dbo.U_ZC3.fee20, 0) AS fyhj
FROM dbo.U_ZC LEFT OUTER JOIN
      dbo.U_ZC3 ON dbo.U_ZC.ID = dbo.U_ZC3.ID LEFT OUTER JOIN
      dbo.U_ZCStatus ON dbo.U_ZC.status = dbo.U_ZCStatus.statusValue



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE VIEW dbo.ZCTimeView
AS
SELECT dbo.U_ZCTime.ID AS TimeID, dbo.U_ZCTime.TimeName, 
      dbo.U_ZCTime.time0 AS ZCTime, dbo.U_ZCTime.tellday, 
      dbo.U_ZCTime.remark AS TimeRemark, dbo.U_ZC.time0, dbo.U_ZC.ID, 
      dbo.U_ZC.danwei, dbo.U_ZC.zeren, dbo.U_ZC.bj, dbo.U_ZC.lx1, dbo.U_ZC.lx2, 
      dbo.U_ZC.lx3, dbo.U_ZC.zcbao, dbo.U_ZC.bank, dbo.U_ZC.htnum, dbo.U_ZC.zhuang, 
      dbo.U_ZC.remark, dbo.U_ZC.status, dbo.U_ZC.depart, dbo.U_ZC.zhwd, 
      dbo.U_ZC.num1, dbo.U_ZC.num2, dbo.U_ZC.quyu, dbo.U_ZC.sshy, dbo.U_ZC.fenlei, 
      dbo.U_ZC.userkind, dbo.U_ZC.zzjg, dbo.U_ZC.jysfzc, dbo.U_ZC.clsj, dbo.U_ZC.zczb, 
      dbo.U_ZC.dqjj, dbo.U_ZC.qygm, dbo.U_ZC.dwdz, dbo.U_ZC.dwfzr, dbo.U_ZC.qyjjxz, 
      dbo.U_ZC.yxzzzk, dbo.U_ZC.xdri, dbo.U_ZC.dkffrq1, dbo.U_ZC.jklsh, dbo.U_ZC.dkye, 
      dbo.U_ZC.dkffrq2, dbo.U_ZC.htdqr, dbo.U_ZC.zjycszje, dbo.U_ZC.zydbfs, 
      dbo.U_ZC.dbrwmc, dbo.U_ZC.yyldxt, dbo.U_ZC.xcyqrq, dbo.U_ZC.jrblsj, 
      dbo.U_ZCTime.ZCID, dbo.U_ZC.guangxia
FROM dbo.U_ZCTime INNER JOIN
      dbo.U_ZC ON dbo.U_ZCTime.ZCID = dbo.U_ZC.ID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCView
AS
SELECT dbo.U_ZCStatus.statusText, dbo.U_UserName.depart AS U_depart, dbo.U_ZC3.pbj, 
      dbo.U_ZC3.plx, dbo.U_ZC3.fee1, dbo.U_ZC3.fee2, dbo.U_ZC3.fee3, dbo.U_ZC3.fee4, 
      dbo.U_ZC3.fee5, dbo.U_ZC3.fee6, dbo.U_ZC3.fee7, dbo.U_ZC3.fee9, dbo.U_ZC3.fee8, 
      dbo.U_ZC3.fee10, dbo.U_ZC3.fee11, dbo.U_ZC3.fee12, dbo.U_ZC3.fee13, 
      dbo.U_ZC3.fee14, dbo.U_ZC3.fee15, dbo.U_ZC3.fee16, dbo.U_ZC3.fee17, 
      dbo.U_ZC3.fee18, dbo.U_ZC3.fee19, dbo.U_ZC3.fee20, dbo.U_ZC.*, 
      ISNULL(dbo.U_ZC.lx1, 0) + ISNULL(dbo.U_ZC.lx2, 0) + ISNULL(dbo.U_ZC.lx3, 0) 
      AS bxhj, ISNULL(dbo.U_ZC.lx1, 0) + ISNULL(dbo.U_ZC.lx2, 0) + ISNULL(dbo.U_ZC.lx3, 
      0) + ISNULL(dbo.U_ZC.bj, 0) AS hjbx
FROM dbo.U_ZC LEFT OUTER JOIN
      dbo.U_ZC3 ON dbo.U_ZC.ID = dbo.U_ZC3.ID LEFT OUTER JOIN
      dbo.U_UserName ON dbo.U_ZC.zeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.U_ZCStatus ON dbo.U_ZC.status = dbo.U_ZCStatus.statusValue



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO







CREATE VIEW dbo.ZX_InfoView
AS
SELECT dbo.ZX_Info.*, dbo.ZX_InfoRead.ydren AS ydren
FROM dbo.ZX_Info LEFT OUTER JOIN
      dbo.ZX_InfoRead ON dbo.ZX_Info.ID = dbo.ZX_InfoRead.infoid



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZX_InfoView1
AS
SELECT dbo.ZX_Info.*, dbo.ZX_InfoRead.ydren AS ydren
FROM dbo.ZX_Info INNER JOIN
      dbo.ZX_InfoRead ON dbo.ZX_Info.ID = dbo.ZX_InfoRead.infoid



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcBNOShenPIView
AS
SELECT BID, zeren, MAX(ID) AS id
FROM dbo.U_ZCBSP
WHERE (time1 IS NULL)
GROUP BY BID, zeren



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcBShenPIView
AS
SELECT BID, zeren, MAX(ID) AS id
FROM dbo.U_ZCBSP
WHERE (time1 IS NOT NULL)
GROUP BY BID, zeren



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcBaoView2
AS
SELECT dbo.U_ZCBAOInfo.BID, SUM(dbo.U_ZC.bj) AS bj, SUM(ISNULL(dbo.U_ZC.lx1, 0) 
      + ISNULL(dbo.U_ZC.lx2, 0) + ISNULL(dbo.U_ZC.lx3, 0)) AS lx
FROM dbo.U_ZCBAOInfo INNER JOIN
      dbo.U_ZC ON dbo.U_ZCBAOInfo.ZCID = dbo.U_ZC.ID
GROUP BY dbo.U_ZCBAOInfo.BID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcTcView1
AS
SELECT distinct dbo.U_ZC2.ZCID, MAX(dbo.U_ZCTC.dotime) AS dotime
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.U_ZCTC ON dbo.U_ZC2.ID = dbo.U_ZCTC.czid
WHERE (dbo.U_ZC2.ZCID IS NOT NULL)
GROUP BY dbo.U_ZC2.ZCID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcTcView2
AS
SELECT distinct dbo.U_ZC2.ZCBID, MAX(dbo.U_ZCTC.dotime) AS dotime
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.U_ZCTC ON dbo.U_ZC2.ID = dbo.U_ZCTC.czid
WHERE (dbo.U_ZC2.ZCBID IS NOT NULL)
GROUP BY dbo.U_ZC2.ZCBID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.CW_InStockView
AS
SELECT dbo.CW_InStock.*, dbo.U_UserName.depart AS depart, dbo.U_ZC.zcbao AS zcbao, 
      0 AS bxhj
FROM dbo.CW_InStock INNER JOIN
      dbo.U_ZC ON dbo.CW_InStock.ZcID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserName ON dbo.CW_InStock.zeren = dbo.U_UserName.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.CW_OutStockView
AS
SELECT dbo.U_ZC.zcbao, dbo.U_UserName.depart, dbo.CW_OutStock.*, 0 AS bxhj
FROM dbo.CW_OutStock INNER JOIN
      dbo.U_ZC ON dbo.CW_OutStock.ZcID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserName ON dbo.CW_OutStock.zeren = dbo.U_UserName.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



/*-----------------------------*/
CREATE VIEW dbo.CW_Pay1View
AS
SELECT dbo.CW_Pay1.ID, dbo.CW_Pay1.BID, dbo.CW_Pay1.bill, dbo.CW_Pay1.billtime, 
      dbo.CW_Pay1.billmen, dbo.CW_Pay1.Bname, dbo.CW_Pay1.Bzeren, 
      dbo.CW_Pay1.remark, dbo.CW_Pay1.checkmen, dbo.CW_Pay1.checktime, 
      dbo.CW_Pay1.fee1, dbo.CW_Pay1.fee2, dbo.CW_Pay1.fee3, dbo.CW_Pay1.fee4, 
      dbo.CW_Pay1.fee6, dbo.CW_Pay1.fee7, dbo.CW_Pay1.fee8, dbo.CW_Pay1.fee9, 
      dbo.CW_Pay1.fee10, dbo.CW_Pay1.fee5, dbo.CW_Pay1.fee11, dbo.CW_Pay1.fee12, 
      dbo.CW_Pay1.fee13, dbo.CW_Pay1.fee14, dbo.CW_Pay1.fee15, dbo.CW_Pay1.fee16, 
      dbo.CW_Pay1.fee17, dbo.CW_Pay1.fee18, dbo.CW_Pay1.fee19, dbo.CW_Pay1.fee20, 
      ISNULL(dbo.CW_Pay1.fee1, 0) + ISNULL(dbo.CW_Pay1.fee2, 0) 
      + ISNULL(dbo.CW_Pay1.fee3, 0) + ISNULL(dbo.CW_Pay1.fee4, 0) 
      + ISNULL(dbo.CW_Pay1.fee5, 0) + ISNULL(dbo.CW_Pay1.fee6, 0) 
      + ISNULL(dbo.CW_Pay1.fee7, 0) + ISNULL(dbo.CW_Pay1.fee8, 0) 
      + ISNULL(dbo.CW_Pay1.fee9, 0) + ISNULL(dbo.CW_Pay1.fee10, 0) 
      + ISNULL(dbo.CW_Pay1.fee11, 0) + ISNULL(dbo.CW_Pay1.fee12, 0) 
      + ISNULL(dbo.CW_Pay1.fee13, 0) + ISNULL(dbo.CW_Pay1.fee14, 0) 
      + ISNULL(dbo.CW_Pay1.fee15, 0) + ISNULL(dbo.CW_Pay1.fee16, 0) 
      + ISNULL(dbo.CW_Pay1.fee17, 0) + ISNULL(dbo.CW_Pay1.fee18, 0) 
      + ISNULL(dbo.CW_Pay1.fee19, 0) + ISNULL(dbo.CW_Pay1.fee20, 0) AS fyhj, 
      ISNULL(dbo.CW_Pay1.fee1, 0) + ISNULL(dbo.CW_Pay1.fee2, 0) 
      + ISNULL(dbo.CW_Pay1.fee3, 0) + ISNULL(dbo.CW_Pay1.fee4, 0) 
      + ISNULL(dbo.CW_Pay1.fee5, 0) + ISNULL(dbo.CW_Pay1.fee6, 0) 
      + ISNULL(dbo.CW_Pay1.fee7, 0) + ISNULL(dbo.CW_Pay1.fee8, 0) 
      + ISNULL(dbo.CW_Pay1.fee9, 0) + ISNULL(dbo.CW_Pay1.fee10, 0) 
      + ISNULL(dbo.CW_Pay1.fee11, 0) + ISNULL(dbo.CW_Pay1.fee12, 0) 
      + ISNULL(dbo.CW_Pay1.fee13, 0) + ISNULL(dbo.CW_Pay1.fee14, 0) 
      + ISNULL(dbo.CW_Pay1.fee15, 0) + ISNULL(dbo.CW_Pay1.fee16, 0) 
      + ISNULL(dbo.CW_Pay1.fee17, 0) + ISNULL(dbo.CW_Pay1.fee18, 0) 
      + ISNULL(dbo.CW_Pay1.fee19, 0) + ISNULL(dbo.CW_Pay1.fee20, 0) AS bxhj, 
      dbo.U_UserAndDepartVIEW.Dnum, dbo.U_UserAndDepartVIEW.depart
FROM dbo.CW_Pay1 INNER JOIN
      dbo.U_UserAndDepartVIEW ON 
      dbo.CW_Pay1.Bzeren = dbo.U_UserAndDepartVIEW.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.CW_PayView
AS
SELECT dbo.CW_Pay.ID, dbo.CW_Pay.ZcID, dbo.CW_Pay.bill, dbo.CW_Pay.billtime, 
      dbo.CW_Pay.danwei, dbo.CW_Pay.billmen, dbo.CW_Pay.zeren, dbo.CW_Pay.remark, 
      dbo.CW_Pay.checkmen, dbo.CW_Pay.checktime, dbo.CW_Pay.fee1, 
      dbo.CW_Pay.fee2, dbo.CW_Pay.fee3, dbo.CW_Pay.fee4, dbo.CW_Pay.fee5, 
      dbo.CW_Pay.fee6, dbo.CW_Pay.fee7, dbo.CW_Pay.fee8, dbo.CW_Pay.fee9, 
      dbo.CW_Pay.fee10, dbo.CW_Pay.fee11, dbo.CW_Pay.fee12, dbo.CW_Pay.fee13, 
      dbo.CW_Pay.fee14, dbo.CW_Pay.fee15, dbo.CW_Pay.fee16, dbo.CW_Pay.fee17, 
      dbo.CW_Pay.fee18, dbo.CW_Pay.fee19, dbo.CW_Pay.fee20, dbo.U_ZC.zcbao, 
      ISNULL(dbo.CW_Pay.fee1, 0) + ISNULL(dbo.CW_Pay.fee2, 0) 
      + ISNULL(dbo.CW_Pay.fee3, 0) + ISNULL(dbo.CW_Pay.fee4, 0) 
      + ISNULL(dbo.CW_Pay.fee5, 0) + ISNULL(dbo.CW_Pay.fee6, 0) 
      + ISNULL(dbo.CW_Pay.fee7, 0) + ISNULL(dbo.CW_Pay.fee8, 0) 
      + ISNULL(dbo.CW_Pay.fee9, 0) + ISNULL(dbo.CW_Pay.fee10, 0) 
      + ISNULL(dbo.CW_Pay.fee11, 0) + ISNULL(dbo.CW_Pay.fee12, 0) 
      + ISNULL(dbo.CW_Pay.fee13, 0) + ISNULL(dbo.CW_Pay.fee14, 0) 
      + ISNULL(dbo.CW_Pay.fee15, 0) + ISNULL(dbo.CW_Pay.fee16, 0) 
      + ISNULL(dbo.CW_Pay.fee17, 0) + ISNULL(dbo.CW_Pay.fee18, 0) 
      + ISNULL(dbo.CW_Pay.fee19, 0) + ISNULL(dbo.CW_Pay.fee20, 0) AS fyhj, 
      ISNULL(dbo.CW_Pay.fee1, 0) + ISNULL(dbo.CW_Pay.fee2, 0) 
      + ISNULL(dbo.CW_Pay.fee3, 0) + ISNULL(dbo.CW_Pay.fee4, 0) 
      + ISNULL(dbo.CW_Pay.fee5, 0) + ISNULL(dbo.CW_Pay.fee6, 0) 
      + ISNULL(dbo.CW_Pay.fee7, 0) + ISNULL(dbo.CW_Pay.fee8, 0) 
      + ISNULL(dbo.CW_Pay.fee9, 0) + ISNULL(dbo.CW_Pay.fee10, 0) 
      + ISNULL(dbo.CW_Pay.fee11, 0) + ISNULL(dbo.CW_Pay.fee12, 0) 
      + ISNULL(dbo.CW_Pay.fee13, 0) + ISNULL(dbo.CW_Pay.fee14, 0) 
      + ISNULL(dbo.CW_Pay.fee15, 0) + ISNULL(dbo.CW_Pay.fee16, 0) 
      + ISNULL(dbo.CW_Pay.fee17, 0) + ISNULL(dbo.CW_Pay.fee18, 0) 
      + ISNULL(dbo.CW_Pay.fee19, 0) + ISNULL(dbo.CW_Pay.fee20, 0) AS bxhj, 
      dbo.U_UserAndDepartVIEW.depart, dbo.U_UserAndDepartVIEW.Dnum
FROM dbo.CW_Pay INNER JOIN
      dbo.U_ZC ON dbo.CW_Pay.ZcID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserAndDepartVIEW ON 
      dbo.CW_Pay.zeren = dbo.U_UserAndDepartVIEW.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.CW_ShouKuan1View
AS
SELECT dbo.CW_ShouKuan1.ID, dbo.CW_ShouKuan1.BID, dbo.CW_ShouKuan1.bill, 
      dbo.CW_ShouKuan1.billtime, dbo.CW_ShouKuan1.billmen, 
      dbo.CW_ShouKuan1.Bname, dbo.CW_ShouKuan1.Bzeren, 
      dbo.CW_ShouKuan1.remark, dbo.CW_ShouKuan1.checkmen, 
      dbo.CW_ShouKuan1.checktime, dbo.CW_ShouKuan1.pbj, dbo.CW_ShouKuan1.plx, 
      ISNULL(dbo.CW_ShouKuan1.pbj, 0) + ISNULL(dbo.CW_ShouKuan1.plx, 0) AS bxhj, 
      dbo.U_UserAndDepartVIEW.Dnum, dbo.U_UserAndDepartVIEW.depart
FROM dbo.CW_ShouKuan1 INNER JOIN
      dbo.U_UserAndDepartVIEW ON 
      dbo.CW_ShouKuan1.Bzeren = dbo.U_UserAndDepartVIEW.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.CW_ShouKuanView
AS
SELECT dbo.CW_ShouKuan.ID, dbo.CW_ShouKuan.ZcID, dbo.CW_ShouKuan.bill, 
      dbo.CW_ShouKuan.billtime, dbo.CW_ShouKuan.billmen, dbo.CW_ShouKuan.danwei, 
      dbo.CW_ShouKuan.zeren, dbo.CW_ShouKuan.remark, dbo.CW_ShouKuan.checkmen, 
      dbo.CW_ShouKuan.checktime, dbo.CW_ShouKuan.pbj, dbo.CW_ShouKuan.plx, 
      dbo.U_ZC.zcbao, ISNULL(dbo.CW_ShouKuan.pbj, 0) 
      + ISNULL(dbo.CW_ShouKuan.plx, 0) AS bxhj, dbo.U_UserAndDepartVIEW.Dnum, 
      dbo.U_UserAndDepartVIEW.depart
FROM dbo.CW_ShouKuan INNER JOIN
      dbo.U_ZC ON dbo.CW_ShouKuan.ZcID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserAndDepartVIEW ON 
      dbo.CW_ShouKuan.zeren = dbo.U_UserAndDepartVIEW.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.CW_StockBillView
AS
SELECT dbo.CW_StockBill.ID, dbo.CW_StockBill.ZcID, dbo.CW_StockBill.gkind, 
      dbo.CW_StockBill.gname, dbo.CW_StockBill.ggxh, dbo.CW_StockBill.num, 
      dbo.CW_StockBill.price, dbo.CW_StockBill.dw, dbo.CW_StockBill.remark, 
      dbo.CW_StockBill.inbill, dbo.CW_StockBill.outbill, dbo.U_ZC.danwei
FROM dbo.CW_StockBill INNER JOIN
      dbo.U_ZC ON dbo.CW_StockBill.ZcID = dbo.U_ZC.ID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.DA_AnJuanFileView
AS
SELECT dbo.DA_AnJuan.ID, dbo.DA_AnJuan.ajnum, dbo.DA_AnJuan.ajname, 
      dbo.DA_AnJuan.time0, dbo.DA_AnJuan.ljren, dbo.DA_AnJuan.ajkind, 
      dbo.DA_AnJuan.remark, dbo.DA_AnJuan.ajstatus, dbo.DA_AnJuan.yjtime, 
      dbo.DA_AnJuan.yjdanwei, dbo.DA_AnJuan.jsren, dbo.DA_Files.ID AS FilesID, 
      dbo.DA_Files.ajnum AS ajnum1, dbo.DA_Files.fileno, dbo.DA_Files.title, 
      dbo.DA_Files.danwei, dbo.DA_Files.depart, dbo.DA_Files.zeren, 
      dbo.DA_Files.filenum, dbo.DA_Files.filecount, dbo.DA_Files.beginPage, 
      dbo.DA_Files.endPage, dbo.DA_Files.jyue, dbo.DA_Files.jyuetime, 
      dbo.DA_Files.djtime, dbo.DA_Files.dtmen
FROM dbo.DA_AnJuan LEFT OUTER JOIN
      dbo.DA_Files ON dbo.DA_AnJuan.ajnum = dbo.DA_Files.ajnum



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.U_ZCTCBUView
AS
SELECT dbo.U_ZCTC.ID, dbo.U_ZCTC.ZcID, dbo.U_ZCTC.time0, dbo.U_ZCTC.zeren, 
      dbo.U_ZCTC.didian, dbo.U_ZCTC.jieguo, dbo.U_ZCTC.kind, 
      ISNULL(dbo.ZCFileView1.Fcount, 0) AS Fcount, dbo.U_ZCTC.status, 
      dbo.U_ZCTC.Bkind, dbo.U_ZCTC.remark, dbo.U_UserAndDepartVIEW.depart, 
      dbo.U_UserAndDepartVIEW.Dnum
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_UserAndDepartVIEW ON 
      dbo.U_ZCTC.zeren = dbo.U_UserAndDepartVIEW.sname LEFT OUTER JOIN
      dbo.ZCFileView1 ON dbo.U_ZCTC.ID = dbo.ZCFileView1.TCID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCDepartTimeView
AS
SELECT dbo.ZCTimeView.*, dbo.U_UserName.leader AS leader, 
      LEFT(dbo.ZCTimeView.danwei, 20) AS danwei1, DATEADD(day, 
      - dbo.ZCTimeView.tellday, dbo.ZCTimeView.ZCTime) AS ZcTime0
FROM dbo.ZCTimeView INNER JOIN
      dbo.U_UserName ON dbo.ZCTimeView.zeren = dbo.U_UserName.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCSPStatView
AS
SELECT dbo.U_ZCSP.*, dbo.U_ZC.depart AS depart, dbo.U_ZC.zeren AS ZCzeren, 
      dbo.U_UserAndDepartVIEW.Dnum AS dnum
FROM dbo.U_ZCSP INNER JOIN
      dbo.U_ZC ON dbo.U_ZCSP.ZCID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserAndDepartVIEW ON dbo.U_ZC.zeren = dbo.U_UserAndDepartVIEW.sname



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.Zc2View1
AS
SELECT dbo.U_ZC2.ZCID, dbo.U_ZC2.spstatus, dbo.U_ZC2.spresult, 
      dbo.ZcTcView1.dotime, dbo.U_ZC2.status1, dbo.U_ZC2.status2
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.ZcTcView1 ON dbo.U_ZC2.ZCID = dbo.ZcTcView1.ZCID
WHERE (dbo.U_ZC2.ZCID IS NOT NULL)



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.Zc2View2
AS
SELECT dbo.U_ZC2.ZCBID, dbo.U_ZC2.spstatus, dbo.U_ZC2.spresult, 
      dbo.ZcTcView2.dotime, dbo.U_ZC2.status1, dbo.U_ZC2.status2
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.ZcTcView2 ON dbo.U_ZC2.ZCBID = dbo.ZcTcView2.ZCBID
WHERE (dbo.U_ZC2.ZCBID IS NOT NULL)



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcBNoShenPI
AS
SELECT dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.ZcBNOShenPIView ON dbo.U_ZCBSP.ID = dbo.ZcBNOShenPIView.id



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcBShenPI
AS
SELECT dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.ZcBShenPIView ON dbo.U_ZCBSP.ID = dbo.ZcBShenPIView.id



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW dbo.ZcBaoView3
AS
SELECT dbo.U_ZCBAO.ID, dbo.U_ZCBAO.Bname, dbo.U_ZCBAO.Bjsf, dbo.U_ZCBAO.Bzeren1 as zeren1,
      dbo.U_ZCBAO.Bzeren AS zeren, dbo.ZcBaoView2.bj, dbo.ZcBaoView2.lx, 
      dbo.U_UserName.depart
FROM dbo.U_ZCBAO INNER JOIN
      dbo.ZcBaoView2 ON dbo.U_ZCBAO.ID = dbo.ZcBaoView2.BID LEFT OUTER JOIN
      dbo.U_UserName ON dbo.U_ZCBAO.Bzeren = dbo.U_UserName.sname


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE VIEW dbo.ZcNoShengPI
AS
SELECT dbo.U_ZCSP.*
FROM dbo.U_ZCSP INNER JOIN
      dbo.ZCNoShenPIView ON dbo.U_ZCSP.ID = dbo.ZCNoShenPIView.id



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcShengPI
AS
SELECT dbo.U_ZCSP.*
FROM dbo.U_ZCSP INNER JOIN
      dbo.ZCShenPIView ON dbo.U_ZCSP.ID = dbo.ZCShenPIView.id



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcView2010
AS
SELECT dbo.ZCView.*, dbo.U_ZC2.spresult AS spresult1, dbo.U_ZC2.status1 AS spstatus1, 
      dbo.U_ZC2.status2 AS sptatus2, 
      dbo.U_ZC2.status1 + '-' + dbo.U_ZC2.status2 AS spText, 
      dbo.U_ZC2.spdotime AS spdotime1, dbo.U_ZC2.spstatus AS spstatus0
FROM dbo.ZCView LEFT OUTER JOIN
      dbo.U_ZC2 ON dbo.ZCView.ID = dbo.U_ZC2.ZCID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.DA_FileCopyBillView
AS
SELECT dbo.DA_Files.ID AS fid, dbo.DA_Files.ajnum, dbo.DA_Files.fileno, 
      dbo.DA_Files.title, dbo.DA_CopyBill.ID, dbo.DA_CopyBill.bill, dbo.DA_CopyBill.fileid, 
      dbo.DA_CopyBill.copycount
FROM dbo.DA_Files INNER JOIN
      dbo.DA_CopyBill ON dbo.DA_Files.ID = dbo.DA_CopyBill.fileid



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZCMyDepartZc
AS
SELECT dbo.ZCView.*, dbo.U_UserName.leader AS leader, LEFT(dbo.ZCView.danwei, 20) 
      AS danwei1, dbo.ZcView2010.spText AS spText
FROM dbo.ZCView INNER JOIN
      dbo.U_UserName ON 
      dbo.ZCView.zeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.ZcView2010 ON dbo.ZCView.ID = dbo.ZcView2010.ID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcNoShenPIINFO
AS
SELECT dbo.ZCView.*, LEFT(dbo.ZCView.danwei, 20) AS danwei1, 
      dbo.ZcNoShengPI.time0 AS SPTime, dbo.ZcNoShengPI.ID AS NID, 
      dbo.ZcNoShengPI.CZID AS czid, dbo.ZcNoShengPI.ZCID AS zcid, 
      dbo.ZcNoShengPI.zeren AS Nzeren, dbo.ZcNoShengPI.time1 AS time1, 
      dbo.ZcNoShengPI.remark AS Nremark, dbo.ZcNoShengPI.kind AS kind, 
      dbo.ZcNoShengPI.PS AS ps, dbo.ZcNoShengPI.PSCount AS pscount
FROM dbo.ZCView INNER JOIN
      dbo.ZcNoShengPI ON dbo.ZCView.ID = dbo.ZcNoShengPI.ZCID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.ZcShenPIINFO
AS
SELECT dbo.ZCView.*, dbo.ZcShengPI.ID AS NID, dbo.ZcShengPI.CZID AS czid, 
      dbo.ZcShengPI.ZCID AS zcid, dbo.ZcShengPI.time0 AS Ntime0, 
      dbo.ZcShengPI.zeren AS Nzeren, dbo.ZcShengPI.remark AS Nremark, 
      dbo.ZcShengPI.kind AS kind, dbo.ZcShengPI.PS AS ps, 
      dbo.ZcShengPI.PSCount AS pscount, LEFT(dbo.ZCView.danwei, 20) AS danwei1, 
      dbo.ZcShengPI.time1 AS SPTime
FROM dbo.ZCView INNER JOIN
      dbo.ZcShengPI ON dbo.ZCView.ID = dbo.ZcShengPI.ZCID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

