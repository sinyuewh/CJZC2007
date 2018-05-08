IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_AJDZFileSeeLog')
	BEGIN
		DROP  Table DA_AJDZFileSeeLog
	END
GO

CREATE TABLE DA_AJDZFileSeeLog
(
    ID int identity(1,1) not null primary key,
	ajnum nvarchar(50) not null,
	time0 datetime not null,
	domen nvarchar(50),
	ajFile nvarchar(200),
	remark nvarchar(100)
)

