<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zcjbzlb1.aspx.cs" Inherits="ZcMng2_Zcjbzlb1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产基本情况表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <colgroup>
                <col align="right" width="25%" />
                <col align="left" width="25%" />
                <col align="right" width="25%" />
                <col align="left" width="25%" />
            </colgroup>
            <tr height="60">
                <td align="center" colspan="4">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司资产基本资料表</strong></p>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    单位名称：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    &nbsp;<asp:Label ID="danwei" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    是否总行委贷：
                </td>
                <td style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zhwd" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    责任部门：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="depart" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    责任人：</td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zeren" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    编号：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="num1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    档案号：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="num2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    货币：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="huobi" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    汇率：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="huilv" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    初始本金：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="bj" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    初始表内息：</td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="lx1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    初始表外息：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="lx2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    初始孳生利息：</td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="lx3" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    所属行业：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="sshy" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    行政区域：</td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="quyu" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    管 辖：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="guangxia" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="height: 30px; border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    政策包类别：</td>
                <td style="border-bottom: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zcbao" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    行 号：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="bank" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    转让价：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zhuang" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="height: 30px; border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    合同编号：</td>
                <td style="height: 30px; border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="htnum" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    转入时间：</td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="time0" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    资产状态：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="status" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    用户自定义分类：</td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="userkind" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
