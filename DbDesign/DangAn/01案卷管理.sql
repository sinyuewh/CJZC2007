IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_AnJuan')
	BEGIN
		DROP  Table DA_AnJuan
	END
GO

CREATE TABLE DA_AnJuan
(
   	ID int identity(1,1) not null,			--数据ID
	ajnum	nvarchar(50),					--案卷编号
	ajname	nvarchar(100),					--案卷名称
	time0	datetime,						--立卷时间
	ljren	nvarchar(50),					--立卷人
	ajkind	nvarchar(50),					--案卷分类
	remark	nvarchar(200),					--备注
	ajstatus	nvarchar(10),				--状态
	yjtime	datetime,						--移交时间
	yjdanwei	nvarchar(200),				--移交单位
	jsren	nvarchar(50)					--经手人
)
GO