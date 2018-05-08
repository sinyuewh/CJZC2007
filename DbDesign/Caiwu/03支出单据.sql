  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_Pay')
	BEGIN
		DROP  Table CW_Pay
	END
GO

CREATE TABLE CW_Pay
(
	ID int identity(1,1) not null,					--����ID
	ZcID int not null references U_ZC(ID),			--�ʲ�ID
	
	bill  varchar(50) primary key,				--���ݱ��
	billtime datetime not null default getdate(),	--��Ʊʱ��
	billmen varchar(50) not null,					--��Ʊ��
	danwei	varchar(200) not null,					--��λ����
	zeren	varchar(50) not null,					--������
	remark	varchar(200) ,							--��ע
	checkmen varchar(50) ,							--�����
	checktime	datetime ,							--���ʱ��
	
	fee1		numeric(18,2),
	fee2		numeric(18,2),
	fee3		numeric(18,2),
	fee4		numeric(18,2),
	fee5		numeric(18,2),
	fee6		numeric(18,2),
	fee7		numeric(18,2),
	fee8		numeric(18,2),
	fee9		numeric(18,2),
	fee10		numeric(18,2),
	fee11		numeric(18,2),
	fee12		numeric(18,2),
	fee13		numeric(18,2),
	fee14		numeric(18,2),
	fee15		numeric(18,2),
	fee16		numeric(18,2),
	fee17		numeric(18,2),
	fee18		numeric(18,2),
	fee19		numeric(18,2),
	fee20		numeric(18,2)
)
GO