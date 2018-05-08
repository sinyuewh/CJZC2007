<%@ page language="C#" autoeventwireup="true" inherits="Info_WriteHuiZhi, App_Web_lh9kwmkt" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提交审阅意见</title>
    <base target="_self"></base>
</head>
<body style="background-color:White">
    <form id="form1" runat="server">
        <div style="padding:15px;">
            <table width="95%" align="left">
                <tr>
                    <td align="left">
                        <asp:TextBox ID="TextBox1" runat="server" Height="130px" TextMode="MultiLine" Width="95%">OK，我已知道这个事。</asp:TextBox><br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="提交审阅意见" OnClick="Button1_Click" />&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            Display="None" ErrorMessage="错误信息：请输入审阅意见！"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph"
                            ShowMessageBox="True" ShowSummary="False" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
