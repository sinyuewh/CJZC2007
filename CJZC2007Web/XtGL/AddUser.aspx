<%@ Page Language="C#" MasterPageFile="~/Common/Master/SystemAdmin.master" AutoEventWireup="true"
    CodeFile="AddUser.aspx.cs" Inherits="XtGL_AddUser" Title="增加新用户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">增加新用户</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                工 号：</td>
            <td>
                <asp:TextBox ID="num" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                姓 名：</td>
            <td>
                <asp:TextBox ID="sname" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                所在部门：</td>
            <td>
                <asp:DropDownList ID="depart" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td>
                职 务：</td>
            <td>
                <asp:TextBox ID="job" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
         <tr height="25">
            <td>
                直接主管：</td>
            <td>
                <asp:TextBox ID="leader" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                手机(小灵通)：</td>
            <td>
                <asp:TextBox ID="cell" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                电子邮件：</td>
            <td>
                <asp:TextBox ID="email" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" /></div>
</asp:Content>
