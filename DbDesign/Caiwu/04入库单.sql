 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_InStock')
	BEGIN
		DROP  Table CW_InStock
	END
GO

CREATE TABLE CW_InStock
(
	ID int identity(1,1) not null,					--����ID
	ZcID int not null references U_ZC(ID),			--�ʲ�ID
	
	bill  varchar(50) primary key,					--���ݱ��
	billtime datetime not null default getdate(),	--��Ʊʱ��
	billmen varchar(50) not null,					--��Ʊ��
	danwei	varchar(200) not null,					--��λ����
	zeren	varchar(50) not null,					--������
	remark	varchar(200) ,							--��ע
	
	checkmen varchar(50) ,							--�����
	checktime	datetime ,							--���ʱ��					--���ʱ��
)
GO