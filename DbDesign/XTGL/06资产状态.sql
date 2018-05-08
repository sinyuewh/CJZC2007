IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZCStatus')
	BEGIN
		DROP  Table U_ZCStatus
	END
GO

CREATE TABLE U_ZCStatus
(
   	statusText nvarchar(50) not null,
	statusValue nvarchar(50) not null,
	num nvarchar(50)
)
GO
