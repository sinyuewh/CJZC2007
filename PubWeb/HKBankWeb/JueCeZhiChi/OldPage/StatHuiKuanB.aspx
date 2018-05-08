<%@ page language="C#" autoeventwireup="true" inherits="JueCeZhiChi_StatHuiKuanB, App_Web_ckqqdyzb" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>回款统计表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_DataBound">
                    <HeaderTemplate>
                        <tr>
                            <td align="left" valign="top">
                                <table width="95%" align="right">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView10" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                              EnableViewState="False" Width="100%">
                                                <Columns>
                                                    <asp:BoundField HeaderText="公司" DataField="gsname">
                                                        <HeaderStyle HorizontalAlign="center" Width="30%" />
                                                        <ItemStyle HorizontalAlign="Center" Width="30%"/>
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="回收款额" DataField="hkje">
                                                        <HeaderStyle HorizontalAlign="center" Width="70%" />
                                                        <ItemStyle HorizontalAlign="Center" Width="70%"/>
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                &nbsp;&nbsp;<asp:Label ID="labDepart" runat="server" Text='<%#Eval("depart")%>' Font-Bold="true"></asp:Label>:
                                <asp:Label ID="DepartHK" runat="server" Text='<%#Eval("hkje")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <table width="95%" align="right">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                             EnableViewState="False" Width="100%">
                                                <Columns>
                                                    <asp:BoundField HeaderText="责任人" DataField="zeren">
                                                        <HeaderStyle HorizontalAlign="center" Width="30%" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="回收款额" DataField="hkje">
                                                        <HeaderStyle HorizontalAlign="center" Width="70%"/>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <tr>
                            <td align="left">
                                <hr width="98%" size="2" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                            </td>
                        </tr>
                    </SeparatorTemplate>
                </asp:Repeater>
            </tr>
        </table>
    </form>
</body>
</html>
