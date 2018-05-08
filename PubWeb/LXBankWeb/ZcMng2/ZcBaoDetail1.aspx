<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng2_ZcBaoDetail1, App_Web_uc5krivz" title="资产包基本资料" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcBaoDetailKind.ascx" TagName="ZcBaoDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ZcBaoDetailKind ID="ZcBaoDetailKind1" runat="server" />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" width="35%" />
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" width="35%" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">资 产 包 信 息 </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：
            </td>
            <td>
                &nbsp;<asp:Label ID="Bname" runat="server" Text=""></asp:Label>
                <asp:Label ID="Bname_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                接收方：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="Bjsf" runat="server"></asp:TextBox>
                <asp:Label ID="Bjsf_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                累计收款：
            </td>
            <td>
                &nbsp;<asp:Label ID="Bljsk" runat="server" Text=""></asp:Label>
                <asp:Label ID="Bljsk_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                累计支出：
            </td>
            <td>
                &nbsp;<asp:Label ID="Bljzc" runat="server" Text=""></asp:Label>
                <asp:Label ID="Bljzc_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                责任人：
            </td>
            <td>
                &nbsp;<asp:Label ID="Bzeren" runat="server" Text=""></asp:Label>
                <asp:Label ID="Bzeren_1" runat="server" Text=""></asp:Label>
            </td>
            <td>
                协办人：
            </td>
            <td>
                &nbsp;<asp:Label ID="Bzeren1" runat="server" Text=""></asp:Label>
                <asp:Label ID="Bzeren1_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                备注：
            </td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="Bremark" runat="server"></asp:TextBox>
                <asp:Label ID="Bremark_1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="SaveDataClick" />
            </td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <colgroup>
                                <col bgcolor="white" align="center" width="8%" />
                                <col bgcolor="white" align="center" width="10%" />
                                <col bgcolor="white" align="left" />
                                <col bgcolor="white" align="right" width="15%" />
                                <col bgcolor="white" align="right" width="15%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="10%" />
                            </colgroup>
                            <tr height="25" bgcolor="gainsboro">
                                <td colspan="7" align="Center">
                                    <strong>资 产 包 详 细 信 息</strong>&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    序号
                                </td>
                                <td>
                                    档案号
                                </td>
                                <td>
                                    单位名称
                                </td>
                                <td>
                                    初始本金
                                </td>
                                <td>
                                    利息
                                </td>
                                <td>
                                    责任部门
                                </td>
                                <td>
                                    责任人
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr height="25">
                            <td>
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td>
                                <%#Eval("num2")%>
                            </td>
                            <td>
                                <a target="_blank" class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                                    title="<%# Eval("danwei") %>">
                                    <%# Eval("danwei1") %>
                                </a>
                            </td>
                            <td>
                                <%#PubComm.GetNumberFormat(Eval("bj"))%>
                            </td>
                            <td>
                                <%#PubComm.GetNumberFormat(Eval("lxhj"))%>
                            </td>
                            <td>
                                <%#Eval("depart")%>
                            </td>
                            <td>
                                <%#Eval("zeren")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr height="25">
                            <td colspan="3">
                                <b>小计</b>
                            </td>
                            <td>
                                <asp:Label ID="labSum1" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="labSum2" runat="server"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        </table>
                        <table>
                            <tr height="3">
                                <td style="width: 3px">
                                </td>
                            </tr>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                
            </td>
        </tr>
    </table>
</asp:Content>
