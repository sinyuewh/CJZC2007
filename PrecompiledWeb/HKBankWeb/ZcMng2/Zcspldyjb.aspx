<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_Zcspldyjb, App_Web_0lscwnk0" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产审批领导意见表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <br />
        <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="center" width="12%" />
                <col bgcolor="white" align="center" width="12%" />
                <col bgcolor="white" align="center" width="12%" />
                <col bgcolor="white" align="center" width="12%" />
                <col bgcolor="white" align="center" width="12%" />
                <col bgcolor="white" align="left" />
            </colgroup>
            <tr height="25">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 0pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    <strong>项目申报号：</strong>
                </td>
                <td colspan="2" align="left" style="border-right: solid 1pt #000000; border-bottom: solid 0pt #000000;
                    height: 30px; border-top: solid 1pt #000000">
                    <asp:Label ID="lab1" runat="server"></asp:Label><br />
                </td>
                <td colspan="2" style="border-right: solid 1pt #000000; border-bottom: solid 0pt #000000;
                    height: 30px; border-top: solid 1pt #000000">
                    <strong>项目档案号：</strong>
                </td>
                <td style="border-right: solid 0pt #000000; border-bottom: solid 0pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    <asp:Label ID="lab2" runat="server"></asp:Label><br />
                </td>
            </tr>
            <tr height="25">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 0pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    <strong>项目名称：</strong>
                </td>
                <td colspan="5" align="left" style="border-right: solid 0pt #000000; border-bottom: solid 0pt #000000;
                    height: 30px; border-top: solid 1pt #000000">
                    <asp:Label ID="lab3" runat="server"></asp:Label><br />
                </td>
            </tr>
            <tr height="30">
                <td colspan="6" align="center" bgcolor="gainsboro" style="height: 30px; border-top: solid 1pt #000000">
                    <strong>领 导 审 批 意 见</strong></td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    部门
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    批阅人
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    批次
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    批阅时间
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;
                    border-top: solid 1pt #000000">
                    批阅
                </td>
                <td align="center" style="border-bottom: solid 1pt #000000; height: 30px; border-top: solid 1pt #000000">
                    具体意见</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr height="30">
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("depart") %>
                            &nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <asp:Label ID="zx" runat="server" Text='<%#Eval("zx") %>' Visible="false"></asp:Label>
                            <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>&nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("pscount") %>
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("time1","{0:yyyy-MM-dd hh:mm:ms}") %>
                            <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>&nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("ps") %>
                            &nbsp;
                        </td>
                        <td style="border-bottom: solid 1pt #000000; height: 30px;">
                            <%#Eval("remark") %>
                            &nbsp;
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
    </form>
</body>
</html>
