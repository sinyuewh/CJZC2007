<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_ZcBaoBillSearchResult, App_Web_0kwdbjis" title="资产包单据浏览" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        SkinID="gridviewSkin"  OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound">
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
                    <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcBaoDetail1.aspx?id=<%# Eval("bid") %>"
                        title="<%# Eval("bname") %>">
                        <%# Eval("bname") %>
                    </a>
                    <asp:Label ID="bname" runat="server" Text='<%# Eval("bname") %>' Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="单据编号">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    [<%# Eval("billkind") %>]<asp:Label ID="Label1" runat="server" Text='<%# Bind("bill") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bxhj" HeaderText="还本息和" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bzeren" HeaderText="责任人">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="操作">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <a href="<%# Eval("EditASP") %>?id=<%# Eval("id") %>" class="blue1">
                        <asp:Label ID="Liulan" runat="server" Text="浏览"></asp:Label></a>
                                             
                     <asp:LinkButton ID="dellinBtn" runat="server" CommandName="Delete" CssClass="blue" Text="删除"
                       CommandArgument='<%# Eval("id") %>'   OnClientClick="JavaScript:return confirm('警告：确定要删除吗？')" ></asp:LinkButton>
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <br />
            <div align="center">
                没有满足您查询条件的数据，请重新查询。<a href="ZcBaoBillSearch.aspx" class="blue">重新查询</a>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
