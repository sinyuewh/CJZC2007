IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_JieYuan')
	BEGIN
		DROP  Table DA_JieYuan
	END
GO

CREATE TABLE DA_JieYuan
(
   	ID int identity(1,1) not null,	
	bill	nvarchar(50),			--���ݱ��
	billtime	datetime,			--��Ʊʱ��
	billmen	nvarchar(50),			--��ƱԱ
	zeren	nvarchar(50),			--������
	paytime	DateTime,				--Ҫ��黹ʱ��
	Paytime1	DateTime,			--ʵ�ʹ黹ʱ��
	remark	nvarchar(200)			--��ע
)
GO


