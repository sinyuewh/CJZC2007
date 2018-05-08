﻿<%@ page language="C#" masterpagefile="~/Common/Master/Info.master" autoeventwireup="true" inherits="Info_InfoDetails, App_Web_6dm0odi6" title="阅读信息" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:FormView ID="FormView1" runat="server" Width="100%">
        <ItemTemplate>
            <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
                <tbody>
                    <tr>
                        <td align="center" height="60">
                            <font size="3"><strong>
                                <%#Eval("title") %>
                            </strong></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="30">
                            <font color="#ff0000">
                                <%#Eval("time0") %>
                            </font>&nbsp;</td>
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
    
    <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
        <tr>
            <td class="d" align="center">
                <asp:Repeater ID="file" runat="server">
                    <ItemTemplate>
                        <a target="_blank" href="<% =Application["root"]%>/Common/MailFiles/<%#Eval("filename") %>">
                            <%#Eval("filename1") %>
                        </a>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        |</SeparatorTemplate>
                </asp:Repeater>
            </td>
        </tr>
        
        <tr>
            <td align="center" style="height: 15px">
                <hr />
                <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text="关闭返回" />
                <%--<asp:LinkButton ID="LinkButton1" runat="server" Text="关闭返回" OnClick="LinkButton1_Click"></asp:LinkButton>--%>
            </td>
        </tr>
    </table>
</asp:Content>