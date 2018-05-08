  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'ZX_WorkLog')
	BEGIN
		DROP  Table ZX_WorkLog
	END
GO

CREATE TABLE ZX_WorkLog
(
   		ID int identity(1,1) not null,			--����ID
		time0	datetime default getdate(),		--�Ǽ�ʱ��
		sname	varchar(50),					--�Ǽ���
		depart	varchar(50),					--���ڲ���
		remark	text							--��ϸ�ճ̰���
)
GO