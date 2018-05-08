  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_JyBill')
	BEGIN
		DROP  Table DA_JyBill
	END
GO

CREATE TABLE DA_JyBill
(
   	ID int identity(1,1) not null primary key,			--数据ID
	ajnum	nvarchar(50),								--案卷编号
	time0	datetime,									--申请时间
	borrow	nvarchar(50),								--申请人
	time1   datetime,									--截止日期
	checkman nvarchar(50),								--审批人
	checktime datetime,									--审批时间
	remark nvarchar(200),								--备注
	status nvarchar(2)									--状态
)
GO