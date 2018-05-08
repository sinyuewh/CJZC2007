IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCSS')
	BEGIN
		DROP  Table U_ZCSS
	END
GO

CREATE TABLE U_ZCSS
(
   
	ID int primary key not null,		--资产ID	
		
	/* 基本信息 */
	sszt	nvarchar(50),				--诉讼状态
	zxzt	nvarchar(50),				--执行状态
	sszl    nvarchar(500),				--诉讼资料
	
	/* 其他信息 */
	最后中断诉讼时效时间	nvarchar(50),
	诉讼时效到期日			nvarchar(50),
	最后中断保证时效时间	nvarchar(50),
	保证时效到期日			nvarchar(50),
	时效中断方式			nvarchar(50),
	执行时效到期日			nvarchar(50),
	查封时效到期日			nvarchar(50),
	查封文字描述			nvarchar(200),
	是否破产				nvarchar(50),
	宣告破产裁定书文号		nvarchar(50),
	破产审理法院			nvarchar(50),
	破产审理法官			nvarchar(50),
	破产债权申报时间		nvarchar(50),
	破产申报债权金额		nvarchar(50),
	破产终结日				nvarchar(50),
	终结破产裁定文书号      nvarchar(50),            
	分配财产金额			nvarchar(50),
	
	起诉时间				nvarchar(50),
	上诉时间				nvarchar(50),
	申请执行时间			nvarchar(50),
	一审法院				nvarchar(50),
	一审代理人				nvarchar(50),
	一审主审法官			nvarchar(50),
	联系方式1				nvarchar(50),
	一审代理律师			nvarchar(50),
	联系方式2				nvarchar(50),
	一审判决书文号			nvarchar(50),
	一审判决时间            nvarchar(50), 
	一审判决金额			nvarchar(50),
	二审法院				nvarchar(50),
	二审代理人				nvarchar(50),
	二审主审法官			nvarchar(50),
	联系方式3				nvarchar(50),
	二审代理律师			nvarchar(50),
	联系方式4				nvarchar(50),
	二审判决书文号			nvarchar(50),
	二审判决时间			nvarchar(50),
	二审判决金额			nvarchar(50),
	执行法院				nvarchar(50),               
	执行法官				nvarchar(50),
	联系方式5				nvarchar(50),
	备注					nvarchar(500)
)
Go

/*------------调整u_zctc表中的字段-----------------------*/
if not exists (select 1 from syscolumns where id=object_id('u_zctc') and name='remark1')
begin
	alter table u_zctc add remark1 nvarchar(2000)
end
go

if not exists (select 1 from syscolumns where id=object_id('u_zctc') and name='filename')
begin
	alter table u_zctc add filename nvarchar(200)
end
go

if not exists (select 1 from syscolumns where id=object_id('u_zctc') and name='filename1')
begin
	alter table u_zctc add filename1 nvarchar(200)
end
go

/*----------------视图数据的调整--------------------*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCTCBUView]') and OBJECTPROPERTY(id, N'IsView') = 1)
	drop view [dbo].[U_ZCTCBUView]
GO


CREATE VIEW dbo.U_ZCTCBUView
AS
  SELECT dbo.U_ZCTC.ID, dbo.U_ZCTC.ZcID, dbo.U_ZCTC.time0, dbo.U_ZCTC.zeren, 
      dbo.U_ZCTC.didian, dbo.U_ZCTC.jieguo, dbo.U_ZCTC.kind, 
      ISNULL(dbo.ZCFileView1.Fcount, 0) AS Fcount, dbo.U_ZCTC.status, 
      dbo.U_ZCTC.Bkind, dbo.U_ZCTC.remark, dbo.U_UserAndDepartVIEW.depart, 
      dbo.U_UserAndDepartVIEW.Dnum, dbo.U_ZCTC.remark1 remark2
FROM dbo.U_ZCTC INNER JOIN
      dbo.U_UserAndDepartVIEW ON 
      dbo.U_ZCTC.zeren = dbo.U_UserAndDepartVIEW.sname LEFT OUTER JOIN
      dbo.ZCFileView1 ON dbo.U_ZCTC.ID = dbo.ZCFileView1.TCID

