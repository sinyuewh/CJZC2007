  
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_InStockBill')
	BEGIN
		DROP  Table CW_InStockBill
	END
GO

/*--收款明细--*/
CREATE TABLE CW_InStockBill
(
	ID int identity(1,1) not null primary key,								--数据ID
	bill  varchar(50) not null references CW_InStock(bill),		--单据编号
	gkind	varchar(50) not null,	--物品分类
	gname	varchar(200) not null,	--物品名称
	ggxh	varchar(200) ,			--规格型号
	num		numeric(18,2) not null,	--数量
	price   numeric(18,2) not null,	--单价
	dw		varchar(20)	,			--单位
	remark	varchar(200)			--备注
)
GO