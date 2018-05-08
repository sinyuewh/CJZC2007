if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBShenPIView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBShenPIView]
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

 