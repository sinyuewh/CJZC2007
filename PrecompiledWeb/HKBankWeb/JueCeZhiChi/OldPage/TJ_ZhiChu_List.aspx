<%@ page language="C#" autoeventwireup="true" inherits="JueCeZhiChi_StatZhiChuB, App_Web_trolmxag" stylesheettheme="CjzcWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>支出统计表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="990px">
            <tr>
                <td>
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
                                                            <HeaderStyle HorizontalAlign="center" Width="18%" />
                                                            <ItemStyle HorizontalAlign="Center" Width="18%"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="费用合计" DataField="fyhj">
                                                            <HeaderStyle HorizontalAlign="center" Width="72%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
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
                                    <asp:Label ID="DepartHK" runat="server" Text='<%#Eval("Sumfee")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <table width="95%" align="right">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                   EnableViewState="False">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="责任人" DataField="zeren">
                                                            <HeaderStyle HorizontalAlign="Center" Width="18%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="申请费" DataField="Sumfee1">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="律师费" DataField="Sumfee2">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="诉讼费" DataField="Sumfee3">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="执行费" DataField="Sumfee4">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="受理费" DataField="Sumfee5">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="仲裁费" DataField="Sumfee6">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="评估费" DataField="Sumfee7">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="物业费" DataField="Sumfee8">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="过路费" DataField="Sumfee9">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Sumfee10" HeaderText="招待费">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="信息费" DataField="Sumfee11">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="其它费" DataField="Sumfee12">
                                                            <HeaderStyle HorizontalAlign="Center" Width="6%"/>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="费用合计" DataField="Sumfee">
                                                            <HeaderStyle HorizontalAlign="center" Width="10%"/>
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
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
