  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_Roles')
	BEGIN
		DROP  Table U_Roles
	END
GO

CREATE TABLE U_Roles
(
   	ID int identity(1,1) not null,
   	num nvarchar(50),     --ÐòºÅ
	Role nvarchar(50) primary key not null, --½ÇÉ«Ãû³Æ
	remark	varchar(100)   --±¸×¢
)
GO