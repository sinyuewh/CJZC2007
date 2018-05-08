 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_Pay1View]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CW_Pay1View]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.CW_Pay1View
AS
SELECT dbo.CW_Pay1.ID, dbo.CW_Pay1.BID, dbo.CW_Pay1.bill, dbo.CW_Pay1.billtime, 
      dbo.CW_Pay1.billmen, dbo.CW_Pay1.Bname, dbo.CW_Pay1.Bzeren, 
      dbo.CW_Pay1.remark, dbo.CW_Pay1.checkmen, dbo.CW_Pay1.checktime, 
      dbo.CW_Pay1.fee1, dbo.CW_Pay1.fee2, dbo.CW_Pay1.fee3, dbo.CW_Pay1.fee4, 
      dbo.CW_Pay1.fee6, dbo.CW_Pay1.fee7, dbo.CW_Pay1.fee8, dbo.CW_Pay1.fee9, 
      dbo.CW_Pay1.fee10, dbo.CW_Pay1.fee5, dbo.CW_Pay1.fee11, dbo.CW_Pay1.fee12, 
      dbo.CW_Pay1.fee13, dbo.CW_Pay1.fee14, dbo.CW_Pay1.fee15, dbo.CW_Pay1.fee16, 
      dbo.CW_Pay1.fee17, dbo.CW_Pay1.fee18, dbo.CW_Pay1.fee19, dbo.CW_Pay1.fee20, 
      dbo.U_UserName.depart, ISNULL(dbo.CW_Pay1.fee1, 0) 
      + ISNULL(dbo.CW_Pay1.fee2, 0) + ISNULL(dbo.CW_Pay1.fee3, 0) 
      + ISNULL(dbo.CW_Pay1.fee4, 0) + ISNULL(dbo.CW_Pay1.fee5, 0) 
      + ISNULL(dbo.CW_Pay1.fee6, 0) + ISNULL(dbo.CW_Pay1.fee7, 0) 
      + ISNULL(dbo.CW_Pay1.fee8, 0) + ISNULL(dbo.CW_Pay1.fee9, 0) 
      + ISNULL(dbo.CW_Pay1.fee10, 0) + ISNULL(dbo.CW_Pay1.fee11, 0) 
      + ISNULL(dbo.CW_Pay1.fee12, 0) + ISNULL(dbo.CW_Pay1.fee13, 0) 
      + ISNULL(dbo.CW_Pay1.fee14, 0) + ISNULL(dbo.CW_Pay1.fee15, 0) 
      + ISNULL(dbo.CW_Pay1.fee16, 0) + ISNULL(dbo.CW_Pay1.fee17, 0) 
      + ISNULL(dbo.CW_Pay1.fee18, 0) + ISNULL(dbo.CW_Pay1.fee19, 0) 
      + ISNULL(dbo.CW_Pay1.fee20, 0) AS fyhj
FROM dbo.CW_Pay1 INNER JOIN
      dbo.U_UserName ON dbo.CW_Pay1.Bzeren = dbo.U_UserName.sname

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

