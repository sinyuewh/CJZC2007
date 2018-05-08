 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCBAOView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCBAOView]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.ZCBAOView
AS
SELECT dbo.U_UserName.depart, dbo.U_ZCStatus.statusText, dbo.U_ZCBAO.*
FROM dbo.U_ZCBAO LEFT OUTER JOIN
      dbo.U_UserName ON 
      dbo.U_ZCBAO.Bzeren = dbo.U_UserName.sname LEFT OUTER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCBAO.Bstatus = dbo.U_ZCStatus.statusValue

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

