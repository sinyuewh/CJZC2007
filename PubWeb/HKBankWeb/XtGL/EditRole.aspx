<%@ page language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_EditRole, App_Web_u3wuv1nz" title="修改角色信息" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="65%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="30%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">修改角色资料</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                角色名称：</td>
            <td>
                <asp:Label ID="role" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                角色说明：</td>
            <td>
                <asp:TextBox ID="remark" runat="server" Width="90%" TextMode="MultiLine" Height="60"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                角色用户：</td>
            <td>
                <asp:CheckBoxList ID="AllUsers" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                    Width="90%">
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
    <br />
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" /></div>
</asp:Content>
