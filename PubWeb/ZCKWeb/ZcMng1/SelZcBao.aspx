<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_SelZcBao2, App_Web_-yo2hwel" title="资产打包" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">请 选 择 一 个 资 产 包 类 别</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：</td>
            <td>
                <asp:RadioButtonList ID="Bstatus" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Width="100%">
                </asp:RadioButtonList></td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="确定资产包名称" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
