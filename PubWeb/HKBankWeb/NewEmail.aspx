<%@ page language="C#" autoeventwireup="true" inherits="NewEmail, App_Web_k7qlrvw3" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新邮件提示</title>
    <base target="_self">
    </base>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="95%" align="center" border="0" cellspacing="1" cellpadding="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col width="30%" align="right" bgcolor="white" />
                    <col align="left" bgcolor="white" />
                </colgroup>
                <tr height="25">
                    <td colspan="2" align="center" bgcolor="#5d7b9d">
                        <strong><font color="#ffffff">新 邮 件 提 示</font></strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        发 件 人：
                    </td>
                    <td>
                        <asp:Label ID="from1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        发件时间：
                    </td>
                    <td>
                        <asp:Label ID="fromtime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        邮件主题：
                    </td>
                    <td>
                        <asp:Label ID="subject" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td colspan="2" width="100%" style="text-align: center">
                        <asp:Button ID="Button1" runat="server" Text="谢谢，我已知道" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
