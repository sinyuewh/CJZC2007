IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC')
	BEGIN
		DROP  Table U_ZC
	END
GO

CREATE TABLE U_ZC
(
	/* 基本资料 */
	ID int identity(1,1) primary key not null,--资产ID	
	depart	nvarchar(50)	,			--责任部门	
	zeren	nvarchar(50)	,			--责任人	
	danwei	nvarchar(50)	,			--单位名称	
	zhwd 	nvarchar(2) 	,			--是否总行委贷	
	num1	nvarchar(50)	,			--编号	
	num2	nvarchar(50)	,			--档案号	
	bj		numeric(18,2)	,			--初始本金	
	lx1		numeric(18,2)	,			--初始表内息	
	lx2		numeric(18,2)	,			--初始表外息	
	lx3		numeric(18,2)	,			--初始孳生利息	
	sshy	nvarchar(50)	,			--所属行业	
	quyu	nvarchar(50)	,			--区域	
	zcbao 	nvarchar(50)	,			--政策包类别	
	bank 	nvarchar(50)	,			--行号	
	zhuang	nvarchar(50)	,			--转让价	
	htnum	nvarchar(50)	,			--合同编号	
	time0	nvarchar(50)	,			--转入时间	
	fenlei 	nvarchar(50)	,			--五级分类结果	
	remark	nvarchar(200)	,			--备注	
	status	nvarchar(50)	,			--资产状态	
	
	/* 附件资料 */
	userkind	nvarchar(500)	,		--用户自定义分类	
	zzjg	nvarchar(50)	,			--组织机构代码	
	jysfzc 	nvarchar(50)	,			--企业经营状况	
	clsj	nvarchar(50)	,			--成立时间	
	zczb	numeric(18,2)	,			--注册资本（万）	
	dqjj 	nvarchar(50)	,			--地区经济与信用状况	
	qygm 	nvarchar(50)	,			--企业规模	
	dwdz	nvarchar(50)	,			--单位地址	
	dwfzr	nvarchar(50)	,			--单位负责人	
	qyjjxz 	nvarchar(50)	,			--企业经济性质	
	yxzzzk 	nvarchar(50)	,			--债务人有效资产状况	
	xdri	nvarchar(50)	,			--首建信贷关系日期	
	dkffrq1	nvarchar(50)	,			--贷款首次发放日期	
	jklsh	nvarchar(50)	,			--借款流水号	
	dkye	numeric(18,2)	,			--贷款余额（万）	
	dkffrq2	nvarchar(50)	,			--贷款发放日期	
	htdqr	nvarchar(50)	,			--合同到期日	
	zjycszje	nvarchar(50)	,		--最近一次上账金额	
	zydbfs	nvarchar(50)	,			--主要担保方式	
	dbrwmc	nvarchar(50)	,			--担保人(物)名称	
	yyldxt	nvarchar(50)	,			--一逾两呆形态	
	xcyqrq	nvarchar(50)	,			--形成逾期时间	
	jrblsj	nvarchar(50)				--进入不良时间	
)
GO

