IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCFilesBU')
	BEGIN
		DROP  Table U_ZCFilesBU
	END
GO

CREATE TABLE U_ZCFilesBU
(
   	ID int identity(1,1) primary key not null,	--附件ID
	TCID int not null ,							--调查ID
	zcID int not null,							--资产ID
	time0 datetime not null default getdate(),	--登记时间
	AttachFile	varchar(200) not null			--附件名称

)
GO

