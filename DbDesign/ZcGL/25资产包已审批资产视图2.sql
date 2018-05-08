if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ZcBShenPI]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ZcBShenPI]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.ZcBShenPI
AS
SELECT dbo.U_ZCBSP.*
FROM dbo.U_ZCBSP INNER JOIN
      dbo.ZcBShenPIView ON dbo.U_ZCBSP.ID = dbo.ZcBShenPIView.id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

