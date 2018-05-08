<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_SeeZcTimeLog, App_Web_0lscwnk0" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>时效提醒日志</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="90%" align="center" border="0" cellpadding="0" cellspacing="0" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="center" width="8%" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
                <col bgcolor="white" align="center" />
            </colgroup>
            <tr height="25">
                <td style="border-bottom: solid 1px #c5c5c5">
                    序号
                </td>
                <td style="border-left: solid 1px #c5c5c5; border-bottom: solid 1px #c5c5c5">
                    单位名称
                </td>
                <td style="border-left: solid 1px #c5c5c5; border-bottom: solid 1px #c5c5c5">
                    时效类型
                </td>
                <td style="border-left: solid 1px #c5c5c5; border-bottom: solid 1px #c5c5c5">
                    提醒时间
                </td>
                <td style="border-left: solid 1px #c5c5c5; border-bottom: solid 1px #c5c5c5">
                    提醒用户
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr height="25">
                        <td>
                            <%#Container.ItemIndex+1 %>
                        </td>
                        <td style="border-left: solid 1px #c5c5c5">
                            <%#Eval("danwei") %>
                        </td>
                        <td style="border-left: solid 1px #c5c5c5">
                            <%#Eval("TimeTypeName")%>
                        </td>
                        <td style="border-left: solid 1px #c5c5c5">
                            <%#Eval("LogTime") %>
                        </td>
                        <td style="border-left: solid 1px #c5c5c5">
                            <%#Eval("LogUser") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
