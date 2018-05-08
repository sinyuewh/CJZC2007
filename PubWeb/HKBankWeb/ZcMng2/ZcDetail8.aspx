<%@ page language="C#" masterpagefile="~/Common/Master/ZcMng.master" autoeventwireup="true" inherits="ZcMng2_ZcDetail8, App_Web_ynb-gsbv" title="所有附件" stylesheettheme="CjzcWeb" %>

<%@ Register Src="ZcDetailKind.ascx" TagName="ZcDetailKind" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ZcDetailKind ID="ZcDetailKind1" runat="server" />
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
                <strong><font color="#ffffff">资 产 的 所 有 附 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td align="right">
                单位名称：</td>
            <td colspan="3" align="left">
                <asp:Label ID="danwei" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                责任部门：</td>
            <td>
                <asp:Label ID="depart" runat="server" Text=""></asp:Label>&nbsp;</td>
            <td>
                责任人：</td>
            <td>
                <asp:Label ID="zeren" runat="server" Text=""></asp:Label>&nbsp;</td>
        </tr>
    </table>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                <colgroup>
                    <col bgcolor="white" align="center" width="15%" />
                    <col bgcolor="white" align="center" width="15%" />
                    <col bgcolor="white" align="center" width="15%" />
                    <col bgcolor="white" align="center" width="15%" />
                    <col bgcolor="white" align="center" />
                    <col bgcolor="white" align="center" width="15%" />
                </colgroup>
                <tr height="25">
                    <td colspan="6" align="Center" bgcolor="gainsboro">
                        <strong>所 有 附 件</strong>
                    </td>
                </tr>
                <tr height="25">
                    <td>
                        序号</td>
                    <td>
                        登记时间
                    </td>
                    <td>
                        登记人
                    </td>
                    <td>
                        类别
                    </td>
                    <td>
                        附件名称
                    </td>
                    <td>
                        打开附件</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="25">
                <td>
                    <%#Eval("num")%>
                </td>
                <td>
                    <%#Eval("time0","{0:yyyy-M-d}")%>
                </td>
                <td>
                    <%#Eval("djren") %>
                </td>
                <td>
                    <%#PubComm.GetString1(Eval("statusText")) %>
                </td>
                <td>
                    <%#Eval("filename")%>
                </td>
                <td>
                    <a href="<%#Application["root"]%>/Common/AttachFiles/<%#Eval("AttachFile")%>" target="_blank"
                        class="blue1">打开附件</a></td>
                <%--                <td>
                    <asp:Label ID="fileid" runat="server" Text='<%#Eval("id")%>' Visible="false"></asp:Label>
                    <asp:LinkButton ID="butDel" runat="server" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除附件</asp:LinkButton>
                </td>--%>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
