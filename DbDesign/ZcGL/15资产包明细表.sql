if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[U_ZCBAOInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[U_ZCBAOInfo]
GO

CREATE TABLE [dbo].[U_ZCBAOInfo] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ZCID] [int] NULL ,
	[BID] [int] NULL 
) ON [PRIMARY]
GO

 