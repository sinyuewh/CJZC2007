<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SPListView.ascx.cs" Inherits="ZcMng3_SPListView" %>
<table width="100%">
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                SkinID="gridviewSkin"  OnRowDataBound="GridView1_RowDataBound" onrowcommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="序">
                        <ItemTemplate>
                            <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                        <HeaderStyle Font-Size="10pt" Height="30" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="档案号">
                        <HeaderStyle Width="5%" />
                        <ItemTemplate>
                            <asp:HyperLink ID="Link2" runat="server" CssClass="blue1">
                            </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Height="28" />
                        <HeaderStyle Font-Size="10pt" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="项目名称">
                        <HeaderStyle Width="21%" />
                        <ItemTemplate>
                            <asp:HyperLink ID="Link1" runat="server" CssClass="blue1" ToolTip="浏览项目的详细信息">
                            </asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left" />
                        <HeaderStyle Font-Size="10pt" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="shijian1" HeaderText="立项时间" DataFormatString="{0:yyyy-MM-dd}"
                        HtmlEncode="false">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="10pt" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="zeren" HeaderText="经办人">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="10pt" />
                    </asp:BoundField>
                                        
                    
                    <asp:BoundField DataField="xmsbh" HeaderText="申报号">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="10pt" />
                    </asp:BoundField>
                                    
                                        
                    <asp:TemplateField HeaderText="审批状态">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="spstatus" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Size="10pt" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="会议时间">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="hysj" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Font-Size="10pt" />
                    </asp:TemplateField>
                                        
                    <asp:BoundField HeaderText="类别">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="10pt" />
                    </asp:BoundField>
                    
                   
                   <asp:BoundField DataField="spresult" HeaderText="执行结果">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="10pt" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="执行状态">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="10pt" />
                        <ItemTemplate>
                            <asp:Label ID="zxzt" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="操作">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle Font-Size="10pt" />
                        <ItemTemplate>
                            <asp:LinkButton ID="button1" Text="删除" runat="server" 
                            CommandName="deleteData"  CommandArgument='<%#Eval("id")%>'
                            OnClientClick="javascript:return confirm('警告：确定要删除资产处置表数据吗？');">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                     
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
