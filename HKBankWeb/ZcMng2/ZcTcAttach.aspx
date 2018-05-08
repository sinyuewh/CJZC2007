<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZcTcAttach.aspx.cs" Inherits="ZcMng2_ZcTcAttach" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相关附件</title>
    <base target="_self" />
    <script language="javascript" type="text/javascript">
        function closeWin()
        {
            if(window.opener!=null)
            {
                window.opener.location.reload();
            }
            window.close();
        }
    </script>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table width="100%" bgcolor="white">
                <tr>
                    <td height="5">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_DataBound">
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
                                            <strong><font color="#ffffff">相 关 附 件</font></strong>
                                        </td>
                                    </tr>
                                    <tr height="25">
                                        <td>
                                            序号</td>
                                        <td>
                                            登记时间
                                        </td>
                                        <td>
                                            附件名称
                                        </td>
                                        <td>
                                            打开附件</td>
                                        <td>
                                            删除附件</td>
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
                                        <%#Eval("filename")%>
                                    </td>
                                    <td>
                                        <a href="<%#Application["root"]%>/Common/AttachFiles/<%#Eval("AttachFile1")%>" target="_blank"
                                            class="blue1">打开附件</a></td>
                                    <td>
                                        <asp:Label ID="fileid" runat="server" Text='<%#Eval("id")%>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="butDel" runat="server" CssClass="blue1" OnClientClick="javascript:return confirm('警告：确定删除数据吗？');">删除附件</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr id="Row1" runat="server">
                    <td>
                        <hr width="95%" />
                        <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                            <tr height="25" bgcolor="white">
                                <td align="center" width="30%">
                                    <strong>上传附件</strong></td>
                                <td align="left">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Height="22" Width="287px" CssClass="text" />&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="上传附件" OnClick="Button1_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            
            <br />
            <input id="Button2" type="button" value="关闭返回" class="but" onclick="javascript:closeWin();" />
        </div>
    </form>
</body>
</html>
