<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_Zcdzwzb, App_Web_zpfhjo5e" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产抵债物资表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="center" width="15%" />
                <col bgcolor="white" align="center" width="20%" />
                <col bgcolor="white" align="center" width="13%" />
                <col bgcolor="white" align="center" width="10%" />
                <col bgcolor="white" align="center" />
            </colgroup>
            <tr height="40">
                <td align="center" colspan="5">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司资产抵债物资表</strong></p>
                </td>
            </tr>
            <tr height="30">
                <td colspan="2" align="right" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    单位名称：</td>
                <td colspan="3" align="left" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="danwei" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    物品名称
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    规格型号</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    库存数量
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    单位</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    备注</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr height="30">
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("gname") %>&nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("ggxh") %>&nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("num") %>&nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("dw") %>&nbsp;
                        </td>
                        <td style="border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("remark") %>&nbsp;
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table>
            <tr height="3">
                <td style="width: 3px">
                </td>
            </tr>
        </table>
        <asp:Repeater ID="Repeater2" runat="server">
            <HeaderTemplate>
                <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                    <colgroup>
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                    </colgroup>
                    <tr height="30">
                        <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; height: 30px; border-top: solid 1pt #000000">
                            <strong>1．入 库 单 据</strong>
                        </td>
                    </tr>
                    <tr height="30">
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            单据编号
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            开票时间</td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            部门
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            责任人</td>
                        <td style="border-bottom: solid 1pt #000000; height: 30px;">
                            开票员</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        [入]<%#Eval("bill") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("billtime","{0:yyyy-M-d}") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("depart") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("zeren") %>&nbsp;
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("billmen")%>&nbsp;
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
        <asp:Repeater ID="Repeater3" runat="server">
            <HeaderTemplate>
                <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                    <colgroup>
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                    </colgroup>
                    <tr height="30">
                        <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; height: 30px; border-top: solid 1pt #000000">
                            <strong>2．出 库 单 据</strong>
                        </td>
                    </tr>
                    <tr height="30">
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            单据编号
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            开票时间</td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            部门
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            责任人</td>
                        <td style="border-bottom: solid 1pt #000000; height: 30px;">
                            开票员</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        [出]<%#Eval("bill") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("billtime","{0:yyyy-M-d}") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("depart") %>&nbsp;
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("zeren") %>&nbsp;
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        <%#Eval("billmen")%>&nbsp;
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
