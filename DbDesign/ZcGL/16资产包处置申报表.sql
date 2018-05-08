 if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCB2]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[U_ZCB2]
GO

CREATE TABLE [dbo].[U_ZCB2] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[BID] [int] NULL ,
	[xmsbh] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[xmbj] [nvarchar] (2000) COLLATE Chinese_PRC_CI_AS NULL ,
	[zclx] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[zcse] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[fsxzly] [nvarchar] (2000) COLLATE Chinese_PRC_CI_AS NULL ,
	[djyj] [nvarchar] (2000) COLLATE Chinese_PRC_CI_AS NULL ,
	[status] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[time0] [datetime] NULL 
) ON [PRIMARY]
GO