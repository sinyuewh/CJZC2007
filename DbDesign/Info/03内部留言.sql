IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_Email')
	BEGIN
		DROP  Table ZX_Email
	END
GO

CREATE TABLE ZX_Email
(
   	ID int identity(1,1) not null,	
	title	nvarchar(200),		--����
	time0	datetime,			--����ʱ��
	remark	text,				--����(HTML��ʽ)
	file1	nvarchar(200),		--����1
	file2	nvarchar(200),		--����2
	file3	nvarchar(200),		--����3
	file4	nvarchar(200),		--����4
	file5	nvarchar(200),		--����5
	from1	nvarchar(20),		--������
	to1		nvarchar(20),		--�ռ���
	fdel	nvarchar(2),		--������ɾ��
	tdel	nvarchar(2),		--�ռ���ɾ��
	readcount	nvarchar(1)		--�Ķ�
)
GO
