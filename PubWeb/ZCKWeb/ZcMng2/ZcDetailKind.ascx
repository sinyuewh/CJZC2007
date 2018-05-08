<%@ control language="C#" autoeventwireup="true" inherits="ZiChan_ZcDetailKind, App_Web_gyjcweka" %>
<script language="javascript" type ="text/javascript">
    function showWindow(url1,width1,height1) {
        var top1 = (window.screen.availHeight - height1) / 2;
        var left1 = (window.screen.availWidth - width1)/2;
        window.open(url1, "", "location=no,Status=no,Menubar=no,Scrollbars=yes,resizable=yes,left="+left1+",top="+top1+",width=" + width1 + ",height=" + height1);
    }

    function showDAFile() {
        var url1 = "SeeDangAnFile.aspx";
        var width1 = 400;
        var height1 = 300;
        showWindow(url1, 400, 300);
    }

    //显示更多的资产项目表
    function showMoreZcShenPi() 
    {
        var id1 = '<%=Request.QueryString["id"] %>';
        var url = "MoreZcShenPi.aspx?id=" + id1;
        showWindow(url, 300, 450);
    }
</script>
<table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr height="10">
        <td>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:HyperLink ID="prevUrl" runat="server" Text="<<" ToolTip="上一个资产"></asp:HyperLink>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue1" CommandArgument="1"
                OnCommand="LinkButton1_Command">1.基本资料</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton9" runat="server" CssClass="blue1" CommandArgument="9"
                OnCommand="LinkButton1_Command">2.资产担保情况</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="blue1" CommandArgument="6"
                OnCommand="LinkButton1_Command">3.时效管理</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="blue1" CommandArgument="2"
                OnCommand="LinkButton1_Command">4.尽职调查</asp:LinkButton>
           
           <%-- 
            |
            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="blue1" CommandArgument="3"
                OnCommand="LinkButton1_Command">5.方案审批</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="blue1" CommandArgument="4"
                OnCommand="LinkButton1_Command">6.方案执行</asp:LinkButton>
                   --%>
            |
         
            
            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="blue1" CommandArgument="5"
                OnCommand="LinkButton1_Command">5.财务数据</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton7" runat="server" CssClass="blue1" CommandArgument="7"
                OnCommand="LinkButton1_Command">6.抵债物资</asp:LinkButton>
            |
            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="blue1" CommandArgument="8"
                OnCommand="LinkButton1_Command">7.所有附件</asp:LinkButton>
            <asp:HyperLink ID="nextUrl" runat="server" Text=">>" ToolTip="下一个资产"></asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="blue1" Visible="false"
              NavigateUrl="javascript:showDAFile();"
              Target="_self">[项目档案]</asp:HyperLink>&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" ForeColor="Red">[最近项目申报表]</asp:HyperLink>
            &nbsp;<a href="javascript:showMoreZcShenPi();" class ="blue">>>更多</a>
        </td>
    </tr>
</table>
