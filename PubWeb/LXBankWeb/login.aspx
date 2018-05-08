<%@ page language="C#" autoeventwireup="true" inherits="login, App_Web_ueve7moi" stylesheettheme="CjzcWeb" %>

<html>
<head id="Head1" runat="server">
    <title>系统登录</title>

    <script language="javascript">
        function setFocus() {
            //设置密码为接收焦点（jin）
            document.forms[0].password.focus();
        }
        function CheckEnter() {
            if (window.event.keyCode == 13) {
                document.forms[0].password.focus();
            }
        }

        function CheckEnter1() {
            if (window.event.keyCode == 13) {
                butLogin();
            }
        }

        function butLogin() {
            if (document.forms[0].username.value == "") {
                alert("错误提示：请输入用户名！");
                document.forms[0].username.focus();
                return false;
            }

            if (document.forms[0].password.value == "") {
                alert("错误提示：请输入登录密码！");
                document.forms[0].password.focus();
                return false;
            }

            document.forms[0].submit();
        }
    </script>

</head>
<body onload="setFocus();">
    <form id="form1" runat="server">
    <table width="790" align="center" border="0" height="100%">
        <tr>
            <td id="Td1" valign="middle" align="center" background="<%#Application["root"]%>/Common/Image/corp/loginBack.jpg"
                height="590" runat="server" style ="background-repeat:no-repeat">
                <br>
                <br>
                <table height="376" width="100%" border="0">
                    <tr>
                        <td width="301" height="135" style="height: 135px">
                        </td>
                        <td valign="bottom" bordercolor="#999999" width="483" colspan="3" height="135" style="height: 135px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="46">
                        </td>
                        <td valign="middle" bordercolor="#999999" width="483" colspan="3" height="46">
                            <p align="center">
                                <span style="font-weight: 700; letter-spacing: 2px"><font face="隶书" color="#003073"
                                    size="6">长江资产经营管理有限公司<br />
                                </font></span><span style="font-weight: 700; letter-spacing: 2px"><font color="#003073"
                                    face="隶书" size="6">资产信息管理系统<br>
                                </font></span>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="301" height="79">
                        </td>
                        <td width="111" height="79">
                        </td>
                        <td align="left" width="368" colspan="2" height="79">
                            <font face="宋体"></font>
                            <br>
                            <table width="100%" border="0">
                                <tr>
                                    <td colspan="2">
                                        用 户 ID：<asp:TextBox ID="username" runat="server" Width="130px" Height="23px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        登陆密码：<asp:TextBox ID="password" runat="server" TextMode="Password" Width="130px"
                                            Height="23px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table border="0">
                                            <tr>
                                                <td style="vertical-align: top">
                                                    访问数据：
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:RadioButtonList ID="db" runat="server">
                                                        <asp:ListItem Value="0" Text="政策资产库" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="联想资产库"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="50">
                                        <font face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <img src="Common/Image/corp/loginButton.gif" onclick="javaScript:butLogin();" style="cursor: hand;"
                                                id="IMG1" /></font> &nbsp;<a href="Common/DbUpgrade.aspx" target="_blank" class="blue"
                                                    style="display: none;">[数据库升级]</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="60">
                                        &nbsp; &nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
