 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_Depart')
	BEGIN
		DROP  Table U_Depart
	END
GO

CREATE TABLE U_Depart
(
   	ID int identity(1,1) not null,
   	num nvarchar(50), --���
	depart	nvarchar(50) primary key not null,--��������
	remark	varchar(100)		  --��ע
)
GO