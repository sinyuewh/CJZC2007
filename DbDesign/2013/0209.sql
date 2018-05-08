IF not EXISTS (SELECT * FROM u_roles WHERE role = '法律顾问')
begin
	insert into u_roles(num,role,remark) 
	values(18,'法律顾问','法律顾问角色') 
end
GO


/*----------法律顾问权限-----------------*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_LawZC')
	BEGIN
		DROP  Table U_LawZC
	END
GO

CREATE TABLE U_LawZC
(
	ID int identity(1,1) not null primary key,		--数据ID
	sname nvarchar(50) not null,					--资产责任人
	kind nvarchar(50) not null,						--资产类型
	dotime datetime not null default getdate(),		--操作时间
	checkmen varchar(50) 							--操作人
)
GO

/*------------调整u_zctc表中的字段-----------------------*/
if not exists (select 1 from syscolumns where id=object_id('u_zctc') and name='leader_remark')
begin
	alter table u_zctc add leader_remark nvarchar(2000)
end
go

if not exists (select 1 from syscolumns where id=object_id('u_zctc') and name='leader_name')
begin
	alter table u_zctc add leader_name nvarchar(50)
end
go

if not exists (select 1 from syscolumns where id=object_id('u_zctc') and name='leader_time')
begin
	alter table u_zctc add leader_time datetime
end
go