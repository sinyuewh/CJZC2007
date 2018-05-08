   IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_QuickTalk')
	BEGIN
		DROP  Table ZX_QuickTalk
	END
GO

CREATE TABLE ZX_QuickTalk
(
   		ID int identity(1,1) not null primary key,			--����ID
		time0	datetime default getdate(),		--�Ǽ�ʱ��
		fmen	varchar(50),
		tmen	varchar(50),					--�Ǽ���
		isRead	varchar(1) default(0),
		remark	text							
)
GO