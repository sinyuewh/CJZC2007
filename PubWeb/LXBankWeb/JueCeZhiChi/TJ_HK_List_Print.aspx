<%@ page language="C#" autoeventwireup="true" inherits="JueCeZhiChi_StatHuiKuanInfoB, App_Web_ediktymv" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>打印回款统计详细表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            EnableViewState="False" Width="760px" HorizontalAlign="center">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单位名称">
                    <HeaderStyle Width="38%" />
                    <ItemTemplate>
                        <%# Eval("danwei1") %>
                    </ItemTemplate>
                    <ItemStyle BackColor="White" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单据编号">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("bill") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                    HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="bxhj" HeaderText="还本息和" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="zeren" HeaderText="责任人">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            EnableViewState="False" Width="760px" HorizontalAlign="center">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%# this.GridView2.PageIndex * this.GridView2.PageSize 
                                         +this.GridView2.Rows.Count + 1%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="资产包名称">
                    <HeaderStyle Width="38%" />
                    <ItemTemplate>
                        <%# Eval("bname") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单据编号">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("bill") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="billtime" HeaderText="开票时间" DataFormatString="{0:yyyy-M-d}"
                    HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="bxhj" HeaderText="还本息和" DataFormatString="{0:N2}" HtmlEncode="False">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="bzeren" HeaderText="责任人">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
