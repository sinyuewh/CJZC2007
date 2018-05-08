<%@ page language="C#" autoeventwireup="true" inherits="ShowMessage, App_Web_svbsm3je" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>浏览短消息</title>

    <script language="javascript">
                
        function SendMessage(sname1)
        {
            var str1='<%#Application["root"]%>/Info/WriteMessage.aspx?tousers='+escape(sname1);
            window.open(str1,"","top=100,left=100,width=500,height=200");
        }
    </script>

</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td height="5">
                    </td>
                </tr>
            </table>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                        <colgroup>
                            <col bgcolor="white" align="center" width="10%" />
                            <col bgcolor="white" align="center" width="15%" />
                            <col bgcolor="white" align="left" />
                            <col bgcolor="white" align="center" width="15%" />
                        </colgroup>
                        <tr height="25" bgcolor="gainsboro">
                            <td colspan="7" align="Center">
                                <strong>您收到的最新短信息</strong>&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr height="25">
                            <th>
                                发件人
                            </th>
                            <th>
                                发件时间
                            </th>
                            <th>
                                短信息
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr height="25">
                        <td>
                            <%#Eval("fmen")%>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("id")%>' />
                        </td>
                        <td>
                            <%#Eval("time0")%>
                        </td>
                        <td>
                            <%#Eval("remark")%>
                        </td>
                        <td>
                            <a href="javascript:SendMessage('<%#Eval("fmen")%>');">回复</a>
                            <asp:LinkButton ID="LinkButton2" runat="server" Visible="false">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                    <table width="100%" align="center">
                        <tr height="3">
                            <td style="width: 3px">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <input id="Button1" type="button" value="关闭返回"  class="but" onclick="javaScript:window.close();" />
                            </td>
                        </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
