<%@ Page Language="C#" MasterPageFile="~/Common/Master/SystemAdmin.master" AutoEventWireup="true"
    CodeFile="AddDepart.aspx.cs" Inherits="XtGL_AddDepart" Title="增加新部门" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">增加新部门</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                部门编号：</td>
            <td>
                <asp:TextBox ID="num" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                部门名称：</td>
            <td>
                <asp:TextBox ID="depart" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                备 注：</td>
            <td>
                <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" Height="60" Width="90%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" /></div>
</asp:Content>
