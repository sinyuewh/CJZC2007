<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatByStatusResult, App_Web_7icq5msn" title="按状态统计结果" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="80%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" width="30%"/>
            <col bgcolor="white" />
        </colgroup>
        <tr height="25">
            <td colspan="3" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 统 计 结 果</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                户数：</td>
            <td colspan="2">
                <asp:LinkButton ID="hs" CssClass="blue2" runat="server" OnClick="hs_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr height="25">
            <td>
                本息合：</td>
            <td>
                <asp:Label ID="bxh1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="bxh2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                还本息合：
            </td>
            <td>
                <asp:Label ID="hbxh1" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="hbxh2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                费用合计：</td>
            <td colspan="2">
                <asp:Label ID="fyhj" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td colspan="3" align="center">
                <input id="Button1" type="button" value="返 回" onclick="javascript:history.back()" class="but" />
            </td>
        </tr>
    </table>
</asp:Content>
