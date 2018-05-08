<%@ page language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_Roles, App_Web_de5ib_om" title="角色管理" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" src="../Common/Script/Common.js"></script>
    <script language="javascript">
        function SeeRoles(infoid)
        {
            var url="SeeRoles.aspx?id="+infoid;
            winOpenOfen(url,400,220);
        }
    </script>
     <table width="100%">
        <tr>
            <td width="98%" valign="top">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" Width="100%" DataKeyNames="id" >
                    <Columns>
                        <asp:BoundField DataField="xuhao" HeaderText="序号">
                            <HeaderStyle Width="8%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="role" HeaderText="角色名称">
                            <HeaderStyle Width="18%" HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="remark" HeaderText="角色说明">
                            <HeaderStyle Width="50%" HorizontalAlign="Left"/>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="包含用户">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href="JavaScript:SeeRoles('<%#Eval("id")%>');" class="blue" target="_self">（<%#Eval("usercount")%>）查看</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <ItemTemplate>
                                <a href="EditRole.aspx?id=<%#Eval("id")%>" class="blue">修改</a>
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
