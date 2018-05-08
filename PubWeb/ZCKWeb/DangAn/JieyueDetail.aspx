<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_JieyueDetail, App_Web_gn-rd1mt" title="文件借阅单明细页面" stylesheettheme="CjzcWeb" %>

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
                <strong><font color="#ffffff">借 阅 单 详 细 数 据</font></strong>
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
                借阅人：</td>
            <td style="height: 25px">
                &nbsp;<asp:Label ID="zeren" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr height="25">
            <td>
                要求归还时间：</td>
            <td>
                <asp:Label ID="paytime" runat="server" Text="Label"></asp:Label></td>
            <td>
                实际归还时间：</td>
            <td>
                <asp:Label ID="paytime1" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp
            </td>
        </tr>
        <tr height="25">
            <td>
                备注：</td>
            <td colspan="3">
                <asp:Label ID="remark" runat="server" Text="Label" Width="100px"></asp:Label></td>
        </tr>
        <tr height="30">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click1" /></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                    OnItemDataBound="Repeater1_ItemDataBound">
                    <HeaderTemplate>
                        <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <colgroup>
                                <col bgcolor="white" align="center" width="5%" />
                                <col bgcolor="white" align="center" width="30%" />
                                <col bgcolor="white" align="center" width="30%" />
                                <col bgcolor="white" align="center" width="35%" />
                            </colgroup>
                            <tr>
                                <td colspan="4" align="center" bgcolor="gainsboro">
                                    <strong>借 阅 单 文 件</strong></td>
                            </tr>
                            <tr height="25">
                                <td>
                                    序号
                                </td>
                                <td>
                                    案卷编号
                                </td>
                                <td>
                                    文件名称
                                </td>
                                <td>
                                    文件内容
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
                                <a href="javaScript:ShowAttach('<%#Eval("fid") %>');" class="blue1">
                                    <%# Eval("title") %>
                                </a>
                            </td>
                            <td>
                                <asp:Label ID="remark" runat="server" Text='<%#Eval("remark") %>'></asp:Label>
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
