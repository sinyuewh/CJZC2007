<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_ZcBaoSearch, App_Web_uiei8leb" title="资产包开票" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td height="30" align="right">
                资产包名称：<asp:TextBox ID="Bname" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />&nbsp;&nbsp;
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
            <asp:TemplateField HeaderText="资产包名称">
                <HeaderStyle Width="38%" />
                <ItemTemplate>
                    <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcBaoDetail1.aspx?id=<%# Eval("id") %>"
                        title="<%# Eval("bname") %>">
                        <%# Eval("bname") %>
                    </a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="bzeren" HeaderText="责任人">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bljsk" HeaderText="累计收款" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bljzc" HeaderText="累计支出" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="操作">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <a href="AddShouKuan1.aspx?bid=<%# Eval("id") %>" class="blue1">收款</a> | <a href="AddPay1.aspx?bid=<%# Eval("id") %>"
                        class="blue1">支出</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <br />
            <div align="center">
                没有符合条件的资产包。
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
