<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyPass.aspx.cs" Inherits="XtGL_ModifyPass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改用户的登录密码</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    <br />
    <table width="90%" align="center">
        <colgroup>
            <col bgcolor=white  width="30%" align="right" />
            <col  bgcolor=white align=left />
        </colgroup>
        <tr height="22">
            <td>
            原密码：
            </td>
            <td>
                <asp:TextBox ID="pass1" runat="server" TextMode="password" Width="80%"></asp:TextBox>
            </td>
        </tr>
        <tr  height="22">
            <td>
            新密码：
            </td>
            <td>
             <asp:TextBox ID="pass2" runat="server" TextMode="password" Width="80%"></asp:TextBox>
            </td>
        </tr>
        <tr  height="22">
            <td>
            重复密码：
            </td>
            <td>
             <asp:TextBox ID="pass3" runat="server" TextMode="password" Width="80%"></asp:TextBox>
            </td>
        </tr>
    </table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="提 交" Width="100" OnClick="Button1_Click" />
    </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="错误：原密码不能为空！" ControlToValidate="pass1" Display="None"></asp:RequiredFieldValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pass2"
            Display="None" ErrorMessage="错误：新密码不能为空！"></asp:RequiredFieldValidator><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pass3"
            Display="None" ErrorMessage="错误：重复密码不能为空！"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="pass3"
            ControlToValidate="pass2" Display="None" ErrorMessage="错误：新密码两次输入不一致!"></asp:CompareValidator>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </form>
    <script language="javascript">
        if ("<%#User.Identity.Name%>"=="")
        {
           window.close();
        }
    </script>
</body>
</html>
