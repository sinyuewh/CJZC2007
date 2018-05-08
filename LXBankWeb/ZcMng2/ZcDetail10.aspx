<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZcDetail10.aspx.cs" Inherits="ZcMng2_ZcDetail10" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>浏览资产修改资料</title>

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick()
 {
    window.close();
 }

// ]]>
    </script>

</head>
<body style="background-color: #ffffff;">
    <form id="form1" runat="server">
        <div>
            <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="right" width="20%" />
                    <col bgcolor="white" align="left" width="30%" />
                    <col bgcolor="white" align="right" width="20%" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="5">
                    <td>
                    </td>
                </tr>
                <tr height="25">
                    <td colspan="4" align="center" bgcolor="#5d7b9d">
                        <strong><font color="#ffffff">资 产 的 基 本 资 料</font></strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        责任部门：</td>
                    <td>
                        <asp:Label ID="depart" runat="server"></asp:Label>
                    </td>
                    <td>
                        责任人：</td>
                    <td>
                        <asp:Label ID="zeren" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        单位名称：</td>
                    <td>
                        <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        是否总行委贷：
                    </td>
                    <td>
                        <asp:Label ID="zhwd" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        编号：
                    </td>
                    <td>
                        <asp:Label ID="num1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        档案号：
                    </td>
                    <td>
                        <asp:Label ID="num2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        货币：
                    </td>
                    <td>
                        <asp:Label ID="huobi" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        汇率：
                    </td>
                    <td>
                        <asp:Label ID="huilv" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        初始本金：</td>
                    <td>
                        <asp:Label ID="bj" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        初始表内息：</td>
                    <td>
                        <asp:Label ID="lx1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        初始表外息：</td>
                    <td>
                        <asp:Label ID="lx2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        初始孳生利息：</td>
                    <td>
                        <asp:Label ID="lx3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        所属行业：
                    </td>
                    <td>
                        <asp:Label ID="sshy" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        行政区域：</td>
                    <td>
                        <asp:Label ID="quyu" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        管 辖：
                    </td>
                    <td>
                        <asp:Label ID="guangxia" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="height: 25px">
                        政策包类别：</td>
                    <td style="height: 25px">
                        <asp:Label ID="zcbao" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        行 号：</td>
                    <td>
                        <asp:Label ID="bank" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        转让价：
                    </td>
                    <td>
                        <%--<asp:Label ID="zhuang" runat="server" Text=""></asp:Label>--%>
                    </td>
                </tr>
                <tr height="25">
                    <td style="height: 25px">
                        合同编号：</td>
                    <td style="height: 25px">
                        <asp:Label ID="htnum" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        转入时间：</td>
                    <td>
                        <asp:Label ID="time0" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        资产状态：</td>
                    <td>
                        <asp:Label ID="status" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        用户自定义分类：</td>
                    <td>
                        <asp:Label ID="userkind" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        修改人：
                    </td>
                    <td>
                        <asp:Label ID="xgr" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        修改时间：
                    </td>
                    <td>
                        <asp:Label ID="xgsj" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td colspan="4" bgcolor="gainsboro" align="center">
                        <strong>业 务 基 本 情 况</strong></td>
                </tr>
                <tr height="25">
                    <td>
                        组织机构代码：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="zzjg" runat="server"></asp:Label>
                    </td>
                    <td>
                        企业经营状况：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="jysfzc" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        成立时间：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="clsj" runat="server"></asp:Label>
                    </td>
                    <td>
                        注册资本(万)：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="zczb" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        地区经济与信用状况：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="dqjj" runat="server"></asp:Label>
                    </td>
                    <td>
                        企业规模：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="qygm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        单位地址：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="dwdz" runat="server"></asp:Label>
                    </td>
                    <td>
                        负责人：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="dwfzr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        企业经济性质：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="qyjjxz" runat="server"></asp:Label>
                    </td>
                    <td>
                        债务人有效资产状况：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="yxzzzk" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        首建信贷关系日期：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="xdri" runat="server"></asp:Label>
                    </td>
                    <td>
                        贷款首次发放日期：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="dkffrq1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        借款流水号：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="jklsh" runat="server"></asp:Label>
                    </td>
                    <td>
                        贷款余额(万)：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="dkye" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        贷款发放日期：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="dkffrq2" runat="server"></asp:Label>
                    </td>
                    <td>
                        合同到期日：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="htdqr" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        最近一次上账金额：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="zjycszje" runat="server"></asp:Label>
                    </td>
                    <td>
                        主要担保方式：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="zydbfs" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        担保人(物)名称：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="dbrwmc" runat="server"></asp:Label>
                    </td>
                    <td>
                        一逾两呆形态：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="yyldxt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        形成逾期时间：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="xcyqrq" runat="server"></asp:Label>
                    </td>
                    <td>
                        进入不良时间：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="jrblsj" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        资产五级分类：
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="fenlei" runat="server"></asp:Label>
                    </td>
                    <td>
                        备 注：</td>
                    <td>
                        &nbsp;
                        <asp:Label ID="remark" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr height="30">
                    <td colspan="4" align="center" style="height: 30px">
                        <input id="Button1" type="button" value="关闭返回" class="but" onclick="return Button1_onclick()" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
