IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCTime')
	BEGIN
		DROP  Table U_ZCTime
	END
GO

CREATE TABLE U_ZCTime
(
   	ID int identity(1,1) primary key not null,
	ZCID	int	,					--资产ID
	TimeName	nvarchar(50),		--时效名称
	time0	DateTime,				--失效时间
	tellday	int	,					--提前警告天数
	remark	nvarchar(200)			--时效说明
)
GO


