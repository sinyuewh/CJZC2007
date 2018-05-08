<%@ page title="档案部门管理员" language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_DangAnDepartManageList, App_Web_widkftde" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            
            <td width="98%" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="num" HeaderText="部门编号">
                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ControlStyle Width="90%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="depart" HeaderText="部门名称">
                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ControlStyle Width="90%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sname" HeaderText="管理员">
                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ControlStyle Width="90%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HyperLink ID="hyper1" CssClass="blue"
                                 runat="server" Text="编辑" NavigateUrl='<%#String.Format("EditAdmin.aspx?id={0}",Eval("id")) %>' >编辑</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="butDelete" runat="server" CausesValidation="False" CommandName="Delete"
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
            <td colspan="2" style="text-align: left">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="增 加" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
