<%@ page title="档案部门管理员" language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_DepartAdminEdit, App_Web_widkftde" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <table width="100%">
        <tr>
            <td width="98%" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="num" HeaderText="序号">
                            <HeaderStyle Width="8%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="depart" HeaderText="部门">
                            <HeaderStyle Width="18%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="remark" HeaderText="档案管理员">
                            <HeaderStyle Width="50%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <ItemTemplate>
                                <a href="DepartAdminEdit.aspx?depart=<%#Eval("depart")%>" class="blue">修改</a>
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
