<%@ page language="C#" masterpagefile="~/Common/Master/DangAn.master" autoeventwireup="true" inherits="DangAn_AnJuanWeiHu, App_Web_d1onhsud" title="案卷维护——检索" stylesheettheme="CjzcWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="60%" align="center" border="0" cellpadding="1" cellspacing="1" bgcolor="#c5c5c5">
        <colgroup>
            <col bgcolor="white" align="right" width="130" />
            <col bgcolor="white" align="left" />
        </colgroup>
        <tr height="25">
            <td colspan="2" align="center" bgcolor="#5d7b9d">
                <strong><font color="#ffffff">输 入 档 案 检 索 条 件</font></strong>
            </td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                案卷分类：</td>
            <td style="height: 25px">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="210px">
                </asp:DropDownList></td>
        </tr>
        <tr height="25">
            <td>
                案卷名称：</td>
            <td>
                <asp:TextBox ID="ajname" runat="server" Width="205px"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                案卷编号：</td>
            <td>
                <asp:TextBox ID="ajnum" runat="server" Width="205px"></asp:TextBox></td>
        </tr>
        <tr height="25" style="display:none">
            <td>
                立卷时间：</td>
            <td>
                <asp:TextBox ID="time1" runat="server" Width="93"></asp:TextBox>至<asp:TextBox ID="time2"
                    runat="server" Width="95"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td style="height: 25px">
                案卷状态：</td>
            <td style="height: 25px">
                <asp:DropDownList ID="ajstatus" runat="server" Width="210px">
                    <asp:ListItem Value="不限">全部...</asp:ListItem>
                    <asp:ListItem Value="2">已移交</asp:ListItem>
                    <asp:ListItem Value="1">未移交</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr height="25" style="display:none">
            <td>
                文 号：</td>
            <td>
                <asp:TextBox ID="fileno" runat="server" Width="205px"></asp:TextBox></td>
        </tr>
        <tr height="25">
            <td>
                文件名称：</td>
            <td>
                <asp:TextBox ID="title" runat="server" Width="205px"></asp:TextBox></td>
        </tr>
        <tr height="30">
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="检索" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
