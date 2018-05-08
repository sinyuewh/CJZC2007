IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_JieYuan')
	BEGIN
		DROP  Table DA_JieYuan
	END
GO

CREATE TABLE DA_JieYuan
(
   	ID int identity(1,1) not null,	
	bill	nvarchar(50),			--单据编号
	billtime	datetime,			--开票时间
	billmen	nvarchar(50),			--开票员
	zeren	nvarchar(50),			--借阅人
	paytime	DateTime,				--要求归还时间
	Paytime1	DateTime,			--实际归还时间
	remark	nvarchar(200)			--备注
)
GO


