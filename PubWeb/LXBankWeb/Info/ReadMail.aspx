<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_ReadMail, App_Web_lh9kwmkt" title="阅读邮件" validaterequest="false" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:FormView ID="mailForm1" runat="server" Width="100%" OnDataBinding="mailForm1_DataBinding"
        OnDataBound="mailForm1_DataBound">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" width="95%" align="center" border="0">
                <tbody>
                    <tr>
                        <td align="center" height="40">
                            <font size="4"><strong>
                                <%#Eval("title") %>
                            </strong></font>
                        </td>
                        <tr height="25">
                            <td align="left">
                                发件人：<%#Eval("from1") %>
                            </td>
                        </tr>
                        <tr height="25">
                            <td align="left">
                                日 期：<%#Eval("time0") %>
                                <hr width="100%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                            </td>
                        </tr>
                        <tr>
                            <td class="d" height="200" valign="top">
                                <%#Eval("remark") %>
                                <br /><br />
                                <span id="info2" runat="server" visible="false">
                                    <input id="Button1" type="button" value="提交审阅意见" class="but" onclick="javascirpt:RepleyLetter();" />
                                    &nbsp;&nbsp;<input id="Button4" type="button" value="点这里浏览相关资料" class="but" onclick="javascript:window.open('<%#Eval("url") %>');" />
                                </span>
                            </td>
                        </tr>
                        <tr height="25">
                            <td align="left">
                                附 件：<a href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file1") %> ' target="_blank">
                                    <asp:Label ID="labFile" runat="server" Text='<%#PubComm.GetString(Eval("file1")) %>'></asp:Label><br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                        href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file2") %> ' target="_blank">
                                        <asp:Label ID="Label1" runat="server" Text='<%#PubComm.GetString(Eval("file2")) %>'></asp:Label><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                            href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file3") %> ' target="_blank">
                                            <asp:Label ID="Label2" runat="server" Text='<%#PubComm.GetString(Eval("file3")) %>'></asp:Label><br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file4") %> ' target="_blank">
                                                <asp:Label ID="Label3" runat="server" Text='<%#PubComm.GetString(Eval("file4")) %>'></asp:Label><br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                    href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file5") %> ' target="_blank">
                                                    <asp:Label ID="Label4" runat="server" Text='<%#PubComm.GetString(Eval("file5")) %>'></asp:Label>
                                                    <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                            </td>
                        </tr>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:HiddenField ID="hidHuiZhi" runat="server" />
    <br />
    <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
        <tr>
            <td align="center" style="height: 11px">
                <asp:Button ID="Button1" runat="server" Text="回 复" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="转 发" OnClick="Button3_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="删 除" OnClick="Button2_Click" OnClientClick="javaScript:return confirm('警告：确定删除数据吗？');" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn1" runat="server" Text="返 回" OnClick="btn1_Click" />
            </td>
        </tr>
    </table>
    <script language="javascript">
        function RepleyLetter()
        {
            window.showModalDialog('WriteHuiZhi.aspx?id=<%#Request.QueryString["id"]%>',"","dialogWidth:400px;dialogHeight:300px;center:yes;status:no");
            top.location.href="ReadMail.aspx?id=<%#Request.QueryString["id"]%>";
        }
    </script>
</asp:Content>
