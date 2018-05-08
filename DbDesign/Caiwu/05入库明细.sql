  
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_InStockBill')
	BEGIN
		DROP  Table CW_InStockBill
	END
GO

/*--�տ���ϸ--*/
CREATE TABLE CW_InStockBill
(
	ID int identity(1,1) not null primary key,								--����ID
	bill  varchar(50) not null references CW_InStock(bill),		--���ݱ��
	gkind	varchar(50) not null,	--��Ʒ����
	gname	varchar(200) not null,	--��Ʒ����
	ggxh	varchar(200) ,			--����ͺ�
	num		numeric(18,2) not null,	--����
	price   numeric(18,2) not null,	--����
	dw		varchar(20)	,			--��λ
	remark	varchar(200)			--��ע
)
GO