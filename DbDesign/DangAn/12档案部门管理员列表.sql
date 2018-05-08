 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_DepartDangAnAdminUsers')
	BEGIN
		DROP  Table U_DepartDangAnAdminUsers
	END
GO

CREATE TABLE U_DepartDangAnAdminUsers
(
   	ID int identity(1,1) not null,
   	num nvarchar(50),     --序号
	depart nvarchar(50),  --部门名称
	sname nvarchar(50)	  --用户名称
	primary key(depart,sname) 
)
GO