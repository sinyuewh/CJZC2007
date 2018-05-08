if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCBAO]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[U_ZCBAO]
GO

CREATE TABLE [dbo].[U_ZCBAO] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Bname] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Btime] [datetime] NULL ,
	[Bren] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Bjsf] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Bljsk] [numeric](18, 2) NULL ,
	[Bljzc] [numeric](18, 2) NULL ,
	[Bremark] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

 