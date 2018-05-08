<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="ZcBaoDetail5.aspx.cs" Inherits="ZcMng2_ZcBaoDetail5" Title="资产包的财务数据" %>

<%@ Register Src="ZcBaoDetailKind.ascx" TagName="ZcBaoDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function AddHKPlan() {
            var url = 'AddHKPlan.aspx?kind=1&zcid=<%=Request["id"]%>';
            top.location.href = url;
        }
    </script>

    <uc1:ZcBaoDetailKind ID="ZcBaoDetailKind1" runat="server" />
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
                <strong><font color="#ffffff">资 产 包 财 务 数 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：
            </td>
            <td colspan="3">
                <asp:Label ID="Bname" runat="server"></asp:Label>
                <asp:Label ID="Bid" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任人：
            </td>
            <td>
                &nbsp;<asp:Label ID="bzeren" runat="server"></asp:Label>
                （<asp:Label ID="depart" runat="server"></asp:Label>）
            </td>
            <td>
                当前状态：
            </td>
            <td>
                &nbsp;<asp:Label ID="statusText" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="status" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                包内资产本金合计：
            </td>
            <td>
                <asp:Label ID="bbjhj" runat="server" Text=""></asp:Label>
            </td>
            <td>
                包内资产利息：
            </td>
            <td>
                <asp:Label ID="blxhj" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                累计收款：
            </td>
            <td>
                <asp:Label ID="ljsk" runat="server" Text=""></asp:Label>
            </td>
            <td>
                累计支出：
            </td>
            <td>
                <asp:Label ID="ljzc" runat="server" Text=""></asp:Label>
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
                        <strong>收 款 单 据1（针对包收款）</strong>
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
                    <%#Eval("bzeren") %>
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
    <asp:Repeater ID="Repeater11" runat="server">
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
                        <strong>收 款 单 据2（针对包内单户收款）</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序
                    </td>
                    <td>
                        名称
                    </td>
                    <td>
                        单据编号
                    </td>
                    <td>
                        开票时间
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
                    <%#Eval("danwei") %>
                </td>
                <td>
                    <a href="<%#Application["root"] %>/Caiwu/EditShouKuan.aspx?id=<%# Eval("id") %>"
                        class="blue1" target="_blank">[收]<%#Eval("bill") %></a>
                </td>
                <td>
                    <%#Eval("billtime","{0:yyyy-M-d}") %>
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
                        <strong>支 出 单 据 （针对包支出）</strong>
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
                    <%#Eval("bzeren") %>
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
    <asp:Repeater ID="Repeater21" runat="server">
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
                    <td colspan="7" align="Center" bgcolor="gainsboro">
                        <strong>支 出 单 据 （针对包内单户支出）</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        次序
                    </td>
                    <td>
                        名称
                    </td>
                    <td>
                        单据编号
                    </td>
                    <td>
                        开票时间
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
                    <%#Eval("danwei") %>
                </td>
                <td>
                     <a href="<%#Application["root"] %>/Caiwu/EditPay.aspx?id=<%# Eval("id") %>"
                        class="blue1" target="_blank">[支]<%#Eval("bill") %></a>
                </td>
                <td>
                    <%#Eval("billtime","{0:yyyy-M-d}") %>
                </td>
                <td>
                    <%#Eval("zeren") %>
                </td>
                <td>
                    <%#Comm.GetNumberFormat(Eval("zchj"))%>
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
