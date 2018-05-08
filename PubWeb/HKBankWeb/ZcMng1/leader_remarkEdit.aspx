<%@ page language="C#" autoeventwireup="true" inherits="ZcMng1_leader_remarkEdit, App_Web_o8vl6oai" stylesheettheme="" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑资产日志评论</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 10; text-align: center">
        <asp:TextBox ID="leader_remark" runat="server" TextMode="MultiLine" Width="90%" Height="150px">
        </asp:TextBox>
        <br /><br />
        <asp:Button ID="button1" runat ="server" Text ="提 交" onclick="button1_Click" />
    </div>
    </form>
</body>
</html>
