if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCBAOFileView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCBAOFileView]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.ZCBAOFileView
AS
SELECT dbo.U_ZCTC.zeren AS djren, dbo.U_ZCStatus.statusText, dbo.U_ZCTC.kind, 
      dbo.U_ZCFiles.*, dbo.U_ZCBAO.Bname, dbo.U_ZCBAO.Bzeren
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_ZCFiles ON dbo.U_ZCTC.ID = dbo.U_ZCFiles.TCID INNER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCTC.kind = dbo.U_ZCStatus.statusValue INNER JOIN
      dbo.U_ZCBAO ON dbo.U_ZCTC.ZcID = dbo.U_ZCBAO.ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 