<%@ control language="C#" autoeventwireup="true" inherits="ZcMng3_info51, App_Web_-gbu33-0" %>
<table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
    <colgroup>
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" width="32%" />
        <col bgcolor="white" align="right" width="18%" />
        <col bgcolor="white" align="left" />
    </colgroup>
    <tr height="25">
        <td colspan="4" align="center" bgcolor="#5d7b9d">
            <strong><font color="#ffffff">3、方 案 审 批</font></strong>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="5">
                    </td>
                </tr>
                <tr id="NoRowData" runat="server">
                    <td align="center" height="40">
                        暂时还没有审批数据！
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="Repeater11" runat="server" OnItemCommand="Repeater1_ItemCommand"
                            OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                                <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="left" />
                                        <col bgcolor="white" align="center" width="11%" />
                                    </colgroup>
                                    <tr height="25">
                                        <td colspan="9" align="center" bgcolor="gainsboro">
                                            <strong>1．部 门 审 批</strong></td>
                                    </tr>
                                    <tr height="25">
                                        <td>
                                            次序</td>
                                        <td>
                                            部门
                                        </td>
                                        <td>
                                            批阅人
                                        </td>
                                        <td>
                                            批次
                                        </td>
                                        <td>
                                            批阅时间
                                        </td>
                                        <td>
                                            批阅
                                        </td>
                                        <td align="center">
                                            具体意见</td>
                                        <td align="center">
                                            操作
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="25">
                                    <td>
                                        <%#Container.ItemIndex+1%>
                                    </td>
                                    <td>
                                        <%#Eval("depart") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("time1","{0:yyyy-MM-dd}") %>
                                        <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("ps") %>
                                    </td>
                                    <td>
                                        <%#Eval("remark") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">批阅</asp:LinkButton>
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
                        <asp:Repeater ID="Repeater17" runat="server" OnItemCommand="Repeater1_ItemCommand"
                            OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                                <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="left" />
                                        <col bgcolor="white" align="center" width="11%" />
                                    </colgroup>
                                    <tr height="25">
                                        <td colspan="9" align="center" bgcolor="gainsboro">
                                            <strong>2．评 审 员 审 批</strong></td>
                                    </tr>
                                    <tr height="25">
                                        <td>
                                            次序</td>
                                        <td>
                                            部门
                                        </td>
                                        <td>
                                            经办人
                                        </td>
                                        <td>
                                            批次
                                        </td>
                                        <td>
                                            时间
                                        </td>
                                        <td>
                                            内容
                                        </td>
                                        <td align="center">
                                            具体意见</td>
                                        <td align="center">
                                            操作
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="25">
                                    <td>
                                        <%#Container.ItemIndex+1%>
                                    </td>
                                    <td>
                                        <%#Eval("depart") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("time1", "{0:yyyy-MM-dd}")%>
                                        <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("ps") %>
                                    </td>
                                    <td>
                                        <%#Eval("remark") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">操作</asp:LinkButton>
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
                        <asp:Repeater ID="Repeater12" runat="server" OnItemCommand="Repeater1_ItemCommand"
                            OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                                <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="left" />
                                        <col bgcolor="white" align="center" width="11%" />
                                    </colgroup>
                                    <tr height="25">
                                        <td colspan="9" align="center" bgcolor="gainsboro">
                                            <strong>3．办 公 室 立 项 编 号</strong></td>
                                    </tr>
                                    <tr height="25">
                                        <td>
                                            次序</td>
                                        <td>
                                            部门
                                        </td>
                                        <td>
                                            批阅人
                                        </td>
                                        <td>
                                            批次
                                        </td>
                                        <td>
                                            批阅时间
                                        </td>
                                        <td>
                                            批阅
                                        </td>
                                        <td align="center">
                                            具体意见</td>
                                        <td align="center">
                                            操作
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="25">
                                    <td>
                                        <%#Container.ItemIndex+1%>
                                    </td>
                                    <td>
                                        <%#Eval("depart") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("time1","{0:yyyy-MM-dd}") %>
                                        <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("ps") %>
                                    </td>
                                    <td>
                                        <%#Eval("remark") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">批阅</asp:LinkButton>
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
                        <asp:Repeater ID="Repeater13" runat="server" OnItemCommand="Repeater1_ItemCommand"
                            OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                                <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="left" />
                                        <col bgcolor="white" align="center" width="11%" />
                                    </colgroup>
                                    <tr height="25">
                                        <td colspan="9" align="center" bgcolor="gainsboro">
                                            <strong>4．审 核 委 员 会 审 批</strong></td>
                                    </tr>
                                    <tr height="25">
                                        <td>
                                            次序</td>
                                        <td>
                                            部门
                                        </td>
                                        <td>
                                            批阅人
                                        </td>
                                        <td>
                                            批次
                                        </td>
                                        <td>
                                            批阅时间
                                        </td>
                                        <td>
                                            批阅
                                        </td>
                                        <td align="center">
                                            具体意见</td>
                                        <td align="center">
                                            操作
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="25">
                                    <td>
                                        <%#Container.ItemIndex+1%>
                                    </td>
                                    <td>
                                        <%#Eval("depart") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="zx" runat="server" Text='<%#Eval("zx") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("time1", "{0:yyyy-MM-dd}")%>
                                        <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("ps") %>
                                    </td>
                                    <td>
                                        <%#Eval("remark") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">批阅</asp:LinkButton>
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
                        <asp:Repeater ID="Repeater15" runat="server" OnItemCommand="Repeater1_ItemCommand"
                            OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                                <table width="98%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="6%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="center" width="12%" />
                                        <col bgcolor="white" align="left" />
                                        <col bgcolor="white" align="center" width="11%" />
                                    </colgroup>
                                    <tr height="25">
                                        <td colspan="9" align="center" bgcolor="gainsboro">
                                            <strong>5．决 策 委 员 会 审 批</strong></td>
                                    </tr>
                                    <tr height="25">
                                        <td>
                                            次序</td>
                                        <td>
                                            部门
                                        </td>
                                        <td>
                                            批阅人
                                        </td>
                                        <td>
                                            批次
                                        </td>
                                        <td>
                                            批阅时间
                                        </td>
                                        <td>
                                            批阅
                                        </td>
                                        <td align="center">
                                            具体意见</td>
                                        <td align="center">
                                            操作
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="25">
                                    <td>
                                        <%#Container.ItemIndex+1%>
                                    </td>
                                    <td>
                                        <%#Eval("depart") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="zx" runat="server" Text='<%#Eval("zx") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="zeren" runat="server" Text='<%#Eval("zeren") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="pscount" runat="server" Text='<%#Eval("pscount") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("time1", "{0:yyyy-MM-dd}")%>
                                        <asp:Label ID="time1" runat="server" Text='<%#Bind("time1")%>' Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <%#Eval("ps") %>
                                    </td>
                                    <td>
                                        <%#Eval("remark") %>
                                    </td>
                                    <td>
                                        <asp:Label ID="kind" runat="server" Text='<%#Eval("kind") %>' Visible="false"></asp:Label>
                                        <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="budPy" runat="server" CommandName="piyue" CssClass="blue">批阅</asp:LinkButton>
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
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
