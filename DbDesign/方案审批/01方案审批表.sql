/* ��������
   ���ټ� 
   2008��10��26��  */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_FASP')
	BEGIN
		DROP  Table U_FASP							--��������
	END
GO

CREATE TABLE U_FASP
(
	id int identity(1,1) primary key not null,		--����ID
	zcid int,										--�ʲ�ID
	
	/* ���÷����걨�� */
	xmsbh		nvarchar(20),						--��Ŀ�걨��
	num2		nvarchar(20),						--������
	xmmc		nvarchar(100),						--��Ŀ����
	danwei		nvarchar(50),						--ծ��λ
	bzrmc		nvarchar(50),						--������λ
	
	zwzg		nvarchar(50),						--ծ�������ܲ��Ż�����
	zqsx		nvarchar(20),						--ծȨʱЧ
	zclx		nvarchar(20),						--�ʲ�����
	zcse		nvarchar(20),						--����
	jiazhi		numeric(18,2),						--��ֵ
	zqce		numeric(18,2),						--�ʲ��ܶ�
	benjin		numeric(18,2),						--����
	lixi		numeric(18,2),						--��Ϣ
	
	xmbj		nvarchar(1000),						--��Ŀ����
	
	/* ��Ŀ���÷��� */
	czfs1		nvarchar(50),						--����1���÷�ʽ
	jtfa1		nvarchar(200),						--��ʽ1����취
	czjg1		numeric(18,2),						--��ʽ1���ü۸�
	qcl1		nvarchar(50),						--��ʽ1 �峥��
	czfs2		nvarchar(50),						--����2���÷�ʽ
	jtfa2		nvarchar(200),						--��ʽ2����취
	czjg2		numeric(18,2),						--��ʽ2���ü۸�
	qcl2		nvarchar(50),						--��ʽ2 �峥��
	
	xgsx		nvarchar(500),						--�������˵��
	depart		nvarchar(50),						--�а첿��
	zeren		nvarchar(50),						--������
	shijian1	datetime,							--����ʱ��
	bmren		varchar(50),						--���Ÿ�����
	bmyj		varchar(200),						--���Ÿ��������
	bmsj		datetime,							--���Ÿ�����ǩ��ʱ��
	
	psren		varchar(50),						--����Ա
	psyj		varchar(500),						--����Ա���
	pssj		datetime,							--����ʱ��
	
	/* ���ίԱ����� */
	hysj1		datetime,							--����ʱ��						
	hydd1		varchar(50),						--����ص�
	
	yingdao1	int,								--Ӧ������
	shidao1		int,								--ʵ������
	quexi1		int,								--ȱϯ����
	
	zcr1		varchar(50),						--������
	ztwy1		nvarchar(50),						--��ͬίԱ
	fdwy1		nvarchar(50),						--����ίԱ
	shyj1		nvarchar(200),						--������
	shsj1		datetime,							--���ʱ��
	shren1		nvarchar(50),						--�������
	
	/* ����ίԱ����� */
	hysj2		datetime,							--����ʱ��	
	hydd2		varchar(50),						--����ص�
	dhwy2		varchar(100),						--����ίԱ
	zhr2		varchar(50),						--������
	ztwy2		nvarchar(50),						--��ͬίԱ
	fdwy2		nvarchar(50),						--����ίԱ
	shyj2		nvarchar(200),						--������
	shsj2		datetime,							--���ʱ��
	shren2		nvarchar(50),						--�������
	
	/* ��ǰ���ֶ�˵�� */
	fsxzly		nvarchar(500),						--��ʽѡ������
	djyj		nvarchar(500),						--�����ƾ�
	status		nvarchar(200),						--��������״̬
	time0		datetime,							--¼��ʱ��
	spkind		nvarchar(2)							--����kind
)
