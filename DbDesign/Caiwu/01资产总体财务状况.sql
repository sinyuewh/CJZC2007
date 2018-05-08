IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC3')
	BEGIN
		DROP  Table U_ZC3
	END
GO

CREATE TABLE U_ZC3
(
	ID int primary key not null,		--�ʲ�ID	
	pbj		numeric(18,2),	--�黹����	
	plx		numeric(18,2),	--�黹��Ϣ
	fee1	numeric(18,2),	--�����
	fee2	numeric(18,2),	--��ʦ��
	fee3	numeric(18,2),	--���Ϸ�
	fee4	numeric(18,2),	--ִ�з�
	fee5	numeric(18,2),	--����Ѽ���ȫ��
	fee6	numeric(18,2),	--�ٲ÷�
	fee7	numeric(18,2),	--������
	fee8	numeric(18,2),	--��ҵ��
	fee9	numeric(18,2),	--��·��
	fee10	numeric(18,2),	--�д���
	fee11	numeric(18,2),	--��Ϣ��ѯ��
	fee12	numeric(18,2),	--��������
	
	fee13	numeric(18,2),	--Ԥ���ֶ�
	fee14	numeric(18,2),	--Ԥ���ֶ�
	fee15	numeric(18,2),	--Ԥ���ֶ�
	fee16	numeric(18,2),	--Ԥ���ֶ�
	fee17	numeric(18,2),	--Ԥ���ֶ�
	fee18	numeric(18,2),	--Ԥ���ֶ�
	fee19	numeric(18,2),	--Ԥ���ֶ�
	fee20	numeric(18,2)	--Ԥ���ֶ�
)

