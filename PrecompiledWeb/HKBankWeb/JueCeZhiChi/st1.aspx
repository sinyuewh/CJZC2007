<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_st1, App_Web_uajp-wst" title="公司资产统计" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        SkinID="gridviewSkin" EnableViewState="False" Width="99%">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="资产状态">
                <ItemTemplate>
                    <%# Eval("statusText")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="户数">
                <ItemTemplate>
                    <a href='ST_ZC_List.aspx?status=<%# Eval("status")%>&depart=<%#curDepart%>'><u><font
                        color="blue">
                        <%# Eval("hs")%>
                    </font></u></a>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="bj3" HeaderText="折合人民币本金" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false" >
                <HeaderStyle HorizontalAlign="Right"  />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="lx3" HeaderText="折合人民币利息" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bjlx3" HeaderText="折合人民币本利合" DataFormatString="{0:N2}"
                HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bj1" HeaderText="人民币本金" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="lx1" HeaderText="人民币利息" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bjlx1" HeaderText="人民币本利和" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            
            <asp:BoundField DataField="bj2" HeaderText="美元本金" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="lx2" HeaderText="美元利息" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bjlx2" HeaderText="美元本利和" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="pbj" HeaderText="累计收款(￥)" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="fee" HeaderText="费用合计(￥)" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        SkinID="gridviewSkin" EnableViewState="False" Width="99%">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <%# this.GridView3.PageIndex * this.GridView3.PageSize 
                                         +this.GridView3.Rows.Count + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="资产包状态">
                <ItemTemplate>
                    <%# Eval("statusText")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="包数">
                <ItemTemplate>
                    <a href='ST_ZCBao_List.aspx?status=<%# Eval("status")%>&depart=<%#curDepart%>'><u><font
                        color="blue">
                        <%# Eval("hs1")%>
                    </font></u></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="户数">
                <ItemTemplate>
                    <%# Eval("hs")%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="bj3" HeaderText="折合人民币本金" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="lx3" HeaderText="折合人民币利息" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bjlx3" HeaderText="折合人民币本利合" DataFormatString="{0:N2}"
                HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bj1" HeaderText="人民币本金" DataFormatString="{0:N2}" HtmlEncode="False" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="lx1" HeaderText="人民币利息" DataFormatString="{0:N2}" HtmlEncode="False" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bjlx1" HeaderText="人民币本利和" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bj2" HeaderText="美元本金" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="lx2" HeaderText="美元利息" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bjlx2" HeaderText="美元本利和" DataFormatString="{0:N2}" HtmlEncode="False" Visible="false">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="pbj" HeaderText="累计收款(￥)" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="fee" HeaderText="费用合计(￥)" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <br />
    
</asp:Content>
