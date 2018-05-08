IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC1')
	BEGIN
		DROP  Table U_ZC1
	END
GO

CREATE TABLE U_ZC1
(
   	ID int primary key not null,		--资产ID	
	zwrhsgz	numeric(18,2),				--债务人回收估值	
	bzrhsgz	numeric(18,2),				--保证人回收估值
	qthsgz	numeric(18,2),				--其他回收贡献值
	hssj	nvarchar(50),				--预计回收时间
	qsqk	nvarchar(200),				--与债务人或其他潜在的偿债方历史洽商情况
	remark	nvarchar(200),				--备注
	
	/* 保证人情况 */
	bzrmc	nvarchar(50),				--保证（单位）人名称
	bzje	numeric(18,2),				--保证金额
	bzyx	nvarchar(2),				--保证有效性 
	bzcznl	nvarchar(50),				--保证人的偿债能力
	bzczyy	nvarchar(50),				--保证人的偿债意愿
	bzwxsm	nvarchar(200),				--保证无效说明
	Remark1	nvarchar(200),				--保证补充说明
	
	/* 资产抵押物 */
	qdza1	nvarchar(50),				--抵押物取得是否存在障碍
	qdzayy1	nvarchar(200),				--抵押物取得障碍原因
	czza1	nvarchar(50),				--抵押物处置是否存在障碍
	zzzayy1	nvarchar(200),				--抵押物处置障碍原因
	bxny1	nvarchar(50),				--抵押物变现难易
	klazfy	numeric(18,2),				--抵押物考虑安置费金额
	flyj1	nvarchar(50),				--抵押物法律意见
	dyhsgz1	numeric(18,2),				--抵押物回收估值
	Remark2	nvarchar(200),				--抵押物补充说明
	
	/* 资产质押物 */
	qdza2	nvarchar(50),				--质押物取得是否存在障碍
	qdzayy2	nvarchar(200),				--质押物取得障碍原因
	czza2	nvarchar(50),				--质押物处置是否存在障碍
	zzzayy2	nvarchar(200),				--质押物处置障碍原因
	bxny2	nvarchar(50),				--质押物变现难易
	flyj2	nvarchar(50),				--质押物法律意见
	dyhsgz2	numeric(18,2),				--质押物回收估值
	Remark3	nvarchar(200)				--质押物补充说明
)
GO
