 /*----------增加失效控制类别-----------------*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_TimeType')
	BEGIN
		DROP  Table U_TimeType
	END
GO

CREATE TABLE U_TimeType
(
	num int not null ,								--序号
	TimeTypeCode nvarchar(50) not null primary key,	--时效类别
	TimeTypeName nvarchar(50) not null,				--时效类别
	Remark nvarchar(500)							--备注
)
GO

 /*----------增加失效类别明细-----------------*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_TimeTypeDetail')
	BEGIN
		DROP  Table U_TimeTypeDetail
	END
GO

CREATE TABLE U_TimeTypeDetail
(
	num int not null ,
	id int identity(1,1) primary key,				--ID
	TimeTypeCode nvarchar(50) not null ,			--时效类别
	day1 int not null,								--开始天数
	day2 int not null,								--失效天数
	TimeTypekind int not null						--时效提醒（0--每月1次 1--每周1次 2--每天1次）
)
GO


