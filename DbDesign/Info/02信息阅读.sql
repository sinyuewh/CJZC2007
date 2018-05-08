IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_InfoRead')
	BEGIN
		DROP  Table ZX_InfoRead
	END
GO

CREATE TABLE ZX_InfoRead
(
	ID int identity(1,1) not null,		
	infoid	int,					--信息id
	ydren	nvarchar(50),			--阅读用户
	ydtime	datetime,				--阅读时间
)
GO

