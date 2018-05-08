 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_Pay1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CW_Pay1]
GO

CREATE TABLE [dbo].[CW_Pay1] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[BID] [int] NOT NULL ,
	[bill] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[billtime] [datetime] NULL ,
	[billmen] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Bname] [varchar] (200) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Bzeren] [varchar] (50) NULL ,
	[remark] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[checkmen] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[checktime] [datetime] NULL ,
	[fee1] [numeric](18, 2) NULL ,
	[fee2] [numeric](18, 2) NULL ,
	[fee3] [numeric](18, 2) NULL ,
	[fee4] [numeric](18, 2) NULL ,
	[fee5] [numeric](18, 2) NULL ,
	[fee6] [numeric](18, 2) NULL ,
	[fee7] [numeric](18, 2) NULL ,
	[fee8] [numeric](18, 2) NULL ,
	[fee9] [numeric](18, 2) NULL ,
	[fee10] [numeric](18, 2) NULL ,
	[fee11] [numeric](18, 2) NULL ,
	[fee12] [numeric](18, 2) NULL ,
	[fee13] [numeric](18, 2) NULL ,
	[fee14] [numeric](18, 2) NULL ,
	[fee15] [numeric](18, 2) NULL ,
	[fee16] [numeric](18, 2) NULL ,
	[fee17] [numeric](18, 2) NULL ,
	[fee18] [numeric](18, 2) NULL ,
	[fee19] [numeric](18, 2) NULL ,
	[fee20] [numeric](18, 2) NULL 
) ON [PRIMARY]
GO

