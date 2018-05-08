<%@ Page Language="C#" MasterPageFile="~/Common/Master/ZcMng.master" AutoEventWireup="true"
    CodeFile="ZcBaoGL.aspx.cs" Inherits="ZcMng1_ZcBaoGL" Title="资产包管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <table width="100%">
        <tr>
            <td height="30" align="right">
                包名：<asp:TextBox ID="Bname" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="查询" OnClick="butSearch_Click" />&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="增加新包" OnClick="butAdd_Click" />
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False"
                    OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="资产包名称">
                            <HeaderStyle  HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcBaoDetail1.aspx?id=<%# Eval("id") %>"
                                    title="<%# Eval("bname") %>">
                                    <%# Eval("bname") %>
                                </a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="Bzeren" HeaderText="责任人">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="bzeren1" HeaderText="协办人">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="Bjsf" HeaderText="接收方">
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Bljsk" HeaderText="累计收款" DataFormatString="{0:N2}" HtmlEncode="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Bljzc" HeaderText="累计支出" DataFormatString="{0:N2}" HtmlEncode="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Bremark" HeaderText="备注">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="修改" ShowHeader="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="editlinBtn" runat="server" CommandName="EditZcb" CommandArgument='<%#Eval("id") %>'
                                    CssClass="blue" Text="修改"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
