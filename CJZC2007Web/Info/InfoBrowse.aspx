<%@ Page Language="C#" MasterPageFile="~/Common/Master/Info.master" AutoEventWireup="true"
    CodeFile="InfoBrowse.aspx.cs" Inherits="Info_InfoBrowse" Title="信息浏览" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" align="center">
        <tr>
            <td align="right">
                类 别：
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True" Value="全部">全部</asp:ListItem>
                    <asp:ListItem Value="内部公告">内部公告</asp:ListItem>
                    <asp:ListItem Value="领导指示">领导指示</asp:ListItem>
                    
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 标 题：
                <asp:TextBox ID="titleTxt" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="过 滤" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" EnableViewState="false" DataKeyNames="ID" OnRowDataBound="GridView1_RowDataBound"
                    OnSorting="GridView1_Sorting" HorizontalAlign="center">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <HeaderStyle Width="8%" />
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                                     +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="标 题" ItemStyle-HorizontalAlign="Left">
                            <HeaderStyle Width="70%" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/Info/Infodetails.aspx?id=<%# Eval("ID") %>">
                                    <%#Eval("title") %><asp:Image ID="noRead" runat="server" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="time0" HeaderText="发布时间" DataFormatString="{0:yy-MM-dd}"
                            HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:PageNavigator ID="PageNavigator1" runat="server" MaxNum="10" OnonPageChangeEvent="PageNavigator1_onPageChangeEvent"
                    PageNavType="数字式" PageSize="10" />
            </td>
        </tr>
    </table>
</asp:Content>
