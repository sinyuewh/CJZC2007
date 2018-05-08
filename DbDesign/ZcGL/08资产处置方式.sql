IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC21')
	BEGIN
		DROP  Table U_ZC21
	END
GO

CREATE TABLE U_ZC21
(
	ID int identity(1,1) primary key not null,
	CZID	int,					--�����걨��ID
	ZCID	int,					--�ʲ�ID
	czfs	varchar(50),			--���÷�ʽ
	czjg	numeric(18,2),			--���ü۸���
	czss	numeric(18,2),			--������ʧ����
	qcl		numeric(18,2),			--�峥�ʣ�����
	yjfy	numeric(18,2),			--Ԥ�Ʒ��ã���
)
GO

