if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_ShouKuan1View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_ShouKuan1View]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.CW_ShouKuan1View
AS
SELECT dbo.CW_ShouKuan1.ID, dbo.CW_ShouKuan1.BID, dbo.CW_ShouKuan1.bill, 
      dbo.CW_ShouKuan1.billtime, dbo.CW_ShouKuan1.billmen, 
      dbo.CW_ShouKuan1.Bname, dbo.CW_ShouKuan1.Bzeren, 
      dbo.CW_ShouKuan1.remark, dbo.CW_ShouKuan1.checkmen, 
      dbo.CW_ShouKuan1.checktime, dbo.CW_ShouKuan1.pbj, dbo.CW_ShouKuan1.plx, 
      dbo.U_UserName.depart, ISNULL(dbo.CW_ShouKuan1.pbj, 0) 
      + ISNULL(dbo.CW_ShouKuan1.plx, 0) AS bxhj
FROM dbo.CW_ShouKuan1 INNER JOIN
      dbo.U_UserName ON dbo.CW_ShouKuan1.Bzeren = dbo.U_UserName.sname

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 