<%@ Page Title="电子档案浏览日志" Language="C#" MasterPageFile="~/Common/Master/DangAn.master"
    AutoEventWireup="true" CodeFile="DangAnSearchLogList.aspx.cs" Inherits="DangAn_DangAnSearchLogList" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" align="center">
        <tr>
            <td align="right">
                档案编号：
                <asp:TextBox ID="ajnum" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 用户姓名：
                <asp:TextBox ID="domen" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="过 滤" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" EnableViewState="false" DataKeyNames="ID" HorizontalAlign="center">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <HeaderStyle Width="8%" HorizontalAlign="Center" />
                             <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                                     +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="time0" HeaderText="浏览时间" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="domen" HeaderText="用户姓名">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ajnum" HeaderText="档案编号">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ajFile" HeaderText="文件名">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="remark" HeaderText="备注">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:PageNavigator ID="PageNavigator1" runat="server" MaxNum="10"
                 OnonPageChangeEvent="PageNavigator1_onPageChangeEvent"
                 PageNavType="数字式" PageSize="15" />
            </td>
        </tr>
    </table>
</asp:Content>
