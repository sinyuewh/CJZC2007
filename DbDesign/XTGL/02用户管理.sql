IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_UserName')
	BEGIN
		DROP  Table U_UserName
	END
GO

CREATE TABLE U_UserName
(
   	ID int identity(1,1) not null,
   	num nvarchar(50), --序号
	sname nvarchar(50) primary key not null,--用户姓名（PK）
	depart	nvarchar(50) ,--所在部门
	job	nvarchar(50) ,--职务
	password nvarchar(50) not null, --登录密码
	cell nvarchar(50) ,--手机
	email nvarchar(200),--电子邮件
	login datetime,	--最近登录,
	leader nvarchar(50)
)
GO
