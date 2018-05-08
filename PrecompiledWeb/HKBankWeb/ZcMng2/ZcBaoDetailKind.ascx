<%@ control language="C#" autoeventwireup="true" inherits="ZcMng2_ZcBaoDetailKind, App_Web_0lscwnk0" %>
<table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr height="10">
        <td>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue1" CommandArgument="1"
                OnCommand="LinkButton1_Command">1.资产包基本资料</asp:LinkButton>
            |
            <%-- <asp:LinkButton ID="LinkButton9" runat="server" CssClass="blue1" CommandArgument="9"
                OnCommand="LinkButton1_Command">2.资产担保情况</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="blue1" CommandArgument="6"
                OnCommand="LinkButton1_Command">3.时效管理</asp:LinkButton>
            |--%>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="blue1" CommandArgument="2"
                OnCommand="LinkButton1_Command">2.尽职调查</asp:LinkButton>
            <%--    
            |
            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="blue1" CommandArgument="3"
                OnCommand="LinkButton1_Command">3.方案审批</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="blue1" CommandArgument="4"
                OnCommand="LinkButton1_Command">4.方案执行</asp:LinkButton>
            | --%>
            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="blue1" CommandArgument="5"
                OnCommand="LinkButton1_Command">3.财务数据</asp:LinkButton>
            |
            <%--<asp:LinkButton ID="LinkButton7" runat="server" CssClass="blue1" CommandArgument="7"
                OnCommand="LinkButton1_Command">8.抵债物资</asp:LinkButton>
            |--%>
            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="blue1" CommandArgument="6"
                OnCommand="LinkButton1_Command">4.所有附件</asp:LinkButton>
            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" ForeColor="Red">[最近项目申报表]</asp:HyperLink>
        </td>
    </tr>
</table>
