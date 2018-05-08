<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="PiYue12.aspx.cs" Inherits="ZcMng2_PiYue12" Title="办公室审批" %>

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
        <tr height="25">
            <td>
                项目申报号：</td>
            <td colspan="3">
                <asp:TextBox ID="xmsbh" runat="server"></asp:TextBox>
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
                <asp:Button ID="Button2" runat="server" Text="提交意见" OnClick="Button2_Click" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="xmsbh"
                    Display="None" ErrorMessage="错误信息：项目申报号不能为空！"></asp:RequiredFieldValidator></td>
        </tr>
    </table>
</asp:Content>
