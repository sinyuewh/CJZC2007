<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true" CodeFile="MyDepartZcTime0.aspx.cs" Inherits="ZcMng1_MyDepartZcTime0" Title="部门资产时效警告" %>
<%-- 在此处添加内容控件 --%>
<%@ Register Src="AdvanceSearch.ascx" TagName="AdvanceSearch" TagPrefix="uc1" %>
<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td height="30" align="right">
                单位名称：<asp:TextBox ID="danwei" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue2" OnClick="LinkButton1_Click">显示高级查询>></asp:LinkButton>
                &nbsp;&nbsp;
            </td>
        </tr>        <tr id="AdvanceRow" runat="server" visible="false">
            <td align="center">
                <uc1:AdvanceSearch id="AdvanceSearch1" runat="server">
                </uc1:AdvanceSearch></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" EnableViewState="False" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="单位名称">
                            <HeaderStyle Width="38%" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail6.aspx?id=<%# Eval("id") %>"
                                    title="<%# Eval("danwei") %>">
                                    <%# Eval("danwei1") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="zeren" HeaderText="责任人" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                        
                        <asp:BoundField DataField="TimeName" HeaderText="时效名称" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZcTime" HeaderText="时效日期" DataFormatString="{0:yyyy-MM-dd}"
                            HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="提前警告">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tellday") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("tellday") %>'></asp:Label>天
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ZcTime0" HeaderText="警告日期" DataFormatString="{0:yyyy-MM-dd}"
                            HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Literal ID="redStar" runat="server"></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>