<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_ZcSP, App_Web_g1yfc6zq" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <span style="font-size: 12pt; font-weight: bold; letter-spacing: 2pt">资产项目处置</span>
        </td>
    </tr>
    <tr>
        <td height="5" valign="bottom">
            <table align="center" width="99%" cellpadding="0" cellspacing="0">
                <tr>
                    <td bgcolor="gray" height="1">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tabNavigator" runat="server">
                <tr>
                    <td height="7" colspan="2">
                    </td>
                </tr>
                <colgroup>
                    <col align="center" width="17%" />
                    <col align="left" />
                </colgroup>
                
                <tr height="26" id="AddRow" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <a href='<%#Application["root"]%>/ZcMng3/SelectZC.aspx'>新增方案审批表</a></td>
                </tr>
                
                <tr height="26" id="Tr4" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <a href='<%#Application["root"]%>/ZcMng3/SelectZCBao.aspx'>新增包方案审批表</a></td>
                </tr>
                
                <tr height="26" id="SPList1" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <asp:HyperLink ID="fangan1" runat="server" NavigateUrl="~/ZcMng3/fangan1.aspx" Text="我的项目审批表"></asp:HyperLink>
                    </td>
                </tr>
                
                <tr height="26" id="SPList2" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/ZcMng3/fangan2.aspx" Text="部门的项目审批表"></asp:HyperLink>
                    </td>
                </tr>
                
                <tr height="26" id="SPList3" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/ZcMng3/fangan3.aspx" Text="公司的项目审批表"></asp:HyperLink>
                    </td>
                </tr>
                <tr id="HR1" runat="server">
                    <td>
                        <br />
                    </td>
                    <td >
                        <hr width="70%" />
                    </td>
                </tr>
                
                <tr height="26" id="Tr1" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ZcMng3/fangan4.aspx" Text="需要我审批的项目"></asp:HyperLink>
                    </td>
                </tr>
                
                <tr height="26" id="Tr2" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ZcMng3/fangan5.aspx" Text="我审批过的项目"></asp:HyperLink>
                    </td>
                </tr>
                
                <tr height="26" id="LeaderMiShu" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ZcMng3/fangan6.aspx" Text="领导秘书办公专栏"></asp:HyperLink>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <br />
                    </td>
                    <td >
                        <hr width="70%" />
                    </td>
                </tr>
                
         
                <tr height="26" id="SearchFangAnTr" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <a href='<%#Application["root"]%>/ZcMng3/SearchFangAn.aspx'>查询方案审批表</a></td>
                </tr>
                
                <tr height="26" id="Tr3" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <a href='<%#Application["root"]%>/ZcMng3/TongJiFangAn.aspx?tjkind=0'>方案审批表统计（单个资产）</a></td>
                </tr>
                
                <tr height="26" id="Tr5" runat="server">
                    <td>
                        <img src='<%#Application["root"]%>/Common/image/Corp/Arrow.GIF' width="14" height="17"></td>
                    <td>
                        <a href='<%#Application["root"]%>/ZcMng3/TongJiFangAn.aspx?tjkind=1'>方案审批表统计（资产包）</a></td>
                </tr>
                
            </table>
        </td>
    </tr>
</table>
