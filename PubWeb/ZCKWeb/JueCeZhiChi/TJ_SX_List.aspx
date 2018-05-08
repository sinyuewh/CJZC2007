<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_TJ_SX_List, App_Web_dr3prqpf" title="时效资产统计列表" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        EnableViewState="False" SkinID="gridviewSkin">
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
                    <a class="blue1" href='<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>'
                        title='<%# Eval("danwei") %>' target="_blank">
                        <%# Eval("danwei1") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="bj" DataFormatString="{0:N2}" HeaderText="初始本金" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bxhj" DataFormatString="{0:N2}" HeaderText="利息" HtmlEncode="False">
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
        </Columns>
    </asp:GridView>
</asp:Content>

