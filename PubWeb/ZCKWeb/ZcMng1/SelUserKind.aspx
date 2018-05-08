<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_SelUserKind, App_Web_-yo2hwel" title="选择用户定自由类别" stylesheettheme="CjzcWeb" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">请 选 择 一 个 或 多 个 用 户 自 定 义 类 别</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                用户自定义分类：</td>
            <td>
                <asp:RadioButtonList ID="userkind" runat="server"  RepeatColumns="2" Width="95%">
                </asp:RadioButtonList></td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="确定资产自定义分类" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
