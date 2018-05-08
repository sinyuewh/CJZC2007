    
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_StockBill')
	BEGIN
		DROP  Table CW_StockBill
	END
GO

/*--�տ���ϸ--*/
CREATE TABLE CW_StockBill
(
	ID int identity(1,1) not null primary key,	
	ZcID int not null references U_ZC(ID),			--�ʲ�ID							--����ID
	gkind	varchar(50) not null,					--��Ʒ����
	gname	varchar(200) not null,					--��Ʒ����
	ggxh	varchar(200) ,							--����ͺ�
	num		numeric(18,2) not null,					--����
	price	numeric(18,2),							--���Ƽ۸�
	dw		varchar(20)	,							--��λ
	remark	varchar(200),							--��ע
	
	inbill	varchar(200),							--��ⵥ���
	outbill varchar(2000)							--���ⵥ���
)
GO