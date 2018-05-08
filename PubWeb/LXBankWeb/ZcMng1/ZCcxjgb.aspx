<%@ page language="C#" autoeventwireup="true" inherits="ZcMng2_ZCcxjgb, App_Web_jdf3giep" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产查询结果表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="90%" align="center" cellpadding="0" cellspacing="0">
            <tr height="40">
                <td align="center">
                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="18pt" Font-Bold="True" BorderColor="White"
                        Height="30px" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="1" bgcolor="black">
                </td>
            </tr>
            <tr>
                <td width="50%" align="left">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
         EnableViewState="False" Width="100%">
        <Columns>
            <asp:BoundField DataField="num2" HeaderText="档案号">
                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="danwei" HeaderText="单位名称">
                <HeaderStyle HorizontalAlign="Center" Width="35%" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="time0" HeaderText="转入时间" DataFormatString="{0:yyyy-MM-dd}"
                HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="bj" HeaderText="初始本金" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bxhj" HeaderText="利息" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="hbxh" HeaderText="还本息和" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="bxhjye" HeaderText="本息合计余额" DataFormatString="{0:N2}" HtmlEncode="False">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="depart" HeaderText="责任部门">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="zeren" HeaderText="责任人">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            <br />
            <div align="center">
                没有满足您查询条件的数据，请重新查询。<a href="<%#Application["root"] %>/ZcMng1/ZongHeSearch.aspx" class="blue">重新查询</a>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>
    </form>
</body>
</html>
