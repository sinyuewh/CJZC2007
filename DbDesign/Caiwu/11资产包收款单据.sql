if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CW_ShouKuan1]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CW_ShouKuan1]
GO

CREATE TABLE [dbo].[CW_ShouKuan1] (
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
	[pbj] [numeric](18, 2) NULL ,
	[plx] [numeric](18, 2) NULL 
) ON [PRIMARY]
GO

 