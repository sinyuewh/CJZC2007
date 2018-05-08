<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_Zcsxxxb, App_Web_zpfhjo5e" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产时效信息表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <tr height="40">
                <td align="center">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司资产时效信息表</strong></p>
                </td>
            </tr>
            <tr>
                <td height="1" bgcolor="black">
                </td>
            </tr>
            <tr>
                <td width="50%" align="left">
                    <asp:Label ID="time" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <colgroup>
                <col align="center" width="20%" />
                <col align="center" />
                <col align="center" />
                <col align="center" />
                <col align="center" />
            </colgroup>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    单位名称</td>
                <td colspan="4" align="left" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="depart" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    时效名称</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    时效日期</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    提前警告</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                    警告日期</td>
                <td style="border-bottom: solid 1pt #000000">
                    备注</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr height="30">
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                            <%#Eval("TimeName")%>&nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                            <%#Eval("ZcTime","{0:yyyy-MM-dd}") %>&nbsp;
                        </td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                            <%#Eval("tellday") %>&nbsp;
                            （天）</td>
                        <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000">
                            <%#Eval("ZcTime0","{0:yyyy-MM-dd}")%>&nbsp;
                            <asp:Literal ID="redStar" runat="server"></asp:Literal>
                        </td>
                        <td style="border-bottom: solid 1pt #000000">
                            <%#Eval("remark")%>&nbsp;
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </form>
</body>
</html>
