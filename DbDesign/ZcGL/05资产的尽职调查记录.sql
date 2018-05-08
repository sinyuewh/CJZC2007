IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_U_ZCTCBU')
	BEGIN
		DROP  Table U_U_ZCTCBU
	END
GO

CREATE TABLE U_U_ZCTCBU
(
   	ID int identity(1,1) primary key not null,	--资产调查ID
	ZcID int ,									--资产ID
	time0 datetime not null default getdate(),	--登记时间
	zeren varchar(50) not null,					--责任人
	remark varchar(200) not null,				--内容
	didian	varchar(100),						--地点
	jieguo	varchar(100),						--结果
	kind varchar(10) not null					--分为阅卷、下户、调查、取证
)
GO
