<%@ page language="C#" masterpagefile="~/Common/Master/JueCe1.master" autoeventwireup="true" inherits="JueCeZhiChi_StatZhiChuInfo, App_Web_uajp-wst" title="支出详细信息" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
     function WinOpen()
     {
        var url="TJ_ZhiChu_List_Print.aspx?dt1=<%#Request["dt1"]%>&dt2=<%#Request["dt2"]%>&depart=<%#Server.UrlEncode(Request["depart"])%>&zeren=<%#Server.UrlEncode(Request["zeren"])%>";
        window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
     }
     
     function OpenDetail(url1,id)
     {
        if(id!="")
        {
            location.href=url1;
        }
     }
    </script>

    <table width="99%" align="center">
        <tr>
            <td align="left">
                <a class="blue2" title="打印当前的支出清单" href="javaScript:WinOpen();"><u>打印支出统计详细信息>></u></a>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="blue2" href="javaScript:window.close();"><u>关闭页面</u></a>
            </td>
        </tr>
    </table>
    
    <div id="SelectStatInfo" style="overflow-x: auto; width: 800px; margin-bottom: 2pt;margin-top: 2pt; vertical-align: top; height:390px;">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            SkinID="gridviewSkin" EnableViewState="False" Width="1300px">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单位名称">
                    <HeaderStyle Width="18%" />
                    <ItemTemplate>
                        <a class="blue1" href="javaScript:OpenDetail('<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("zcid") %>','<%# Eval("zcid") %>');"
                            title="<%# Eval("danwei") %>">
                            <%# Eval("danwei1") %>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                    HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="费用合计" DataField="fyhj" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="申请费" DataField="fee1" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="律师费" DataField="fee2" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="诉讼费" DataField="fee3" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="执行费" DataField="fee4" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="受理费" DataField="fee5" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="仲裁费" DataField="fee6" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="评估费" DataField="fee7" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="物业费" DataField="fee8" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="过路费" DataField="fee9" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="fee10" HeaderText="招待费" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="信息费" DataField="fee11" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="其它费" DataField="fee12" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            SkinID="gridviewSkin" EnableViewState="False" Width="1300px">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                       <%# this.GridView2.PageIndex * this.GridView2.PageSize 
                                         +this.GridView2.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="资产包名称">
                    <HeaderStyle Width="18%" />
                    <ItemTemplate>
                        <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcBaoDetail1.aspx?id=<%# Eval("bid") %>"
                            title="<%# Eval("bname") %>">
                            <%# Eval("bname") %>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                    HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField HeaderText="费用合计" DataField="fyhj" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="申请费" DataField="fee1" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="律师费" DataField="fee2" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="诉讼费" DataField="fee3" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="执行费" DataField="fee4" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="受理费" DataField="fee5" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="仲裁费" DataField="fee6" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="评估费" DataField="fee7" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="物业费" DataField="fee8" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="过路费" DataField="fee9" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="fee10" HeaderText="招待费" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="信息费" DataField="fee11" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField HeaderText="其它费" DataField="fee12" DataFormatString="{0:C}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
    </div>
    <script language="javascript">
        var sel=document.getElementById("SelectStatInfo");
        var wid1=window.screen.availWidth*96/100;
        var wid2=Math.round(wid1);
        sel.style.width=wid2+"px";
    </script>
</asp:Content>
