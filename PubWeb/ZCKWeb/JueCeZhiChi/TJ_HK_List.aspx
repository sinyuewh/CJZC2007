<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatHuiKuanInfo, App_Web_dr3prqpf" title="回款详细信息" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <script language="javascript" type="text/javascript">
 function WinOpen()
 {
    var url="TJ_HK_List_Print.aspx?dt1=<%#Request["dt1"]%>&dt2=<%#Request["dt2"]%>&depart=<%#Server.UrlEncode(Request["depart"])%>&zeren=<%#Server.UrlEncode(Request["zeren"])%>";
    window.open(url,"","location=no,Status=no,Menubar=yes,left=10,top=10,width=800,height=600,Scrollbars=yes,resizable=yes");
 }
 
 </script>
 <table  width="100%">
    <tr>
        <td align="right">
            <a class="blue2" href="javaScript:WinOpen();">打印回款统计详细信息</a>
        </td>
    </tr>
 </table>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        SkinID="gridviewSkin" EnableViewState="False">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单位名称">
                <HeaderStyle Width="38%" />
                <ItemTemplate>
                    <a class="blue1" href="javaScript:OpenTJ_HK_List('<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("zcid") %>','<%# Eval("zcid") %>');"
                        title='<%# Eval("danwei") %>'>
                        <%# Eval("danwei1") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单据编号">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("bill") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bxhj" HeaderText="还本息和(￥)" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="zeren" HeaderText="责任人">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    
    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        SkinID="gridviewSkin" EnableViewState="False">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <%# this.GridView2.PageIndex * this.GridView2.PageSize 
                                         +this.GridView2.Rows.Count + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="资产包名称">
                <HeaderStyle Width="38%" />
                <ItemTemplate>
                    <a class="blue1" href="javaScript:OpenTJ_HK_List('<%#Application["root"] %>/ZcMng2/ZcBaoDetail1.aspx?id=<%# Eval("bid") %>','<%# Eval("bid") %>');"
                        title="<%# Eval("bname") %>">
                        <%# Eval("bname") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单据编号">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("bill") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bxhj" HeaderText="还本息和(￥)" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bzeren" HeaderText="责任人">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    
    <script language="javascript">
        function OpenTJ_HK_List(url1,id)
        {
            if(id!="")
            {
                location.href=url1;
            }
        }
    </script>
</asp:Content>
