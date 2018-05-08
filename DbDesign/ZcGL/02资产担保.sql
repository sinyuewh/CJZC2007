IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC1')
	BEGIN
		DROP  Table U_ZC1
	END
GO

CREATE TABLE U_ZC1
(
   	ID int primary key not null,		--�ʲ�ID	
	zwrhsgz	numeric(18,2),				--ծ���˻��չ�ֵ	
	bzrhsgz	numeric(18,2),				--��֤�˻��չ�ֵ
	qthsgz	numeric(18,2),				--�������չ���ֵ
	hssj	nvarchar(50),				--Ԥ�ƻ���ʱ��
	qsqk	nvarchar(200),				--��ծ���˻�����Ǳ�ڵĳ�ծ����ʷǢ�����
	remark	nvarchar(200),				--��ע
	
	/* ��֤����� */
	bzrmc	nvarchar(50),				--��֤����λ��������
	bzje	numeric(18,2),				--��֤���
	bzyx	nvarchar(2),				--��֤��Ч�� 
	bzcznl	nvarchar(50),				--��֤�˵ĳ�ծ����
	bzczyy	nvarchar(50),				--��֤�˵ĳ�ծ��Ը
	bzwxsm	nvarchar(200),				--��֤��Ч˵��
	Remark1	nvarchar(200),				--��֤����˵��
	
	/* �ʲ���Ѻ�� */
	qdza1	nvarchar(50),				--��Ѻ��ȡ���Ƿ�����ϰ�
	qdzayy1	nvarchar(200),				--��Ѻ��ȡ���ϰ�ԭ��
	czza1	nvarchar(50),				--��Ѻ�ﴦ���Ƿ�����ϰ�
	zzzayy1	nvarchar(200),				--��Ѻ�ﴦ���ϰ�ԭ��
	bxny1	nvarchar(50),				--��Ѻ���������
	klazfy	numeric(18,2),				--��Ѻ�￼�ǰ��÷ѽ��
	flyj1	nvarchar(50),				--��Ѻ�﷨�����
	dyhsgz1	numeric(18,2),				--��Ѻ����չ�ֵ
	Remark2	nvarchar(200),				--��Ѻ�ﲹ��˵��
	
	/* �ʲ���Ѻ�� */
	qdza2	nvarchar(50),				--��Ѻ��ȡ���Ƿ�����ϰ�
	qdzayy2	nvarchar(200),				--��Ѻ��ȡ���ϰ�ԭ��
	czza2	nvarchar(50),				--��Ѻ�ﴦ���Ƿ�����ϰ�
	zzzayy2	nvarchar(200),				--��Ѻ�ﴦ���ϰ�ԭ��
	bxny2	nvarchar(50),				--��Ѻ���������
	flyj2	nvarchar(50),				--��Ѻ�﷨�����
	dyhsgz2	numeric(18,2),				--��Ѻ����չ�ֵ
	Remark3	nvarchar(200)				--��Ѻ�ﲹ��˵��
)
GO
