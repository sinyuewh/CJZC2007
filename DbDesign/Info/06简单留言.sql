   IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_QuickTalk')
	BEGIN
		DROP  Table ZX_QuickTalk
	END
GO

CREATE TABLE ZX_QuickTalk
(
   		ID int identity(1,1) not null primary key,			--数据ID
		time0	datetime default getdate(),		--登记时间
		fmen	varchar(50),
		tmen	varchar(50),					--登记人
		isRead	varchar(1) default(0),
		remark	text							
)
GO