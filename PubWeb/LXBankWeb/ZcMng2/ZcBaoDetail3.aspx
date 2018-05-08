<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng2_ZcBaoDetail3, App_Web_uc5krivz" title="资产包方案审批" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcBaoDetailKind.ascx" TagName="ZcBaoDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ZcBaoDetailKind ID="ZcBaoDetailKind1" runat="server" />
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">当 前 方 案 审 批</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：</td>
            <td colspan="3">
                <asp:Label ID="danwei" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任人：</td>
            <td>
                &nbsp;<asp:Label ID="zeren" runat="server"></asp:Label>
                （<asp:Label ID="depart" runat="server"></asp:Label>）
            </td>
            <td>
                当前状态：</td>
            <td>
                &nbsp;<asp:Label ID="statusText" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="status" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td colspan="4" bgcolor="gainsboro" align="center">
                <strong>资 产 包 处 置 申 报 情 况</strong></td>
        </tr>
        <tr height="25" style="display: none;">
            <td>
                资产处置ID：
            </td>
            <td colspan="3">
                <asp:Label ID="zcczid" runat="server"></asp:Label>
                <asp:Label ID="zcczid_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                项目申报号：
            </td>
            <td colspan="3">
                <asp:Label ID="xmsbh" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产类型：
            </td>
            <td>
                <asp:TextBox ID="zclx" runat="server"></asp:TextBox>
                <asp:Label ID="zclx_1" runat="server"></asp:Label>
            </td>
            <td>
                资产数额：
            </td>
            <td>
                <asp:TextBox ID="zcse" runat="server"></asp:TextBox>
                <asp:Label ID="zcse_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                项目背景：
            </td>
            <td colspan="3">
                <asp:TextBox ID="xmbj" runat="server" TextMode="MultiLine" Width="85%" Height="45px"></asp:TextBox>
                <asp:Label ID="xmbj_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                方式选择理由：
            </td>
            <td colspan="3">
                <asp:TextBox ID="fsxzly" runat="server" TextMode="MultiLine" Width="85%" Height="45px"></asp:TextBox>
                <asp:Label ID="fsxzly_1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                定价依据：
            </td>
            <td colspan="3">
                <asp:TextBox ID="djyj" runat="server" TextMode="MultiLine" Width="85%" Height="45px"></asp:TextBox>
                <asp:Label ID="djyj_1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="butSaveData" runat="server" Text="更新资料" OnClick="SaveDataClick" />&nbsp;&nbsp;
                &nbsp;&nbsp;
                <asp:Button ID="butSendToDepartLeader" CommandArgument="11" runat="server" Text="送部门审批"
                    OnClick="butSendToDepartLeader_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="BID"
                        runat="server" Text="" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="复制申报情况到资产" OnClick="Button1_Click" /></td>
        </tr>
    </table>
    <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Repeater ID="Repeater6" runat="server" OnItemCommand="Repeater6_ItemCommand"
                    OnItemDataBound="Repeater6_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <colgroup>
                                <col bgcolor="white" align="center" width="10%" />
                                <col bgcolor="white" align="center" width="20%" />
                                <col bgcolor="white" align="center" width="13%" />
                                <col bgcolor="white" align="center" width="13%" />
                                <col bgcolor="white" align="center" width="13%" />
                                <col bgcolor="white" align="center" width="13%" />
                                <col bgcolor="white" align="center" width="18%" />
                            </colgroup>
                            <tr height="25" bgcolor="gainsboro">
                                <td colspan="7" align="Center">
                                    <strong>资 产 处 置 方 式</strong>&nbsp;&nbsp;
                                    <asp:LinkButton ID="AddZcczfs" runat="server" OnClick="Button2_Click" CssClass="blue2">添加资产处置方式>></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    序号
                                </td>
                                <td>
                                    处置方式
                                </td>
                                <td>
                                    处置价格
                                </td>
                                <td>
                                    处置损失
                                </td>
                                <td>
                                    清偿率(%)
                                </td>
                                <td>
                                    预计费用
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr height="25">
                            <td>
                                <%#Container.ItemIndex+1 %>
                            </td>
                            <td>
                                <%#Eval("czfs")%>
                            </td>
                            <td>
                                <%#Eval("czjg")%>
                            </td>
                            <td>
                                <%#Eval("czss")%>
                            </td>
                            <td>
                                <%#Eval("qcl")%>
                            </td>
                            <td>
                                <%#Eval("yjfy")%>
                            </td>
                            <td>
                                <asp:Label ID="zccz" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CssClass="blue1"
                                    OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                                <asp:LinkButton ID="butEdit" runat="server" CommandName="update" CssClass="blue1">修改</asp:LinkButton>
                                <asp:LinkButton ID="butCopy" runat="server" CommandName="Copy" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定要复制到所有资产吗？');">复制</asp:LinkButton>
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
    <br />
    <asp:Repeater ID="Repeater11" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
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
                    <%#Eval("time1","{0:yyyy-MM-dd HH:mm:ss}") %>
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
    <asp:Repeater ID="Repeater12" runat="server" OnItemCommand="Repeater1_ItemCommand"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
                        <strong>2．办 公 室 立 项 编 号</strong></td>
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
                    <%#Eval("time1", "{0:yyyy-MM-dd HH:mm:ss}")%>
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
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
                        <strong>3．审 核 委 员 会 审 批</strong></td>
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
                    <%#Eval("time1", "{0:yyyy-MM-dd HH:mm:ss}")%>
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
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="6%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="center" width="12%" />
                    <col bgcolor="white" align="left" />
                    <col bgcolor="white" align="center" width="11%" />
                </colgroup>
                <tr height="25">
                    <td colspan="9" align="center" bgcolor="gainsboro">
                        <strong>4．决 策 委 员 会 审 批</strong></td>
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
                    <%#Eval("time1", "{0:yyyy-MM-dd HH:mm:ss}")%>
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
</asp:Content>
