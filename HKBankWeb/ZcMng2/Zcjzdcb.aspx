<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zcjzdcb.aspx.cs" Inherits="ZcMng2_Zcjzdcb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资产尽职调查表</title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0" bgcolor="#c5c5c5">
            <colgroup>
                <col bgcolor="white" align="right" width="20%" />
                <col bgcolor="white" align="left" width="30%" />
                <col bgcolor="white" align="right" width="20%" />
                <col bgcolor="white" align="left" />
            </colgroup>
            <tr height="40">
                <td align="center" colspan="4">
                    <p style="font-weight: normal; font-size: 18pt;">
                        <strong>武汉长江资产公司资产尽职调查表</strong></p>
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    单位名称：</td>
                <td colspan="3" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                    <asp:Label ID="danwei" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    责任人：</td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    &nbsp;<asp:Label ID="zeren" runat="server"></asp:Label>
                    （<asp:Label ID="depart" runat="server"></asp:Label>）
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    当前状态：</td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    &nbsp;<asp:Label ID="statusText" runat="server"></asp:Label>
                    <asp:Label ID="status" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        
        <br />
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>1．阅 卷 记 录</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>&nbsp;
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>&nbsp;
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>&nbsp;
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>&nbsp;
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
    <asp:Repeater ID="Repeater2" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>2．下 户 记 录</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>&nbsp;
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>&nbsp;
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>&nbsp;
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>&nbsp;
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
    <asp:Repeater ID="Repeater3" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>3．取 证 记 录</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>&nbsp;
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>&nbsp;
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>&nbsp;
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>&nbsp;
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
    <asp:Repeater ID="Repeater4" runat="server">
        <HeaderTemplate>
            <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1">
                <colgroup>
                    <col align="center" width="15%" />
                    <col align="center" width="15%" />
                    <col align="center" width="25%" />
                    <col align="center" width="15%" />
                    <col align="left" width="15%" />
                    <col align="center" width="15%" />
                </colgroup>
                <tr height="30">
                    <td colspan="6" align="Center" style="border-bottom: solid 1pt #000000; border-top: solid 1pt #000000">
                        <strong>4．报 告 记 录</strong>
                    </td>
                </tr>
                <tr height="30">
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记时间
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        登记人
                    </td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        主要内容</td>
                    <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        地点</td>
                    <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                        结果
                    </td>
                    <td style="border-bottom: solid 1pt #000000; height: 30px;">
                        状态
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr height="30">
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("time0","{0:yyyy-M-d}") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("zeren") %>&nbsp;
                </td>
                <td align="left" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("remark") %>&nbsp;
                </td>
                <td style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("didian") %>&nbsp;
                </td>
                <td align="center" style="border-right: solid 1pt #000000; border-bottom: solid 1pt #000000; height: 30px;">
                    <%#Eval("jieguo") %>&nbsp;
                </td>
                <td style="border-bottom: solid 1pt #000000; height: 30px;">
                    <asp:Label ID="status" runat="server" Text='<%#Eval("status") %>'></asp:Label>&nbsp;
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
