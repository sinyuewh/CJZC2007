IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_InfoRead')
	BEGIN
		DROP  Table ZX_InfoRead
	END
GO

CREATE TABLE ZX_InfoRead
(
	ID int identity(1,1) not null,		
	infoid	int,					--��Ϣid
	ydren	nvarchar(50),			--�Ķ��û�
	ydtime	datetime,				--�Ķ�ʱ��
)
GO

