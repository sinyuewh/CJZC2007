IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_ShouKuanPlan')
	BEGIN
		DROP  Table CW_ShouKuanPlan
	END
GO

CREATE TABLE CW_ShouKuanPlan
(
	ID int identity(1,1) not null,					--数据ID
	ZcID int not null references U_ZC(ID),	
	pbj	numeric(18,2),							--预计收回本金
	plx	numeric(18,2),							--预计收回利息
	time0	datetime default getdate(),			--收款时间
	remark	nvarchar(500)						--备注

)

