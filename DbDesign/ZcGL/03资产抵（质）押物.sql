IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC11')
	BEGIN
		DROP  Table U_ZC11
	END
GO

CREATE TABLE U_ZC11
(
	ID int identity(1,1) primary key not null,
	ZCID	int,				--�ʲ�ID
	wplb	nvarchar(50),		--��� �ֵ䣨��Ѻ�����Ѻ�ﲻͬ��
	wpsl	numeric(18,2),		--����
	wpdw	nvarchar(50),		--��λ
	wpjz	numeric(18,2),		--��ֵ
	wpkind	nvarchar(2)			--���� 0��1 ��0��ʾ��Ѻ�1��ʾ��Ѻ�
)

