<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_Print, App_Web_dq1vueyh" title="文件复印单页面" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td height="30" align="right">
                复印人：<asp:TextBox ID="zeren" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin"
                    DataKeyNames="id" OnRowDeleting="GridView1_RowDeleting" >
                    <Columns>
                        <asp:TemplateField HeaderText="单据编号">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/DangAn/ShowPrintDetail.aspx?id=<%# Eval("id") %>">
                                    <%# Eval("bill") %>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="开票时间" DataField="billtime" DataFormatString="{0:yyyy-MM-dd}"
                            HtmlEncode="False">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="复印人" DataField="zeren">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="开票员" DataField="billmen">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%--<a href="EditJieyueInfo.aspx?id=<%#Eval("id") %>" class="blue">修改</a>--%>
                                <asp:LinkButton ID="LinkbutEdit" runat="server" CommandName="edit" CssClass="blue1"><a href="EditPrintInfo.aspx?id=<%#Eval("id")%>" class="blue">修改</a></asp:LinkButton>
                                <asp:LinkButton ID="Delbut" runat="server" CommandName="delete" CssClass="blue1"
                                    OnClientClick="javascript:return confirm('警告：确定要删除数据吗？');">删除</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
