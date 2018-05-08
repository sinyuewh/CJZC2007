  /*----------增加时效提醒日志-----------------*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_TimeLog')
	BEGIN
		DROP  Table U_TimeLog
	END
GO

CREATE TABLE U_TimeLog
(
	id int identity(1,1) primary key,				--ID
	Timeid int,									--时效id
	LogTime datetime ,							--提醒时间
	LogUser nvarchar(50)							--提醒用户
)
GO