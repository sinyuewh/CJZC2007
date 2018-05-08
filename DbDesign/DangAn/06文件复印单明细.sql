IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_CopyBill')
	BEGIN
		DROP  Table DA_CopyBill
	END
GO

CREATE TABLE DA_CopyBill
(
   	ID int identity(1,1) not null,	
	bill	nvarchar(50),			--���ݱ��
	fileid	int not null,
	copycount int not null
)
GO

