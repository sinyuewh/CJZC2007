<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_MyZcBaoList1, App_Web_jdf3giep" title="我协办的资产包" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td height="30" align="right">
                资产包名称：<asp:TextBox ID="Bname" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <div style="margin-top: 10; background-color: #f0f8ff; border: 1px solid silver;
        overflow-x: auto; width: 1000px; display:none;">
       
        <br />
        <br />
    </div>
    
     <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            SkinID="gridviewSkin" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="序">
                    <ItemTemplate>
                        <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                     +this.GridView1.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="资产包名称">
                    <HeaderStyle Width="15%" />
                    <ItemTemplate>
                        <asp:HyperLink ID="Link1" runat="server" CssClass="blue1" ToolTip="浏览详细信息">
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="责任人">
                    <ItemTemplate>
                        <%#Eval("zeren") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="本金">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="benjin" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="利息">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="lixi" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="总额">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="zqce" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审批">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="spstatus" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="执行结果">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="spresult" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="执行状态">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="zxzt" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="户数" DataField="hs">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="回款">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="zcid" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="zcbid" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="huikuan" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="支出">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="zhichu" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <center>
                    <br />
                    没有发现满足条件的数据，请重新查询!</center>
            </EmptyDataTemplate>
        </asp:GridView>
</asp:Content>
