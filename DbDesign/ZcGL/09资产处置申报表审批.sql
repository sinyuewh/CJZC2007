IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCSPBU')
	BEGIN
		DROP  Table U_ZCSPBU
	END
GO

CREATE TABLE U_ZCSPBU
(
   	ID int identity(1,1) primary key not null,
	CZID	int,				--处置申报表ID
	ZCID	int,				--资产ID
	time0	DateTime,			--发出时间
	zeren	nvarchar(50),		--审批人
	time1	DateTime,			--审批时间
	remark	nvarchar(500),		--审批意见
	kind	nvarchar(2),		--审批分类
	PS	nvarchar(50),			--审批决定
	PSCount	int					--审批次数
)
GO
