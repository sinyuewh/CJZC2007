    
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_StockBill')
	BEGIN
		DROP  Table CW_StockBill
	END
GO

/*--收款明细--*/
CREATE TABLE CW_StockBill
(
	ID int identity(1,1) not null primary key,	
	ZcID int not null references U_ZC(ID),			--资产ID							--数据ID
	gkind	varchar(50) not null,					--物品分类
	gname	varchar(200) not null,					--物品名称
	ggxh	varchar(200) ,							--规格型号
	num		numeric(18,2) not null,					--数量
	price	numeric(18,2),							--估计价格
	dw		varchar(20)	,							--单位
	remark	varchar(200),							--备注
	
	inbill	varchar(200),							--入库单编号
	outbill varchar(2000)							--出库单编号
)
GO