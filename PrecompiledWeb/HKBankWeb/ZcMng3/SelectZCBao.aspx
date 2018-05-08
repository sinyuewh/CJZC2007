<%@ page language="C#" masterpagefile="~/Common/Master/Zcsp.master" autoeventwireup="true" inherits="ZcMng3_SelectZCBao, App_Web_ubawstme" title="选中资产包数据" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
    function myAddZc(zcid1,zccount1)
    {
       var result=true;
       if(zccount1!=0)
       {
          result=confirm("提示：该资产包曾经处置过["+zccount1+"]次，你确定需要再次处置吗？");
       }
       if(result)
       {
          top.location.href="AddSbb.aspx?zcbid="+zcid1;
       }
    }
</script>
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
            <asp:TemplateField HeaderText="资产包名称">
                <HeaderStyle Width="38%" />
                <ItemTemplate>
                    <a target="_blank" class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcBaoDetail1.aspx?id=<%# Eval("id") %>"
                        title="<%# Eval("bname") %>">
                        <%# Eval("bname") %>
                    </a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="bjsf" HeaderText="接收方">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bljsk" HeaderText="累计收款">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bljzc" HeaderText="累计支出">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="操作">
                <ItemStyle HorizontalAlign="center" Width="10%" />
                <ItemTemplate>
                    <asp:HyperLink CssClass="blue1" ID="HyperLink1" runat="server" ToolTip="增加资产包处置表"><u>增加&gt;&gt;</u></asp:HyperLink>
                    
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="次" Visible="false">
                <ItemStyle HorizontalAlign="center" Width="5%" />
                <ItemTemplate>
                    <asp:HyperLink ID="ChuZhiCount" runat="server" Text="0"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <br />
            <div align="center">
                没有满足您查询条件的数据，请重新查询。
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
