IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC3')
	BEGIN
		DROP  Table U_ZC3
	END
GO

CREATE TABLE U_ZC3
(
	ID int primary key not null,		--资产ID	
	pbj		numeric(18,2),	--归还本金	
	plx		numeric(18,2),	--归还利息
	fee1	numeric(18,2),	--申请费
	fee2	numeric(18,2),	--律师费
	fee3	numeric(18,2),	--诉讼费
	fee4	numeric(18,2),	--执行费
	fee5	numeric(18,2),	--受理费及保全费
	fee6	numeric(18,2),	--仲裁费
	fee7	numeric(18,2),	--评估费
	fee8	numeric(18,2),	--物业费
	fee9	numeric(18,2),	--过路费
	fee10	numeric(18,2),	--招待费
	fee11	numeric(18,2),	--信息咨询费
	fee12	numeric(18,2),	--其他费用
	
	fee13	numeric(18,2),	--预留字段
	fee14	numeric(18,2),	--预留字段
	fee15	numeric(18,2),	--预留字段
	fee16	numeric(18,2),	--预留字段
	fee17	numeric(18,2),	--预留字段
	fee18	numeric(18,2),	--预留字段
	fee19	numeric(18,2),	--预留字段
	fee20	numeric(18,2)	--预留字段
)

