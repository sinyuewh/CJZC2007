<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZiChan_ZcDetail5, App_Web_kckafmby" title="资产的财务数据" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() 
{
    url="Zccwsjb.aspx?zcid=<%#Request["id"]%>";    
    window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
}


// ]]>
    
    function AddHKPlan()
    {
        var url='AddHKPlan.aspx?kind=0&zcid=<%=Request["id"]%>';
        top.location.href=url;
    }
    </script>

    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 的 财 务 数 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：
            </td>
            <td colspan="3">
                <asp:Label ID="danwei" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：
            </td>
            <td>
                <asp:Label ID="depart" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                责任人：
            </td>
            <td>
                <asp:Label ID="zeren" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                初始本金：
            </td>
            <td>
                <asp:Label ID="bj" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                利息：
            </td>
            <td>
                <asp:Label ID="lx" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                归还本金：
            </td>
            <td>
                <asp:Label ID="pbj" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                归还利息：
            </td>
            <td>
                <asp:Label ID="plx" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                本金余额：
            </td>
            <td>
                <asp:Label ID="bjye" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                利息余额：
            </td>
            <td>
                <asp:Label ID="lxye" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                还本息合：
            </td>
            <td>
                <asp:Label ID="hbxh" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                本息合计余额：
            </td>
            <td>
                <asp:Label ID="bxhjye" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>处 置 费 用 合 计</strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                申请费：
            </td>
            <td>
                <asp:Label ID="fee1" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                律师费：
            </td>
            <td>
                <asp:Label ID="fee2" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                诉讼费：
            </td>
            <td>
                <asp:Label ID="fee3" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                执行费：
            </td>
            <td>
                <asp:Label ID="fee4" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                受理费及保全费：
            </td>
            <td>
                <asp:Label ID="fee5" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                仲裁费：
            </td>
            <td>
                <asp:Label ID="fee6" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                评估费：
            </td>
            <td>
                <asp:Label ID="fee7" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                物业费：
            </td>
            <td>
                <asp:Label ID="fee8" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                过路费：
            </td>
            <td>
                <asp:Label ID="fee9" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                招待费：
            </td>
            <td>
                <asp:Label ID="fee10" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                信息咨询费：
            </td>
            <td>
                <asp:Label ID="fee11" runat="server" Text=""></asp:Label>&nbsp;
            </td>
            <td>
                其他费用：
            </td>
            <td>
                <asp:Label ID="fee12" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="25">
            <td>
                费用合计：
            </td>
            <td colspan="3">
                <asp:Label ID="fyhj" runat="server" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <input id="Button2" type="button" runat="server" value="打印资产财务数据" class="but" onclick="return Button2_onclick()" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="right" />
                    <col bgcolor="white" align="right" />
                    <col bgcolor="white" align="right" />
                </colgroup>
                <tr height="25">
                    <td colspan="8" align="Center" bgcolor="gainsboro">
                        <strong>1．收 款 单 据</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序
                    </td>
                    <td>
                        单据编号
                    </td>
                    <td>
                        开票时间
                    </td>
                    <td>
                        部门
                    </td>
                    <td>
                        责任人
                    </td>
                    <td>
                        归还本金
                    </td>
                    <td>
                        归还利息
                    </td>
                    <td>
                        小计
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <a href="<%#Application["root"] %>/Caiwu/<%# Eval("EditASP") %>?id=<%# Eval("id") %>"
                        class="blue1" target="_blank">[收]<%#Eval("bill") %></a>
                </td>
                <td>
                    <%#Eval("billtime","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td>
                    <%#Comm.GetNumberFormat(Eval("pbj")) %>
                </td>
                <td>
                    <%#Comm.GetNumberFormat(Eval("plx")) %>
                </td>
                <td>
                    <%#Comm.GetNumberFormat(Eval("bxhj")) %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td style="width: 3px">
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater2" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="right" />
                </colgroup>
                <tr height="25">
                    <td colspan="6" align="Center" bgcolor="gainsboro">
                        <strong>2．支 出 单 据</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序
                    </td>
                    <td>
                        单据编号
                    </td>
                    <td>
                        开票时间
                    </td>
                    <td>
                        部门
                    </td>
                    <td>
                        责任人
                    </td>
                    <td>
                        支出合计
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <a href="<%#Application["root"] %>/Caiwu/<%# Eval("EditASP") %>?id=<%# Eval("id") %>"
                        class="blue1" target="_blank">[支]<%#Eval("bill") %></a>
                </td>
                <td>
                    <%#Eval("billtime","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("depart") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td>
                    <%#Comm.GetNumberFormat(Eval("fyhj"))%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td style="width: 3px">
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="center" />
            <col bgcolor="white" align="right" />
            <col bgcolor="white" align="left" />
            <col bgcolor="white" align="center" />
        </colgroup>
        <tr height="25">
            <td colspan="5" align="Center" bgcolor="gainsboro">
                <strong>3．回 款 计 划</strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                次序
            </td>
            <td>
                回款时间
            </td>
            <td>
                金额
            </td>
            <td>
                &nbsp;说明
            </td>
            <td>
                操作
                <asp:LinkButton ID="link2" runat="server" Text="增加" OnClientClick="javascript:AddHKPlan();return false;"></asp:LinkButton>
            </td>
        </tr>
        <asp:Repeater ID="Repeater3" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr height="25">
                    <td>
                        <%#Container.ItemIndex+1%>
                    </td>
                    <td>
                        <%#Eval("time0","{0:yyyy-M-d}") %>
                    </td>
                    <td>
                        <%#Eval("pbj","{0:n}") %>
                    </td>
                    <td>
                        &nbsp;<%#Eval("remark") %>
                    </td>
                    <td>
                        <asp:LinkButton ID="link1" runat="server" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('提示：确定要删除吗？');">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </table>
    <table>
        <tr height="3">
            <td style="width: 3px">
            </td>
        </tr>
    </table>
</asp:Content>
