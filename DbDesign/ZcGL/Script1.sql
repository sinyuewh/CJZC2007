IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'ZCStateView1')
	BEGIN
		DROP  View ZCStateView1
	END
GO

CREATE View ZCStateView1 AS

	SELECT U_ZC.danwei, U_ZC.bj, U_ZC.lx1, U_ZC.lx2, U_ZC.lx3, 
      U_ZC.depart, U_ZC.zeren, U_ZC.ID, U_ZC.status, 
      U_ZCStatus.statusText, U_ZC.userkind, U_ZC3.pbj, U_ZC3.plx, 
      U_ZC3.fee1, U_ZC3.fee2, U_ZC3.fee3, U_ZC3.fee4, U_ZC3.fee5, 
      U_ZC3.fee6, U_ZC3.fee7, U_ZC3.fee8, U_ZC3.fee9, 
      U_ZC3.fee10, U_ZC3.fee11, U_ZC3.fee12, U_ZC3.fee13, 
      U_ZC3.fee14, U_ZC3.fee15, U_ZC3.fee16, U_ZC3.fee17, 
      U_ZC3.fee18, U_ZC3.fee19, U_ZC3.fee20
FROM U_ZC LEFT OUTER JOIN
      U_ZC3 ON U_ZC.ID = U_ZC3.ID LEFT OUTER JOIN
      U_ZCStatus ON U_ZC.status = U_ZCStatus.statusValue
