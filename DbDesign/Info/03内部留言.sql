IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_Email')
	BEGIN
		DROP  Table ZX_Email
	END
GO

CREATE TABLE ZX_Email
(
   	ID int identity(1,1) not null,	
	title	nvarchar(200),		--标题
	time0	datetime,			--发出时间
	remark	text,				--正文(HTML格式)
	file1	nvarchar(200),		--附件1
	file2	nvarchar(200),		--附件2
	file3	nvarchar(200),		--附件3
	file4	nvarchar(200),		--附件4
	file5	nvarchar(200),		--附件5
	from1	nvarchar(20),		--发件人
	to1		nvarchar(20),		--收件人
	fdel	nvarchar(2),		--发件人删除
	tdel	nvarchar(2),		--收件人删除
	readcount	nvarchar(1)		--阅读
)
GO
