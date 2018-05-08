IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_Info')
	BEGIN
		DROP  Table ZX_Info
	END
GO

CREATE TABLE ZX_Info
(
   		ID int identity(1,1) not null,			--����ID
		title	nvarchar(200),			--����
		time0	datetime,				--�Ǽ�ʱ��
		remark	text	,				--����(HTML��ʽ)
		file1	nvarchar(200)	,		--����1
		file2	nvarchar(200),			--����2
		file3	nvarchar(200)	,		--����3
		file4	nvarchar(200)	,		--����4
		file5	nvarchar(200),			--����5
		kind	nvarchar(10),			--���
		readcount	int					--�Ķ�����
)
GO

