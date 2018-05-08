<%@ Page Language="C#" MasterPageFile="~/Common/Master/CaiWu.master" AutoEventWireup="true" 
CodeFile="ZcBaoBillSearch.aspx.cs" Inherits="CaiWu_ZcBaoBillSearch" Title="资产包单据浏览" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 单 据 的 检 索 条 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据的类别：</td>
            <td>
                <asp:RadioButtonList ID="billkind" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                    <asp:ListItem Selected="True" Value="0">收款单据</asp:ListItem>
                    <asp:ListItem Value="1">支出单据</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：</td>
            <td>
                <asp:TextBox ID="bname" runat="server" Width="244px" /></td>
        </tr>
        <tr height="25">
            <td>
                责 任 人：</td>
            <td>
                <asp:TextBox ID="bzeren" runat="server" Width="244px" /></td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="billnum" runat="server" Width="244px" /></td>
        </tr>
        <tr height="25">
            <td>
                开票时间：</td>
            <td>
                <asp:TextBox ID="time1" runat="server" Width="109px" />
                至
                <asp:TextBox ID="time2" runat="server" Width="108px" /></td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="查询单据" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

