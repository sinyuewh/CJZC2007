   IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_Item')
	BEGIN
		DROP  Table U_Item
	END
GO

CREATE TABLE U_Item
(
   	ID int identity(1,1) not null,
   	num nvarchar(50),     --���
	ItemText nvarchar(100) primary key not null,    --��Ŀ����
	ItemValue nvarchar(2000)	  --��Ŀ��ֵ
)
GO