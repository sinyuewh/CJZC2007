<%@ page language="C#" autoeventwireup="true" inherits="ZcMng1_ZcNoFenPeib, App_Web_o8vl6oai" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未分配资产表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <tr height="40">
                <td align="center">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司待分配资产表</strong></p>
                </td>
            </tr>
            <tr>
                <td height="0.5" bgcolor="black">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        EnableViewState="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                         +this.GridView1.Rows.Count + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="num2" HeaderText="档案号">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="单位名称">
                                <HeaderStyle Width="50%" />
                                <ItemTemplate>
                                    <%# Eval("danwei") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="guangxia" HeaderText="管辖" />
                            <asp:BoundField HeaderText="责任人" />
                        </Columns>
                        <RowStyle Height="30px" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
