 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_AJDZFile')
	BEGIN
		DROP  Table DA_AJDZFile
	END
GO

CREATE TABLE DA_AJDZFile
(
   	ID int identity(1,1) not null primary key,			--数据ID
	ajnum	nvarchar(50),								--案卷编号
	time0	datetime,									--上传时间
	ljren	nvarchar(50),								--立卷人
	ajFile  nvarchar(200),								--案卷文件名
	ajTrueFile nvarchar(200),							--案卷真实的文件名
	remark nvarchar(200)								--备注
)
GO