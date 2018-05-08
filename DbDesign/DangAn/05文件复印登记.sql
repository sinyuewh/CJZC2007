IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_Copy')
	BEGIN
		DROP  Table DA_Copy
	END
GO

CREATE TABLE DA_Copy
(
   
	ID int identity(1,1) not null,	
	bill	nvarchar(50),			--单据编号
	billtime	datetime,			--开票时间
	billmen	nvarchar(50),			--开票员
	zeren	nvarchar(50),			--复印人
	remark	nvarchar(200)			--备注
)
GO
