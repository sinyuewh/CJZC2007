IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_Copy')
	BEGIN
		DROP  Table DA_Copy
	END
GO

CREATE TABLE DA_Copy
(
   
	ID int identity(1,1) not null,	
	bill	nvarchar(50),			--���ݱ��
	billtime	datetime,			--��Ʊʱ��
	billmen	nvarchar(50),			--��ƱԱ
	zeren	nvarchar(50),			--��ӡ��
	remark	nvarchar(200)			--��ע
)
GO
