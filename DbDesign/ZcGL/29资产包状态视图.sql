if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCBStateView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCBStateView]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.ZCBStateView
AS
SELECT dbo.U_ZCBAO.*, dbo.U_ZCStatus.statusText
FROM dbo.U_ZCBAO LEFT OUTER JOIN
      dbo.U_ZCStatus ON dbo.U_ZCBAO.Bstatus = dbo.U_ZCStatus.statusValue

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 