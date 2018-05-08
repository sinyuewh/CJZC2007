<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_InfoMaintenance, App_Web_2t7cinkt" title="维护信息" stylesheettheme="CjzcWeb" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
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
            <td width="98%" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="ID" OnRowDeleting="GridView1_RowDeleting"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"
                    OnRowUpdating="GridView1_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                                     +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:TemplateField>
                        <asp:BoundField DataField="title" HeaderText="标题">
                            <HeaderStyle Width="50%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="time0" HeaderText="发布时间" DataFormatString="{0:yy-MM-dd}"
                            HtmlEncode="False">
                            <HeaderStyle  HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="信息类别">
                            <HeaderStyle  />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("kind") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href="EditInfo.aspx?id=<%#Eval("ID") %>" class="blue">编辑</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="linBtn4" runat="server" CausesValidation="false" CommandName="Delete"
                                    CssClass="blue" Text="删除" OnClientClick="javaScript:return confirm('警告：确定要删除数据吗？');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top" align="center">
            </td>
        </tr>
        <tr>
            <td>
                <cc1:PageNavigator ID="PageNavigator1" runat="server" OnonPageChangeEvent="PageNavigator1_onPageChangeEvent"
                    PageNavType="数字式" PageSize="30" MaxNum="10" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                
            </td>
        </tr>
    </table>
</asp:Content>
