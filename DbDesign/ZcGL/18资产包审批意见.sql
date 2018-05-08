if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCBSP]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[U_ZCBSP]
GO

CREATE TABLE [dbo].[U_ZCBSP] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[CZID] [int] NULL ,
	[BID] [int] NULL ,
	[time0] [datetime] NULL ,
	[zeren] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[time1] [datetime] NULL ,
	[remark] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[kind] [nvarchar] (2) COLLATE Chinese_PRC_CI_AS NULL ,
	[PS] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[PSCount] [int] NULL ,
	[zx] [int] NULL 
) ON [PRIMARY]
GO

 