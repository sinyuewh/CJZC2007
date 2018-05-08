<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_SelZeRen, App_Web_o8vl6oai" title="选择资产责任人" stylesheettheme="CjzcWeb" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">选 择 资 产 责 任 人</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产责任人：</td>
            <td>
                <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="下一步>>" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
