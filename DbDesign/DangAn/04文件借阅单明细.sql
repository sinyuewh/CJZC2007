IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_JieYuanBill')
	BEGIN
		DROP  Table DA_JieYuanBill
	END
GO

CREATE TABLE DA_JieYuanBill
(
   	ID int identity(1,1) not null,	
	bill	nvarchar(50),			--���ݱ��
	fileid	int						--�ļ�ID
)
GO

