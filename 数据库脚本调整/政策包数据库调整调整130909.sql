/*-------------------切换数据库-----------------------------*/
use CJZC2007
go

/*--------------------更新数据库表-------------------------*/
if not exists (select 1 from syscolumns where id=object_id('U_OLDZC') and name='Zeren2')
begin
	alter table U_OLDZC add Zeren2 nvarchar(50)
end
go

if not exists (select 1 from syscolumns where id=object_id('U_OLDZC') and name='bzhtong')
begin
	alter table U_OLDZC add bzhtong nvarchar(250)
end
go



/*-------------刷新视图------------------------------------*/
/****** Object:  View [dbo].[CW_InStockView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_InStockView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[CW_InStockView]
GO
/****** Object:  View [dbo].[ZX_InfoView1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZX_InfoView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZX_InfoView1]
GO
/****** Object:  View [dbo].[CW_OutStockView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_OutStockView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[CW_OutStockView]
GO
/****** Object:  View [dbo].[CW_Pay1View]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_Pay1View]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[CW_Pay1View]
GO
/****** Object:  View [dbo].[CW_PayView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_PayView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[CW_PayView]
GO
/****** Object:  View [dbo].[CW_ShouKuan1View]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_ShouKuan1View]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[CW_ShouKuan1View]
GO
/****** Object:  View [dbo].[CW_ShouKuanView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_ShouKuanView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[CW_ShouKuanView]
GO
/****** Object:  View [dbo].[CW_StockBillView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_StockBillView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[CW_StockBillView]
GO
/****** Object:  View [dbo].[DA_AnJuanFileView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DA_AnJuanFileView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[DA_AnJuanFileView]
GO
/****** Object:  View [dbo].[DA_AnJuanView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DA_AnJuanView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[DA_AnJuanView]
GO
/****** Object:  View [dbo].[DA_FileCopyBillView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DA_FileCopyBillView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[DA_FileCopyBillView]
GO
/****** Object:  View [dbo].[U_UserAndDepartVIEW]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_UserAndDepartVIEW]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_UserAndDepartVIEW]
GO
/****** Object:  View [dbo].[U_ZC2BaoSearchView1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2BaoSearchView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_ZC2BaoSearchView1]
GO
/****** Object:  View [dbo].[U_ZC2BaoSearchView2]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2BaoSearchView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_ZC2BaoSearchView2]
GO
/****** Object:  View [dbo].[U_ZC2SearchView1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2SearchView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_ZC2SearchView1]
GO
/****** Object:  View [dbo].[U_ZC2SearchView11]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2SearchView11]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_ZC2SearchView11]
GO
/****** Object:  View [dbo].[U_ZC2SearchView2]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2SearchView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_ZC2SearchView2]
GO
/****** Object:  View [dbo].[U_ZCSPSearchView1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZCSPSearchView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_ZCSPSearchView1]
GO
/****** Object:  View [dbo].[U_ZCTCBUView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZCTCBUView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[U_ZCTCBUView]
GO
/****** Object:  View [dbo].[Zc2View1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Zc2View1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[Zc2View1]
GO
/****** Object:  View [dbo].[Zc2View2]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Zc2View2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[Zc2View2]
GO
/****** Object:  View [dbo].[ZCBAOFileView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCBAOFileView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCBAOFileView]
GO
/****** Object:  View [dbo].[ZCBAOView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCBAOView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCBAOView]
GO
/****** Object:  View [dbo].[ZcBaoView2]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBaoView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcBaoView2]
GO
/****** Object:  View [dbo].[ZcBaoView3]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBaoView3]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcBaoView3]
GO
/****** Object:  View [dbo].[ZcBNoShenPI]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBNoShenPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcBNoShenPI]
GO
/****** Object:  View [dbo].[ZcBNOShenPIView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBNOShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcBNOShenPIView]
GO
/****** Object:  View [dbo].[ZcBShenPI]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBShenPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcBShenPI]
GO
/****** Object:  View [dbo].[ZcBShenPIView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcBShenPIView]
GO
/****** Object:  View [dbo].[ZCBStateView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCBStateView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCBStateView]
GO
/****** Object:  View [dbo].[ZCDepartTimeView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCDepartTimeView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCDepartTimeView]
GO
/****** Object:  View [dbo].[ZCFileView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCFileView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCFileView]
GO
/****** Object:  View [dbo].[ZCFileView1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCFileView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCFileView1]
GO
/****** Object:  View [dbo].[ZCMyDepartZc]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCMyDepartZc]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCMyDepartZc]
GO
/****** Object:  View [dbo].[ZcNoShengPI]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcNoShengPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcNoShengPI]
GO
/****** Object:  View [dbo].[ZcNoShenPIINFO]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcNoShenPIINFO]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcNoShenPIINFO]
GO
/****** Object:  View [dbo].[ZCNoShenPIView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCNoShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCNoShenPIView]
GO
/****** Object:  View [dbo].[ZCShenBaoView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCShenBaoView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCShenBaoView]
GO
/****** Object:  View [dbo].[ZcShengPI]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcShengPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcShengPI]
GO
/****** Object:  View [dbo].[ZcShenPIINFO]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcShenPIINFO]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcShenPIINFO]
GO
/****** Object:  View [dbo].[ZCShenPIView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCShenPIView]
GO
/****** Object:  View [dbo].[ZCSP1View]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCSP1View]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCSP1View]
GO
/****** Object:  View [dbo].[ZCSPStatView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCSPStatView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCSPStatView]
GO
/****** Object:  View [dbo].[ZCSPView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCSPView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCSPView]
GO
/****** Object:  View [dbo].[ZCStateView1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCStateView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCStateView1]
GO
/****** Object:  View [dbo].[ZcTcView1]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcTcView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcTcView1]
GO
/****** Object:  View [dbo].[ZcTcView2]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcTcView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcTcView2]
GO
/****** Object:  View [dbo].[ZCTimeView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCTimeView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCTimeView]
GO
/****** Object:  View [dbo].[ZCView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZCView]
GO
/****** Object:  View [dbo].[ZcView2010]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcView2010]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZcView2010]
GO
/****** Object:  View [dbo].[ZX_InfoView]    Script Date: 09/10/2013 11:22:02 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZX_InfoView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[ZX_InfoView]
GO
/****** Object:  View [dbo].[CW_InStockView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_InStockView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.CW_InStockView
AS
SELECT dbo.CW_InStock.*, dbo.U_UserName.depart AS depart, dbo.U_ZC.zcbao AS zcbao, 
      0 AS bxhj
FROM dbo.CW_InStock INNER JOIN
      dbo.U_ZC ON dbo.CW_InStock.ZcID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserName ON dbo.CW_InStock.zeren = dbo.U_UserName.sname



' 
GO
/****** Object:  View [dbo].[ZCFileView1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCFileView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCFileView1
AS
SELECT TCID, COUNT(*) AS Fcount
FROM dbo.U_ZCFiles
GROUP BY TCID


' 
GO
/****** Object:  View [dbo].[ZcBNOShenPIView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBNOShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcBNOShenPIView
AS
SELECT BID, zeren, MAX(ID) AS id
FROM dbo.U_ZCBSP
WHERE (time1 IS NULL)
GROUP BY BID, zeren



' 
GO
/****** Object:  View [dbo].[ZCTimeView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCTimeView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'




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


' 
GO
/****** Object:  View [dbo].[ZcTcView2]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcTcView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcTcView2
AS
SELECT distinct dbo.U_ZC2.ZCBID, MAX(dbo.U_ZCTC.dotime) AS dotime
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.U_ZCTC ON dbo.U_ZC2.ID = dbo.U_ZCTC.czid
WHERE (dbo.U_ZC2.ZCBID IS NOT NULL)
GROUP BY dbo.U_ZC2.ZCBID


' 
GO
/****** Object:  View [dbo].[ZcBShenPIView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcBShenPIView
AS
SELECT BID, zeren, MAX(ID) AS id
FROM dbo.U_ZCBSP
WHERE (time1 IS NOT NULL)
GROUP BY BID, zeren


' 
GO
/****** Object:  View [dbo].[ZCView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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


' 
GO
/****** Object:  View [dbo].[ZcTcView1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcTcView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcTcView1
AS
SELECT distinct dbo.U_ZC2.ZCID, MAX(dbo.U_ZCTC.dotime) AS dotime
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.U_ZCTC ON dbo.U_ZC2.ID = dbo.U_ZCTC.czid
WHERE (dbo.U_ZC2.ZCID IS NOT NULL)
GROUP BY dbo.U_ZC2.ZCID



' 
GO
/****** Object:  View [dbo].[ZcView2010]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcView2010]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcView2010
AS
SELECT dbo.ZCView.*, dbo.U_ZC2.spresult AS spresult1, dbo.U_ZC2.status1 AS spstatus1, 
      dbo.U_ZC2.status2 AS sptatus2, 
      dbo.U_ZC2.status1 + ''-'' + dbo.U_ZC2.status2 AS spText, 
      dbo.U_ZC2.spdotime AS spdotime1, dbo.U_ZC2.spstatus AS spstatus0
FROM dbo.ZCView LEFT OUTER JOIN
      dbo.U_ZC2 ON dbo.ZCView.ID = dbo.U_ZC2.ZCID


' 
GO
/****** Object:  View [dbo].[ZCNoShenPIView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCNoShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'




CREATE VIEW dbo.ZCNoShenPIView
AS
SELECT ZCID, zeren, MAX(ID) AS id
FROM dbo.U_ZCSP
WHERE (time1 IS NULL)
GROUP BY ZCID, zeren


' 
GO
/****** Object:  View [dbo].[ZCShenPIView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCShenPIView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCShenPIView
AS
SELECT ZCID, zeren, MAX(ID) AS id
FROM dbo.U_ZCSP
WHERE (time1 IS NOT NULL)
GROUP BY ZCID, zeren

/*jinshouji---------------------------------------------------------------------------------*/

' 
GO
/****** Object:  View [dbo].[U_UserAndDepartVIEW]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_UserAndDepartVIEW]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'




/*---------------------------------*/
CREATE VIEW dbo.U_UserAndDepartVIEW
AS
SELECT dbo.U_UserName.*, dbo.U_Depart.num AS Dnum
FROM dbo.U_UserName INNER JOIN
      dbo.U_Depart ON dbo.U_UserName.depart = dbo.U_Depart.depart


' 
GO
/****** Object:  View [dbo].[U_ZCSPSearchView1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZCSPSearchView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'

CREATE View U_ZCSPSearchView1 AS

	select zcid,dbo.getSpStatus(kind,ps) spstatus from u_zcsp where id in(
select max(id) id from u_zcsp where zcid is not null and (zx=''1'' and (kind=''13''or kind=''15'')) or kind=''11''
group by zcid )


'
GO
/****** Object:  View [dbo].[ZX_InfoView1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZX_InfoView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'


CREATE VIEW dbo.ZX_InfoView1
AS
SELECT dbo.ZX_Info.*, dbo.ZX_InfoRead.ydren AS ydren
FROM dbo.ZX_Info INNER JOIN
      dbo.ZX_InfoRead ON dbo.ZX_Info.ID = dbo.ZX_InfoRead.infoid




' 
GO
/****** Object:  View [dbo].[CW_OutStockView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_OutStockView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.CW_OutStockView
AS
SELECT dbo.U_ZC.zcbao, dbo.U_UserName.depart, dbo.CW_OutStock.*, 0 AS bxhj
FROM dbo.CW_OutStock INNER JOIN
      dbo.U_ZC ON dbo.CW_OutStock.ZcID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserName ON dbo.CW_OutStock.zeren = dbo.U_UserName.sname




' 
GO
/****** Object:  View [dbo].[CW_Pay1View]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_Pay1View]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[CW_PayView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_PayView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[CW_ShouKuan1View]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_ShouKuan1View]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[CW_ShouKuanView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_ShouKuanView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[CW_StockBillView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CW_StockBillView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.CW_StockBillView
AS
SELECT dbo.CW_StockBill.ID, dbo.CW_StockBill.ZcID, dbo.CW_StockBill.gkind, 
      dbo.CW_StockBill.gname, dbo.CW_StockBill.ggxh, dbo.CW_StockBill.num, 
      dbo.CW_StockBill.price, dbo.CW_StockBill.dw, dbo.CW_StockBill.remark, 
      dbo.CW_StockBill.inbill, dbo.CW_StockBill.outbill, dbo.U_ZC.danwei
FROM dbo.CW_StockBill INNER JOIN
      dbo.U_ZC ON dbo.CW_StockBill.ZcID = dbo.U_ZC.ID




' 
GO
/****** Object:  View [dbo].[DA_AnJuanFileView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DA_AnJuanFileView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[DA_AnJuanView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DA_AnJuanView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.DA_AnJuanView
AS
SELECT ID, ajnum, ajname, time0, ljren, ajkind, remark, ajstatus
FROM dbo.DA_AnJuan




' 
GO
/****** Object:  View [dbo].[DA_FileCopyBillView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DA_FileCopyBillView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.DA_FileCopyBillView
AS
SELECT dbo.DA_Files.ID AS fid, dbo.DA_Files.ajnum, dbo.DA_Files.fileno, 
      dbo.DA_Files.title, dbo.DA_CopyBill.ID, dbo.DA_CopyBill.bill, dbo.DA_CopyBill.fileid, 
      dbo.DA_CopyBill.copycount
FROM dbo.DA_Files INNER JOIN
      dbo.DA_CopyBill ON dbo.DA_Files.ID = dbo.DA_CopyBill.fileid





' 
GO
/****** Object:  View [dbo].[U_ZC2BaoSearchView1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2BaoSearchView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'

CREATE View U_ZC2BaoSearchView1 AS

	select id,zcbid,xmmc,danwei,hysj1,hysj2,spstatus,status1,status2,spresult,spdotime
from u_zc2  where zcbid is not null


' 
GO
/****** Object:  View [dbo].[U_ZC2BaoSearchView2]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2BaoSearchView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'

CREATE View U_ZC2BaoSearchView2 AS

	select * from U_ZC2BaoSearchView1 where id in (select max(id) id from U_ZC2BaoSearchView1 group by zcbid) 

' 
GO
/****** Object:  View [dbo].[U_ZC2SearchView1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2SearchView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'

CREATE View U_ZC2SearchView1 AS

	select U_ZC2.id,U_ZC2.zcid,
	xmmc,danwei,hysj1,hysj2,U_ZCSPSearchView1.spstatus spstatus,status1,status2,spresult,spdotime
from u_zc2 left outer join U_ZCSPSearchView1
on U_ZC2.zcid=U_ZCSPSearchView1.zcid 
where U_ZC2.zcid is not null


' 
GO
/****** Object:  View [dbo].[U_ZC2SearchView11]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2SearchView11]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'

CREATE View U_ZC2SearchView11 AS

	select zcid,max(id) id from U_ZC2SearchView1 group by zcid

' 
GO
/****** Object:  View [dbo].[U_ZC2SearchView2]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZC2SearchView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'

CREATE View U_ZC2SearchView2 AS

	select * from U_ZC2SearchView1 where exists ( select * from U_ZC2SearchView11 where id=U_ZC2SearchView1.id) 


' 
GO
/****** Object:  View [dbo].[U_ZCTCBUView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[U_ZCTCBUView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[Zc2View1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Zc2View1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.Zc2View1
AS
SELECT dbo.U_ZC2.ZCID, dbo.U_ZC2.spstatus, dbo.U_ZC2.spresult, 
      dbo.ZcTcView1.dotime, dbo.U_ZC2.status1, dbo.U_ZC2.status2
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.ZcTcView1 ON dbo.U_ZC2.ZCID = dbo.ZcTcView1.ZCID
WHERE (dbo.U_ZC2.ZCID IS NOT NULL)




' 
GO
/****** Object:  View [dbo].[Zc2View2]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Zc2View2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.Zc2View2
AS
SELECT dbo.U_ZC2.ZCBID, dbo.U_ZC2.spstatus, dbo.U_ZC2.spresult, 
      dbo.ZcTcView2.dotime, dbo.U_ZC2.status1, dbo.U_ZC2.status2
FROM dbo.U_ZC2 LEFT OUTER JOIN
      dbo.ZcTcView2 ON dbo.U_ZC2.ZCBID = dbo.ZcTcView2.ZCBID
WHERE (dbo.U_ZC2.ZCBID IS NOT NULL)




' 
GO
/****** Object:  View [dbo].[ZCBAOFileView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCBAOFileView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'





CREATE VIEW dbo.ZCBAOFileView
AS
SELECT dbo.U_ZCTC.zeren AS djren, dbo.U_ZCStatus.statusText, dbo.U_ZCTC.kind, 
      dbo.U_ZCFiles.*, dbo.U_ZCBAO.Bname AS bname, 
      dbo.U_ZCBAO.Bzeren AS bzeren
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_ZCFiles ON dbo.U_ZCTC.ID = dbo.U_ZCFiles.TCID INNER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCTC.kind = dbo.U_ZCStatus.statusValue INNER JOIN
      dbo.U_ZCBAO ON dbo.U_ZCTC.ZcID = dbo.U_ZCBAO.ID




' 
GO
/****** Object:  View [dbo].[ZCBAOView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCBAOView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[ZcBaoView2]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBaoView2]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW dbo.ZcBaoView2
AS
SELECT dbo.U_ZCBAOInfo.BID, SUM(dbo.U_ZC.bj) AS bj, SUM(ISNULL(dbo.U_ZC.lx1, 0) 
      + ISNULL(dbo.U_ZC.lx2, 0) + ISNULL(dbo.U_ZC.lx3, 0)) AS lx, COUNT(*) AS hs
FROM dbo.U_ZCBAOInfo INNER JOIN
      dbo.U_ZC ON dbo.U_ZCBAOInfo.ZCID = dbo.U_ZC.ID
GROUP BY dbo.U_ZCBAOInfo.BID

' 
GO
/****** Object:  View [dbo].[ZcBaoView3]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBaoView3]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW dbo.ZcBaoView3
AS
SELECT dbo.U_ZCBAO.ID, dbo.U_ZCBAO.Bname, dbo.U_ZCBAO.Bjsf, 
      dbo.U_ZCBAO.bzeren1 AS zeren1, dbo.U_ZCBAO.Bzeren AS zeren, 
      dbo.ZcBaoView2.bj, dbo.ZcBaoView2.lx, dbo.U_UserName.depart, 
      dbo.ZcBaoView2.hs
FROM dbo.U_ZCBAO INNER JOIN
      dbo.ZcBaoView2 ON dbo.U_ZCBAO.ID = dbo.ZcBaoView2.BID LEFT OUTER JOIN
      dbo.U_UserName ON dbo.U_ZCBAO.Bzeren = dbo.U_UserName.sname

' 
GO
/****** Object:  View [dbo].[ZcBNoShenPI]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBNoShenPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcBNoShenPI
AS
SELECT dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.ZcBNOShenPIView ON dbo.U_ZCBSP.ID = dbo.ZcBNOShenPIView.id







' 
GO
/****** Object:  View [dbo].[ZcBShenPI]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcBShenPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcBShenPI
AS
SELECT dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.ZcBShenPIView ON dbo.U_ZCBSP.ID = dbo.ZcBShenPIView.id





' 
GO
/****** Object:  View [dbo].[ZCBStateView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCBStateView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCBStateView
AS
SELECT dbo.U_ZCBAO.*, dbo.U_ZCStatus.statusText AS statusText, 
      dbo.U_UserName.depart AS depart
FROM dbo.U_ZCBAO INNER JOIN
      dbo.U_UserName ON 
      dbo.U_ZCBAO.Bzeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCBAO.Bstatus = dbo.U_ZCStatus.statusValue




' 
GO
/****** Object:  View [dbo].[ZCDepartTimeView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCDepartTimeView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCDepartTimeView
AS
SELECT dbo.ZCTimeView.*, dbo.U_UserName.leader AS leader, 
      LEFT(dbo.ZCTimeView.danwei, 20) AS danwei1, DATEADD(day, 
      - dbo.ZCTimeView.tellday, dbo.ZCTimeView.ZCTime) AS ZcTime0
FROM dbo.ZCTimeView INNER JOIN
      dbo.U_UserName ON dbo.ZCTimeView.zeren = dbo.U_UserName.sname




' 
GO
/****** Object:  View [dbo].[ZCFileView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCFileView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCFileView
AS
SELECT dbo.U_ZCTC.zeren AS djren, dbo.U_ZCStatus.statusText, dbo.U_ZCTC.kind, 
      dbo.U_ZC.danwei, dbo.U_ZC.zeren, dbo.U_ZC.depart, dbo.U_ZCFiles.*
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_ZCFiles ON dbo.U_ZCTC.ID = dbo.U_ZCFiles.TCID INNER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCTC.kind = dbo.U_ZCStatus.statusValue INNER JOIN
      dbo.U_ZC ON dbo.U_ZCTC.ZcID = dbo.U_ZC.ID






' 
GO
/****** Object:  View [dbo].[ZCMyDepartZc]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCMyDepartZc]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'CREATE VIEW dbo.ZCMyDepartZc
AS
SELECT dbo.ZCView.statusText, dbo.ZCView.U_depart, dbo.ZCView.pbj, dbo.ZCView.plx, 
      dbo.ZCView.fee1, dbo.ZCView.fee2, dbo.ZCView.fee3, dbo.ZCView.fee4, 
      dbo.ZCView.fee5, dbo.ZCView.fee6, dbo.ZCView.fee7, dbo.ZCView.fee9, 
      dbo.ZCView.fee8, dbo.ZCView.fee10, dbo.ZCView.fee11, dbo.ZCView.fee12, 
      dbo.ZCView.fee13, dbo.ZCView.fee14, dbo.ZCView.fee15, dbo.ZCView.fee16, 
      dbo.ZCView.fee17, dbo.ZCView.fee18, dbo.ZCView.fee19, dbo.ZCView.fee20, 
      dbo.ZCView.num2, dbo.ZCView.danwei, dbo.ZCView.bj, dbo.ZCView.lx1, 
      dbo.ZCView.lx2, dbo.ZCView.lx3, dbo.ZCView.quyu, dbo.ZCView.guangxia, 
      dbo.ZCView.bank, dbo.ZCView.sshy, dbo.ZCView.depart, dbo.ZCView.zeren, 
      dbo.ZCView.zhwd, dbo.ZCView.num1, dbo.ZCView.zcbao, dbo.ZCView.zhuang, 
      dbo.ZCView.htnum, dbo.ZCView.ID, dbo.ZCView.time0, dbo.ZCView.fenlei, 
      dbo.ZCView.remark, dbo.ZCView.huobi, dbo.ZCView.huilv, dbo.ZCView.status, 
      dbo.ZCView.userkind, dbo.ZCView.zzjg, dbo.ZCView.jysfzc, dbo.ZCView.clsj, 
      dbo.ZCView.zczb, dbo.ZCView.dqjj, dbo.ZCView.qygm, dbo.ZCView.dwdz, 
      dbo.ZCView.dwfzr, dbo.ZCView.qyjjxz, dbo.ZCView.yxzzzk, dbo.ZCView.xdri, 
      dbo.ZCView.dkffrq1, dbo.ZCView.jklsh, dbo.ZCView.dkye, dbo.ZCView.dkffrq2, 
      dbo.ZCView.htdqr, dbo.ZCView.zjycszje, dbo.ZCView.zydbfs, dbo.ZCView.dbrwmc, 
      dbo.ZCView.yyldxt, dbo.ZCView.xcyqrq, dbo.ZCView.jrblsj, dbo.ZCView.gx, 
      dbo.ZCView.Bstatus, dbo.ZCView.spstatus, dbo.ZCView.spresult, 
      dbo.ZCView.spdotime, dbo.ZCView.status1, dbo.ZCView.status2, dbo.ZCView.zeren1, 
      dbo.ZCView.bxhj, dbo.ZCView.hjbx, dbo.U_UserName.leader, 
      LEFT(dbo.ZCView.danwei, 20) AS danwei1, dbo.ZcView2010.spText
FROM dbo.ZCView INNER JOIN
      dbo.U_UserName ON 
      dbo.ZCView.zeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.ZcView2010 ON dbo.ZCView.ID = dbo.ZcView2010.ID
' 
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'USER',N'dbo', N'VIEW',N'ZCMyDepartZc', NULL,NULL))
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ZCView"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 109
               Right = 178
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "U_UserName"
            Begin Extent = 
               Top = 6
               Left = 216
               Bottom = 109
               Right = 350
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ZcView2010"
            Begin Extent = 
               Top = 148
               Left = 413
               Bottom = 251
               Right = 553
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ZCMyDepartZc'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'USER',N'dbo', N'VIEW',N'ZCMyDepartZc', NULL,NULL))
EXEC dbo.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'USER',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ZCMyDepartZc'
GO
/****** Object:  View [dbo].[ZcNoShengPI]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcNoShengPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'





CREATE VIEW dbo.ZcNoShengPI
AS
SELECT dbo.U_ZCSP.*
FROM dbo.U_ZCSP INNER JOIN
      dbo.ZCNoShenPIView ON dbo.U_ZCSP.ID = dbo.ZCNoShenPIView.id




' 
GO
/****** Object:  View [dbo].[ZcNoShenPIINFO]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcNoShenPIINFO]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[ZCShenBaoView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCShenBaoView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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




' 
GO
/****** Object:  View [dbo].[ZcShengPI]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcShengPI]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZcShengPI
AS
SELECT dbo.U_ZCSP.*
FROM dbo.U_ZCSP INNER JOIN
      dbo.ZCShenPIView ON dbo.U_ZCSP.ID = dbo.ZCShenPIView.id




' 
GO
/****** Object:  View [dbo].[ZcShenPIINFO]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZcShenPIINFO]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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



' 
GO
/****** Object:  View [dbo].[ZCSP1View]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCSP1View]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCSP1View
AS
SELECT dbo.U_UserName.depart, dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.U_UserName ON dbo.U_ZCBSP.zeren = dbo.U_UserName.sname




' 
GO
/****** Object:  View [dbo].[ZCSPStatView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCSPStatView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCSPStatView
AS
SELECT dbo.U_ZCSP.*, dbo.U_ZC.depart AS depart, dbo.U_ZC.zeren AS ZCzeren, 
      dbo.U_UserAndDepartVIEW.Dnum AS dnum
FROM dbo.U_ZCSP INNER JOIN
      dbo.U_ZC ON dbo.U_ZCSP.ZCID = dbo.U_ZC.ID INNER JOIN
      dbo.U_UserAndDepartVIEW ON dbo.U_ZC.zeren = dbo.U_UserAndDepartVIEW.sname




' 
GO
/****** Object:  View [dbo].[ZCSPView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCSPView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW dbo.ZCSPView
AS
SELECT dbo.U_ZCSP.*, dbo.U_UserName.depart AS depart
FROM dbo.U_ZCSP INNER JOIN
      dbo.U_UserName ON dbo.U_ZCSP.zeren = dbo.U_UserName.sname




' 
GO
/****** Object:  View [dbo].[ZCStateView1]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZCStateView1]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'



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



' 
GO
/****** Object:  View [dbo].[ZX_InfoView]    Script Date: 09/10/2013 11:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ZX_InfoView]') AND OBJECTPROPERTY(id, N'IsView') = 1)
EXEC dbo.sp_executesql @statement = N'







CREATE VIEW dbo.ZX_InfoView
AS
SELECT dbo.ZX_Info.*, dbo.ZX_InfoRead.ydren AS ydren
FROM dbo.ZX_Info LEFT OUTER JOIN
      dbo.ZX_InfoRead ON dbo.ZX_Info.ID = dbo.ZX_InfoRead.infoid




' 
GO
