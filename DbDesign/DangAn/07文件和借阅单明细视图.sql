SELECT dbo.DA_Files.title, dbo.DA_JieYuanBill.*
FROM dbo.DA_Files INNER JOIN
      dbo.DA_JieYuanBill ON dbo.DA_Files.ID = dbo.DA_JieYuanBill.fileid