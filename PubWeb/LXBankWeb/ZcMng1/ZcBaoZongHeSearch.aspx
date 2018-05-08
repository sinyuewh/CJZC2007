<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_ZcBaoZongHeSearch, App_Web_z4gjhdph" title="资产包综合查询" stylesheettheme="CjzcWeb" %>
    
 <%@ Register src="SearchControl.ascx" tagname="SearchControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div id="SearchTable" runat="server">
        <uc1:SearchControl ID="SearchControl1" runat="server" SearchType="资产包" />
    </div>
    <div id="SearchInfo" runat="server" visible="false" align="center">
        <asp:Button ID="butSearch" runat="server" Text="重新查询" OnClick="butSearch_Click" />
        <br />
        <div style="margin-top: 10">
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                SkinID="gridviewSkin" onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="序">
                        <ItemTemplate>
                            <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                     +this.GridView1.Rows.Count + 1%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                   
                    
                    
                    <asp:TemplateField HeaderText="资产包名称">
                        <HeaderStyle Width="10%" />
                        <ItemTemplate>
                            <asp:HyperLink ID="Link1" runat="server" CssClass="blue1" ToolTip="浏览详细信息">
                            </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left" />
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
                    <asp:BoundField DataField="zeren" HeaderText="经办人">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
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
                    
                    
                </Columns>
                
                <EmptyDataTemplate>
                    <center>
                        <br />
                        没有发现满足条件的数据，请重新查询!</center>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
