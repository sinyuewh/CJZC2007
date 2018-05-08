IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'DA_Files')
	BEGIN
		DROP  Table DA_Files
	END
GO

CREATE TABLE DA_Files
(
   	ID int identity(1,1) not null,		
	ajnum	nvarchar(50),			--������
	fileno	nvarchar(50),			--�ĺ�
	title	nvarchar(200),			--����
	danwei	nvarchar(200),			--��λ
	depart	nvarchar(50),			--���β���
	zeren	nvarchar(50),			--������
	filenum	numeric(18,2),			--˳��
	filecount	int,				--�ļ�ҳ��
	beginPage	int,				--��ʼҳ
	endPage	int,					--����ҳ
	jyue	nvarchar(50),			--������
	jyuetime	DateTime,			--���ʱ��
	djtime	DateTime,				--�Ǽ�ʱ��
	dtmen	nvarchar(50)			--�Ǽ���
)
GO

