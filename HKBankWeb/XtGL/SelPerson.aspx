<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelPerson.aspx.cs" Inherits="XtGL_SelPerson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择用户</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table width="100%" bgcolor="white">
                <tr>
                    <td height="5">
                    </td>
                </tr>
                <tr id="Row1" runat="server">
                    <td>
                        <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <tr height="25" bgcolor="white">
                                <td align="center" width="20%" style="text-align: right">
                                    <strong>用户姓名：</strong></td>
                                <td align="left">
                                    <asp:TextBox ID="sname" runat="server" Width="321px"></asp:TextBox>&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="搜索用户" OnClick="Button1_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                                <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                                    <colgroup>
                                        <col bgcolor="white" align="center" width="15%" />
                                        <col bgcolor="white" align="center" width="15%" />
                                        <col bgcolor="white" align="center" />
                                        <col bgcolor="white" align="center" width="15%" />
                                        <col bgcolor="white" align="center" width="15%" />
                                    </colgroup>
                                    <tr height="25">
                                        <td colspan="5" align="Center" bgcolor="#5d7b9d">
                                            <strong><font color="#ffffff">选 择 用 户</font></strong>
                                        </td>
                                    </tr>
                                    <tr height="25">
                                        <td>
                                            选中</td>
                                        <td>
                                            姓名
                                        </td>
                                        <td>
                                            所在部门
                                        </td>
                                        <td>
                                            职务</td>
                                        <td>
                                            移动电话</td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr height="25">
                                    <td>
                                    </td>
                                    <td>
                                        <%#Eval("sname")%>
                                    </td>
                                    <td>
                                        <%#Eval("depart")%>
                                    </td>
                                    <td>
                                        <%#Eval("job")%>
                                    </td>
                                    <td>
                                        <%#Eval("cell")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
            <br />
            <input id="Button2" type="button" value="确定返回" class="but" onclick="window.opener.location.reload();window.close();" />
            &nbsp; &nbsp; &nbsp;
            <input id="Button3" type="button" value="取消返回" class="but" onclick="window.opener.location.reload();window.close();" /></div>
    </form>
</body>
</html>
