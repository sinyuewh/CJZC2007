<%@ page language="C#" autoeventwireup="true" inherits="ZcMng3_ZcZXTongJi, App_Web_pyuhrx5l" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产执行统计结果</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="990" align="center" border="0" cellpadding="0" cellspacing="0">
                <tr bgcolor="white">
                    <td align="center" height="50" valign="middle">
                        <b><span style="font-size: 16pt">不良资产项目处置情况统计</span></b>
                    </td>
                </tr>
            </table>
            <table width="990" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="black">
                <tr bgcolor="white" height="25">
                    <td align="center" width="80pt" rowspan="3">
                        <b>部门</b>
                    </td>
                    <td align="center" width="40pt" rowspan="3">
                        <b>申报<br />
                            项目</b>
                    </td>
                    <td align="center" width="40pt" rowspan="3">
                        <b>批准<br />
                            项目</b>
                    </td>
                    <td colspan="23" align="center">
                        <b>项 目 执 行 情 况</b>
                    </td>
                </tr>
                <tr bgcolor="white" height="25">
                    <td align="center" width="40pt" rowspan="2">
                        <b>协商<br />
                            处置</b>
                    </td>
                    <td colspan="4" align="center">
                        <b>其 中</b>
                    </td>
                    <td align="center" width="40pt" rowspan="2">
                        <b>诉讼<br />
                            处置</b>
                    </td>
                    <td colspan="8" align="center">
                        <b>其 中</b>
                    </td>
                    <td align="center" width="40pt" rowspan="2">
                        <b>其他<br />
                            处置</b>
                    </td>
                    <td colspan="8" align="center">
                        <b>其 中</b>
                    </td>
                </tr>
                <tr height="49" bgcolor="white">
                    <td width="35" align="center">
                        谈判</td>
                    <td width="35" align="center">
                        签订协议</td>
                    <td width="35" align="center">
                        部分执行</td>
                    <td width="35" align="center">
                        全部执行</td>
                    <td width="35" align="center">
                        立案</td>
                    <td width="35" align="center">
                        财产保全</td>
                    <td width="35" align="center">
                        一审</td>
                    <td width="35" align="center">
                        二审</td>
                    <td width="35" align="center">
                        申请执行</td>
                    <td width="35" align="center">
                        结案</td>
                    <td width="35" align="center">
                        中止执行</td>
                    <td width="35" align="center">
                        终止执行</td>
                    <td width="35" align="center">
                        打包处置</td>
                    <td width="35" align="center">
                        委托拍卖</td>
                    <td width="35" align="center">
                        合作处置</td>
                    <td width="35" align="center">
                        委托追偿</td>
                    <td width="35" align="center">
                        债权重组</td>
                    <td width="35" align="center">
                        破产清偿</td>
                    <td width="35" align="center">
                        <br />
                    </td>
                    <td width="35" align="center">
                        <br />
                    </td>
                </tr>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr height="25" bgcolor="white">
                            <td align="center">
                                <b>汇总 </b>
                            </td>
                            <td align="center">
                                1
                            </td>
                            <td align="center">
                                2
                            </td>
                            <td width="35" align="center">
                                3</td>
                            <td width="35" align="center">
                                4</td>
                            <td width="35" align="center">
                                5</td>
                            <td width="35" align="center">
                                6</td>
                            <td width="35" align="center">
                                7</td>
                            <td width="35" align="center">
                                8</td>
                            <td width="35" align="center">
                                9</td>
                            <td width="35" align="center">
                                1</td>
                            <td width="35" align="center">
                                2</td>
                            <td width="35" align="center">
                                3</td>
                            <td width="35" align="center">
                                4</td>
                            <td width="35" align="center">
                                5</td>
                            <td width="35" align="center">
                                6</td>
                            <td width="35" align="center">
                                7</td>
                            <td width="35" align="center">
                                8</td>
                            <td width="35" align="center">
                                9</td>
                            <td width="35" align="center">
                                10</td>
                            <td width="35" align="center">
                                11</td>
                            <td width="35" align="center">
                                1
                            </td>
                            <td width="35" align="center">
                                2
                            </td>
                            <td align="center">
                                3
                            </td>
                            <td align="center">
                                4
                            </td>
                            <td align="center">
                                5
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
