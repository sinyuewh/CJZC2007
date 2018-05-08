IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_UserName')
	BEGIN
		DROP  Table U_UserName
	END
GO

CREATE TABLE U_UserName
(
   	ID int identity(1,1) not null,
   	num nvarchar(50), --���
	sname nvarchar(50) primary key not null,--�û�������PK��
	depart	nvarchar(50) ,--���ڲ���
	job	nvarchar(50) ,--ְ��
	password nvarchar(50) not null, --��¼����
	cell nvarchar(50) ,--�ֻ�
	email nvarchar(200),--�����ʼ�
	login datetime,	--�����¼,
	leader nvarchar(50)
)
GO
