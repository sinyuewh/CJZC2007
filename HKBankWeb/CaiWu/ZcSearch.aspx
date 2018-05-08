<%@ Page Language="C#" MasterPageFile="~/Common/Master/CaiWu.master" AutoEventWireup="true"
    CodeFile="ZcSearch.aspx.cs" Inherits="CaiWu_CaiWuIndex" Title="日常业务" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 资 产 检 索 条 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td>
                <asp:TextBox ID="danwei" runat="server" Width="200" /></td>
        </tr>
        <tr height="25">
            <td>
                政策包类别：</td>
            <td>
                <asp:RadioButtonList ID="zcbao" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:RadioButtonList ID="depart" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                    AutoPostBack="true" OnSelectedIndexChanged="depart_SelectedIndexChanged">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                责 任 人：</td>
            <td>
                <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="6">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="25">
            <td>
                档案编号：</td>
            <td>
                <asp:TextBox ID="num2" runat="server" Width="200" /></td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="查询资产" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
