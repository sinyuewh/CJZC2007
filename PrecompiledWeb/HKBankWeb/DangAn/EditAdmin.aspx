<%@ page title="编辑档案部门管理员" language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_EditAdmin, App_Web_widkftde" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">编 辑 档 案 部 门 管 理 员</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                序号：
            </td>
            <td>
                <asp:TextBox ID="num" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                部门：
            </td>
            <td>
                <asp:DropDownList ID="depart" runat ="server" AutoPostBack ="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                管理员：
            </td>
            <td style="height: 25px">
                <asp:DropDownList ID="sname" runat ="server">
                </asp:DropDownList>
            </td>
        </tr>
       
        <tr height="25">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="确定" />&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="返回" OnClientClick="location.href='DangAnDepartManageList.aspx';return false;" />
            </td>
        </tr>
    </table>
</asp:Content>
