<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatByJZDC, App_Web_mfnj-ysd" title="尽职调查统计" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td height="30" align="right">
                时间段：<asp:TextBox ID="BeginTime" runat="server" Width="100"></asp:TextBox>——<asp:TextBox
                    ID="EndTime" runat="server" Width="100"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="butSearch" runat="server" Text="查询" OnClick="butSearch_Click" />
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_DataBound">
                <ItemTemplate>
                    <tr>
                        <td align="left">
                            &nbsp;&nbsp;<asp:Label ID="labDepart" runat="server" Text='<%#Eval("depart")%>' Font-Bold="true"></asp:Label>:
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table width="95%" align="right">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            SkinID="gridviewSkin" EnableViewState="False">
                                            <Columns>
                                                <asp:BoundField HeaderText="责任人" DataField="zeren">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="阅卷" DataField="count1">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="下户" DataField="count2">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="取证" DataField="count3">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="报告" DataField="count4">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="合计" DataField="count5">
                                                    <HeaderStyle HorizontalAlign="Center" />
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
</asp:Content>
