<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_ZcZx, App_Web_pyuhrx5l" title="资产执行" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="85%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    <asp:Label ID="dckind" runat="server" Text=""></asp:Label>
                </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 84px">
                主要内容：</td>
            <td colspan="3">
                <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Height="74px" Width="94%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                地点：</td>
            <td>
                <asp:TextBox ID="didian" runat="server" Width="165px"></asp:TextBox>
            </td>
            <td>
                结果：</td>
            <td>
                <asp:TextBox ID="jieguo" runat="server" Width="169px"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button2" runat="server" Text="提交数据" OnClick="Button2_Click" />
                &nbsp;
                <asp:Button ID="Button1" runat="server" Text="取消返回" OnClick="Button1_Click" CausesValidation="False" /></td>
        </tr>
    </table>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="错误：主要内容栏目不能为空！" ControlToValidate="remark" Display="None"></asp:RequiredFieldValidator><asp:ValidationSummary
        ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>

