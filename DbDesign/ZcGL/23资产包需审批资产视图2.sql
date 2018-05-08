if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBNoShenPI]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBNoShenPI]
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

 