<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_InfoHead, App_Web_pnvmybnf" %>

<script language="javascript" src="<%#Application["root"] %>/Common/Script/calendar.js">
</script>

<script language="javascript" src="<%#Application["root"] %>/Common/Script/Common.js"></script>

<script language="javascript" type="text/javascript">
function WinOpenHeader()
{
   var url="<%#Application["root"]%>/OnLineUser.aspx";
   window.open(url,"OnLineUserWindow","left=600,top=20,height=600,width=200,Scrollbars=yes");
}
</script>

<table width="100%" align="center" cellpadding="0" cellspacing="0" bordercolor="#c4cad0"
    border="0" bgcolor="#f5f5f5">
    <tr>
        <td height="90" background="<%#Application["root"] %>/Common/Image/Corp/banner.jpg"
            align="right">
        </td>
    </tr>
    <tr>
        <td>
            <table bgcolor="#000000" border="0" bordercolordark="#ffffff" width="100%" align="center"
                id="info1" runat="server">
                <tr height="22">
                    <td width="16%">
                        <font color="#FFFFff">【<%#Page.User.Identity.Name%>】欢迎您回来！</font>
                    </td>
                    <td align="right">
                        <table id="tabInfo1" runat="server">
                            <tr>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"] %>/Info/InfoBrowse.aspx"><font color="#FFFF00">资讯平台</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"] %>/Info/MyRcaiPai.aspx"><font color="#FFFF00">日程安排</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="javaScript:WinOpenHeader();"><font color="#FFFF00">在线用户</font></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
