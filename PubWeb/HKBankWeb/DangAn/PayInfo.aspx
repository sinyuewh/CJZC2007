<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_PayInfo, App_Web_dq1vueyh" title="文件借阅归还" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">归 还 文 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                借阅单编号：</td>
            <td>
                <asp:Label ID="bill" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr height="25">
            <td>
                要求归还时间：</td>
            <td>
                <asp:Label ID="paytime" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                实际归还时间：</td>
            <td>
                <asp:TextBox ID="paytim1" runat="server"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />&nbsp;&nbsp
                &nbsp; &nbsp;
                <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
