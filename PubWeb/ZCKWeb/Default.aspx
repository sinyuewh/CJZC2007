<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_svbsm3je" stylesheettheme="CjzcWeb" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register Src="~/Common/Controls/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="~/Common/Controls/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>系统首页</title>
    <script language="javascript">
        var gt1=window.setInterval(setWindowTime,600);
        function setWindowTime()
        {
            var lsp1=document.getElementById("time0");
            var ltime=new Date();
            var lday=ltime.getDay();
            ldays="";
            switch(lday)
            {
                case 0:
                    ldays="星期日";
                    break;
                case 1:
                    ldays="星期一";
                    break;
                case 2:
                    ldays="星期二";
                    break;
                case 3:
                    ldays="星期三";
                    break;
                case 4:
                    ldays="星期四";
                    break;
                case 5:
                    ldays="星期五";
                    break;     
                case 6:
                    ldays="星期六";
                    break;
                }
                
                //计算时间
                lh=ltime.getHours();
                if(lh<10)
                {
                    lh="0"+lh;
                }
                else
                {
                    lh=lh+"";
                }
                
                lm=ltime.getMinutes();
                if(lm<10)
                {
                    lm="0"+lm;
                }
                else
                {
                    lm=lm+"";
                }
                
                ls=ltime.getSeconds();
                if(ls<10)
                {
                    ls="0"+ls;
                }
                else
                {
                    ls=ls+"";
                }
                
                lsp1.innerText=lh+":"+lm+":"+ls+"  "+ldays;
            
            }
               
            function SendMessage(sname1)
            {
                var str1="<%#Application["root"] %>/Info/WriteMessage.aspx?tousers="+escape(sname1);
                window.open(str1,"","top=100,left=100,width=500,height=200");
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
                    <td colspan="3" width="100%">
                        <uc1:Header ID="Header1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" height="100%" bgcolor="#DEEAEA" valign="top" style="border-right-width: 1pt;
                        border-right-style: solid; border-right-color: #46316c">
                        &nbsp;
                    </td>
                    <td valign="top">
                        <table>
                            <tr>
                                <td height="30">
                                </td>
                            </tr>
                        </table>
                        <table width="80%" border="0" cellpadding="1" cellspacing="1" align="center" bgcolor="#c5c5c5">
                            <colgroup>
                                <col align="right" width="30%" />
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
                            
                            <tr bgcolor="white" id="count1" runat ="server">
                                <td height="25">
                                    未读邮件&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:HyperLink ID="HypEmail" runat="server" Font-Bold="true" ForeColor="red"
                                        Font-Underline="true" NavigateUrl="~/Info/ReceiveMail.aspx">0</asp:HyperLink>
                                    封
                                </td>
                            </tr>
                            
                            <tr bgcolor="white" id="count2" runat ="server">
                                <td height="25">
                                    未读消息&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:HyperLink ID="HypMessage" runat="server" Font-Bold="true" Font-Underline="true"
                                        NavigateUrl="~/Info/ReceiveMessage.aspx">0</asp:HyperLink>
                                    封
                                </td>
                            </tr>
                            
                            <tr bgcolor="white" id="count3" runat ="server">
                                <td height="25">
                                    批阅申请&nbsp;
                                </td>
                                <td>
                                    &nbsp;资产&nbsp;<asp:HyperLink ID="HyperZc" runat="server" Font-Bold="true" Font-Underline="true"
                                        NavigateUrl="~/ZcMng3/fangan4.aspx">0</asp:HyperLink>&nbsp;个 &nbsp;资产包&nbsp;<asp:HyperLink
                                            ID="HypZcb" runat="server" Font-Bold="true" Font-Underline="true" NavigateUrl="~/ZcMng1/ShenPiZcBIng.aspx">0</asp:HyperLink>&nbsp;个
                                </td>
                            </tr>
                            
                            
                            <tr bgcolor="white" id="count4" runat ="server">
                                <td height="25">
                                    当前在线用户&nbsp;
                                </td>
                                <td>
                                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="horizontal" OnItemDataBound="DataList1_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server"><%#((DictionaryEntry)Container.DataItem).Value %></asp:HyperLink>
                                        </ItemTemplate>
                                        <SeparatorTemplate>
                                            ,</SeparatorTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            
                            <tr bgcolor="white" id="count5" runat ="server">
                                <td height="25">
                                    今天工作安排&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:HyperLink ID="HypToday" runat="server" NavigateUrl="~/Info/ReceiveMessage.aspx"></asp:HyperLink>
                                </td>
                            </tr>
                            
                            <tr bgcolor="white" id="count6" runat ="server">
                                <td height="25">
                                    本周工作安排&nbsp;
                                </td>
                                <td>
                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                                        SkinID="gridviewSkin" EnableViewState="false" DataKeyNames="ID"  BorderWidth="0"
                                        ShowHeader="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="日程安排" ItemStyle-HorizontalAlign="Left">
                                                <ItemStyle Width="75%" />
                                                <ItemTemplate>
                                                    <a class="blue1" href="<%#Application["root"] %>/Info/RcanpaiDetails.aspx?time0=<%# Eval("plantime","{0:yyyy-MM-dd}") %>">
                                                        <%#Eval("subject") %>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="plantime" HeaderText="日程时间" DataFormatString="{0:dddd}"
                                                HtmlEncode="False">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            
                            <tr bgcolor="white" id="count7" runat ="server">
                                <td height="25">
                                    个人时效警告&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:HyperLink ID="HypTime1" runat="server" Font-Bold="true" ForeColor="red"
                                        Font-Underline="true" NavigateUrl="~/ZcMng1/MyZcTime0.aspx">0</asp:HyperLink>
                                    个
                                </td>
                            </tr>
                            
                            <tr bgcolor="white" id="BLeader" runat="server">
                                <td height="25">
                                    部门时效警告&nbsp;
                                </td>
                                <td>
                                    &nbsp;<asp:HyperLink ID="HypTime2" runat="server" Font-Bold="true" ForeColor="red"
                                        Font-Underline="true" NavigateUrl="~/ZcMng1/MyDepartZcTime0.aspx">0</asp:HyperLink>
                                    个
                                </td>
                            </tr>
                            
                        </table>
                    </td>
                    <td width="15%" height="440" bgcolor="#DEEAEA" valign="top" style="border-left-width: 1pt;
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
