IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCFilesBU')
	BEGIN
		DROP  Table U_ZCFilesBU
	END
GO

CREATE TABLE U_ZCFilesBU
(
   	ID int identity(1,1) primary key not null,	--����ID
	TCID int not null ,							--����ID
	zcID int not null,							--�ʲ�ID
	time0 datetime not null default getdate(),	--�Ǽ�ʱ��
	AttachFile	varchar(200) not null			--��������

)
GO

