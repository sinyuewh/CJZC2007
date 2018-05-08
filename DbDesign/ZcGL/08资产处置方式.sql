IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC21')
	BEGIN
		DROP  Table U_ZC21
	END
GO

CREATE TABLE U_ZC21
(
	ID int identity(1,1) primary key not null,
	CZID	int,					--处置申报表ID
	ZCID	int,					--资产ID
	czfs	varchar(50),			--处置方式
	czjg	numeric(18,2),			--处置价格（万）
	czss	numeric(18,2),			--处置损失（万）
	qcl		numeric(18,2),			--清偿率（％）
	yjfy	numeric(18,2),			--预计费用（万）
)
GO

