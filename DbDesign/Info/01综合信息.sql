IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_Info')
	BEGIN
		DROP  Table ZX_Info
	END
GO

CREATE TABLE ZX_Info
(
   		ID int identity(1,1) not null,			--数据ID
		title	nvarchar(200),			--标题
		time0	datetime,				--登记时间
		remark	text	,				--正文(HTML格式)
		file1	nvarchar(200)	,		--附件1
		file2	nvarchar(200),			--附件2
		file3	nvarchar(200)	,		--附件3
		file4	nvarchar(200)	,		--附件4
		file5	nvarchar(200),			--附件5
		kind	nvarchar(10),			--类别
		readcount	int					--阅读次数
)
GO

