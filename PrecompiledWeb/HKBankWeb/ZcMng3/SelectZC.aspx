<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_SelectZC, App_Web_ubawstme" title="选择立项的资产数据" stylesheettheme="CjzcWeb" %>
<%@ Register Src="~/ZcMng1/AdvanceSearch.ascx" TagName="AdvanceSearch" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
    function myAddZc(zcid1,zccount1)
    {
       var result=true;
       if(zccount1!=0)
       {
          result=confirm("提示：该资产曾经处置过["+zccount1+"]次，你确定需要再次处置吗？");
       }
       if(result)
       {
          top.location.href="AddSbb.aspx?zcid="+zcid1;
       }
    }
</script>
    <table width="100%">
        <tr>
            <td height="30" align="right">
                单位名称：<asp:TextBox ID="danwei" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue2" OnClick="LinkButton1_Click">显示高级查询>></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;   
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr id="AdvanceRow" runat="server" visible="false">
            <td align="center" style="height: 252px">
                <uc1:advancesearch id="AdvanceSearch1" runat="server"></uc1:advancesearch>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" EnableViewState="False" OnRowDataBound="GridView1_RowDataBound">
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
                            <HeaderStyle Width="30%" />
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
                        <asp:TemplateField HeaderText="操作">
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" CssClass="blue1" runat="server" ToolTip="增加资产处置表"><u>增加&gt;&gt;</u></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="次">
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                            <ItemTemplate>
                                <asp:HyperLink ID="ChuZhiCount" runat="server" Text="0"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="选" Visible="false">
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                            <ItemTemplate>
                                <input type="checkbox" id="seldoc" value="" name="seldoc" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
       
    </table>
</asp:Content>
