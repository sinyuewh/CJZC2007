<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_ZcBaoZcDetail, App_Web_o8vl6oai" title="资产包中资产" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                        <asp:BoundField DataField="time0" HeaderText="转入时间" DataFormatString="{0:yyyy-MM-dd}"
                            HtmlEncode="False">
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
                        <asp:BoundField DataField="statusText" HeaderText="当前状态">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
</asp:Content>

