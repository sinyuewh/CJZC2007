if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCTCBUView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[U_ZCTCBUView]
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
      dbo.U_ZCTC.Bkind, dbo.U_ZCTC.remark, dbo.U_UserName.depart
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_UserName ON 
      dbo.U_ZCTC.zeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.ZCFileView1 ON dbo.U_ZCTC.ID = dbo.ZCFileView1.TCID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 