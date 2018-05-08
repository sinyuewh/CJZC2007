<%@ Page Language="C#" MasterPageFile="~/Common/Master/CaiWu.master" AutoEventWireup="true"
    CodeFile="AddShouKuan.aspx.cs" Inherits="CaiWu_AddShouKuan" Title="增加资产收款单据" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">收 款 票 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="bill" runat="server"></asp:TextBox></td>
            <td>
                开票时间：</td>
            <td>
                <asp:TextBox ID="billtime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td>
                <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
            </td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="zeren" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                归还本金：</td>
            <td>
                <asp:TextBox ID="pbj" runat="server"></asp:TextBox>
            </td>
            <td>
                归还利息：</td>
            <td>
                <asp:TextBox ID="plx" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                开票员：</td>
            <td>
                <asp:Label ID="billmen" runat="server" Text=""></asp:Label>
            </td>
            <td>
                备注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="提交数据" OnClick="SaveDataClick" OnClientClick="javaScript:return confirm('警告：确定提交数据吗？');" />
            </td>
        </tr>
    </table>
</asp:Content>
