  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_Pay')
	BEGIN
		DROP  Table CW_Pay
	END
GO

CREATE TABLE CW_Pay
(
	ID int identity(1,1) not null,					--数据ID
	ZcID int not null references U_ZC(ID),			--资产ID
	
	bill  varchar(50) primary key,				--单据编号
	billtime datetime not null default getdate(),	--开票时间
	billmen varchar(50) not null,					--开票人
	danwei	varchar(200) not null,					--单位名称
	zeren	varchar(50) not null,					--责任人
	remark	varchar(200) ,							--备注
	checkmen varchar(50) ,							--审核人
	checktime	datetime ,							--审核时间
	
	fee1		numeric(18,2),
	fee2		numeric(18,2),
	fee3		numeric(18,2),
	fee4		numeric(18,2),
	fee5		numeric(18,2),
	fee6		numeric(18,2),
	fee7		numeric(18,2),
	fee8		numeric(18,2),
	fee9		numeric(18,2),
	fee10		numeric(18,2),
	fee11		numeric(18,2),
	fee12		numeric(18,2),
	fee13		numeric(18,2),
	fee14		numeric(18,2),
	fee15		numeric(18,2),
	fee16		numeric(18,2),
	fee17		numeric(18,2),
	fee18		numeric(18,2),
	fee19		numeric(18,2),
	fee20		numeric(18,2)
)
GO