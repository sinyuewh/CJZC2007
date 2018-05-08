<%@ Page Title="长资公司不良资产综合查询" Language="C#" MasterPageFile="~/Common/Master/ZcZongHe.master"
    AutoEventWireup="true" CodeFile="ZongHeSearch.aspx.cs" Inherits="ZongHeSearch" %>

<%@ Register Src="ZcMng1/ZcZongHeSearch.ascx" TagName="ZcZongHeSearch" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="SearchTable" runat="server">
        <table width="90%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" width="32%" />
                <col bgcolor="white" align="right" width="18%" />
                <col bgcolor="white" align="left" />
            </colgroup>
            <tr height="25">
                <td colspan="4" align="center" bgcolor="#5d7b9d">
                    <strong><font color="#ffffff">资 产 综 合 查 询</font> </strong>
                </td>
            </tr>
            <!---查询条件-->
            <tr height="25" id="ZcRow0" runat="server">
                <td>
                    单位名称：
                </td>
                <td>
                    <asp:TextBox ID="danwei" runat="server" Width="250"></asp:TextBox>
                </td>
                <td>
                    档案编号：
                </td>
                <td>
                    <asp:TextBox ID="num2" runat="server" Width="250" />(精确)
                </td>
            </tr>
            <tr height="25" id="noRawData" runat="server">
                <td>
                    责任部门：
                </td>
                <td valign="top">
                    <asp:RadioButtonList ID="depart" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatColumns="3">
                    </asp:RadioButtonList>
                </td>
                <td>
                    责 任 人：
                </td>
                <td>
                    <asp:RadioButtonList ID="zeren" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr height="30">
                <td colspan="4" align="center">
                    <asp:Button ID="Button1" runat="server" Text="查询资产" />
                </td>
            </tr>
        </table>
    </div>
    <div id="SearchInfo" runat="server" align="center">
        <br />
        <div style="margin-top: 10; background-color: #f0f8ff; border: 0px solid silver;
            overflow: auto; width: 91%">
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                SkinID="gridviewSkin">
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
                            <asp:HyperLink ID="Link1" runat="server" CssClass="blue1" Target="_self" ToolTip="浏览详细信息">
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
