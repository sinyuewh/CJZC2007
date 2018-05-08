<%@ Page Language="C#" MasterPageFile="~/Common/Master/Zcsp.master" AutoEventWireup="true"
    CodeFile="SearchFangAn.aspx.cs" Inherits="ZcMng3_SearchFangAn" Title="查询方案审批表" %>

<%@ Register Src="SPListView.ascx" TagName="SPListView" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="SearchTable" runat="server">
        <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="right" width="20%" />
                <col bgcolor="white" align="left" width="30%" />
                <col bgcolor="white" align="right" width="20%" />
                <col bgcolor="white" align="left" />
            </colgroup>
            <tr>
                <td colspan="4" align="center" height="25" bgcolor="gainsboro">
                    <strong>&nbsp;查 询 方 案 审 批 表</strong>
                </td>
            </tr>
            <tr height="25">
                <td>
                    项目名称：</td>
                <td>
                    <asp:TextBox ID="xmmc" runat="server" Width="140" /></td>
                <td>
                    项目申报号：</td>
                <td>
                    <asp:TextBox ID="xmsbh" runat="server" Width="140" /></td>
            </tr>
            
             <tr height="25">
                <td>
                   档案号 ：</td>
                <td>
                    <asp:TextBox ID="num2" runat="server" Width="140" /></td>
                <td>
                    单位名称：</td>
                <td>
                     <asp:TextBox ID="danwei" runat="server" Width="140" />
                </td>
            </tr>
            
            <tr height="25">
                <td style="height: 25px">
                    方案审批状态：</td>
                <td style="height: 25px">
                    <asp:DropDownList ID="spstatus" runat="server">
                        <asp:ListItem Text="全部..." Value=""></asp:ListItem>
                        <asp:ListItem Text="审批中" Value="0"></asp:ListItem>
                        <asp:ListItem Text="审核委员会批" Value="1"></asp:ListItem>
                        <asp:ListItem Text="决策委员会批" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 25px">
                    方案执行结果：</td>
                <td style="height: 25px">
                    <asp:DropDownList ID="spresult" runat="server">
                        
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr height="25">
                <td>
                    方案执行状态：
                </td>
                <td>
                    <asp:DropDownList ID="status1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="status1_SelectedIndexChanged">
                        
                    </asp:DropDownList>
                    －
                    <asp:DropDownList ID="status2" runat="server">
                        
                    </asp:DropDownList>
                </td>
                
                <td>
                    <span style="color:Red ">资产类别：</span>
                </td>
                <td>
                    <asp:RadioButtonList ID="zckind" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="单条资产" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="资产包" Value="1"></asp:ListItem>
                        <asp:ListItem Text="不限" Value="" Enabled="false"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr height="25" id="DepartRow" runat="server">
                <td>
                    会议时间：</td>
                <td colspan="3">
                    <asp:TextBox ID="time1" runat="server" Width="109px" />
                    至
                    <asp:TextBox ID="time2" runat="server" Width="109px" /></td>
            </tr>
            <tr height="30">
                <td colspan="4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="查询项目" OnClick="Button1_Click" /></td>
            </tr>
        </table>
    </div>
    
    <div id="SearchInfo" runat="server" visible="false" align="center" 
    style="overflow:scroll; width:100%">
        <asp:Button ID="butSearch" runat="server" Text="重新查询" OnClick="butSearch_Click" />
        <br />
        <div style="margin-top:10">
        <asp:GridView ID="GridView1" runat="server" Width="1400" AllowSorting="True" AutoGenerateColumns="False" 
            SkinID="gridviewSkin" OnRowDataBound="GridView1_RowDataBound" 
                onsorted="GridView1_Sorted" onsorting="GridView1_Sorting">
            <Columns>
                <asp:TemplateField HeaderText="序">
                    <ItemTemplate>
                        <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                     +this.GridView1.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                
                <asp:BoundField DataField="xmsbh" HeaderText="申报号">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="档案号">
                    <ItemTemplate>
                        <asp:HyperLink ID="Link2" runat="server" CssClass="blue1">
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="项目名称">
                    <HeaderStyle Width="15%" />
                    <ItemTemplate>
                        <asp:HyperLink ID="Link1" runat="server" CssClass="blue1" ToolTip="浏览项目的详细信息">
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
                               
                  <asp:BoundField DataField="hysj" HeaderText="会议时间" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>               
                
                
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
                
                                
                <asp:BoundField HeaderText="执行结果" DataField="spresult">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="执行状态">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="zxzt" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="sort1" HeaderText="排序" Visible="false"
                SortExpression="sort1">
                    <HeaderStyle HorizontalAlign="Center" />
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
        </asp:GridView>
        
        <br /><br />
	         
         <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
            SkinID="gridviewSkin" OnRowDataBound="GridView1_RowDataBound" 
                onsorted="GridView1_Sorted" onsorting="GridView1_Sorting">
            <Columns>
                <asp:TemplateField HeaderText="序">
                    <ItemTemplate>
                        <%# this.GridView2.PageIndex * this.GridView2.PageSize 
                                     +this.GridView2.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                
                <asp:BoundField DataField="xmsbh" HeaderText="申报号">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="档案号">
                    <ItemTemplate>
                        <asp:HyperLink ID="Link2" runat="server" CssClass="blue1">
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="项目名称">
                    <HeaderStyle Width="15%" />
                    <ItemTemplate>
                        <asp:HyperLink ID="Link1" runat="server" CssClass="blue1" ToolTip="浏览项目的详细信息">
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
                               
                  <asp:BoundField DataField="hysj" HeaderText="会议时间" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>               
                
                
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
                
                                
                <asp:BoundField HeaderText="执行结果" DataField="spresult">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="执行状态">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="zxzt" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="sort1" HeaderText="排序" Visible="false"
                SortExpression="sort1">
                    <HeaderStyle HorizontalAlign="Center" />
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
            
        </asp:GridView>
        </div>
        
    </div>
</asp:Content>
