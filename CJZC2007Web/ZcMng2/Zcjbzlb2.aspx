<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zcjbzlb2.aspx.cs" Inherits="ZcMng2_Zcjbzlb2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产业务情况表</title>
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
                        <strong>武汉长江资产公司资产业务情况表</strong></p>
                </td>
            </tr>
            <tr height="30">
                <td style="border-top: solid 1pt #000000;border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    组织机构代码：
                </td>
                <td style="border-top: solid 1pt #000000;border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zzjg" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-top: solid 1pt #000000;border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    企业经营状况：
                </td>
                <td style="border-top: solid 1pt #000000;border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="jysfzc" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    成立时间：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="clsj" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    注册资本(万)：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zczb" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    地区经济与信用状况：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="dqjj" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    企业规模：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="qygm" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    单位地址：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="dwdz" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    负责人：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="dwfzr" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    企业经济性质：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="qyjjxz" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    债务人有效资产状况：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="yxzzzk" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    首建信贷关系日期：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="xdri" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    贷款首次发放日期：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="dkffrq1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    借款流水号：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="jklsh" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    贷款余额(万)：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="dkye" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    贷款发放日期：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="dkffrq2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    合同到期日：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="htdqr" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    最近一次上账金额：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zjycszje" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    主要担保方式：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="zydbfs" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    担保人(物)名称：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="dbrwmc" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    一逾两呆形态：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="yyldxt" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    形成逾期时间：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="xcyqrq" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    进入不良时间：
                </td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="jrblsj" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    五级分类：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="fenlei" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    备 注：</td>
                <td style="border-bottom: solid 1pt #000000">
                    &nbsp;<asp:Label ID="remark" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
