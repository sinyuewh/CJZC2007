<%@ page title="法律顾问浏览资产" language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_LawGwList, App_Web_z4gjhdph" stylesheettheme="CjzcWeb" %>

<%@ Register src="SearchControl.ascx" tagname="SearchControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <script language="javascript" src="../Common/Script/Common.js"></script>

    <div id="SearchTable" runat="server">
        <uc1:SearchControl ID="SearchControl1" runat="server"  />
    </div>
    <div id="SearchInfo" runat="server" visible="false" align="center">
        <asp:Button ID="butSearch" runat="server" Text="重新查询" OnClick="butSearch_Click" />
        <br />
        
        <div style="margin-top: 10;
             background-color:#f0f8ff;
	         border: 1px solid silver;
	         overflow: auto;
	         width:1400">
	         
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                SkinID="gridviewSkin" onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序">
                        <ItemTemplate>
                            <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                     +this.GridView1.Rows.Count + 1%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="num2" HeaderText="档案">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="单位名称">
                        <HeaderStyle Width="20%" />
                        <ItemTemplate>
                            <asp:HyperLink ID="Link1" runat="server" Target="_blank" CssClass="blue1" ToolTip="浏览详细信息">
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
                    
                    <asp:BoundField DataField="zeren1" HeaderText="协管员">
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
        </div>
    </div>
</asp:Content>
