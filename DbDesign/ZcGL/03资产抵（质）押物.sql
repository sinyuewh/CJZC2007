IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC11')
	BEGIN
		DROP  Table U_ZC11
	END
GO

CREATE TABLE U_ZC11
(
	ID int identity(1,1) primary key not null,
	ZCID	int,				--资产ID
	wplb	nvarchar(50),		--类别 字典（抵押物和质押物不同）
	wpsl	numeric(18,2),		--数量
	wpdw	nvarchar(50),		--单位
	wpjz	numeric(18,2),		--估值
	wpkind	nvarchar(2)			--分类 0、1 （0表示抵押物、1表示质押物）
)

