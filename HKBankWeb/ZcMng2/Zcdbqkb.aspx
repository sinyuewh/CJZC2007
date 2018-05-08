<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zcdbqkb.aspx.cs" Inherits="ZcMng2_Zcdbqkb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产担保情况表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <colgroup>
                <col align="right" width="24%" />
                <col align="left" width="26%" />
                <col align="right" width="24%" />
                <col align="left" />
            </colgroup>
            <tr height="40">
                <td align="center" colspan="4">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司资产担保情况表</strong></p>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    债务人回收估值：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="zwrhsgz" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    保证人回收估值：
                </td>
                <td style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="bzrhsgz" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    其他回收贡献值：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="qthsgz" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    预计回收时间：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="hssj" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    与债务人或其他潜在的偿债方历史洽商情况：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="qsqk" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    备注：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="remark" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="35">
                <td colspan="4" align="center">
                    <strong>保 证 单 位 (人)&nbsp; &nbsp;情 况</strong></td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    保证(单位)人名称：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    <asp:Label ID="bzrmc" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    保证金额：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px; border-top: solid 1pt #000000">
                    <asp:Label ID="bzje" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    保证有效性：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bzyx" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    保证人的偿债能力：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bzcznl" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    保证人的偿债意愿：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bzczyy" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    保证无效说明：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bzwxsm" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    保证补充说明：
                </td>
                <td colspan="3" style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="Remark1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="35" align="center">
                <td colspan="4" align="Center">
                    <strong>抵 押 物 情 况</strong>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    抵押物取得是否存在障碍：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="qdza1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    抵押物取得障碍原因：
                </td>
                <td style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="qdzayy1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    抵押物处置是否存在障碍：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="czza1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    抵押物处置障碍原因：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="zzzayy1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    抵押物变现难易：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bxny1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    抵押物考虑安置费金额：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="klazfy" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    抵押物法律意见：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="flyj1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    抵押物回收估值：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="dyhsgz1" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    抵押物补充说明：
                </td>
                <td colspan="3" style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="Remark2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="35" align="center">
                <td colspan="4" align="Center">
                    <strong>抵 押 物 详 细 情 况</strong>
                </td>
            </tr>
            <tr height="30">
                <td colspan="4" width="100%" align="left">
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <colgroup>
                            <col align="center" width="25%" />
                            <col align="center" width="25%" />
                            <col align="center" width="25%" />
                            <col align="center" width="25%" />
                        </colgroup>
                        <tr height="30">
                            <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000;
                                border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">抵押物类别</span>
                            </td>
                            <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">抵押物数量</span>
                            </td>
                            <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">单位</span>
                            </td>
                            <td style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">估值 </span>
                            </td>
                        </tr>
                        <asp:Repeater ID="repeater1" runat="server">
                            <ItemTemplate>
                                <tr height="30">
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt">
                                            <%#Eval("wplb") %>&nbsp;
                                        </span>
                                    </td>
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt">
                                            <%#Eval("wpsl") %>&nbsp;
                                        </span>
                                    </td>
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt">
                                            <%#Eval("wpdw") %>&nbsp;
                                        </span>
                                    </td>
                                    <td style="border-bottom: solid 1pt #000000;">
                                        <span style="font-size: 13pt">
                                            <%#PubComm.GetNumberFormat(Eval("wpjz")) %>&nbsp;
                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr height="35" align="center">
                <td colspan="4" align="Center">
                    <strong>质 押 物 情 况</strong>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    质押物取得是否存在障碍：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="qdza2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    质押物取得障碍原因：
                </td>
                <td style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="qdzayy2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    质押物处置是否存在障碍：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="czza2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    质押物处置障碍原因：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="zzzayy2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    质押物变现难易：
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="bxny2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    质押物法律意见：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="flyj2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    质押物回收估值：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="dyhsgz2" runat="server" Text=""></asp:Label>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    质押物补充说明：
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="Remark3" runat="server" Text=""></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="35" align="center">
                <td colspan="4" align="Center">
                    <strong>质 押 物 详 细 情 况</strong>
                </td>
            </tr>
            <tr height="30">
                <td colspan="4" width="100%" align="left">
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <colgroup>
                            <col align="center" width="25%" />
                            <col align="center" width="25%" />
                            <col align="center" width="25%" />
                            <col align="center" width="25%" />
                        </colgroup>
                        <tr height="30">
                            <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000;
                                border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">质押物类别</span>
                            </td>
                            <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">质押物数量</span>
                            </td>
                            <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">单位</span>
                            </td>
                            <td style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                                <span style="font-size: 13pt">估值 </span>
                            </td>
                        </tr>
                        <asp:Repeater ID="repeater2" runat="server">
                            <ItemTemplate>
                                <tr height="30">
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt">
                                            <%#Eval("wplb") %>&nbsp;
                                        </span>
                                    </td>
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt">
                                            <%#Eval("wpsl") %>&nbsp;
                                        </span>
                                    </td>
                                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                                        <span style="font-size: 13pt">
                                            <%#Eval("wpdw") %>&nbsp;
                                        </span>
                                    </td>
                                    <td style="border-bottom: solid 1pt #000000;">
                                        <span style="font-size: 13pt">
                                            <%#PubComm.GetNumberFormat(Eval("wpjz")) %>&nbsp;
                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
