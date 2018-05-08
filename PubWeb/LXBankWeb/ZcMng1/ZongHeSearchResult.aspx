<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZiChan_ZongHeSearchResult, App_Web_jdf3giep" title="查询结果" enableviewstate="false" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function Button3_onclick() {

        }
        var first = "true";
        function tablevisible()
        {   
            if(document.getElementById("tab1")!=null)
            {
                if(first == "true")
                {
                    document.getElementById("tab1").style.display="";
                    <%#this.lab1.ClientID%>.innerText = "隐藏查询条件<<";
                    first = "false";
                }
                else
                {
                    document.getElementById("tab1").style.display="none";
                    <%#this.lab1.ClientID%>.innerText = ">>显示查询条件";
                    first = "true";
                }
            }
        }
        function WinOpen()
        {
             var url="ZCcxjgb.aspx";     
             window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
        }
    </script>

    <table width="99%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="white">
        <tr height="20">
            <td align="right">
                <a id="but1" class="blue2" href="javaScript:tablevisible();">
                    <asp:Label ID="lab1" runat="server" Text=">>显示查询条件"></asp:Label></a> &nbsp;&nbsp;&nbsp;&nbsp;
                <a class="blue2" href="javaScript:WinOpen();">打印查询结果</a>
            </td>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Label ID="zcid" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" border="0">
        <tr>
            <td>
                <table width="99%" id="tab1" align="left" border="0" cellpadding="1" cellspacing="1"
                    bgcolor="#c5c5c5" visible="true" style="display: none">
                    <colgroup>
                        <col bgcolor="white" align="right" width="20%" />
                        <col bgcolor="white" align="left" width="30%" />
                        <col bgcolor="white" align="right" width="20%" />
                        <col bgcolor="white" align="left" />
                    </colgroup>
                    <tr height="25">
                        <td colspan="4" align="center" bgcolor="#5d7b9d">
                            <strong><font color="#ffffff">资 产 的 检 索 条 件</font></strong>
                        </td>
                    </tr>
                    <tr height="25">
                        <td>
                            单位名称：</td>
                        <td>
                            <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            政策包类别：</td>
                        <td>
                            <asp:Label ID="zcbao" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr height="25">
                        <td>
                            责任部门：</td>
                        <td>
                            <asp:Label ID="depart" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            责 任 人：</td>
                        <td>
                            <asp:Label ID="zeren" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr height="25">
                        <td>
                            行政区域：</td>
                        <td>
                            <asp:Label ID="quyu" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            打包分类：
                        </td>
                        <td>
                            <asp:Label ID="bstatus" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr height="25">
                        <td>
                            行业分类：</td>
                        <td>
                            <asp:Label ID="hangye" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            行业性质分类：</td>
                        <td>
                            <asp:Label ID="fenlei" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr height="25">
                        <td>
                            资产状态：</td>
                        <td>
                            <asp:Label ID="status" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            用户自定义分类：</td>
                        <td>
                            <asp:Label ID="userkind" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" EnableViewState="false">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="num2" HeaderText="档案号">
                            <HeaderStyle HorizontalAlign="Center" Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="单位名称">
                            <HeaderStyle Width="25%" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                                    title="<%# Eval("danwei") %>">
                                    <%# Eval("danwei1") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="bj" HeaderText="初始本金" DataFormatString="{0:N2}" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bxhj" HeaderText="利息" DataFormatString="{0:N2}" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="本息合计">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <%#String.Format("{0:N2}",Eval("hjbx"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="depart" HeaderText="责任部门">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="zeren" HeaderText="责任人">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="zeren1" HeaderText="协管员">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <br />
                        <div align="center">
                            没有满足您查询条件的数据，请重新查询。<a href="<%#Application["root"] %>/ZcMng1/ZongHeSearch.aspx" class="blue">重新查询</a>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
