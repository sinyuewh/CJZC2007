<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng2_PiYue13, App_Web_qf07ssj0" title="审核委员会审批" stylesheettheme="CjzcWeb" %>
<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="75%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">发 表 批 阅 意 见 </font></strong>
            </td>
        </tr>
        <tr height="25" id="Tr1" runat="server">
            <td>
                意见选项：</td>
            <td colspan="3">
                <asp:RadioButtonList ID="piyue" runat="server" RepeatDirection="Horizontal" Width="235px">
                    <asp:ListItem>同意</asp:ListItem>
                    <asp:ListItem>不同意</asp:ListItem>
                    <asp:ListItem>送决策委员会</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 84px">
                批阅意见：</td>
            <td colspan="3">
                <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Height="74px" Width="94%"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="piyue"
                    Display="None" ErrorMessage="错误信息：请选择一个批阅意见！"></asp:RequiredFieldValidator>
                <asp:Button ID="Button2" runat="server" Text="提交意见" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
