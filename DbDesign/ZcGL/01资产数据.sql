IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'U_ZC')
	BEGIN
		DROP  Table U_ZC
	END
GO

CREATE TABLE U_ZC
(
	/* �������� */
	ID int identity(1,1) primary key not null,--�ʲ�ID	
	depart	nvarchar(50)	,			--���β���	
	zeren	nvarchar(50)	,			--������	
	danwei	nvarchar(50)	,			--��λ����	
	zhwd 	nvarchar(2) 	,			--�Ƿ�����ί��	
	num1	nvarchar(50)	,			--���	
	num2	nvarchar(50)	,			--������	
	bj		numeric(18,2)	,			--��ʼ����	
	lx1		numeric(18,2)	,			--��ʼ����Ϣ	
	lx2		numeric(18,2)	,			--��ʼ����Ϣ	
	lx3		numeric(18,2)	,			--��ʼ������Ϣ	
	sshy	nvarchar(50)	,			--������ҵ	
	quyu	nvarchar(50)	,			--����	
	zcbao 	nvarchar(50)	,			--���߰����	
	bank 	nvarchar(50)	,			--�к�	
	zhuang	nvarchar(50)	,			--ת�ü�	
	htnum	nvarchar(50)	,			--��ͬ���	
	time0	nvarchar(50)	,			--ת��ʱ��	
	fenlei 	nvarchar(50)	,			--�弶������	
	remark	nvarchar(200)	,			--��ע	
	status	nvarchar(50)	,			--�ʲ�״̬	
	
	/* �������� */
	userkind	nvarchar(500)	,		--�û��Զ������	
	zzjg	nvarchar(50)	,			--��֯��������	
	jysfzc 	nvarchar(50)	,			--��ҵ��Ӫ״��	
	clsj	nvarchar(50)	,			--����ʱ��	
	zczb	numeric(18,2)	,			--ע���ʱ�����	
	dqjj 	nvarchar(50)	,			--��������������״��	
	qygm 	nvarchar(50)	,			--��ҵ��ģ	
	dwdz	nvarchar(50)	,			--��λ��ַ	
	dwfzr	nvarchar(50)	,			--��λ������	
	qyjjxz 	nvarchar(50)	,			--��ҵ��������	
	yxzzzk 	nvarchar(50)	,			--ծ������Ч�ʲ�״��	
	xdri	nvarchar(50)	,			--�׽��Ŵ���ϵ����	
	dkffrq1	nvarchar(50)	,			--�����״η�������	
	jklsh	nvarchar(50)	,			--�����ˮ��	
	dkye	numeric(18,2)	,			--��������	
	dkffrq2	nvarchar(50)	,			--���������	
	htdqr	nvarchar(50)	,			--��ͬ������	
	zjycszje	nvarchar(50)	,		--���һ�����˽��	
	zydbfs	nvarchar(50)	,			--��Ҫ������ʽ	
	dbrwmc	nvarchar(50)	,			--������(��)����	
	yyldxt	nvarchar(50)	,			--һ��������̬	
	xcyqrq	nvarchar(50)	,			--�γ�����ʱ��	
	jrblsj	nvarchar(50)				--���벻��ʱ��	
)
GO

