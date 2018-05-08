<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_AlreadySendMail, App_Web_r4t0yj0h" title="已发邮件详细信息" stylesheettheme="CjzcWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FormView ID="mailForm1" runat="server" Width="100%">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" width="95%" align="center" border="0">
                <tbody>
                    <tr>
                        <td align="center" height="60">
                            <font size="5"><strong><%#Eval("title") %></strong></font>
                        </td>
                      
                        <tr>
                            <td align="left">
                                收件人：<%#Eval("to1") %>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                日 期：<%#Eval("time0") %>
                                <hr width="80%" size="3" color="#46316c" style="FILTER: alpha(opacity=100,finishopacity=0,style=3)"> 
                            </td>
                        </tr>
                        <tr height="25">
                            <td align="left">
                                附 件：<a href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file1") %> ' target="_blank">
                                       <asp:Label ID="labFile" runat="server" Text='<%#PubComm.GetString(Eval("file1")) %>'></asp:Label><br />
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file2") %> ' target="_blank">
                                       <asp:Label ID="Label1" runat="server" Text='<%#PubComm.GetString(Eval("file2")) %>'></asp:Label><br />
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file3") %> ' target="_blank">
                                       <asp:Label ID="Label2" runat="server" Text='<%#PubComm.GetString(Eval("file3")) %>'></asp:Label><br />
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file4") %> ' target="_blank">
                                       <asp:Label ID="Label3" runat="server" Text='<%#PubComm.GetString(Eval("file4")) %>'></asp:Label><br />
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='<%#Application["root"]%>/Common/MailFiles/<%#Eval("file5") %> ' target="_blank">
                                       <asp:Label ID="Label4" runat="server" Text='<%#PubComm.GetString(Eval("file5")) %>'></asp:Label>
                                <hr width="80%" size="3" color="#46316c" style="filter: alpha(opacity=100,finishopacity=0,style=3)">
                            </td>
                        </tr>
                    </tr>
                    <tr>
                        <td class="d" height="200" valign="top">
                            <%#Eval("remark") %>
                        </td>
                        
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
       
        <tr>
            <td height="9">
                
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 15px">
                <asp:Button ID="Button1" runat="server"  Text="删 除" OnClick="Button1_Click"  OnClientClick="javaScript:return confirm('警告：确定删除数据吗？');"  />&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button3" runat="server"  Text="重 发" OnClick="Button3_Click"    />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server"  Text="转 发" OnClick="Button2_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn1" runat="server"  Text="返 回" OnClick="btn1_Click"  />
                
            </td>
        </tr>
        
    </table>
</asp:Content>

