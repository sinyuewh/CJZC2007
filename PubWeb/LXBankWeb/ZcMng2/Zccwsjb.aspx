<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_Zccwsjb, App_Web_qf07ssj0" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产财务数据表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <colgroup>
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" width="32%" />
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" />
            </colgroup>
            <tr height="40">
                <td align="center" colspan="4">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司资产财务数据表</strong></p>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    单位名称：</td>
                <td colspan="3" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="danwei" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="25">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    责任部门：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="depart" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    责任人：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="zeren" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="25">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    初始本金：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bj" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    利息：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="lx" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    归还本金：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="pbj" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    归还利息：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="plx" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    本金余额：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bjye" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    利息余额：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="lxye" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    还本息合：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="hbxh" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    本息合计余额：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bxhjye" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td colspan="4" align="center">
                    <strong>处 置 费 用 合 计</strong></td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    申请费：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    <asp:Label ID="fee1" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    律师费：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px; border-top: solid 1pt #000000">
                    <asp:Label ID="fee2" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    诉讼费：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee3" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    执行费：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee4" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="25">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    受理费及保全费：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee5" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    仲裁费：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee6" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    评估费：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee7" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    物业费：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee8" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    过路费：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee9" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    招待费：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee10" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    信息咨询费：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee11" runat="server" Text=""></asp:Label>&nbsp;</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    其他费用：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fee12" runat="server" Text=""></asp:Label>&nbsp;</td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    费用合计：</td>
                <td colspan="3" style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="fyhj" runat="server" Text=""></asp:Label>&nbsp;</td>
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
                        <col bgcolor="white" align="right" />
                        <col bgcolor="white" align="right" />
                        <col bgcolor="white" align="right" />
                    </colgroup>
                    <tr height="30">
                        <td colspan="8" align="Center" style="height: 30px; border-top: solid 1pt #000000">
                            <strong>1．收 款 单 据</strong>
                        </td>
                    </tr>
                    <tr height="30">
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            单据编号
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            开票时间</td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            部门
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            责任人</td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            归还本金</td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            归还利息</td>
                        <td style="border-bottom: solid 1pt #000000; height: 30px; border-top: solid 1pt #000000">
                            小计</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        [收]<%#Eval("bill") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("billtime","{0:yyyy-M-d}") %>
                        &nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("depart") %>
                        &nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("zeren") %>
                        &nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#PubComm.GetNumberFormat(Eval("pbj")) %>
                        &nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#PubComm.GetNumberFormat(Eval("plx")) %>
                        &nbsp;
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        <%#PubComm.GetNumberFormat(Eval("bxhj")) %>
                        &nbsp;
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
                        <col bgcolor="white" align="right" />
                    </colgroup>
                    <tr height="30">
                        <td colspan="6" align="Center" style="height: 30px; border-top: solid 1pt #000000">
                            <strong>2．支 出 单 据</strong>
                        </td>
                    </tr>
                    <tr height="30">
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            单据编号
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            开票时间</td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            部门
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                            border-top: solid 1pt #000000">
                            责任人</td>
                        <td style="border-bottom: solid 1pt #000000; height: 30px; border-top: solid 1pt #000000">
                            支出合计</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        [支]<%#Eval("bill") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("billtime","{0:yyyy-M-d}") %>
                        &nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("depart") %>
                        &nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("zeren") %>
                        &nbsp;
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        <%#PubComm.GetNumberFormat(Eval("fyhj"))%>
                        &nbsp;
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
    </form>
</body>
</html>
