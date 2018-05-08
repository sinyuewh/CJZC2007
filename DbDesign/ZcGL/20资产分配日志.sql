IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZcFPLog')
	BEGIN
		DROP  Table U_ZcFPLog
	END
GO

CREATE TABLE U_ZcFPLog
(
	id int identity(1,1) primary key,
	zcid int,
	time1 datetime default getdate(),
	domen varchar(50) not null,
	zeren1 varchar(50),  --原责任人
	zeren2 varchar(50)   --新责任人
)

