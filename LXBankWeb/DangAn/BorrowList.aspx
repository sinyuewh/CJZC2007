<%@ Page Title="档案查询申请单列表" Language="C#" MasterPageFile="~/Common/Master/DangAn.master"
    AutoEventWireup="true" CodeFile="BorrowList.aspx.cs" Inherits="DangAn_BorrowList" %>

<%@ Register Assembly="SysFrame" Namespace="JSJ.SysFrame.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" align="center">
        <tr>
            <td align="right">
                档案编号：
                <asp:TextBox ID="ajnum" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 申请人：
                <asp:TextBox ID="domen" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="过 滤" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" AllowSorting="true" AutoGenerateColumns="False"
                    SkinID="gridviewSkin" DataKeyNames="ID" HorizontalAlign="center">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <HeaderStyle Width="8%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# this.GridView1.PageIndex * this.GridView1.PageSize 
                                                     +this.GridView1.Rows.Count + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ajnum" HeaderText="案卷编号">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="time0" HeaderText="申请时间">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="borrow" HeaderText="申请人">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="checktime" HeaderText="审批时间">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="time1" HeaderText="截止日期">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="checkman" HeaderText="批准人">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <%#Eval("status").ToString() == "1" ? "√" : 
                                  ( Eval("status").ToString() == "0" ? "×": "" )%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="link1" CssClass="blue" CommandName="agree" runat="server" Text="同意"
                                    CommandArgument='<%#Eval("id")%>'></asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="Link2" CssClass="blue" CommandName="disagree" runat="server"
                                    Text="不同意" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:PageNavigator ID="PageNavigator1" runat="server" MaxNum="10" OnonPageChangeEvent="PageNavigator1_onPageChangeEvent"
                    PageNavType="数字式" PageSize="15" />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                &nbsp;<font color="blue">提示：1)档案申请批准的期限为1个月，1个月后，将自动失效。</font>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 45px">
                <font color="blue">2)系统将自动删除一年前的档案查询申请单。</font>
            </td>
        </tr>
    </table>
</asp:Content>
