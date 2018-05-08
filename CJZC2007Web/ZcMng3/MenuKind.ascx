<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuKind.ascx.cs" Inherits="ZcMng3_MenuKind" %>
<table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr height="10">
        <td>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:HyperLink ID="hyp1" runat="server">>>浏览相关资产详细情况</asp:HyperLink>
            |
            <asp:LinkButton ID="link1" runat="server" CssClass="blue1" CommandArgument="1"
                OnCommand="LinkButton1_Command">1.项目情况</asp:LinkButton>
            |
            <asp:LinkButton ID="link2" runat="server" CssClass="blue1" CommandArgument="2"
                OnCommand="LinkButton1_Command">2.处置方案</asp:LinkButton>
            <span id="editmenu" runat="server">
                |
                <asp:LinkButton ID="link5" runat="server" CssClass="blue1" CommandArgument="5"
                    OnCommand="LinkButton1_Command">3.方案审批情况</asp:LinkButton>
                |
                <asp:LinkButton ID="link6" runat="server" CssClass="blue1" CommandArgument="6"
                    OnCommand="LinkButton1_Command">4.方案执行情况</asp:LinkButton>
                |
                <asp:LinkButton ID="link3" runat="server" CssClass="blue1" CommandArgument="3"
                    OnCommand="LinkButton1_Command">5.审核委员会</asp:LinkButton>
                |
                <asp:LinkButton ID="link4" runat="server" CssClass="blue1" CommandArgument="4"
                    OnCommand="LinkButton1_Command">6.决策委员会</asp:LinkButton>
            </span>
        </td>
    </tr>
</table>
