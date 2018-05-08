 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCB21]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[U_ZCB21]
GO

CREATE TABLE [dbo].[U_ZCB21] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[CZID] [int] NULL ,
	[BID] [int] NULL ,
	[czfs] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[czjg] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[czss] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[qcl] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[yjfy] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO
