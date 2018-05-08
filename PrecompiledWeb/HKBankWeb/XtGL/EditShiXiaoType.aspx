<%@ page title="时效类别明细" language="C#" masterpagefile="~/Common/Master/SystemAdmin.master" autoeventwireup="true" inherits="XtGL_EditShiXiaoType, App_Web_rhavpchx" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="95%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" width="35%" />
            <col bgcolor="white" align="right" width="15%" />
            <col bgcolor="white" align="left" width="35%" />
        </colgroup>
        <tr height="25">
            <td colspan="4" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">时 效 类 别 信 息 </font></strong>
            </td>
        </tr>
        <tr height="25">
            <td>
                序号：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="num" runat="server"></asp:TextBox>
            </td>
            <td>
                时效类别编码：
            </td>
            <td>
                &nbsp;<asp:TextBox ID="timetypecode" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr height="25">
            <td>
                时效类别名称：
            </td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="timetypename" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr heiht="25">
            <td>
                时效说明：
            </td>
            <td colspan="3">
                &nbsp;<asp:TextBox ID="remark" runat="server" Width="85%" TextMode="MultiLine" Height="120"></asp:TextBox>
            </td>
        </tr>
        <tr height="30" id="row1" runat="server" visible="false">
            <td colspan="4" align="center" style="height: 30px">
                <asp:Button ID="Button1" runat="server" Text="更新资料" />
            </td>
        </tr>
    </table>
    <br />
    <table width="95%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
                    <colgroup>
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                        <col bgcolor="white" align="center" />
                    </colgroup>
                    <tr height="25" bgcolor="gainsboro">
                        <td colspan="7" align="Center">
                            <strong>时 效 提 醒 方 式</strong>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            序号
                        </td>
                        <td>
                            开始提醒（包括）
                        </td>
                        <td>
                            结束提醒（包括）
                        </td>
                        <td>
                            提醒方式
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr height="25">
                                <td>
                                    <%#Eval("num")%>
                                </td>
                                <td>
                                    <%#Eval("day1")%>（天）前
                                </td>
                                <td>
                                    <%#Eval("day2")%>（天）前
                                </td>
                                <td>
                                    <%#Eval("timetypekind").ToString()=="0" ? "每月一次" :
                                     ( Eval("timetypekind").ToString() == "1" ? "每周一次" :"每日一次")
                                    %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div style="text-align: center; margin-top:10px">
                    <asp:Button ID="Button2" runat="server" Text="返 回"
                     OnClientClick="javascript:history.go(-1);return false;" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
