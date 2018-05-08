<%@ page language="C#" autoeventwireup="true" inherits="ZcMng3_Upgrade, App_Web_k7qlrvw3" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据升级用</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp;<br />
        &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="调整U_ZC2的数据" OnClick="Button1_Click" /><br />
        <br />
        <br />
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="U_ZC21的数据导入U_ZC2" OnClick="Button2_Click" /><br />
        <br />
        <br />
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="增加评审员的处理意见" OnClick="Button3_Click" /></div>
    </form>
</body>
</html>
