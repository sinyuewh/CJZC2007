<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng2_EditZcCzfs, App_Web_zpfhjo5e" title="更新资产处置方式" stylesheettheme="CjzcWeb" %>
<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="85%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="35%" />
            <col bgcolor="white" align="left" width="65%" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    资 产 处 置 方 式 信 息
                </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                处置方式：
            </td>
            <td>
                <asp:TextBox ID="czfs" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                处置价格(万)：
            </td>
            <td>
                <asp:TextBox ID="czjg" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                处置损失(万)：
            </td>
            <td>
                <asp:TextBox ID="czss" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                清偿率(%)：
            </td>
            <td>
                <asp:TextBox ID="qcl" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                预计费用(万)：
            </td>
            <td>
                <asp:TextBox ID="yjfy" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="SaveDataClick" />
            </td>
        </tr>
    </table>
</asp:Content>