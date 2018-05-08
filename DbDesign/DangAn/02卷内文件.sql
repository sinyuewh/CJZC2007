IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_Files')
	BEGIN
		DROP  Table DA_Files
	END
GO

CREATE TABLE DA_Files
(
   	ID int identity(1,1) not null,		
	ajnum	nvarchar(50),			--案卷编号
	fileno	nvarchar(50),			--文号
	title	nvarchar(200),			--标题
	danwei	nvarchar(200),			--单位
	depart	nvarchar(50),			--责任部门
	zeren	nvarchar(50),			--责任人
	filenum	numeric(18,2),			--顺序
	filecount	int,				--文件页数
	beginPage	int,				--开始页
	endPage	int,					--结束页
	jyue	nvarchar(50),			--借阅人
	jyuetime	DateTime,			--借出时间
	djtime	DateTime,				--登记时间
	dtmen	nvarchar(50)			--登记人
)
GO

