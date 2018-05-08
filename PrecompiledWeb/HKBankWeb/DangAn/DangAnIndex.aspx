<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_DangAnIndex, App_Web_widkftde" title="案卷列表" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin"
                    DataKeyNames="id" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ajnum" HeaderText="编号">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="分类" DataField="ajkind">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="案卷名称">
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/DangAn/AnJuanDetail.aspx?id=<%# Eval("id") %>">
                                    <%# Eval("ajname") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField HeaderText="立卷时间" DataField="time0" DataFormatString="{0:yyyy-MM-dd}"
                            HtmlEncode="False">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="状态">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="ajstatus" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
