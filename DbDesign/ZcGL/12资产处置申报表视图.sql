CREATE VIEW dbo.ZCShenBaoView
AS
SELECT dbo.U_ZC.depart AS cbdepart, dbo.U_ZC.zeren AS cbzeren, dbo.U_ZC2.*, 
      dbo.U_ZC.danwei, dbo.U_ZC.bj, dbo.U_ZC.lx1, dbo.U_ZC.lx2, dbo.U_ZC.lx3, 
      ISNULL(dbo.U_ZC.bj, 0) + ISNULL(dbo.U_ZC.lx1, 0) + ISNULL(dbo.U_ZC.lx2, 0) 
      + ISNULL(dbo.U_ZC.lx3, 0) AS zqze, ISNULL(dbo.U_ZC.lx1, 0) 
      + ISNULL(dbo.U_ZC.lx2, 0) + ISNULL(dbo.U_ZC.lx3, 0) AS lx
FROM dbo.U_ZC2 INNER JOIN
      dbo.U_ZC ON dbo.U_ZC2.ZCID = dbo.U_ZC.ID
