<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FangAnChuZhiTongJi.aspx.cs"
    Inherits="ZcMng3_FangAnChuZhiTongJi" EnableTheming="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>不良资产项目处置情况统计</title>
    <style>
        .Style1
        {
            font-size:11pt; 
            font-weight:bold;
        }
        
        .Style2
        {
            font-size:14pt; 
            font-weight:bold;
        }
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 27px;
        }
        .style3
        {
            height: 33px;
        }
        .style4
        {
            height: 24px;
        }
        .style5
        {
            height: 23px;
        }
    </style>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="1350" align="center">
                <tr height="50">
                    <td class="Style2" align="center">
                        不良资产（<asp:Label ID="tjkind" runat="server"></asp:Label>）项目处置情况统计(<%=DateTime.Parse(Request["time0"]).ToString("yyyy年M月d日")%>～<%=DateTime.Parse(Request["time1"]).ToString("yyyy年M月d日")%>)
                    </td>
                </tr>
            </table>
            <table width="1350" align="center" cellpadding="1" cellspacing="1" bgcolor="black"
                style="border: solid 1pt black">
                <colgroup>
                    <col width="80" align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                    <col align="center" bgcolor="white" />
                </colgroup>
                <tr>
                    <td rowspan="3">
                        <b>部门</b>
                    </td>
                    <td rowspan="3">
                        <b>申报<br />
                            项目</b>
                    </td>
                    <td colspan="3">
                        <b>项目审批情况 </b>
                    </td>
                    <td class="style1" colspan="23">
                        <b>项 目 执 行 情 况</b>
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">
                        <b>批准<br />
                            项目</b>
                    </td>
                    <td colspan="2">
                        &nbsp; <b>其中</b>
                    </td>
                    <td rowspan="2">
                        <b>协商<br />
                            处置</b>
                    </td>
                    <td class="style2" colspan="4">
                        <b>其中</b>
                    </td>
                    <td rowspan="2">
                        <b>诉讼<br />
                            处置</b>
                    </td>
                    <td class="style2" colspan="8">
                        <b>其中</b>
                    </td>
                    <td rowspan="2">
                        <b>其他<br />
                            处置</b>
                    </td>
                    <td class="style2" colspan="8">
                        <b>其中</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        审核<br />
                        会批
                    </td>
                    <td>
                        决策<br />
                        会批
                    </td>
                    <td class="style3">
                        谈判
                    </td>
                    <td class="style3">
                        签订<br />
                        协议
                    </td>
                    <td class="style3">
                        部分<br />
                        执行
                    </td>
                    <td class="style3">
                        全部<br />
                        执行
                    </td>
                    <td class="style3">
                        立案
                    </td>
                    <td class="style3">
                        财产<br />
                        保全
                    </td>
                    <td class="style3">
                        一审
                    </td>
                    <td class="style3">
                        二审
                    </td>
                    <td class="style3">
                        申请<br />
                        执行
                    </td>
                    <td class="style3">
                        结案
                    </td>
                    <td class="style3">
                        中止<br />
                        执行
                    </td>
                    <td class="style3">
                        终止<br />
                        执行
                    </td>
                    <td class="style3">
                        打包<br />
                        处置
                    </td>
                    <td class="style3">
                        委托<br />
                        拍卖
                    </td>
                    <td class="style3">
                        合作<br />
                        处置
                    </td>
                    <td class="style3">
                        委托<br />
                        追踪
                    </td>
                    <td class="style3">
                        债券<br />
                        重组
                    </td>
                    <td class="style3">
                        破产<br />
                        清偿
                    </td>
                    <td class="style3">
                        其他
                    </td>
                    <td class="style3">
                        其他
                    </td>
                </tr>
                <asp:Repeater ID="repeater2" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="style4">
                                <%#Eval("col1") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col2") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col3") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col4") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col5") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col6") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col7") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col8") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col9") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col10") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col11") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col12") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col13") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col14") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col15") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col16") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col17") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col18") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col19") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col20") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col21") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col22") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col23") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col24") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col25") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col26") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col27") %>
                            </td>
                            <td class="style4">
                                <%#Eval("col28") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                   
                </asp:Repeater>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
