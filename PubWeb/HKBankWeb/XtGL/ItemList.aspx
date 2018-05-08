<%@ page language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_ItemList, App_Web_u3wuv1nz" title="系统配置" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="98%" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="num" HeaderText="编号">
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ControlStyle Width="90%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="itemtext" HeaderText="配置名称">
                            <HeaderStyle Width="25%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ControlStyle Width="90%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="itemValue" HeaderText="配置的值">
                            <HeaderStyle  HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ControlStyle Width="90%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center"  Width="15%"  />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href="EditItem.aspx?id=<%#Eval("id")%>" class="blue1">编辑</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top" align="center">
            </td>
        </tr>
    </table>
</asp:Content>
