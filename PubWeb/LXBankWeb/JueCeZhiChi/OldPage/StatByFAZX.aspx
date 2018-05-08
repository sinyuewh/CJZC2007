<%@ page language="C#" masterpagefile="~/Common/Master/JueCe.master" autoeventwireup="true" inherits="JueCeZhiChi_StatByFAZX, App_Web_mfnj-ysd" title="方案执行统计" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                            SkinID="gridviewSkin" EnableViewState="False" OnRowDataBound="GridView1_RowDataBound">
                                            <Columns>
                                                <asp:BoundField HeaderText="责任人" DataField="zeren">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="协商谈判" DataField="count6">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="诉讼" DataField="count7">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="申请执行" DataField="count8">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="强制执行" DataField="count9">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="中止执行" DataField="count10">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="终止执行" DataField="count11">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="办结" DataField="count12">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="合计">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="LabHJ" runat="server" Text='<%#Eval("count13") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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

