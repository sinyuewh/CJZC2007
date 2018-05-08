<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="MyZc1.aspx.cs" Inherits="ZcMng1_MyZc1" Title="我协办的资产" %>

<%@ Register Src="AdvanceSearch.ascx" TagName="AdvanceSearch" TagPrefix="uc1" %>
<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td height="30" align="right">
                单位名称：<asp:TextBox ID="danwei" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="blue2" OnClick="LinkButton1_Click">显示高级查询>></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <%--<a class="blue2" href="javaScript:WinOpen();">打印我负责资产</a>--%>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr id="AdvanceRow" runat="server" visible="false">
            <td align="center" style="height: 252px">
                <uc1:AdvanceSearch ID="AdvanceSearch1" runat="server"></uc1:AdvanceSearch>
            </td>
        </tr>
        <tr>
            <td>
                <div style="margin-top: 10; background-color: #f0f8ff; border: 1px solid silver;
                    overflow-x: auto; width: 1000px">
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        SkinID="gridviewSkin" EnableViewState="False" OnRowDataBound="GridView1_RowDataBound"
                        Width="1400px">
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
                                <HeaderStyle Width="22%" />
                                <ItemTemplate>
                                    <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                                        title="<%# Eval("danwei") %>">
                                        <%# Eval("danwei1") %>
                                    </a>
                                </ItemTemplate>
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
                            <asp:BoundField DataField="zeren" HeaderText="责任人">
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
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="MyTimeCount" runat="server" />
    <asp:HiddenField ID="MyEmail" runat="server" Value="0" />
    <asp:HiddenField ID="MyInfo" runat="server" Value="0" />
</asp:Content>
