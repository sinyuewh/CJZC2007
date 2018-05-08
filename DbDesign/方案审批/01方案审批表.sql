/* 方案审批
   金寿吉 
   2008年10月26日  */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_FASP')
	BEGIN
		DROP  Table U_FASP							--方案审批
	END
GO

CREATE TABLE U_FASP
(
	id int identity(1,1) primary key not null,		--数据ID
	zcid int,										--资产ID
	
	/* 处置方案申报表 */
	xmsbh		nvarchar(20),						--项目申报号
	num2		nvarchar(20),						--档案号
	xmmc		nvarchar(100),						--项目名称
	danwei		nvarchar(50),						--债务单位
	bzrmc		nvarchar(50),						--担保单位
	
	zwzg		nvarchar(50),						--债务人主管部门或区域
	zqsx		nvarchar(20),						--债权时效
	zclx		nvarchar(20),						--资产类型
	zcse		nvarchar(20),						--数额
	jiazhi		numeric(18,2),						--价值
	zqce		numeric(18,2),						--资产总额
	benjin		numeric(18,2),						--本金
	lixi		numeric(18,2),						--利息
	
	xmbj		nvarchar(1000),						--项目背景
	
	/* 项目处置方案 */
	czfs1		nvarchar(50),						--方案1处置方式
	jtfa1		nvarchar(200),						--方式1具体办法
	czjg1		numeric(18,2),						--方式1处置价格
	qcl1		nvarchar(50),						--方式1 清偿率
	czfs2		nvarchar(50),						--方案2处置方式
	jtfa2		nvarchar(200),						--方式2具体办法
	czjg2		numeric(18,2),						--方式2处置价格
	qcl2		nvarchar(50),						--方式2 清偿率
	
	xgsx		nvarchar(500),						--相关事项说明
	depart		nvarchar(50),						--承办部门
	zeren		nvarchar(50),						--经办人
	shijian1	datetime,							--经办时间
	bmren		varchar(50),						--部门负责人
	bmyj		varchar(200),						--部门负责人意见
	bmsj		datetime,							--部门负责人签字时间
	
	psren		varchar(50),						--评审员
	psyj		varchar(500),						--评审员意见
	pssj		datetime,							--评审时间
	
	/* 审核委员会意见 */
	hysj1		datetime,							--会议时间						
	hydd1		varchar(50),						--会议地点
	
	yingdao1	int,								--应到人数
	shidao1		int,								--实到人数
	quexi1		int,								--缺席人数
	
	zcr1		varchar(50),						--主持人
	ztwy1		nvarchar(50),						--赞同委员
	fdwy1		nvarchar(50),						--反对委员
	shyj1		nvarchar(200),						--审核意见
	shsj1		datetime,							--审核时间
	shren1		nvarchar(50),						--审核主任
	
	/* 决策委员会意见 */
	hysj2		datetime,							--会议时间	
	hydd2		varchar(50),						--会议地点
	dhwy2		varchar(100),						--到会委员
	zhr2		varchar(50),						--主持人
	ztwy2		nvarchar(50),						--赞同委员
	fdwy2		nvarchar(50),						--反对委员
	shyj2		nvarchar(200),						--审核意见
	shsj2		datetime,							--审核时间
	shren2		nvarchar(50),						--审核主任
	
	/* 以前的字段说明 */
	fsxzly		nvarchar(500),						--方式选择理由
	djyj		nvarchar(500),						--定价移居
	status		nvarchar(200),						--方案审批状态
	time0		datetime,							--录入时间
	spkind		nvarchar(2)							--审批kind
)
