 use HKbankData
 Go
 
  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCTCBUView')
	BEGIN
		DROP  view U_ZCTCBUView
	END
GO

create view U_ZCTCBUView as 
 
 SELECT   dbo.U_ZCTC.ID, dbo.U_ZCTC.ZcID, dbo.U_ZCTC.time0, dbo.U_ZCTC.zeren, dbo.U_ZCTC.didian, dbo.U_ZCTC.jieguo, 
                dbo.U_ZCTC.kind, ISNULL(dbo.ZCFileView1.Fcount, 0) AS Fcount, dbo.U_ZCTC.status, dbo.U_ZCTC.Bkind, 
                dbo.U_ZCTC.remark, dbo.U_UserAndDepartVIEW.depart, dbo.U_UserAndDepartVIEW.Dnum, 
                dbo.U_ZCTC.remark1 AS remark2
FROM      dbo.U_ZCTC INNER JOIN
                dbo.U_UserAndDepartVIEW ON dbo.U_ZCTC.zeren = dbo.U_UserAndDepartVIEW.sname LEFT OUTER JOIN
                dbo.ZCFileView1 ON dbo.U_ZCTC.ID = dbo.ZCFileView1.TCID