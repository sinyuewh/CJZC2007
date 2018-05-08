<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_EditShouKuan, App_Web_uiei8leb" title="出库单据" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">出 库 单 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:Label ID="bill" runat="server" Text=""></asp:Label>
            </td>
            <td>
                开票时间：</td>
            <td>
                <asp:Label ID="billtime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                单位名称：</td>
            <td>
                <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
            </td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="zeren" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                开票员：</td>
            <td>
                <asp:Label ID="billmen" runat="server" Text=""></asp:Label>
            </td>
            <td>
                备注：</td>
            <td>
                <asp:Label ID="remark" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="审核单据" OnClick="SaveDataClick" OnClientClick="javaScript:return confirm('警告：确定票据通过审核吗？');" />&nbsp;
                <input id="Button2" type="button" value="退出返回" class="but" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <tr height="25">
                    <td colspan="7" align="Center" bgcolor="gainsboro">
                        <strong>出 库 明 细</strong>
                    </td>
                </tr>
                <colgroup>
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" />
                </colgroup>
                <tr height="25">
                    <td>
                        次序</td>
                    <td>
                        物品类别
                    </td>
                    <td>
                        物品名称
                    </td>
                    <td>
                        规格型号
                    </td>
                    <td>
                        单位
                    </td>
                    <td>
                        出库数量
                    </td>
                    <td>
                        备注</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <%#Eval("gkind") %>
                </td>
                <td>
                    <%#Eval("gname")%>
                </td>
                <td>
                    <%#Eval("ggxh")%>
                </td>
                <td>
                    <%#Eval("dw")%>
                </td>
                <td>
                    <%#Eval("num")%>
                </td>
                <td>
                    <%#Eval("remark")%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <table>
                <tr height="3">
                    <td style="width: 3px">
                    </td>
                </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
