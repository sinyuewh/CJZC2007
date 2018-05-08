  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_WorkLog')
	BEGIN
		DROP  Table ZX_WorkLog
	END
GO

CREATE TABLE ZX_WorkLog
(
   		ID int identity(1,1) not null,			--数据ID
		time0	datetime default getdate(),		--登记时间
		sname	varchar(50),					--登记人
		depart	varchar(50),					--所在部门
		remark	text							--详细日程安排
)
GO