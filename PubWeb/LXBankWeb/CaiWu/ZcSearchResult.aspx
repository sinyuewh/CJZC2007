<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_SearchResult, App_Web_e5meitto" title="查询结果" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <asp:BoundField DataField="num2" HeaderText="档案号">
                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="单位名称">
                <HeaderStyle Width="30%" />
                <ItemTemplate>
                    <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                        title="<%# Eval("danwei") %>" target="_blank">
                        <%# Eval("danwei1") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="zeren" HeaderText="责任人">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bj" HeaderText="初始本金" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bxhj" HeaderText="利息" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            
            <asp:TemplateField HeaderText="操作">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <a href="AddShouKuan.aspx?zcid=<%# Eval("id") %>" class="blue1">收款</a> |
                    <a href="AddPay.aspx?zcid=<%# Eval("id") %>" class="blue1">支出</a> |
                    <a href="AddInStock.aspx?zcid=<%# Eval("id") %>" class="blue1">入库</a> |
                    <a href="AddOutStock.aspx?zcid=<%# Eval("id") %>" class="blue1">出库</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <br />
            <div align="center">
                没有满足您查询条件的数据，请重新查询。<a href="ZcSearch.aspx" class="blue">重新查询</a>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
