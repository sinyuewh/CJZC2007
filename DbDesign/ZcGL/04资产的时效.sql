IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCTime')
	BEGIN
		DROP  Table U_ZCTime
	END
GO

CREATE TABLE U_ZCTime
(
   	ID int identity(1,1) primary key not null,
	ZCID	int	,					--�ʲ�ID
	TimeName	nvarchar(50),		--ʱЧ����
	time0	DateTime,				--ʧЧʱ��
	tellday	int	,					--��ǰ��������
	remark	nvarchar(200)			--ʱЧ˵��
)
GO


