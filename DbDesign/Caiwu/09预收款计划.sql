IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CW_ShouKuanPlan')
	BEGIN
		DROP  Table CW_ShouKuanPlan
	END
GO

CREATE TABLE CW_ShouKuanPlan
(
	ID int identity(1,1) not null,					--����ID
	ZcID int not null references U_ZC(ID),	
	pbj	numeric(18,2),							--Ԥ���ջر���
	plx	numeric(18,2),							--Ԥ���ջ���Ϣ
	time0	datetime default getdate(),			--�տ�ʱ��
	remark	nvarchar(500)						--��ע

)

