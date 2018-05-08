<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_ueve7moi" stylesheettheme="CjzcWeb" %>

<%@ Import Namespace="System.Collections" %>
<%@ Register Src="~/Common/Controls/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="~/Common/Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>系统首页</title>

    <script language="javascript" type ="text/javascript">
        var gt1 = window.setInterval(setWindowTime, 600);
        function setWindowTime() {
            var lsp1 = document.getElementById("time0");
            var ltime = new Date();
            var lday = ltime.getDay();
            ldays = "";
            switch (lday) {
                case 0:
                    ldays = "星期日";
                    break;
                case 1:
                    ldays = "星期一";
                    break;
                case 2:
                    ldays = "星期二";
                    break;
                case 3:
                    ldays = "星期三";
                    break;
                case 4:
                    ldays = "星期四";
                    break;
                case 5:
                    ldays = "星期五";
                    break;
                case 6:
                    ldays = "星期六";
                    break;
            }

            //计算时间
            lh = ltime.getHours();
            if (lh < 10) {
                lh = "0" + lh;
            }
            else {
                lh = lh + "";
            }

            lm = ltime.getMinutes();
            if (lm < 10) {
                lm = "0" + lm;
            }
            else {
                lm = lm + "";
            }

            ls = ltime.getSeconds();
            if (ls < 10) {
                ls = "0" + ls;
            }
            else {
                ls = ls + "";
            }

            lsp1.innerText = lh + ":" + lm + ":" + ls + "  " + ldays;

        }
               
            
    </script>

</head>
<body>

    <script language="javascript" type="text/javascript">
        
    </script>

    <form id="form1" runat="server">
    <div>
        <table width="99%" align="center" border="0" bgcolor="#f6f6f6" height="100%">
            <tr>
                <td colspan="3" width="100%" height="30">
                    <uc1:Header ID="Header1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="15%" height="100%" bgcolor="#DEEAEA" valign="top" style="border-right-width: 1pt;
                    border-right-style: solid; border-right-color: #46316c">
                    &nbsp;
                </td>
                <td valign="top">
                    <table width="95%" border="0" cellpadding="1" style="margin-top: 10px" cellspacing="1"
                        align="center" bgcolor="#c5c5c5">
                        <colgroup>
                            <col align="right" width="15%" />
                            <col align="left" />
                        </colgroup>
                        <tr bgcolor="white">
                            <td height="25" colspan="2" align="Right">
                                <span id="time0" style="font-size: 14pt; font-weight: bold"></span>&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr bgcolor="white">
                            <td height="25" colspan="2" align="center">
                                <b>欢迎您，<asp:Label ID="username" runat="server"></asp:Label>，今天是您第
                                    <asp:Label ID="labLogin" runat="server">1</asp:Label>
                                    次登录系统，祝您工作愉快。</b>
                            </td>
                        </tr>
                        <tr bgcolor="white" id="count3" runat="server">
                            <td height="25">
                                批阅申请&nbsp;
                            </td>
                            <td>
                                &nbsp;资产&nbsp;<asp:HyperLink ID="HyperZc" runat="server" Font-Bold="true" Font-Underline="true"
                                    NavigateUrl="~/ZcMng3/fangan4.aspx">0</asp:HyperLink>&nbsp;个 &nbsp;资产包&nbsp;<asp:HyperLink
                                        ID="HypZcb" runat="server" Font-Bold="true" Font-Underline="true" NavigateUrl="~/ZcMng1/ShenPiZcBIng.aspx">0</asp:HyperLink>&nbsp;个
                            </td>
                        </tr>
                        <tr bgcolor="white">
                            <td height="25">
                                个人时效警告&nbsp;
                            </td>
                            <td>
                                <table width="100%" align="center" border="0" cellpadding="0"
                                 cellspacing="0" bgcolor="#c5c5c5"   >
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="8%" />
                                        <col bgcolor="white" align="center" />
                                        <col bgcolor="white" align="center" />
                                        <col bgcolor="white" align="center" />
                                        <col bgcolor="white" align="center" />
                                    </colgroup>
                                    <tr height="25">
                                        <td style ="border-bottom:solid 1px #c5c5c5">
                                            序号
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            单位名称
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            时效类型
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            时效日期
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            提醒日志
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="Repeater1" runat="server"  >
                                        <ItemTemplate>
                                            <tr height="25">
                                                <td>
                                                    <%#Container.ItemIndex+1 %>
                                                    <asp:Label ID="timeid" Visible ="false" runat ="server" Text ='<%#Eval("id") %>'></asp:Label>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <a class ="blue" href='<%=Application["root"]%>/ZcMng2/ZcDetail1.aspx?id=<%#Eval("zcid") %>' target="_blank"><%#Eval("danwei") %></a>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <%#Eval("TimeTypeName")%>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <%#Eval("time0","{0:yyyy-MM-dd}") %>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <a class="blue1" target="_blank" href='<%=Application["root"]%>/ZcMng2/SeeZcTimeLog.aspx?timeid=<%#Eval("id") %>'>查看</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="white">
                            <td height="25">
                                他人时效警告&nbsp;
                            </td>
                            <td>
                                <table width="100%" align="center" border="0" cellpadding="0" 
                                cellspacing="0" bgcolor="#c5c5c5" >
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="8%" />
                                        <col bgcolor="white" align="center" />
                                        <col bgcolor="white" align="center" />
                                        <col bgcolor="white" align="center" />
                                        <col bgcolor="white" align="center" />
                                    </colgroup>
                                    <tr height="25">
                                        <td style ="border-bottom:solid 1px #c5c5c5">
                                            序号
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            单位名称
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            时效类型
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            时效日期
                                        </td>
                                        <td style ="border-left:solid 1px #c5c5c5;border-bottom:solid 1px #c5c5c5">
                                            提醒日志
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="Repeater2" runat="server" EnableViewState="false" >
                                        <ItemTemplate>
                                            <tr height="25">
                                                <td>
                                                    <%#Container.ItemIndex+1 %>
                                                    <asp:Label ID="timeid" Visible ="false" runat ="server" Text ='<%#Eval("id") %>'></asp:Label>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <a class ="blue" href='<%=Application["root"]%>/ZcMng2/ZcDetail1.aspx?id=<%#Eval("zcid") %>' target="_blank"><%#Eval("danwei") %></a>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <%#Eval("TimeTypeName")%>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <%#Eval("time0","{0:yyyy-MM-dd}") %>
                                                </td>
                                                <td style ="border-left:solid 1px #c5c5c5">
                                                    <a class="blue1" target="_blank" href='<%=Application["root"]%>/ZcMng2/SeeZcTimeLog.aspx?timeid=<%#Eval("id") %>'>查看</a>
                                                </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="15%" height="100%" bgcolor="#DEEAEA" valign="top" style="border-left-width: 1pt;
                    border-left-style: solid; border-left-color: #46316c">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" width="100%" height="30">
                    <uc2:footer ID="Footer1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
