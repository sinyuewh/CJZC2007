 /*
    ÊÓÍ¼ËµÃ÷£º
 
 */
 
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'UserRoleViews')
	BEGIN
		DROP  View UserRoleViews
	END
GO
 
 Create View UserRoleViews 
 As
 (
 
 SELECT dbo.U_Roles.ID, dbo.U_Roles.num, dbo.U_Roles.Role, dbo.U_RoleUsers.sname, 
      dbo.U_UserName.depart
FROM dbo.U_Roles INNER JOIN
      dbo.U_RoleUsers ON dbo.U_Roles.Role = dbo.U_RoleUsers.Role INNER JOIN
      dbo.U_UserName ON dbo.U_RoleUsers.sname = dbo.U_UserName.sname
      
  )