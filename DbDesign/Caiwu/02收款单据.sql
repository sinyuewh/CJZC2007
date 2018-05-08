 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_ShouKuan')
	BEGIN
		DROP  Table CW_ShouKuan
	END
GO

CREATE TABLE CW_ShouKuan
(
	ID int identity(1,1) not null,					--数据ID
	ZcID int not null references U_ZC(ID),			--资产ID
	
	bill  varchar(50) primary key,					--单据编号
	billtime datetime not null default getdate(),	--开票时间
	billmen varchar(50) not null,					--开票人
	danwei	varchar(200) not null,					--单位名称
	zeren	varchar(50) not null,					--责任人
	remark	varchar(200) ,							--备注
	
	checkmen varchar(50) ,							--审核人
	checktime	datetime ,							--审核时间	
	
	pbj   numeric(18,2) ,							--收回本金
	plx	  numeric(18,2)								--收回利息
)
GO

 