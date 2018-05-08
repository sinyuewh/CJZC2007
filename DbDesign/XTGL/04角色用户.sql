  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_RoleUsers')
	BEGIN
		DROP  Table U_RoleUsers
	END
GO

CREATE TABLE U_RoleUsers
(
   	ID int identity(1,1) not null,
   	num nvarchar(50),     --序号
	Role nvarchar(50),    --角色名称
	sname nvarchar(50)	  --用户名称
	primary key(role,sname) 
)
GO