IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC2')
	BEGIN
		DROP  Table U_ZC2
	END
GO

CREATE TABLE U_ZC2
(
	ID int identity(1,1) primary key not null,
	ZCID	int,					--�ʲ�ID
	xmsbh	nvarchar(50),			--��Ŀ�걨��
	xmbj	nvarchar(200),			--��Ŀ����
	zclx	nvarchar(50),			--�ʲ�����
	zcse	nvarchar(50),			--�ʲ�����
	fsxzly	nvarchar(200),			--��ʽѡ������
	djyj	nvarchar(200),			--��������
	status	nvarchar(200),			--����״̬
)
GO

