<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng1_EditZcBao, App_Web_-yo2hwel" title="资产包维护" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" width="35%" />
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" width="35%" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">
                    资 产 包 信 息
                </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                资产包名称：
            </td>
            <td>
                <asp:TextBox ID="Bname" runat="server"></asp:TextBox>
            </td>
            <td>
                接收方：
            </td>
            <td>
                <asp:TextBox ID="Bjsf" runat="server"></asp:TextBox>
            </td>
        </tr>
<%--        <tr height="25">
            <td>
                累计收款：
            </td>
            <td>
                <asp:TextBox ID="Bljsk" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                累计支出：
            </td>
            <td>
                <asp:TextBox ID="Bljzc" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        
        <tr heiht="25">
            <td>
                责任人：
            </td>
            <td>
                <asp:TextBox ID="Bzeren" runat="server"></asp:TextBox>
            </td>
            <td>
                协办人:
            </td>
            <td>
                <asp:TextBox ID="Bzeren1" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        
        <tr heiht="25">
            <td>
                备注：
            </td>
            <td colspan="3">
                <asp:TextBox ID="Bremark" runat="server"></asp:TextBox>
            </td>
        </tr>
        
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" OnClick="SaveDataClick" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />
            </td>
        </tr>
        
    </table>
    <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <HeaderTemplate>
                        <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <colgroup>
                                <col bgcolor="white" align="center" width="10%" />
                                <col bgcolor="white" align="center" width="20%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="15%" />
                                <col bgcolor="white" align="center" width="10%" />
                            </colgroup>
                            <tr height="25" bgcolor="gainsboro">
                                <td colspan="7" align="Center">
                                    <strong>资 产 包 详 细 信 息</strong>&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    序号
                                </td>
                                <td>
                                    单位名称
                                </td>
                                <td>
                                    初始本金
                                </td>
                                <td>
                                    利息
                                </td>
                                <td>
                                    责任部门
                                </td>
                                <td>
                                    责任人
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
                                <a class="blue1" href="<%#Application["root"] %>/ZcMng2/ZcDetail1.aspx?id=<%# Eval("id") %>"
                                    title="<%# Eval("danwei") %>">
                                    <%# Eval("danwei1") %>
                                </a>
                            </td>
                            <td>
                                <%#Comm.GetNumberFormat(Eval("bj"))%>
                            </td>
                            <td>
                                <%#Comm.GetNumberFormat(Eval("lxhj"))%>
                            </td>
                            <td>
                                <%#Eval("depart")%>
                            </td>
                            <td>
                                <%#Eval("zeren")%>
                            </td>
                            <td>
<%--                                <asp:Label ID="zcid" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>--%>
                                <asp:LinkButton ID="butDel" runat="server" CommandName="delete" CommandArgument='<%#Eval("id") %>' CssClass="blue1"
                                    OnClientClick="javascript:return confirm('警告：确定剥离该资产吗？');">剥离</asp:LinkButton>
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
</asp:Content>

