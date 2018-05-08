IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_AnJuan')
	BEGIN
		DROP  Table DA_AnJuan
	END
GO

CREATE TABLE DA_AnJuan
(
   	ID int identity(1,1) not null,			--����ID
	ajnum	nvarchar(50),					--������
	ajname	nvarchar(100),					--��������
	time0	datetime,						--����ʱ��
	ljren	nvarchar(50),					--������
	ajkind	nvarchar(50),					--�������
	remark	nvarchar(200),					--��ע
	ajstatus	nvarchar(10),				--״̬
	yjtime	datetime,						--�ƽ�ʱ��
	yjdanwei	nvarchar(200),				--�ƽ���λ
	jsren	nvarchar(50)					--������
)
GO