IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_U_ZCTCBU')
	BEGIN
		DROP  Table U_U_ZCTCBU
	END
GO

CREATE TABLE U_U_ZCTCBU
(
   	ID int identity(1,1) primary key not null,	--�ʲ�����ID
	ZcID int ,									--�ʲ�ID
	time0 datetime not null default getdate(),	--�Ǽ�ʱ��
	zeren varchar(50) not null,					--������
	remark varchar(200) not null,				--����
	didian	varchar(100),						--�ص�
	jieguo	varchar(100),						--���
	kind varchar(10) not null					--��Ϊ�ľ��»������顢ȡ֤
)
GO
