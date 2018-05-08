 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_RCAP')
	BEGIN
		DROP  Table ZX_RCAP
	END
GO

CREATE TABLE ZX_RCAP
(
   		ID int identity(1,1) not null,			--Êý¾ÝID
		time0	datetime default getdate(),	
		sname	varchar(50),					
		depart	varchar(50),					
		plantime	datetime,					
		endtime		datetime,					
		subject		varchar(50),				
		remark	text							
)
GO