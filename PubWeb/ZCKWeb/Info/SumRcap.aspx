<%@ page language="C#" autoeventwireup="true" inherits="Info_SumRcap, App_Web_6dm0odi6" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>日常安排汇总统计</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="98%" bgcolor="#c5c5c5" align="center" cellpadding="1" cellspacing="1">
                <colgroup>
                    <col width="15%" bgcolor="white" align="center" />
                    <col width="30%" bgcolor="white" align="left" />
                    <col bgcolor="white" align="left" />
                </colgroup>
                <tr height="25" bgcolor="#ccffcc">
                    <td>
                        <b>日程时间</b>
                    </td>
                    <td>
                        <b>安排摘要</b>
                    </td>
                    <td>
                        <b>详细安排</b>
                    </td>
                </tr>
                <asp:Repeater ID="repeater1" runat="server">
                    <ItemTemplate>
                        <tr height="25" bgcolor="white">
                            <td>
                                <%#Eval("plantime","{0:yyyy-MM-dd dddd}") %>
                            </td>
                            <td>
                                <%#Eval("subject")%>
                            </td>
                            <td>
                                <%#Eval("remark")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
