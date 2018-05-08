<%@ page language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_XtGlIndex, App_Web__q1xm6yj" title="部门设置" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="98%" valign="top">
                <asp:GridView ID="GridView1" runat="server"
                 AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting"
                    OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                     OnRowUpdating="GridView1_RowUpdating">
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
                        <asp:BoundField DataField="remark" HeaderText="备注">
                            <HeaderStyle Width="35%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ControlStyle Width="90%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="更新" CssClass="blue"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="取消" CssClass="blue"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                                    Text="编辑" CssClass="blue"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"
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
            <td colspan="2" style="text-align: center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="增 加" /></td>
        </tr>
    </table>
</asp:Content>
