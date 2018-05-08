<%@ page title="时效类别管理" language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_ShiXiaoList, App_Web_rhavpchx" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td width="98%" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="timetypename">
                    <Columns>
                        <asp:BoundField DataField="num" HeaderText="序号">
                            <HeaderStyle Width="8%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="timetypename" HeaderText="时效类别">
                            <HeaderStyle Width="18%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="remark" HeaderText="时效说明">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <ItemTemplate>
                                <a href="EditShiXiaoType.aspx?TimeTypeCode=<%#Eval("TimeTypeCode")%>" class="blue">修改</a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="12%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top" align="center">
            </td>
        </tr>
    </table>
</asp:Content>
