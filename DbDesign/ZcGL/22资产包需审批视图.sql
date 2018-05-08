if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBNOShenPIView]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBNOShenPIView]
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

