<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_EditPrintInfo, App_Web_d1onhsud" title="复印单详细" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="../Common/Script/Common.js"></script>

    <script language="javascript">
    function ShowAttach(fid)
    {
        url="ShowFileInfo.aspx?id="+fid;
        winOpenOfen(url,600,400);
    }
    </script>

    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" width="32%" />
            <col bgcolor="white" align="right" width="18%" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">复 印 单 详 细 数 据</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                单据编号：</td>
            <td style="height: 25px">
                <asp:Label ID="bill" runat="server" Text="Label"></asp:Label></td>
            <td style="height: 25px">
                开票时间：</td>
            <td style="height: 25px">
                <asp:Label ID="billtime" runat="server" Text="Label" Width="100px"></asp:Label></td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                开票员：</td>
            <td style="height: 25px">
                <asp:Label ID="billmen" runat="server" Text="Label"></asp:Label></td>
            <td style="height: 25px">
                复印人：</td>
            <td style="height: 25px">
                <asp:Label ID="zeren" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                备注：</td>
            <td colspan="3">
                <asp:Label ID="remark" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button2" runat="server" Text="确定" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click1" /></td>
        </tr>
    </table>
    <br />
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
        <tr>
            <td colspan="4">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                    OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <colgroup>
                                <col bgcolor="white" align="center" width="5%" />
                                <col bgcolor="white" align="center" width="20%" />
                                <col bgcolor="white" align="center" width="25%" />
                                <col bgcolor="white" align="center" width="30%" />
                                <col bgcolor="white" align="center" width="10%" />
                                <col bgcolor="white" align="center" width="10%" />
                            </colgroup>
                            <tr height="25">
                                <td colspan="6" align="center" bgcolor="gainsboro">
                                    <strong>复 印 单 文 件</strong>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Button3_Click" CssClass="blue2">添加文件>></asp:LinkButton>
                                </td>
                            </tr>
                            <tr height="25">
                                <td>
                                    序号
                                </td>
                                <td>
                                    档案编号
                                </td>
                                <td>
                                    文件名称
                                </td>
                                <td>
                                    文件内容
                                </td>
                                <td>
                                    复印页数
                                </td>
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
                                <asp:Label ID="ajnum" runat="server" Text='<%#Eval("ajnum") %>'></asp:Label>
                            </td>
                            <td>
                                <a href="javaScript:ShowAttach('<%#Eval("fid") %>');" class="blue1"><%# Eval("title") %></a>
                            </td>
                            <td>
                                <asp:Label ID="remark" runat="server" Text='<%#Eval("remark") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("copycount") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="seldoc" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="LinkbutDel" runat="server" CommandName="delete" CssClass="blue"
                                    OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                        <table>
                            <tr height="3">
                                <td>
                                </td>
                            </tr>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</asp:Content>
