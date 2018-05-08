IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCSPBU')
	BEGIN
		DROP  Table U_ZCSPBU
	END
GO

CREATE TABLE U_ZCSPBU
(
   	ID int identity(1,1) primary key not null,
	CZID	int,				--�����걨��ID
	ZCID	int,				--�ʲ�ID
	time0	DateTime,			--����ʱ��
	zeren	nvarchar(50),		--������
	time1	DateTime,			--����ʱ��
	remark	nvarchar(500),		--�������
	kind	nvarchar(2),		--��������
	PS	nvarchar(50),			--��������
	PSCount	int					--��������
)
GO
