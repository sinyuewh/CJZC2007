<%@ control language="C#" autoeventwireup="true" inherits="Common_Controls_Header, App_Web_aj5ajsvo" %>

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
    bgcolor="#f5f5f5">
    <tr>
        <td height="90" background="<%#Application["root"] %>/Common/Image/Corp/banner.jpg"
            align="right" valign="middle">
        </td>
    </tr>
    <tr>
        <td>
            <table bgcolor="#000000" border="0" bordercolordark="#ffffff" width="100%" align="center">
                <tr height="22">
                    <td width="16%">
                        <font color="#FFFFff">【<%#Page.User.Identity.Name%>】欢迎您回来！</font>
                    </td>
                    <td align="right">
                        <table id="tabInfo1" runat="server">
                            <tr>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/default.aspx"><font color="#FFFF00">首页</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/ZcMng1/MyZc.aspx"><font color="#FFFF00">资产现状</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/ZcMng3/fangan1.aspx"><font color="#FFFF00">资产处置</font></a>
                                </td>
                                <td align="center" width="1" id="CWZX1" runat="server">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" id="CWZX2" runat="server" onmouseout="JavaScript:this.bgColor='';"
                                    onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/Caiwu/ZcSearch.aspx"><font color="#FFFF00">财务中心</font></a>
                                </td>
                                <td align="center" width="1" id="JCZC1" runat="server">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" id="JCZC2" runat="server" onmouseout="JavaScript:this.bgColor='';"
                                    onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/JueCeZhiChi/St1.aspx"><font color="#FFFF00">决策支持</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/DangAn/DangAnSearch.aspx"><font color="#FFFF00">档案管理</font></a>
                                </td>
                                <%--<td align="center" width="1" >
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';"
                                    onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"] %>/Info/InfoBrowse.aspx"><font color="#FFFF00">资讯平台</font></a>
                                </td>--%>
                               <%-- <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"] %>/Info/MyRcaiPai.aspx"><font color="#FFFF00">日程安排</font></a>
                                </td>--%>
                                <td align="center" width="1" id="SYS_Menu1" runat="server">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" id="SYS_Menu2" runat="server" onmouseout="JavaScript:this.bgColor='';"
                                    onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/XtGL/XtGlIndex.aspx"><font color="#FFFF00">系统管理</font></a>
                                </td>
                               <%-- <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="javaScript:WinOpenHeader();"><font color="#FFFF00">在线用户</font></a>
                                </td>--%>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/ZcMng1/ZcLogSearch.aspx"><font color="#FFFF00">资产日志</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/ZcMng1/HuiKuanPlanSearch.aspx"><font color="#FFFF00">
                                        回款计划</font></a>
                                </td>
                            </tr>
                        </table>
                        <table id="tabInfo2" runat="server">
                            <tr>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/default.aspx"><font color="#FFFF00">首页</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"]%>/ZcMng1/LawGwList.aspx"><font color="#FFFF00">资产现状</font></a>
                                </td>
                                <td align="center" width="1">
                                    <font color="#ffffff">&nbsp;|&nbsp;</font>
                                </td>
                                <td align="center" onmouseout="JavaScript:this.bgColor='';" onmouseover="JavaScript:this.bgColor='#4B6DC0';JavaScript:this.style.cursor='hand';">
                                    <a href="<%#Application["root"] %>/Info/ReceiveMail.aspx"><font color="#FFFF00">资讯平台</font></a>
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
