   IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_Item')
	BEGIN
		DROP  Table U_Item
	END
GO

CREATE TABLE U_Item
(
   	ID int identity(1,1) not null,
   	num nvarchar(50),     --序号
	ItemText nvarchar(100) primary key not null,    --条目名称
	ItemValue nvarchar(2000)	  --条目的值
)
GO