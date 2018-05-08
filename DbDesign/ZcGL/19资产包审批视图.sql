if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZCSP1View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZCSP1View]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.ZCSP1View
AS
SELECT dbo.U_UserName.depart AS Expr1, dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.U_UserName ON dbo.U_ZCBSP.zeren = dbo.U_UserName.sname

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 