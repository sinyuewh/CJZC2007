<%@ page language="C#" masterpagefile="~/Common/Master/CaiWu.master" autoeventwireup="true" inherits="CaiWu_AddShouKuan, App_Web_byogtmtx" title="增加入库单据" stylesheettheme="CjzcWeb" %>

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
                <strong><font color="#ffffff">入 库 单 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                单据编号：</td>
            <td>
                <asp:TextBox ID="bill" runat="server"></asp:TextBox></td>
            <td>
                开票时间：</td>
            <td>
                <asp:TextBox ID="billtime" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="remark" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center">
                <asp:Button ID="Button1" runat="server" Text="提交数据" OnClick="SaveDataClick" OnClientClick="javaScript:return confirm('警告：确定提交数据吗？');" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Text="增加明细" OnClick="AddPayBill" /></td>
        </tr>
    </table>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <tr height="25">
                    <td colspan="9" align="Center" bgcolor="gainsboro">
                        <strong>入 库 明 细</strong>
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
                        数量
                    </td>
                    <td>
                        单价
                    </td>
                    <td>
                        单位
                    </td>
                    <td>
                        备注</td>
                    <td>
                        删除</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Container.ItemIndex+1%>
                </td>
                <td>
                    <asp:DropDownList ID="gkind" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="gname" runat="server" Text='<%#Eval("gname")%>' Width="100"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="ggxh" runat="server" Text='<%#Eval("ggxh")%>' Width="100"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="num" runat="server" Text='<%#Eval("num")%>' Width="60"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="price" runat="server" Text='<%#Eval("price")%>' Width="60"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="dw" runat="server" Text='<%#Eval("dw")%>' Width="60"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="remark" runat="server" Text='<%#Eval("remark")%>' Width="100"></asp:TextBox>
                </td>
                <td align="center">
                    <asp:Label ID="seldoc" runat="server" Text='<%#Container.ItemIndex%>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                        OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
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
