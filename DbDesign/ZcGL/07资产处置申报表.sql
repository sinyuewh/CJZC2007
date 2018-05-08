IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC2')
	BEGIN
		DROP  Table U_ZC2
	END
GO

CREATE TABLE U_ZC2
(
	ID int identity(1,1) primary key not null,
	ZCID	int,					--资产ID
	xmsbh	nvarchar(50),			--项目申报号
	xmbj	nvarchar(200),			--项目背景
	zclx	nvarchar(50),			--资产类型
	zcse	nvarchar(50),			--资产数额
	fsxzly	nvarchar(200),			--方式选择理由
	djyj	nvarchar(200),			--定价依据
	status	nvarchar(200),			--审批状态
)
GO

