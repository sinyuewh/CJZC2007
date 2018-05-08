<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_Zcczsbb, App_Web_zpfhjo5e" enabletheming="false" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产处置方式申报表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <br />
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <tr height="20">
                <td align="right" colspan="2">
                    <span style="font-size: 11pt">秘密&nbsp;&nbsp; </span>
                </td>
            </tr>
            <tr height="40">
                <td align="center" colspan="2">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司不良资产项目处置方案申报表</strong></p>
                </td>
            </tr>
            <tr height="40">
                <td width="50%" align="left">
                    &nbsp;&nbsp;<span style="font-size: 13pt">项目申报号：<asp:Label ID="xmsbh" runat="server" />号</span>
                </td>
                <td>
                    &nbsp;&nbsp;<span style="font-size: 13pt">项目档案号：<asp:Label ID="num2" runat="server" />号</span>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="black">
                </td>
            </tr>
            <tr height="40">
                <td align="left" colspan="2" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000; height: 40px;">
                    <span style="font-size: 13pt">项目名称：<asp:Label ID="danwei" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr height="80">
                <td align="left" valign="top" colspan="2" style="border-bottom: solid 1pt #000000">
                    <span style="font-size: 13pt; line-height: 150%">项目背景：<br />
                        <asp:Label ID="xmbj" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr height="40">
                <td width="50%" align="left" style="border-bottom: solid 1pt #000000; border-right: solid 1pt #000000;">
                    <span style="font-size: 13pt">资产类型：<asp:Label ID="zclx" runat="server"></asp:Label></span>
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    <span style="font-size: 13pt">&nbsp;&nbsp;资产数额：<asp:Label ID="zcse" runat="server"></asp:Label></span>
                </td>
            </tr>
            <tr height="40">
                <td colspan="2" align="left" style="border-bottom: solid 1pt #000000;">
                    <span style="font-size: 13pt">债权总额：<asp:Label ID="zqze" runat="server" />
                        万元。 其中： 本金<asp:Label ID="bj" runat="server" />
                        万元； 利息<asp:Label ID="lx" runat="server" />
                        万元 </span>
                </td>
            </tr>
            <tr height="40">
                <td colspan="2" width="100%" align="left">
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <colgroup>
                            <col align="left" width="40%" />
                            <col align="center" width="15%" />
                            <col align="center" width="15%" />
                            <col align="center" width="15%" />
                            <col align="center" width="15%" />
                        </colgroup>
                        <tr height="40">
                            <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                <span style="font-size: 13pt">处 置 方 式<br />
                                    （一种或多种）</span>
                            </td>
                            <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                <span style="font-size: 13pt">处置价格<br />
                                </span>
                            </td>
                            <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                <span style="font-size: 13pt">处置损失<br />
                                    </span>
                            </td>
                            <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                <span style="font-size: 13pt">清偿率
                                    <br />
                                    </span>
                            </td>
                            <td style="border-bottom: solid 1pt #000000">
                                <span style="font-size: 13pt">预计费用<br />
                                    </span>
                            </td>
                        </tr>
                        <asp:Repeater ID="repeater1" runat="server">
                            <ItemTemplate>
                                <tr height="40">
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt"><%#Eval("czfs")%></span><br />
                                    </td>
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt"><%#Eval("czjg")%></span><br />
                                    </td>
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt"><%#Eval("czss")%></span><br />
                                    </td>
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt"><%#Eval("qcl")%></span><br />
                                    </td>
                                    <td style="border-bottom: solid 1pt #000000;">
                                        <span style="font-size: 13pt"><%#Eval("yjfy")%></span><br />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr height="80">
                <td colspan="2" align="left" valign="top" style="border-bottom: solid 1pt #000000;
                    line-height: 150%">
                    <span style="font-size: 13pt">方式选择理由：
                        <br />
                        <asp:Label ID="fsxzly" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr height="80">
                <td colspan="2" align="left" valign="top" style="border-bottom: solid 1pt #000000;
                    line-height: 150%">
                    <span style="font-size: 13pt">定价依据：
                        <br />
                        <asp:Label ID="djyj" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr height="40">
                <td width="50%" align="left" rowspan="2" style="border-bottom: solid 1pt #000000;
                    border-right: solid 1pt #000000; line-height: 150%" valign="top" height="80">
                    <table width="100%">
                        <tr>
                            <td align="left">
                                <span style="font-size: 13pt">部门负责人意见：
                                    <br />
                                    <asp:Label ID="bmremark" runat="server" Text=""></asp:Label>
                                </span>
                                <div align="right" style="font-size: 13pt">
                                    <br />
                                    <asp:Label ID="zeren1" runat="server" Text=""></asp:Label>
                                    &nbsp;&nbsp;
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span style="font-size: 13pt">
                                    <asp:Label ID="time1" runat="server"></asp:Label>
                                    &nbsp;&nbsp; </span>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    <span style="font-size: 13pt">承办部门：
                        <asp:Label ID="cbdepart" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <tr height="40">
                <td style="border-bottom: solid 1pt #000000; line-height: 150%">
                    <table width="100%">
                        <tr>
                            <td>
                                <span style="font-size: 13pt">经 办 人：<asp:Label ID="cbzeren" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span style="font-size: 13pt">
                                    <asp:Label ID="time" runat="server"></asp:Label>&nbsp;&nbsp; </span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="2" bgcolor="black">
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <span style="font-size: 11pt; line-height: 150%; margin-top: 15pt">注：本表由经办人填写并签名，经部门负责人审核签字后，送机要室登记编项目申报号；连同该项目处置方案及其相关附件一并报本公司不良资产处置审核委员会审核。注意严格保密。
                    </span>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </form>
</body>
</html>
